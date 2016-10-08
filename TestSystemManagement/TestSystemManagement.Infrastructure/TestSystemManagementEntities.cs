﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestSystem.Models;

namespace TestSystemManagement.Infrastructure
{
    public class TestSystemManagementEntities : TestSystemManagementContext
    {
        public new DbSet<Users> Users { get; set; }
        public new DbSet<TestChildSubject> TestChildSubjects { get; set; }
        public new DbSet<TestDetail> TestDetails { get; set; }
        public new DbSet<TestMap> TestMaps { get; set; }
        public new DbSet<TestSubject> TestSubjects { get; set; }
        public new DbSet<Result> Results { get; set; }
    }
}