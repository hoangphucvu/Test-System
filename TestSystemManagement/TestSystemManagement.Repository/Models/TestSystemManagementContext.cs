using System.Data.Entity;
using TestSystemManagement.Core;

namespace TestSystemManagement.Repository.Models
{
    public class TestSystemManagementContext : DbContext
    {
        public TestSystemManagementContext() : base("name=TestSystemManagementDB")
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<TestChildSubject> TestChildSubjects { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<TestMap> TestMaps { get; set; }
        public DbSet<TestSubject> TestSubjects { get; set; }
        public DbSet<Result> Results { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    ////// define primary key
        //    modelBuilder.Entity<Users>().HasKey(k => k.Id);
        //    modelBuilder.Entity<Result>().HasKey(k => k.Id);
        //    modelBuilder.Entity<TestChildSubject>().HasKey(k => k.Id);
        //    modelBuilder.Entity<TestDetail>().HasKey(k => k.Id);
        //    modelBuilder.Entity<TestMap>().HasKey(k => k.Id);
        //    modelBuilder.Entity<TestSubject>().HasKey(k => k.Id);
        //    ////// auto increment
        //    modelBuilder.Entity<Users>().Property(k => k.Id).
        //    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    modelBuilder.Entity<TestChildSubject>().Property(k => k.Id).
        //    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    modelBuilder.Entity<TestDetail>().Property(k => k.Id).
        //    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    modelBuilder.Entity<TestMap>().Property(k => k.Id).
        //    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    modelBuilder.Entity<TestSubject>().Property(k => k.Id).
        //    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    modelBuilder.Entity<Result>().Property(k => k.Id).
        //    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}