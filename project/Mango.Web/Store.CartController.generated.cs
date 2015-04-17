// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
#pragma warning disable 1591, 3008, 3009, 0108
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Mango.Web.Areas.Store.Controllers
{
    public partial class CartController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CartController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Login()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Register()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CartController Actions { get { return MVC.StoreArea.Cart; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Store";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Cart";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Cart";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Customer = "Customer";
            public readonly string CheckoutPayPal = "CheckoutPayPal";
            public readonly string CheckoutReview = "CheckoutReview";
            public readonly string CheckoutReviewOrderCont = "CheckoutReviewOrderCont";
            public readonly string CheckoutReviewTransCont = "CheckoutReviewTransCont";
            public readonly string CheckoutCancel = "CheckoutCancel";
            public readonly string CheckoutCancelContinue = "CheckoutCancelContinue";
            public readonly string CheckoutErrorContinue = "CheckoutErrorContinue";
            public readonly string CheckoutCompleteContinue = "CheckoutCompleteContinue";
            public readonly string Account = "Account";
            public readonly string Login = "Login";
            public readonly string Register = "Register";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Customer = "Customer";
            public const string CheckoutPayPal = "CheckoutPayPal";
            public const string CheckoutReview = "CheckoutReview";
            public const string CheckoutReviewOrderCont = "CheckoutReviewOrderCont";
            public const string CheckoutReviewTransCont = "CheckoutReviewTransCont";
            public const string CheckoutCancel = "CheckoutCancel";
            public const string CheckoutCancelContinue = "CheckoutCancelContinue";
            public const string CheckoutErrorContinue = "CheckoutErrorContinue";
            public const string CheckoutCompleteContinue = "CheckoutCompleteContinue";
            public const string Account = "Account";
            public const string Login = "Login";
            public const string Register = "Register";
        }


        static readonly ActionParamsClass_Customer s_params_Customer = new ActionParamsClass_Customer();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Customer CustomerParams { get { return s_params_Customer; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Customer
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Login
        {
            public readonly string model = "model";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string model = "model";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Account = "Account";
                public readonly string Checkout = "Checkout";
                public readonly string CheckoutCancel = "CheckoutCancel";
                public readonly string CheckoutComplete = "CheckoutComplete";
                public readonly string CheckoutError = "CheckoutError";
                public readonly string CheckoutReview = "CheckoutReview";
                public readonly string CheckoutReviewOrder = "CheckoutReviewOrder";
                public readonly string CheckoutReviewTrans = "CheckoutReviewTrans";
                public readonly string Customer = "Customer";
                public readonly string Index = "Index";
            }
            public readonly string Account = "~/Areas/Store/Views/Cart/Account.cshtml";
            public readonly string Checkout = "~/Areas/Store/Views/Cart/Checkout.cshtml";
            public readonly string CheckoutCancel = "~/Areas/Store/Views/Cart/CheckoutCancel.cshtml";
            public readonly string CheckoutComplete = "~/Areas/Store/Views/Cart/CheckoutComplete.cshtml";
            public readonly string CheckoutError = "~/Areas/Store/Views/Cart/CheckoutError.cshtml";
            public readonly string CheckoutReview = "~/Areas/Store/Views/Cart/CheckoutReview.cshtml";
            public readonly string CheckoutReviewOrder = "~/Areas/Store/Views/Cart/CheckoutReviewOrder.cshtml";
            public readonly string CheckoutReviewTrans = "~/Areas/Store/Views/Cart/CheckoutReviewTrans.cshtml";
            public readonly string Customer = "~/Areas/Store/Views/Cart/Customer.cshtml";
            public readonly string Index = "~/Areas/Store/Views/Cart/Index.cshtml";
            static readonly _EditorTemplatesClass s_EditorTemplates = new _EditorTemplatesClass();
            public _EditorTemplatesClass EditorTemplates { get { return s_EditorTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _EditorTemplatesClass
            {
                public readonly string AddressViewModel = "AddressViewModel";
                public readonly string CustomerViewModel = "CustomerViewModel";
                public readonly string LoginViewModel = "LoginViewModel";
                public readonly string RegisterViewModel = "RegisterViewModel";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_CartController : Mango.Web.Areas.Store.Controllers.CartController
    {
        public T4MVC_CartController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CustomerOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Customer()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Customer);
            CustomerOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CustomerOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Mango.Web.Areas.Store.Models.CartCustomerViewModel viewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Customer(Mango.Web.Areas.Store.Models.CartCustomerViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Customer);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            CustomerOverride(callInfo, viewModel);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutPayPalOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckoutPayPal()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckoutPayPal);
            CheckoutPayPalOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutReviewOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutReview()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutReview);
            CheckoutReviewOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutReviewOrderContOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutReviewOrderCont()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutReviewOrderCont);
            CheckoutReviewOrderContOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutReviewTransContOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutReviewTransCont()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutReviewTransCont);
            CheckoutReviewTransContOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutCancelOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutCancel()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutCancel);
            CheckoutCancelOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutCancelContinueOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutCancelContinue()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutCancelContinue);
            CheckoutCancelContinueOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutErrorContinueOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutErrorContinue()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutErrorContinue);
            CheckoutErrorContinueOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckoutCompleteContinueOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CheckoutCompleteContinue()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CheckoutCompleteContinue);
            CheckoutCompleteContinueOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AccountOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Account()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Account);
            AccountOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Mango.Web.Areas.Store.Models.CartAccountViewModel model, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Login(Mango.Web.Areas.Store.Models.CartAccountViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Mango.Web.Areas.Store.Models.CartAccountViewModel model, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Register(Mango.Web.Areas.Store.Models.CartAccountViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            RegisterOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108
