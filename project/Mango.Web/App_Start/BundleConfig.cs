using System.Web;
using System.Web.Optimization;

namespace Mango.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~" + Links.Scripts.bootstrap_js,
                      "~" + Links.Scripts.respond_js));


            #region Styles

            // root application
            bundles.Add(new StyleBundle("~/Content/shared").Include(
                "~" + Links.Content.bootstrap_css,
                "~" + Links.Content.shared_css));

            // Area: Admin
            bundles.Add(new StyleBundle("~/Content/area_admin").Include(
                "~" + Links.Content.bootstrap_css,
                "~" + Links.Content.areas_css,
                "~" + Links.Content.area_admin_css));

            // Area: Store
            bundles.Add(new StyleBundle("~/Content/area_store").Include(
                "~" + Links.Content.bootstrap_css,
                "~" + Links.Content.areas_css,
                "~" + Links.Content.area_store_css));

            #endregion
        }
    }
}
