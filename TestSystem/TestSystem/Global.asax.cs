using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestSystem.Models;

namespace TestSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static TestSystemManagementContext context = new TestSystemManagementContext();

        private void DBMigraSeed()
        {
            context.Database.CreateIfNotExists();
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TestSystemManagementContext,
                Migrations.Configuration>()
            );
        }

        protected void Application_Start()
        {
            BundleTable.EnableOptimizations = true;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DBMigraSeed();
        }
    }
}