using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestSystem.Models;

namespace TestSystemManagement.Infrastructure
{
    public class TestSystemManagementEntities : TestSystemManagementContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<TestChildSubject> TestChildSubjects { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<TestMap> TestMaps { get; set; }
        public DbSet<TestSubject> TestSubjects { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}