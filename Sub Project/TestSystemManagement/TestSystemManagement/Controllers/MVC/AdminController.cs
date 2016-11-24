using System.Web.Mvc;
using TestSystemManagement.Helpers;
using TestSystemManagement.Models;

namespace TestSystemManagement.Controllers.MVC
{
    [Session]
    public class AdminController : Controller
    {
        private readonly TestSystemManagementEntities _db = new TestSystemManagementEntities();

        public ActionResult Index()
        {
            return View();
        }
    }
}