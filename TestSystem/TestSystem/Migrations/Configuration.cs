namespace TestSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestSystem.Models.TestSystemManagementContext>
    {
        private readonly bool pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TestSystem.Models.TestSystemManagementContext";
            var migrator = new DbMigrator(this);
            pendingMigrations = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(TestSystem.Models.TestSystemManagementContext context)
        {
            //Exit if there aren't any pending migrations
            if (!pendingMigrations) return;

            context.Users.AddOrUpdate(
            p => p.Id,
              new Users() { UserId = "51303129", Username = "phucngo", Password = "070695", Level = 1 }
            );
        }
    }
}