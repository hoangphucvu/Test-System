using System.Configuration;

namespace TestSystemManagement.Repository.Config
{
    public class Helper
    {
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static readonly string TableDetails = "TestDetails";
    }
}