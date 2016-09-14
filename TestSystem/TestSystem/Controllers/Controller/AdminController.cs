using System;
using System.Web.Mvc;
using TestSystem.Helpers;
using TestSystem.Models;
using TestSystem.Repository;

namespace TestSystem.Controllers
{
    [Session]
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public IAdminRepo _repo;

        public AdminController(IAdminRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrEmpty(passWord))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }

            var currentUser = _repo.Login(userName, passWord);
            //if (currentUser != null)
            //{
            //    //Session["user"] = new Users { Username = userName, Level = 1 };
            //    Session.Add(Constant.UserSession, currentUser);
            //}
            return new JsonResult { Data = currentUser, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}