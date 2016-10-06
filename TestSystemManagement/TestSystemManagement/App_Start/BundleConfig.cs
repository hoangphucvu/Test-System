using System.Web;
using System.Web.Optimization;

namespace TestSystemManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/lib-css").Include(
                     "~/Content/Css-Lib/materialize.min.css",
                     "~/Content/Css-Lib/font-awesome.min.css",
                     "~/Content/Css-Lib/bootstrap-material-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/web-css").Include(
                    "~/Content/Style/dash-board.css",
                    "~/Content/Style/create-new-quiz.css",
                    "~/Content/Style/upload.css"));

            bundles.Add(new ScriptBundle("~/site-js").Include(
                      "~/Scripts/app/site.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                       "~/Scripts/Lib-Js/jquery-1.10.2.min.js",
                       "~/Scripts/Lib-Js/materialize.min.js",
                       "~/Scripts/Lib-Js/moment.min.js",
                       "~/Scripts/Lib-Js/bootstrap-material-datetimepicker.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/angular-lib").Include(
                      "~/Scripts/Lib-Js/angular.js",
                      "~/Scripts/Lib-Js/angular-route.js"
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}