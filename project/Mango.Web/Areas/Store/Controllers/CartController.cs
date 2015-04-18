using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Links;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Core.Web.Checkout;
using Mango.Core.Web.Helpers;
using Mango.Web.Areas.Store.Models;
using Mango.Web.Attributes;
using Mango.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Mango.Web.ViewModelHelpers;

namespace Mango.Web.Areas.Store.Controllers
{
    [RouteArea("store")]
    [RoutePrefix("cart")]
    [Route("{action}")]
    [LogoutIfAdmin]
    public partial class CartController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IOrderLineItemService _orderLineItemService;
        private readonly ICartService _cartService;
        private readonly ICheckoutService _checkoutService;
        private readonly IPayPalNvpApiCallerService _payPalNvpApiCallerService;

        public CartController() { }

        public CartController(IAddressService addressService, ICustomerService customerService,
            IOrderService orderService, IOrderLineItemService orderLineItemService,
            ICartService cartService, ICheckoutService checkoutService, IPayPalNvpApiCallerService payPalNvpApiCallerService)
        {
            _addressService = addressService;
            _customerService = customerService;
            _orderService = orderService;
            _orderLineItemService = orderLineItemService;
            _cartService = cartService;
            _checkoutService = checkoutService;
            _payPalNvpApiCallerService = payPalNvpApiCallerService;
        }
        public CartController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
                    return RedirectToAction(MVC.StoreArea.Cart.CheckoutPayPal());
                }
            }
            return View(viewModel);
        }

        #region Paypal


        public virtual ActionResult CheckoutPayPal()
        {
            var orderId = UserSessionData.OrderId;

            string retMsg = "";
            string token = "";
            decimal amtVal = _orderService.GetOrder(orderId).TotalAmount;
            string amt = amtVal.ToString();
            bool ret = _payPalNvpApiCallerService.ShortcutExpressCheckout(orderId, amt, ref token, ref retMsg);

            if (ret)
            {
                UserSessionData.Token = token;
                UserSessionData.PaymentAmount = amtVal;

                return Redirect(retMsg);
            }
            else
            {
                return View("Completed");
            }

        }

        public virtual ViewResult CheckoutReview()
        {
            string retMsg = "";
            string token = "";
            decimal paymentAmountOnCheckout = 0;
            string payerID = "";

            var decoder = new PayPalNvpCodec();

            token = UserSessionData.Token;
            paymentAmountOnCheckout = UserSessionData.PaymentAmount;

            bool ret = _payPalNvpApiCallerService.GetCheckoutDetails(token, ref payerID, ref decoder, ref retMsg);
            if (ret)
            {

                // Verify total payment amount as set on CheckoutStart.aspx.
                try
                {
                    decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
                    if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
                    {
                        return View("CheckoutError");
                    }
                }
                catch (Exception)
                {
                    return View("CheckoutError");
                }


                //Session information
                UserSessionData.PayerID = payerID;
                var orderID = UserSessionData.OrderId;

                //Update the order with PayPal Informatin              
                var firstName = decoder["FIRSTNAME"].ToString();
                var lastName = decoder["LASTNAME"].ToString();
                var streetLine1 = decoder["SHIPTOSTREET"].ToString();
                var streetLine2 = decoder["SHIPTOCITY"].ToString();
                var state = decoder["SHIPTOSTATE"].ToString();
                var postalCode = decoder["SHIPTOZIP"].ToString();
                var country = decoder["SHIPTOCOUNTRYCODE"].ToString();
                var email = decoder["EMAIL"].ToString();
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
                    OrderDate = decoder["TIMESTAMP"].ToString(),
                    Username = User.Identity.Name,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = streetLine1,
                    City = streetLine2,
                    State = state,
                    PostalCode = postalCode,
                    Email = email,
                    TotalAmount = paymentAmountOnCheckout.ToString()
                };
                ViewBag.PayPalReview = ppReview;

                return View("CheckoutReviewOrder");
            }
            else
            {
                return View("CheckoutError");
            }
        }
        public virtual ViewResult CheckoutReviewOrderCont()
        {

            int orderId;
            int currentOrderId = 0;
            string retMsg = "";
            string token = "";
            string finalPaymentAmount = "";
            string payerId = "";

            var decoder = new PayPalNvpCodec();


            token = UserSessionData.Token.ToString();
            finalPaymentAmount = UserSessionData.PaymentAmount.ToString();
            payerId = UserSessionData.PayerID;
            var payPalEmail = UserSessionData.PayPalEmail;

            bool ret = _payPalNvpApiCallerService.DoCheckoutPayment(finalPaymentAmount, token, payerId, ref decoder, ref retMsg);
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

                return View("CheckoutReviewTrans");
            }
            else
            {
                return View("CheckoutError");
            }
        }
        public virtual ViewResult CheckoutReviewTransCont()
        {
            return View("Completed");
        }

        public virtual ViewResult CheckoutCancel()
        {
            return View("CheckoutCancel");
        }

        public virtual ViewResult CheckoutCancelContinue()
        {
            return View("Completed");
        }

        public virtual ViewResult CheckoutErrorContinue()
        {
            return View("Completed");
        }

        public virtual ViewResult CheckoutCompleteContinue()
        {
            return View("Completed");
        }

        // End PayPal

       

        public int UpdateOrderShipTo(int orderId, string firstName, string lastName, string company, string email,
            string streetLine1, string streetLine2, string streetLine3,
            string city, string postalCode, string county, string country)
        {
            var order = _orderService.GetOrder(orderId);
            order.ShipAddress.FirstName = firstName;
            order.ShipAddress.LastName = lastName;
            //order.Company = company;
            order.Customer.Email = email;
            order.ShipAddress.AddressLine1 = streetLine1;
            order.ShipAddress.AddressLine2 = streetLine2;
            order.ShipAddress.City = city;
            order.ShipAddress.Zip = postalCode;
            order.ShipAddress.County = county;
            order.ShipAddress.Country = country;
            _orderService.EditOrder(order);
            return orderId;
        }

        public int UpdateOrderConfirmation(int orderId, string paymentConfirmation)
        {
            var order = _orderService.GetOrder(orderId);
            order.PayPalOrderConfirmation = paymentConfirmation;
            _orderService.EditOrder(order);
            return orderId;
        }

        #endregion

        #region Account

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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
        [AllowAnonymous]
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
            var result = await SignInManager.PasswordSignInAsync(model.LoginViewModel.Email, model.LoginViewModel.Password, model.LoginViewModel.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout"); //TODO handle lockout
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
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
                var result = await UserManager.CreateAsync(user, model.RegisterViewModel.Password);
                if (result.Succeeded)
                {
                    // Add user to Customer role
                    await UserManager.AddToRoleAsync(user.Id, "Customer");

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

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

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}