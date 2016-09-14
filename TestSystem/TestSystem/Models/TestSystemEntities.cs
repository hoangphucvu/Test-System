using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class TestSystemEntities : TestSystemManagementContext
    {
        public DbContext db = new TestSystemManagementContext();

        public TestSystemEntities()
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<TestChildSubject> TestChildSubjects { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<TestMap> TestMaps { get; set; }
        public DbSet<TestSubject> TestSubjects { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}