using System.Web.Mvc;

namespace TestSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}