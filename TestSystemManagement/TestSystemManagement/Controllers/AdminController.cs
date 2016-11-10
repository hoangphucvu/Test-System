using System.Web.Mvc;
using TestSystemManagement.Core;
using TestSystemManagement.Helpers;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Controllers
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