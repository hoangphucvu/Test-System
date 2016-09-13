using System;
using System.Web.Mvc;
using TestSystem.Models;
using TestSystem.Repository;

namespace TestSystem.Controllers
{
    public class AdminController : Controller
    {
        public IAdminRepo _repo;

        public AdminController(IAdminRepo repo)
        {
            _repo = repo;
        }

        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName, string passWord)
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
            if (currentUser != null)
            {
                //Session["user"] = new Users { Username = userName, Level = 1 };
                Session.Add(Constant.UserSession, currentUser);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}