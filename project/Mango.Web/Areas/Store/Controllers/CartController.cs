using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Core.Web;
using Mango.Core.Web.Checkout;
using Mango.Core.Web.Helpers;
using Mango.Web.Areas.Store.Models;
using Mango.Web.Attributes;
using Mango.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Mango.Web.Areas.Store.Controllers
{
    [RouteArea("store")]
    [RoutePrefix("cart")]
    [Route("{action}")]
    [LogoutIfAdmin]
    public partial class CartController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly ICheckoutService _checkoutService;
        private readonly IPayPalNvpApiCallerService _payPalNvpApiCallerService;
        
        private IOwinContext _owinCotext;
        private IOwinContext OwinContext { get { return _owinCotext ?? HttpContext.GetOwinContext(); } set { _owinCotext = value; } }

        #region Account

        private ApplicationSignInManager _signInManager { get { return OwinContext.Get<ApplicationSignInManager>(); } }
        private ApplicationUserManager _userManager { get { return OwinContext.GetUserManager<ApplicationUserManager>(); } }
        private IAuthenticationManager _authenticationManager { get { return OwinContext.Authentication; } }

        #endregion

        public CartController() { }

        public CartController(IOrderService orderService, ICartService cartService, ICheckoutService checkoutService, IPayPalNvpApiCallerService payPalNvpApiCallerService)
        {
            _orderService = orderService;
            _cartService = cartService;
            _checkoutService = checkoutService;
            _payPalNvpApiCallerService = payPalNvpApiCallerService;
        }
        public CartController(IOwinContext owinContext)
        {
            _owinCotext = owinContext;
        }

        /// <summary>
        /// GET: /store/cart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Index()
        {
            var viewModel = new CartIndexViewModel
            {
                CartModel = _cartService.GetCartModel()
            };
            return View(viewModel);
        }

        /// <summary>
        /// GET: /store/cart/customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Customer()
        {
            // Setup Customer
            var loggedInUsername = HttpContext.User.Identity.GetUserName();
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var customer = _checkoutService.Customer(loggedInUsername, isAuthenticated);

            // Setup Shipping Address
            var shipAddress = _checkoutService.ShippingAddress(customer);

            var addressesViewModel = new CartCustomerViewModel
            {
                Customer = Mapper.Map<Customer, CustomerViewModel>(customer),
                ShippingAddress = Mapper.Map<Address, AddressViewModel>(shipAddress)
            };

            return View(addressesViewModel);
        }

        /// <summary>
        /// POST: /store/cart/customer
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Customer(CartCustomerViewModel viewModel)
        {
            // Check if cart is empty
            var cart = _cartService.GetCartModel();
            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var customer = Mapper.Map<CustomerViewModel, Customer>(viewModel.Customer);
                    var shippingAddress = Mapper.Map<AddressViewModel, Address>(viewModel.ShippingAddress);
                    UserSessionData.OrderId = _checkoutService.CreateOrder(customer, shippingAddress);
                    _cartService.ClearCart();
                    return RedirectToAction(MVC.StoreArea.Cart.CheckoutPayPal());
                }
            }
            return View(viewModel);
        }

        #region Paypal

        /// <summary>
        /// GET: /store/cart/checkoutpaypal
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult CheckoutPayPal()
        {
            var orderId = UserSessionData.OrderId;
            var retMsg = string.Empty;
            var token = string.Empty;
            var amtVal = _orderService.GetOrder(orderId).TotalAmount;
            var amt = amtVal.ToString(CultureInfo.InvariantCulture);
            var errorMessage = new StringBuilder();
            var ret = _payPalNvpApiCallerService.ShortcutExpressCheckout(orderId, amt, ref token, ref retMsg);
            if (ret)
            {
                UserSessionData.Token = token;
                UserSessionData.PaymentAmount = amtVal;
                return Redirect(retMsg);
            }
            errorMessage.AppendLine("Paypal Call Failed");
            errorMessage.AppendLine("Method: IPayPalNvpApiCallerService.ShortcutExpressCheckout()");
            errorMessage.AppendLine("ControllerMethod: Cart.CheckoutPayPal()");
            errorMessage.AppendLine(string.Format("retMsg: {0}", retMsg));
            ExceptionLogger.Log(errorMessage, new List<object> { RouteData });
            return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutError);
        }

        /// <summary>
        /// GET: /store/cart/checkoutreview
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutReview()
        {
            
            var decoder = new PayPalNvpCodec();
            var token = UserSessionData.Token;
            var paymentAmountOnCheckout = UserSessionData.PaymentAmount;
            var retMsg = string.Empty;
            var payerID = string.Empty;
            var errorMessage = new StringBuilder();
            var ret = _payPalNvpApiCallerService.GetCheckoutDetails(token, ref payerID, ref decoder, ref retMsg);
            if (ret)
            {
                try
                {
                    decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"]);
                    if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
                    {
                        errorMessage.AppendLine("Paypal Amount is different from Checkout Amount");
                        errorMessage.AppendFormat("Checkout Amount: {0}\r\n", paymentAmountOnCheckout);
                        errorMessage.AppendFormat("PayPal Amount: {0}\r\n", paymentAmoutFromPayPal);
                        errorMessage.AppendLine("ControllerMethod: Cart.CheckoutReview()");
                        errorMessage.AppendFormat("retMsg: {0}\r\n", retMsg);
                        ExceptionLogger.Log(errorMessage, new List<object> { RouteData });
                        return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutError);
                    }
                }
                catch (Exception innerException)
                {
                    errorMessage.AppendLine("Checkout Error, see inner exception.");
                    errorMessage.AppendLine("ControllerMethod: Cart.CheckoutReview()");
                    ExceptionLogger.Log(errorMessage, innerException, new List<object> { RouteData });
                    return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutError);
                }


                //Session information
                UserSessionData.PayerID = payerID;
                var orderID = UserSessionData.OrderId;

                //Update the order with PayPal Informatin              
                var firstName = decoder["FIRSTNAME"];
                var lastName = decoder["LASTNAME"];
                var streetLine1 = decoder["SHIPTOSTREET"];
                var streetLine2 = decoder["SHIPTOCITY"];
                var state = decoder["SHIPTOSTATE"];
                var postalCode = decoder["SHIPTOZIP"];
                var email = decoder["EMAIL"];
                //Total = Convert.ToDecimal(decoder["AMT"].ToString());

                UserSessionData.PayPalEmail = email;

                //TODO uncomment
                //orderID = UpdateOrderShipTo(orderID, firstName, lastName, company, email,
                //    streetLine1, streetLine2, streetLine3,
                //    city, postalCode, county, country);

                //Prepare for display
                var ppReview = new PayPalReviewViewModel
                {
                    OrderID = orderID.ToString(),
                    OrderDate = decoder["TIMESTAMP"],
                    Username = User.Identity.Name,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = streetLine1,
                    City = streetLine2,
                    State = state,
                    PostalCode = postalCode,
                    Email = email,
                    TotalAmount = paymentAmountOnCheckout.ToString(CultureInfo.InvariantCulture)
                };
                ViewBag.PayPalReview = ppReview;
                return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutReviewOrder);
            }

            errorMessage = new StringBuilder();
            errorMessage.AppendLine("Paypal Call Failed");
            errorMessage.AppendLine("Method: IPayPalNvpApiCallerService.GetCheckoutDetails()");
            errorMessage.AppendLine("ControllerMethod: Cart.CheckoutReview()");
            errorMessage.AppendLine(string.Format("retMsg: {0}", retMsg));
            ExceptionLogger.Log(errorMessage, new List<object> { RouteData });
            return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutError);
        }

        /// <summary>
        /// GET: /store/cart/checkoutreviewordercont
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutReviewOrderCont()
        {
            var decoder = new PayPalNvpCodec();
            var retMsg = string.Empty;
            var token = UserSessionData.Token;
            var finalPaymentAmount = UserSessionData.PaymentAmount.ToString(CultureInfo.InvariantCulture);
            var payerId = UserSessionData.PayerID;
            var payPalEmail = UserSessionData.PayPalEmail;

            var ret = _payPalNvpApiCallerService.DoCheckoutPayment(finalPaymentAmount, token, payerId, ref decoder, ref retMsg);
            if (ret)
            {
                // Retrieve PayPal confirmation value.
                string paymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"];

                //Update the order 
                _orderService.UpdatePayPalProperties(UserSessionData.OrderId, token, payerId, payPalEmail, paymentConfirmation);

                //Reset session data
                UserSessionData.PaymentAmount = 0;
                UserSessionData.OrderId = 0;

                ViewBag.PaymentConfirmation = paymentConfirmation;
                return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutReviewTrans);
            }
            
            var message = new StringBuilder();
            message.AppendLine("Paypal Call Failed");
            message.AppendLine("Method: IPayPalNvpApiCallerService.DoCheckoutPayment()");
            message.AppendLine("ControllerMethod: Cart.CheckoutReviewOrderCont()");
            message.AppendLine(string.Format("retMsg: {0}", retMsg));
            ExceptionLogger.Log(message, new List<object> { RouteData });
            return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutError);
        }

        /// <summary>
        /// GET: /store/cart/checkoutreviewtranscont
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutReviewTransCont()
        {
            return View(MVC.StoreArea.Cart.Views.ViewNames.Completed);
        }

        /// <summary>
        /// GET: /store/cart/checkoutcancel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutCancel()
        {
            return View(MVC.StoreArea.Cart.Views.ViewNames.CheckoutCancel);
        }

        /// <summary>
        /// GET: /store/cart/checkoutcancelcontinue
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutCancelContinue()
        {
            return View(MVC.StoreArea.Cart.Views.ViewNames.Completed);
        }

        /// <summary>
        /// GET: /store/cart/checkouterrorcontinue
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutErrorContinue()
        {
            return View(MVC.StoreArea.Cart.Views.ViewNames.Completed);
        }

        /// <summary>
        /// GET: /store/cart/checkoutcompletecontinue
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ViewResult CheckoutCompleteContinue()
        {
            return View(MVC.StoreArea.Cart.Views.ViewNames.Completed);
        }

        #endregion // PayPal

        #region Account

        /// <summary>
        /// GET: /store/cart/guestcheckout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult GuestCheckout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _authenticationManager.SignOut();
            }
            return RedirectToAction(MVC.StoreArea.Cart.Customer());
        }

        /// <summary>
        /// GET: /store/cart/account
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Account()
        {
            ViewBag.ReturnUrl = Url.Action(MVC.StoreArea.Cart.Customer());
            var viewModel = new CartAccountViewModel
            {
                LoginViewModel = new LoginViewModel(),
                RegisterViewModel = new RegisterViewModel()
            };
            return View(viewModel);
        }

        /// <summary>
        /// POST: /store/cart/login
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(CartAccountViewModel model, string returnUrl)
        {
            model.LoginMethod = "Login";

            if (!ModelState.IsValid)
            {
                return View(MVC.StoreArea.Cart.Views.ViewNames.Account, model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.LoginViewModel.Email, model.LoginViewModel.Password, model.LoginViewModel.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout"); //TODO handle lockout
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                default: // Includes 'case SignInStatus.Failure:'
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(MVC.StoreArea.Cart.Views.ViewNames.Account, model);
            }
        }

        /// <summary>
        /// POST: /store/cart/register
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(CartAccountViewModel model, string returnUrl)
        {
            model.LoginMethod = "Register";

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.RegisterViewModel.Email, Email = model.RegisterViewModel.Email };
                var result = await _userManager.CreateAsync(user, model.RegisterViewModel.Password);
                if (result.Succeeded)
                {
                    // Add user to Customer role
                    await _userManager.AddToRoleAsync(user.Id, "Customer");

                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(MVC.StoreArea.Cart.Views.ViewNames.Account, model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        /// <summary>
        /// Prevents hijacking <see cref="returnUrl"/>
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(MVC.StoreArea.Home.Index());
        }

        #endregion
    }
}