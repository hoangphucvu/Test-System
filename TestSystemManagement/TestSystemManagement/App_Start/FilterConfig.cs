using System.Web;
using System.Web.Mvc;
using TestSystemManagement.App_Start;

namespace TestSystemManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}