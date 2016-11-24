using System.Web;
using System.Web.Optimization;

namespace TestSystemManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/web-css").Include(
                     "~/Content/Css-Lib/materialize.min.css",
                     "~/Content/Css-Lib/font-awesome.min.css",
                     "~/Content/Style/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/site-js").Include(
                      "~/Scripts/app/site.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                       "~/Scripts/Lib-Js/jquery-1.10.2.min.js",
                       "~/Scripts/Lib-Js/materialize.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/angular-lib").Include(
                      "~/Scripts/Lib-Js/angular.js",
                      "~/Scripts/Lib-Js/angular-route.js",
                      "~/Scripts/Lib-Js/angular-animate.min.js"
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}