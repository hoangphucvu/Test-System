using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TestSystemManagement.Repository.Config
{
    public class Helper
    {
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static readonly string TableDetails = "TestDetails";
    }
}