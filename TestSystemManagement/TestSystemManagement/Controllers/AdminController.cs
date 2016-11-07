using System.Web.Mvc;
using TestSystemManagement.Core;
using TestSystemManagement.Helpers;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Controllers
{
    [Session]
    public class AdminController : Controller
    {
        private TestSystemManagementEntities _db = new TestSystemManagementEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertTextData(TestDetail testDetail)
        {
            _db.TestDetails.Add(testDetail);
            _db.SaveChanges();
            return new JsonResult { Data = true };
        }
    }
}