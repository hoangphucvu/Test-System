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
            bundles.Add(new StyleBundle("~/bootstrap").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap-theme.css",
                     "~/Content/Css-Lib/font-awesome.min.css",
                     "~/Content/Style/site.css"
                      ));
            bundles.Add(new ScriptBundle("~/site-js").Include(
                      "~/Scripts/scripts.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                       "~/Scripts/Lib-Js/jquery-1.10.2.min.js",
                       "~/Scripts/Lib-Js/materialize.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Lib-Js/angular.min.js",
                         "~/Scripts/Lib-Js/angular-sanitize.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/angular-app").IncludeDirectory(
                      "~/Scripts/app", "*.js", true
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}