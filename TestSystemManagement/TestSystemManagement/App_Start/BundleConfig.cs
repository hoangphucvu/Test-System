using System.Web;
using System.Web.Optimization;

namespace TestSystemManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                       "~/Scripts/jquery-1.10.2.min.js",
                       "~/Scripts/materialize.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/angular-lib").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js"
                      ));
            bundles.Add(new StyleBundle("~/lib-css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/font-awesome.min.css"));
        }
    }
}