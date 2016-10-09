using System.Web;
using System.Web.Mvc;

namespace TestSystemManagement.Repository
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
