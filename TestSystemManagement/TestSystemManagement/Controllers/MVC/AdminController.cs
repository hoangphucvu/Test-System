using System;
using System.Linq;
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

        public ActionResult CreateQuestion()
        {
            return View();
        }

        public ActionResult ImportQuestion()
        {
            return View();
        }

        public ActionResult CourseManage()
        {
            return View();
        }

        public ActionResult DownloadQuestion()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DownloadQuestion(int easy, int mid, int hard)
        {
            var result = _db.TestDetails
                .Where(x => x.TypeOfQuestion == easy)
                .Where(x => x.TypeOfQuestion == mid)
                .Where(x => x.TypeOfQuestion == hard)
                .OrderBy(context => Guid.NewGuid()).ToList();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult UpdateQuestionDetail(int id)
        {
            var testDetails = new TestDetail();

            var questionRemove = _db.TestDetails.SingleOrDefault(data => data.Id == id);

            return View(questionRemove);
        }
    }
}