using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestSystemManagement.Models;

namespace TestSystemManagement.Helpers
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = HttpContext.Current.Session[Constant.UserSession];
            if (session == null &&
                (filterContext.RouteData.Values["controller"].ToString().ToLower() != "admin"
                || filterContext.RouteData.Values["action"].ToString().ToLower() != "login"))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}