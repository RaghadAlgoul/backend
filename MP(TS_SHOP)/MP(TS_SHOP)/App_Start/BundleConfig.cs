using System.Web;
using System.Web.Optimization;

namespace MP_TS_SHOP_
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/TS_SHOP/Script").Include(
                       "~/Content/assets/js/jquery-1.11.0.min.js",
                       "~/Content/assets/js/jquery-migrate-1.2.1.min.js",
                       "~/Content/assets/js/bootstrap.bundle.min.js",
                       "~/Content/assets/js/templatemo.js",
                       "~/Content/assets/js/custom.js",
                       "~/Content/assets/js/slick.min.js"


                       ));






            bundles.Add(new StyleBundle("~/TS_SHOP/css").Include(
                     "~/Content/assets/css/bootstrap.min.css",
                     "~/Content/assets/css/templatemo.css",
                     "~/Content/assets/css/custom.css",
                     "~/MyCss.css",
                     "~/Content/assets/css/fontawesome.min.css",
                     "~/Content/assets/css/slick.min.css",
                     "~/Content/assets/css/slick-theme.css"
                     ));

           

            bundles.Add(new StyleBundle("~/PersonProfile/css").Include(
                      "~/Content/PersonalProfile/css/style.css",
                      "~/Content/PersonalProfile/css/style.css"

                     ));


            bundles.Add(new StyleBundle("~/Admin/css").Include(
                     "~/Content/AdminStyle/css/fontawesome.min.css",
                     "~/Content/AdminStyle/css/bootstrap.min.css",
                     "~/Content/AdminStyle/css/templatemo-style.css"
                    ));

        }
    }
}
