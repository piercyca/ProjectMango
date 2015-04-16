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
using Mango.Web.Areas.Store.Models;
using Mango.Web.Attributes;
using Mango.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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
        private readonly ICartService _cartService;

        public CartController() { }

        public CartController(IAddressService addressService, ICustomerService customerService,
            IOrderService orderService, ICartService cartService)
        {
            _addressService = addressService;
            _customerService = customerService;
            _orderService = orderService;
            _cartService = cartService;
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
            var customer = new Customer();
            var loggedInUsername = HttpContext.User.Identity.GetUserName();
            if (HttpContext.User.Identity.IsAuthenticated && (!string.IsNullOrEmpty(loggedInUsername)))
            {
                customer = _customerService.GetCustomer(loggedInUsername);
                if (customer == null)
                {
                    customer = new Customer { Email = loggedInUsername, Username = loggedInUsername };
                }
            }

            // Setup default addresses
            var shippingAddress = new AddressViewModel(AddressType.Ship);

            // Get last order addresses
            if (customer.CustomerId > 0)
            {
                // Populate default address
                shippingAddress.FirstName = customer.FirstName;
                shippingAddress.LastName = customer.LastName;

                var order = _orderService.GetOrdersByCustomer(customer.CustomerId).OrderByDescending(o => o.DateCreated).FirstOrDefault();
                if (order != null)
                {
                    if (order.ShipAddress != null)
                    {
                        shippingAddress = Mapper.Map<Address, AddressViewModel>(order.ShipAddress);
                    }
                }
            }

            var addressesViewModel = new CartCustomerViewModel
            {
                Customer = Mapper.Map<Customer, CustomerViewModel>(customer),
                ShippingAddress = shippingAddress
            };

            return View(addressesViewModel);
        }

        public virtual ActionResult Cart()
        {
            //Display all the information
            PaypalCartModel cartModel = new PaypalCartModel
            {
                BuyerName = "Pratik Bhoir",
                ShippingAddress = "Mumbai. Pin - 602304",
                CartItems = new List<PayPalCartItemModel>
                {
                    new PayPalCartItemModel {ProductId = 1, ProductName = "Product 1", Quantity = 1, UnitPrice = 3},
                    new PayPalCartItemModel {ProductId = 2, ProductName = "Product 2", Quantity = 2, UnitPrice = 2}
                }
            };

            Session["PayPalModel"] = cartModel;
            Session["payment_amt"] = cartModel.TotalAmount;
            return View(cartModel);
        }

        #region Paypal

        // PayPal
        public ActionResult CheckoutWithPayPal()
        {
            var cart = _cartService.GetCartModel();
            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
                return View("Completed");
            }
            

                int orderID = StoreOrderAndOrderItems(cart);
                UserSessionData.OrderID = orderID;

                NVPAPICaller payPalCaller = new NVPAPICaller();
                payPalCaller.SetCredentials();

                string retMsg = "";
                string token = "";
                decimal amtVal = cart.ComputeTotalValue();
                string amt = amtVal.ToString();
                bool ret = payPalCaller.ShortcutExpressCheckout(cart, amt, ref token, ref retMsg);

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

        public ViewResult CheckoutReview()
        {

            int orderID;

            string firstName, lastName, company, email,
                streetLine1, streetLine2, streetLine3,
                city, postalCode, county, country;

            string retMsg = "";
            string token = "";
            decimal paymentAmountOnCheckout = 0;
            string PayerID = "";

            NVPAPICaller payPalCaller = new NVPAPICaller();
            payPalCaller.SetCredentials();

            NVPCodec decoder = new NVPCodec();

            token = UserSessionData.Token.ToString();
            paymentAmountOnCheckout = UserSessionData.PaymentAmount;

            bool ret = payPalCaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
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
                UserSessionData.PayerID = PayerID;
                orderID = UserSessionData.OrderID;

                //Update the order with PayPal Informatin
                company = string.Empty; city = string.Empty; county = string.Empty;
                //OrderDate = Convert.ToDateTime(decoder["TIMESTAMP"].ToString());
                //Username = User.Identity.Name;
                firstName = decoder["FIRSTNAME"].ToString();
                lastName = decoder["LASTNAME"].ToString();
                streetLine1 = decoder["SHIPTOSTREET"].ToString();
                streetLine2 = decoder["SHIPTOCITY"].ToString();
                streetLine3 = decoder["SHIPTOSTATE"].ToString();
                postalCode = decoder["SHIPTOZIP"].ToString();
                country = decoder["SHIPTOCOUNTRYCODE"].ToString();
                email = decoder["EMAIL"].ToString();
                //Total = Convert.ToDecimal(decoder["AMT"].ToString());
                orderID = UpdateOrderShipTo(orderID, firstName, lastName, company, email,
                    streetLine1, streetLine2, streetLine3,
                    city, postalCode, county, country);

                //Prepare for display
                PayPalReview ppReview = new PayPalReview();
                ppReview.OrderID = orderID.ToString();
                ppReview.OrderDate = decoder["TIMESTAMP"].ToString();
                ppReview.Username = User.Identity.Name;
                ppReview.FirstName = firstName;
                ppReview.LastName = lastName;
                ppReview.Address = streetLine1;
                ppReview.City = streetLine2;
                ppReview.State = streetLine3;
                ppReview.PostalCode = postalCode;
                ppReview.Email = email;
                ppReview.TotalAmount = paymentAmountOnCheckout.ToString();
                ViewBag.PayPalReview = ppReview;

                return View("CheckoutReviewOrder");
            }
            else
            {
                return View("CheckoutError");
            }
        }
        public ViewResult CheckoutReviewOrderCont()
        {

            int orderID;
            int currentOrderId = 0;
            string retMsg = "";
            string token = "";
            string finalPaymentAmount = "";
            string PayerID = "";

            NVPAPICaller payPalCaller = new NVPAPICaller();
            payPalCaller.SetCredentials();

            NVPCodec decoder = new NVPCodec();


            token = UserSessionData.Token.ToString();
            finalPaymentAmount = UserSessionData.PaymentAmount.ToString();
            PayerID = UserSessionData.PayerID;
            currentOrderId = UserSessionData.OrderID;

            bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);
            if (ret)
            {
                // Retrieve PayPal confirmation value.
                string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();

                //Update the order 
                orderID = UserSessionData.OrderID;
                orderID = UpdateOrderConfirmation(orderID, PaymentConfirmation);

                //Reset session data
                UserSessionData.PaymentAmount = 0;
                UserSessionData.OrderID = 0;

                ViewBag.PaymentConfirmation = PaymentConfirmation;

                //Reduce the quantity of products in stock
                IEnumerable<OrderItem> orderItems = orderItemRepository.OrderItems.Where(x => x.OrderID == orderID);
                foreach (var orderItem in orderItems)
                {
                    UpdateProductQuantity(orderItem.ProductID, orderItem.Quantity);
                }

                return View("CheckoutReviewTrans");
            }
            else
            {
                return View("CheckoutError");
            }
        }
        public ViewResult CheckoutReviewTransCont()
        {
            return View("Completed");
        }

        public ViewResult CheckoutCancel()
        {
            return View("CheckoutCancel");
        }

        public ViewResult CheckoutCancelContinue()
        {
            return View("Completed");
        }

        public ViewResult CheckoutErrorContinue()
        {
            return View("Completed");
        }

        public ViewResult CheckoutCompleteContinue()
        {
            return View("Completed");
        }

        // End PayPal

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