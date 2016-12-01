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

        public ActionResult QuestionManage()
        {
            return View();
        }

        public ActionResult CourseManage()
        {
            return View();
        }

        public ActionResult UpdateQuestionDetail(int id)
        {
            var testDetails = new TestDetail();

            var questionRemove = _db.TestDetails.SingleOrDefault(data => data.Id == id);

            return View(questionRemove);
        }
    }
}