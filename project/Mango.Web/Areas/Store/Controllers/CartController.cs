using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Links;
using Mango.Core.Entity;
using Mango.Core.Service;
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

        public CartController() { }

        public CartController(IAddressService addressService, ICustomerService customerService,
            IOrderService orderService, IProductService productService)
        {
            _addressService = addressService;
            _customerService = customerService;
            _orderService = orderService;
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
        public virtual ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: /store/customer
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