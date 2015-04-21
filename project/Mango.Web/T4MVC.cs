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
    static readonly ApiClass s_Api = new ApiClass();
    public static ApiClass Api { get { return s_Api; } }
    static readonly StoreClass s_Store = new StoreClass();
    public static StoreClass StoreArea { get { return s_Store; } }
    public static Mango.Web.Controllers.AccountController Account = new Mango.Web.Controllers.T4MVC_AccountController();
    public static Mango.Web.Controllers.HomeController Home = new Mango.Web.Controllers.T4MVC_HomeController();
    public static Mango.Web.Controllers.ManageController Manage = new Mango.Web.Controllers.T4MVC_ManageController();
    public static Mango.Web.Controllers.StoreController Store = new Mango.Web.Controllers.T4MVC_StoreController();
    public static Mango.Web.Controllers.UtilityController Utility = new Mango.Web.Controllers.T4MVC_UtilityController();
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
        public Mango.Web.Areas.Admin.Controllers.OrderController Order = new Mango.Web.Areas.Admin.Controllers.T4MVC_OrderController();
        public Mango.Web.Areas.Admin.Controllers.OrganizationController Organization = new Mango.Web.Areas.Admin.Controllers.T4MVC_OrganizationController();
        public Mango.Web.Areas.Admin.Controllers.ProductCategoryController ProductCategory = new Mango.Web.Areas.Admin.Controllers.T4MVC_ProductCategoryController();
        public Mango.Web.Areas.Admin.Controllers.ProductController Product = new Mango.Web.Areas.Admin.Controllers.T4MVC_ProductController();
        public Mango.Web.Areas.Admin.Controllers.UserController User = new Mango.Web.Areas.Admin.Controllers.T4MVC_UserController();
        public T4MVC.Admin.SharedController Shared = new T4MVC.Admin.SharedController();
    }
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class ApiClass
    {
        public readonly string Name = "Api";
        public T4MVC.Api.SharedController Shared = new T4MVC.Api.SharedController();
    }
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class StoreClass
    {
        public readonly string Name = "Store";
        public Mango.Web.Areas.Store.Controllers.CartController Cart = new Mango.Web.Areas.Store.Controllers.T4MVC_CartController();
        public Mango.Web.Areas.Store.Controllers.HomeController Home = new Mango.Web.Areas.Store.Controllers.T4MVC_HomeController();
        public Mango.Web.Areas.Store.Controllers.ProductController Product = new Mango.Web.Areas.Store.Controllers.T4MVC_ProductController();
        public T4MVC.Store.BaseController Base = new T4MVC.Store.BaseController();
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
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_FileStreamResult : System.Web.Mvc.FileStreamResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_FileStreamResult(string area, string controller, string action, string protocol = null): base(default(System.IO.Stream), " ")
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ViewResult : System.Web.Mvc.ViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
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
                    public static readonly string SortableImages_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/SortableImages.min.js") ? Url("SortableImages.min.js") : Url("SortableImages.js");
                    public static readonly string UploadImage_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/UploadImage.min.js") ? Url("UploadImage.min.js") : Url("UploadImage.js");
                }
            
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Store {
                private const string URLPATH = "~/Scripts/Areas/Store";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class Cart {
                    private const string URLPATH = "~/Scripts/Areas/Store/Cart";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string CartService_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/CartService.min.js") ? Url("CartService.min.js") : Url("CartService.js");
                }
            
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class Product {
                    private const string URLPATH = "~/Scripts/Areas/Store/Product";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string Customize_output_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Customize-output.min.js") ? Url("Customize-output.min.js") : Url("Customize-output.js");
                }
            
            }
        
        }
    
        public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
        public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        public static readonly string jquery_2_1_3_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.3.intellisense.min.js") ? Url("jquery-2.1.3.intellisense.min.js") : Url("jquery-2.1.3.intellisense.js");
        public static readonly string jquery_2_1_3_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.3.min.js") ? Url("jquery-2.1.3.min.js") : Url("jquery-2.1.3.js");
        public static readonly string jquery_2_1_3_min_js = Url("jquery-2.1.3.min.js");
        public static readonly string jquery_2_1_3_min_map = Url("jquery-2.1.3.min.map");
        public static readonly string jquery_ui_1_11_4_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-ui-1.11.4.min.js") ? Url("jquery-ui-1.11.4.min.js") : Url("jquery-ui-1.11.4.js");
        public static readonly string jquery_ui_1_11_4_min_js = Url("jquery-ui-1.11.4.min.js");
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
        public static readonly string area_admin_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/area_admin.min.css") ? Url("area_admin.min.css") : Url("area_admin.css");
             
        public static readonly string area_store_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/area_store.min.css") ? Url("area_store.min.css") : Url("area_store.css");
             
        public static readonly string areas_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/areas.min.css") ? Url("areas.min.css") : Url("areas.css");
             
        public static readonly string bootstrap_theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap-theme.min.css") ? Url("bootstrap-theme.min.css") : Url("bootstrap-theme.css");
             
        public static readonly string bootstrap_theme_css_map = Url("bootstrap-theme.css.map");
        public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
        public static readonly string bootstrap_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/bootstrap.min.css") ? Url("bootstrap.min.css") : Url("bootstrap.css");
             
        public static readonly string bootstrap_css_map = Url("bootstrap.css.map");
        public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
        public static readonly string font_awesome_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/font-awesome.min.css") ? Url("font-awesome.min.css") : Url("font-awesome.css");
             
        public static readonly string font_awesome_min_css = Url("font-awesome.min.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class images {
            private const string URLPATH = "~/Content/images";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string ajax_loader_gif = Url("ajax-loader.gif");
            public static readonly string alumni_png = Url("alumni.png");
            public static readonly string AM_mc_vs_dc_ae_png = Url("AM_mc_vs_dc_ae.png");
            public static readonly string background_png = Url("background.png");
            public static readonly string coaster_leather_png = Url("coaster leather.png");
            public static readonly string coffee_cup_white_16_png = Url("coffee cup white 16.png");
            public static readonly string coffee_mug_black_png = Url("coffee mug black.png");
            public static readonly string coffee_mug_White_png = Url("coffee mug White.png");
            public static readonly string collegiateproducts_png = Url("collegiateproducts.png");
            public static readonly string etchieve_logo_cap_png = Url("etchieve-logo-cap.png");
            public static readonly string etchieve_logo_solid_png = Url("etchieve-logo-solid.png");
            public static readonly string etchieve_logo_png = Url("etchieve-logo.png");
            public static readonly string Glass_Beer_Mug_Georgia_png = Url("Glass Beer Mug Georgia.png");
            public static readonly string Glass_Coffee_Cup_Georgia_png = Url("Glass Coffee Cup Georgia.png");
            public static readonly string glass_coffee_cup_png = Url("glass coffee cup.png");
            public static readonly string glass_cutting_board_georgia_shape_png = Url("glass cutting board georgia shape.png");
            public static readonly string glass_mug_handle_png = Url("glass mug handle.png");
            public static readonly string Glass_Rocks_Georgia_png = Url("Glass Rocks Georgia.png");
            public static readonly string gtech_png = Url("gtech.png");
            public static readonly string logo_605x182_jpg = Url("logo-605x182.jpg");
            public static readonly string logo_93x28_jpg = Url("logo-93x28.jpg");
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class logos {
                private const string URLPATH = "~/Content/images/logos";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string ugalogo_png = Url("ugalogo.png");
                public static readonly string ugalogo2_png = Url("ugalogo2.png");
                public static readonly string ugalogo3_png = Url("ugalogo3.png");
                public static readonly string ugalogo4_png = Url("ugalogo4.png");
                public static readonly string ugalogo5_png = Url("ugalogo5.png");
            }
        
            public static readonly string noimageavail_png = Url("noimageavail.png");
            public static readonly string official_licensed_logo_jpg = Url("official_licensed_logo.jpg");
            public static readonly string ornamentsplash_png = Url("ornamentsplash.png");
            public static readonly string paypal_button_medium_png = Url("paypal-button-medium.png");
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class product {
                private const string URLPATH = "~/Content/images/product";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string product_image_png = Url("product-image.png");
            }
        
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
             
        public static readonly string shared_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/shared.min.css") ? Url("shared.min.css") : Url("shared.css");
             
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class themes {
            private const string URLPATH = "~/Content/themes";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class @base {
                private const string URLPATH = "~/Content/themes/base";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string accordion_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/accordion.min.css") ? Url("accordion.min.css") : Url("accordion.css");
                     
                public static readonly string all_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/all.min.css") ? Url("all.min.css") : Url("all.css");
                     
                public static readonly string autocomplete_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/autocomplete.min.css") ? Url("autocomplete.min.css") : Url("autocomplete.css");
                     
                public static readonly string base_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/base.min.css") ? Url("base.min.css") : Url("base.css");
                     
                public static readonly string button_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/button.min.css") ? Url("button.min.css") : Url("button.css");
                     
                public static readonly string core_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/core.min.css") ? Url("core.min.css") : Url("core.css");
                     
                public static readonly string datepicker_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/datepicker.min.css") ? Url("datepicker.min.css") : Url("datepicker.css");
                     
                public static readonly string dialog_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/dialog.min.css") ? Url("dialog.min.css") : Url("dialog.css");
                     
                public static readonly string draggable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/draggable.min.css") ? Url("draggable.min.css") : Url("draggable.css");
                     
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class images {
                    private const string URLPATH = "~/Content/themes/base/images";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string ui_bg_flat_0_aaaaaa_40x100_png = Url("ui-bg_flat_0_aaaaaa_40x100.png");
                    public static readonly string ui_bg_flat_75_ffffff_40x100_png = Url("ui-bg_flat_75_ffffff_40x100.png");
                    public static readonly string ui_bg_glass_55_fbf9ee_1x400_png = Url("ui-bg_glass_55_fbf9ee_1x400.png");
                    public static readonly string ui_bg_glass_65_ffffff_1x400_png = Url("ui-bg_glass_65_ffffff_1x400.png");
                    public static readonly string ui_bg_glass_75_dadada_1x400_png = Url("ui-bg_glass_75_dadada_1x400.png");
                    public static readonly string ui_bg_glass_75_e6e6e6_1x400_png = Url("ui-bg_glass_75_e6e6e6_1x400.png");
                    public static readonly string ui_bg_glass_95_fef1ec_1x400_png = Url("ui-bg_glass_95_fef1ec_1x400.png");
                    public static readonly string ui_bg_highlight_soft_75_cccccc_1x100_png = Url("ui-bg_highlight-soft_75_cccccc_1x100.png");
                    public static readonly string ui_icons_222222_256x240_png = Url("ui-icons_222222_256x240.png");
                    public static readonly string ui_icons_2e83ff_256x240_png = Url("ui-icons_2e83ff_256x240.png");
                    public static readonly string ui_icons_454545_256x240_png = Url("ui-icons_454545_256x240.png");
                    public static readonly string ui_icons_888888_256x240_png = Url("ui-icons_888888_256x240.png");
                    public static readonly string ui_icons_cd0a0a_256x240_png = Url("ui-icons_cd0a0a_256x240.png");
                }
            
                public static readonly string menu_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/menu.min.css") ? Url("menu.min.css") : Url("menu.css");
                     
                public static readonly string progressbar_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/progressbar.min.css") ? Url("progressbar.min.css") : Url("progressbar.css");
                     
                public static readonly string resizable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/resizable.min.css") ? Url("resizable.min.css") : Url("resizable.css");
                     
                public static readonly string selectable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/selectable.min.css") ? Url("selectable.min.css") : Url("selectable.css");
                     
                public static readonly string selectmenu_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/selectmenu.min.css") ? Url("selectmenu.min.css") : Url("selectmenu.css");
                     
                public static readonly string slider_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/slider.min.css") ? Url("slider.min.css") : Url("slider.css");
                     
                public static readonly string sortable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/sortable.min.css") ? Url("sortable.min.css") : Url("sortable.css");
                     
                public static readonly string spinner_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/spinner.min.css") ? Url("spinner.min.css") : Url("spinner.css");
                     
                public static readonly string tabs_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tabs.min.css") ? Url("tabs.min.css") : Url("tabs.css");
                     
                public static readonly string theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/theme.min.css") ? Url("theme.min.css") : Url("theme.css");
                     
                public static readonly string tooltip_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tooltip.min.css") ? Url("tooltip.min.css") : Url("tooltip.css");
                     
            }
        
        }
    
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
                            public const string SortableImages_js = "~/Scripts/Areas/Admin/Shared/SortableImages.js"; 
                            public const string UploadImage_js = "~/Scripts/Areas/Admin/Shared/UploadImage.js"; 
                        }
                    }
                    public static class Assets
                    {
                    }
                }
                public static partial class Store 
                {
                    public static partial class Cart 
                    {
                        public static class Assets
                        {
                            public const string CartService_js = "~/Scripts/Areas/Store/Cart/CartService.js"; 
                        }
                    }
                    public static partial class Product 
                    {
                        public static class Assets
                        {
                            public const string Customize_output_js = "~/Scripts/Areas/Store/Product/Customize-output.js"; 
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
                public const string jquery_ui_1_11_4_js = "~/Scripts/jquery-ui-1.11.4.js"; 
                public const string jquery_ui_1_11_4_min_js = "~/Scripts/jquery-ui-1.11.4.min.js"; 
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
            public static partial class images 
            {
                public static partial class logos 
                {
                    public static class Assets
                    {
                    }
                }
                public static partial class product 
                {
                    public static class Assets
                    {
                    }
                }
                public static class Assets
                {
                }
            }
            public static partial class themes 
            {
                public static partial class @base 
                {
                    public static partial class images 
                    {
                        public static class Assets
                        {
                        }
                    }
                    public static class Assets
                    {
                        public const string accordion_css = "~/Content/themes/base/accordion.css";
                        public const string all_css = "~/Content/themes/base/all.css";
                        public const string autocomplete_css = "~/Content/themes/base/autocomplete.css";
                        public const string base_css = "~/Content/themes/base/base.css";
                        public const string button_css = "~/Content/themes/base/button.css";
                        public const string core_css = "~/Content/themes/base/core.css";
                        public const string datepicker_css = "~/Content/themes/base/datepicker.css";
                        public const string dialog_css = "~/Content/themes/base/dialog.css";
                        public const string draggable_css = "~/Content/themes/base/draggable.css";
                        public const string menu_css = "~/Content/themes/base/menu.css";
                        public const string progressbar_css = "~/Content/themes/base/progressbar.css";
                        public const string resizable_css = "~/Content/themes/base/resizable.css";
                        public const string selectable_css = "~/Content/themes/base/selectable.css";
                        public const string selectmenu_css = "~/Content/themes/base/selectmenu.css";
                        public const string slider_css = "~/Content/themes/base/slider.css";
                        public const string sortable_css = "~/Content/themes/base/sortable.css";
                        public const string spinner_css = "~/Content/themes/base/spinner.css";
                        public const string tabs_css = "~/Content/themes/base/tabs.css";
                        public const string theme_css = "~/Content/themes/base/theme.css";
                        public const string tooltip_css = "~/Content/themes/base/tooltip.css";
                    }
                }
                public static class Assets
                {
                }
            }
            public static class Assets
            {
                public const string area_admin_css = "~/Content/area_admin.css";
                public const string area_store_css = "~/Content/area_store.css";
                public const string areas_css = "~/Content/areas.css";
                public const string bootstrap_theme_css = "~/Content/bootstrap-theme.css";
                public const string bootstrap_theme_min_css = "~/Content/bootstrap-theme.min.css";
                public const string bootstrap_css = "~/Content/bootstrap.css";
                public const string bootstrap_min_css = "~/Content/bootstrap.min.css";
                public const string font_awesome_css = "~/Content/font-awesome.css";
                public const string font_awesome_min_css = "~/Content/font-awesome.min.css";
                public const string PagedList_css = "~/Content/PagedList.css";
                public const string shared_css = "~/Content/shared.css";
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


