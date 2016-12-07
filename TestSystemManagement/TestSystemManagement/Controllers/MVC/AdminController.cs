using System;
using System.Linq;
using System.Web.Mvc;
using TestSystemManagement.Helpers;
using TestSystemManagement.Interfaces;
using TestSystemManagement.Models;
using TestSystemManagement.Repository;

namespace TestSystemManagement.Controllers.MVC
{
    [Session]
    public class AdminController : Controller
    {
        private readonly TestSystemManagementEntities _db = new TestSystemManagementEntities();
        private readonly ITestDetailRepository _testDetailRepository = new TestDetailRepository();

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

        public ActionResult UpdateQuestionDetail(int id)
        {
            var questionRemove = _db.TestDetails.SingleOrDefault(data => data.Id == id);

            return View(questionRemove);
        }
    }
}