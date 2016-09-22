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
                      "~/Scripts/materialize.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js"
                      ));
            bundles.Add(new StyleBundle("~/lib-css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/font-awesome.min.css"));
        }
    }
}