﻿// <auto-generated />
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

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    static readonly AdminClass s_Admin = new AdminClass();
    public static AdminClass Admin { get { return s_Admin; } }
    static readonly StoreClass s_Store = new StoreClass();
    public static StoreClass Store { get { return s_Store; } }
    public static Mango.Web.Controllers.AccountController Account = new Mango.Web.Controllers.T4MVC_AccountController();
    public static Mango.Web.Controllers.HomeController Home = new Mango.Web.Controllers.T4MVC_HomeController();
    public static Mango.Web.Controllers.ManageController Manage = new Mango.Web.Controllers.T4MVC_ManageController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class AdminClass
    {
        public readonly string Name = "Admin";
        public Mango.Web.Areas.Admin.Controllers.CustomerController Customer = new Mango.Web.Areas.Admin.Controllers.T4MVC_CustomerController();
        public Mango.Web.Areas.Admin.Controllers.HomeController Home = new Mango.Web.Areas.Admin.Controllers.T4MVC_HomeController();
        public Mango.Web.Areas.Admin.Controllers.OrganizationController Organization = new Mango.Web.Areas.Admin.Controllers.T4MVC_OrganizationController();
        public Mango.Web.Areas.Admin.Controllers.ProductCategoryController ProductCategory = new Mango.Web.Areas.Admin.Controllers.T4MVC_ProductCategoryController();
        public Mango.Web.Areas.Admin.Controllers.ProductController Product = new Mango.Web.Areas.Admin.Controllers.T4MVC_ProductController();
        public Mango.Web.Areas.Admin.Controllers.UserController User = new Mango.Web.Areas.Admin.Controllers.T4MVC_UserController();
        public T4MVC.Admin.SharedController Shared = new T4MVC.Admin.SharedController();
    }
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class StoreClass
    {
        public readonly string Name = "Store";
        public Mango.Web.Areas.Store.Controllers.HomeController Home = new Mango.Web.Areas.Store.Controllers.T4MVC_HomeController();
        public T4MVC.Store.SharedController Shared = new T4MVC.Store.SharedController();
    }
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        private const string URLPATH = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string _references_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/_references.min.js") ? Url("_references.min.js") : Url("_references.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Areas {
            private const string URLPATH = "~/Scripts/Areas";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Admin {
                private const string URLPATH = "~/Scripts/Areas/Admin";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class Product {
                    private const string URLPATH = "~/Scripts/Areas/Admin/Product";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string Layout_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Layout.min.js") ? Url("Layout.min.js") : Url("Layout.js");
                }
            
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class Shared {
                    private const string URLPATH = "~/Scripts/Areas/Admin/Shared";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string UploadImage_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/UploadImage.min.js") ? Url("UploadImage.min.js") : Url("UploadImage.js");
                }
            
            }
        
        }
    
        public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
        public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        public static readonly string jquery_2_1_3_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.3.intellisense.min.js") ? Url("jquery-2.1.3.intellisense.min.js") : Url("jquery-2.1.3.intellisense.js");
        public static readonly string jquery_2_1_3_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.3.min.js") ? Url("jquery-2.1.3.min.js") : Url("jquery-2.1.3.js");
        public static readonly string jquery_2_1_3_min_js = Url("jquery-2.1.3.min.js");
        public static readonly string jquery_2_1_3_min_map = Url("jquery-2.1.3.min.map");
        public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
        public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
        public static readonly string modernizr_2_8_3_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/modernizr-2.8.3.min.js") ? Url("modernizr-2.8.3.min.js") : Url("modernizr-2.8.3.js");
        public static readonly string npm_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/npm.min.js") ? Url("npm.min.js") : Url("npm.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class product_canvas {
            private const string URLPATH = "~/Scripts/product-canvas";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string canvas_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/canvas.min.js") ? Url("canvas.min.js") : Url("canvas.js");
            public static readonly string fabric_min_js = Url("fabric.min.js");
            public static readonly string wordwrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/wordwrap.min.js") ? Url("wordwrap.min.js") : Url("wordwrap.js");
        }
    
        public static readonly string respond_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/respond.min.js") ? Url("respond.min.js") : Url("respond.js");
        public static readonly string respond_matchmedia_addListener_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/respond.matchmedia.addListener.min.js") ? Url("respond.matchmedia.addListener.min.js") : Url("respond.matchmedia.addListener.js");
        public static readonly string respond_matchmedia_addListener_min_js = Url("respond.matchmedia.addListener.min.js");
        public static readonly string respond_min_js = Url("respond.min.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        private const string URLPATH = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class bootstrap {
            private const string URLPATH = "~/Content/bootstrap";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string alerts_less = Url("alerts.less");
            public static readonly string badges_less = Url("badges.less");
            public static readonly string bootstrap_less = Url("bootstrap.less");
            public static readonly string breadcrumbs_less = Url("breadcrumbs.less");
            public static readonly string button_groups_less = Url("button-groups.less");
            public static readonly string buttons_less = Url("buttons.less");
            public static readonly string carousel_less = Url("carousel.less");
            public static readonly string close_less = Url("close.less");
            public static readonly string code_less = Url("code.less");
            public static readonly string component_animations_less = Url("component-animations.less");
            public static readonly string dropdowns_less = Url("dropdowns.less");
            public static readonly string forms_less = Url("forms.less");
            public static readonly string glyphicons_less = Url("glyphicons.less");
            public static readonly string grid_less = Url("grid.less");
            public static readonly string input_groups_less = Url("input-groups.less");
            public static readonly string jumbotron_less = Url("jumbotron.less");
            public static readonly string labels_less = Url("labels.less");
            public static readonly string list_group_less = Url("list-group.less");
            public static readonly string media_less = Url("media.less");
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class mixins {
                private const string URLPATH = "~/Content/bootstrap/mixins";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string alerts_less = Url("alerts.less");
                public static readonly string background_variant_less = Url("background-variant.less");
                public static readonly string border_radius_less = Url("border-radius.less");
                public static readonly string buttons_less = Url("buttons.less");
                public static readonly string center_block_less = Url("center-block.less");
                public static readonly string clearfix_less = Url("clearfix.less");
                public static readonly string forms_less = Url("forms.less");
                public static readonly string gradients_less = Url("gradients.less");
                public static readonly string grid_framework_less = Url("grid-framework.less");
                public static readonly string grid_less = Url("grid.less");
                public static readonly string hide_text_less = Url("hide-text.less");
                public static readonly string image_less = Url("image.less");
                public static readonly string labels_less = Url("labels.less");
                public static readonly string list_group_less = Url("list-group.less");
                public static readonly string nav_divider_less = Url("nav-divider.less");
                public static readonly string nav_vertical_align_less = Url("nav-vertical-align.less");
                public static readonly string opacity_less = Url("opacity.less");
                public static readonly string pagination_less = Url("pagination.less");
                public static readonly string panels_less = Url("panels.less");
                public static readonly string progress_bar_less = Url("progress-bar.less");
                public static readonly string reset_filter_less = Url("reset-filter.less");
                public static readonly string resize_less = Url("resize.less");
                public static readonly string responsive_visibility_less = Url("responsive-visibility.less");
                public static readonly string size_less = Url("size.less");
                public static readonly string tab_focus_less = Url("tab-focus.less");
                public static readonly string table_row_less = Url("table-row.less");
                public static readonly string text_emphasis_less = Url("text-emphasis.less");
                public static readonly string text_overflow_less = Url("text-overflow.less");
                public static readonly string vendor_prefixes_less = Url("vendor-prefixes.less");
            }
        
            public static readonly string mixins_less = Url("mixins.less");
            public static readonly string modals_less = Url("modals.less");
            public static readonly string navbar_less = Url("navbar.less");
            public static readonly string navs_less = Url("navs.less");
            public static readonly string normalize_less = Url("normalize.less");
            public static readonly string pager_less = Url("pager.less");
            public static readonly string pagination_less = Url("pagination.less");
            public static readonly string panels_less = Url("panels.less");
            public static readonly string popovers_less = Url("popovers.less");
            public static readonly string print_less = Url("print.less");
            public static readonly string progress_bars_less = Url("progress-bars.less");
            public static readonly string responsive_embed_less = Url("responsive-embed.less");
            public static readonly string responsive_utilities_less = Url("responsive-utilities.less");
            public static readonly string scaffolding_less = Url("scaffolding.less");
            public static readonly string tables_less = Url("tables.less");
            public static readonly string theme_less = Url("theme.less");
            public static readonly string thumbnails_less = Url("thumbnails.less");
            public static readonly string tooltip_less = Url("tooltip.less");
            public static readonly string type_less = Url("type.less");
            public static readonly string utilities_less = Url("utilities.less");
            public static readonly string variables_less = Url("variables.less");
            public static readonly string wells_less = Url("wells.less");
        }
    
        public static readonly string bootstrap_theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap-theme.min.css") ? Url("bootstrap-theme.min.css") : Url("bootstrap-theme.css");
             
        public static readonly string bootstrap_theme_css_map = Url("bootstrap-theme.css.map");
        public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
        public static readonly string bootstrap_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.css") ? Url("bootstrap.min.css") : Url("bootstrap.css");
             
        public static readonly string bootstrap_css_map = Url("bootstrap.css.map");
        public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class fonts {
            private const string URLPATH = "~/Content/fonts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string glyphicons_halflings_regular_eot = Url("glyphicons-halflings-regular.eot");
            public static readonly string glyphicons_halflings_regular_svg = Url("glyphicons-halflings-regular.svg");
            public static readonly string glyphicons_halflings_regular_ttf = Url("glyphicons-halflings-regular.ttf");
            public static readonly string glyphicons_halflings_regular_woff = Url("glyphicons-halflings-regular.woff");
            public static readonly string glyphicons_halflings_regular_woff2 = Url("glyphicons-halflings-regular.woff2");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class images {
            private const string URLPATH = "~/Content/images";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string _02_granite_platter_state_ga_png = Url("02-granite platter state ga.png");
            public static readonly string _04_granite_welcome_sign_png = Url("04-granite welcome sign.png");
            public static readonly string ajax_loader_gif = Url("ajax-loader.gif");
            public static readonly string alumni_png = Url("alumni.png");
            public static readonly string coaster_leather_png = Url("coaster leather.png");
            public static readonly string coffee_cup_white_16_png = Url("coffee cup white 16.png");
            public static readonly string coffee_mug_black_png = Url("coffee mug black.png");
            public static readonly string coffee_mug_White_png = Url("coffee mug White.png");
            public static readonly string collegiateproducts_png = Url("collegiateproducts.png");
            public static readonly string cuttingboard_png = Url("cuttingboard.png");
            public static readonly string family_plaque_png = Url("family plaque.png");
            public static readonly string Glass_Beer_Mug_Georgia_png = Url("Glass Beer Mug Georgia.png");
            public static readonly string Glass_Coffee_Cup_Georgia_png = Url("Glass Coffee Cup Georgia.png");
            public static readonly string glass_coffee_cup_png = Url("glass coffee cup.png");
            public static readonly string glass_cutting_board_georgia_shape_png = Url("glass cutting board georgia shape.png");
            public static readonly string glass_mug_handle_png = Url("glass mug handle.png");
            public static readonly string Glass_Rocks_Georgia_png = Url("Glass Rocks Georgia.png");
            public static readonly string granite_cheese_board_georgia_shape_png = Url("granite cheese board georgia shape.png");
            public static readonly string gtech_png = Url("gtech.png");
            public static readonly string logo_605x182_jpg = Url("logo-605x182.jpg");
            public static readonly string logo_93x28_jpg = Url("logo-93x28.jpg");
            public static readonly string official_licensed_logo_jpg = Url("official_licensed_logo.jpg");
            public static readonly string ornamentsplash_png = Url("ornamentsplash.png");
            public static readonly string rocks_square_png = Url("rocks square.png");
            public static readonly string shot_glass_15_png = Url("shot glass 15.png");
            public static readonly string smallglass_png = Url("smallglass.png");
            public static readonly string Stemless_wine_glass_Georgia_png = Url("Stemless wine glass Georgia.png");
            public static readonly string ugalogo_jpg = Url("ugalogo.jpg");
            public static readonly string ugalogo_png = Url("ugalogo.png");
            public static readonly string wineglass_stemless_png = Url("wineglass stemless.png");
            public static readonly string wineglasskit_png = Url("wineglasskit.png");
        }
    
        public static readonly string PagedList_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/PagedList.min.css") ? Url("PagedList.min.css") : Url("PagedList.css");
             
        public static readonly string site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/site.min.css") ? Url("site.min.css") : Url("site.css");
             
        public static readonly string store_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/store.min.css") ? Url("store.min.css") : Url("store.css");
             
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class Areas 
            {
                public static partial class Admin 
                {
                    public static partial class Product 
                    {
                        public static class Assets
                        {
                            public const string Layout_js = "~/Scripts/Areas/Admin/Product/Layout.js"; 
                        }
                    }
                    public static partial class Shared 
                    {
                        public static class Assets
                        {
                            public const string UploadImage_js = "~/Scripts/Areas/Admin/Shared/UploadImage.js"; 
                        }
                    }
                    public static class Assets
                    {
                    }
                }
                public static class Assets
                {
                }
            }
            public static partial class product_canvas 
            {
                public static class Assets
                {
                    public const string canvas_js = "~/Scripts/product-canvas/canvas.js"; 
                    public const string fabric_min_js = "~/Scripts/product-canvas/fabric.min.js"; 
                    public const string wordwrap_js = "~/Scripts/product-canvas/wordwrap.js"; 
                }
            }
            public static class Assets
            {
                public const string _references_js = "~/Scripts/_references.js"; 
                public const string bootstrap_js = "~/Scripts/bootstrap.js"; 
                public const string bootstrap_min_js = "~/Scripts/bootstrap.min.js"; 
                public const string jquery_2_1_3_intellisense_js = "~/Scripts/jquery-2.1.3.intellisense.js"; 
                public const string jquery_2_1_3_js = "~/Scripts/jquery-2.1.3.js"; 
                public const string jquery_2_1_3_min_js = "~/Scripts/jquery-2.1.3.min.js"; 
                public const string jquery_validate_js = "~/Scripts/jquery.validate.js"; 
                public const string jquery_validate_min_js = "~/Scripts/jquery.validate.min.js"; 
                public const string jquery_validate_unobtrusive_js = "~/Scripts/jquery.validate.unobtrusive.js"; 
                public const string jquery_validate_unobtrusive_min_js = "~/Scripts/jquery.validate.unobtrusive.min.js"; 
                public const string modernizr_2_8_3_js = "~/Scripts/modernizr-2.8.3.js"; 
                public const string npm_js = "~/Scripts/npm.js"; 
                public const string respond_js = "~/Scripts/respond.js"; 
                public const string respond_matchmedia_addListener_js = "~/Scripts/respond.matchmedia.addListener.js"; 
                public const string respond_matchmedia_addListener_min_js = "~/Scripts/respond.matchmedia.addListener.min.js"; 
                public const string respond_min_js = "~/Scripts/respond.min.js"; 
            }
        }
        public static partial class Content 
        {
            public static partial class bootstrap 
            {
                public static partial class mixins 
                {
                    public static class Assets
                    {
                    }
                }
                public static class Assets
                {
                }
            }
            public static partial class fonts 
            {
                public static class Assets
                {
                }
            }
            public static partial class images 
            {
                public static class Assets
                {
                }
            }
            public static class Assets
            {
                public const string bootstrap_theme_css = "~/Content/bootstrap-theme.css";
                public const string bootstrap_theme_min_css = "~/Content/bootstrap-theme.min.css";
                public const string bootstrap_css = "~/Content/bootstrap.css";
                public const string bootstrap_min_css = "~/Content/bootstrap.min.css";
                public const string PagedList_css = "~/Content/PagedList.css";
                public const string site_css = "~/Content/site.css";
                public const string store_css = "~/Content/store.css";
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108


