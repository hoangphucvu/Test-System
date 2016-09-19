using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSystem.Helpers;
using TestSystem.Models;
using TestSystemManagement.Core;
using TestSystemManagement.Core.Interfaces;

namespace TestSystemManagement.Controllers
{
    [Session]
    public class AdminController : Controller
    {
        private IUsersRepository repo;
        protected Logger logAccessPath = new Logger("~/Log/AccessLog.txt");
        protected Logger logaction = new Logger("~/LogFiles/ActionLog.txt");

        public AdminController(IUsersRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Login-Logout

        public ActionResult Login()
        {
            if (Session[Constant.UserSession] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {
            var currentUser = repo.Login(userName, passWord);
            if (currentUser != null)
            {
                Session[Constant.UserSession] = currentUser;
                if (!System.IO.File.Exists(logAccessPath.path))
                {
                }
                else
                {
                    logAccessPath.WriteAuthLog(userName, "login");
                }
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Logout()
        {
            Session[Constant.UserSession] = null;
            return RedirectToAction("Login");
        }

        #endregion Login-Logout
    }
}