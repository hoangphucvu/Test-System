using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestSystem.Models;

namespace TestSystem.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Users)Session[Constant.UserSession];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Admin", action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}