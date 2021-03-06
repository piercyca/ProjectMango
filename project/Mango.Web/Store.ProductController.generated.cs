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
    public partial class ProductController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProductController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Category()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Category);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Customize()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Customize);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductController Actions { get { return MVC.StoreArea.Product; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Store";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Product";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Product";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Category = "Category";
            public readonly string Customize = "Customize";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Category = "Category";
            public const string Customize = "Customize";
        }


        static readonly ActionParamsClass_Category s_params_Category = new ActionParamsClass_Category();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Category CategoryParams { get { return s_params_Category; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Category
        {
            public readonly string urlSlug = "urlSlug";
        }
        static readonly ActionParamsClass_Customize s_params_Customize = new ActionParamsClass_Customize();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Customize CustomizeParams { get { return s_params_Customize; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Customize
        {
            public readonly string urlSlug = "urlSlug";
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
                public readonly string Category = "Category";
                public readonly string Customize = "Customize";
            }
            public readonly string Category = "~/Areas/Store/Views/Product/Category.cshtml";
            public readonly string Customize = "~/Areas/Store/Views/Product/Customize.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ProductController : Mango.Web.Areas.Store.Controllers.ProductController
    {
        public T4MVC_ProductController() : base(Dummy.Instance) { }

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
        partial void CategoryOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string urlSlug);

        [NonAction]
        public override System.Web.Mvc.ActionResult Category(string urlSlug)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Category);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlSlug", urlSlug);
            CategoryOverride(callInfo, urlSlug);
            return callInfo;
        }

        [NonAction]
        partial void CustomizeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string urlSlug);

        [NonAction]
        public override System.Web.Mvc.ActionResult Customize(string urlSlug)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Customize);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlSlug", urlSlug);
            CustomizeOverride(callInfo, urlSlug);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108
