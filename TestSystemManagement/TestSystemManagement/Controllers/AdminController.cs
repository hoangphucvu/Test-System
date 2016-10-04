using System.Web.Mvc;
using TestSystem.Helpers;

namespace TestSystemManagement.Controllers
{
    [Session]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}