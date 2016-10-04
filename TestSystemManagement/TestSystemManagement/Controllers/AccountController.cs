using System.Web.Mvc;
using TestSystem.Models;
using TestSystemManagement.Core;
using TestSystemManagement.Infrastructure;

namespace TestSystemManagement.Controllers
{
    public class AccountController : Controller
    {
        private IUsersRepository repo;
        public Logger log = new Logger();

        public AccountController(IUsersRepository repo)
        {
            this.repo = repo;
        }

        #region Login-Logout

        public ActionResult Login()
        {
            if (Session[Constant.UserSession] != null)
            {
                return RedirectToAction("Index", "Admin");
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
                log.WriteAuthLog(userName, "login");
                var result = new { data = true, name = currentUser.Username };
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Logout()
        {
            Session[Constant.UserSession] = null;
            return Redirect("Login");
        }

        #endregion Login-Logout
    }
}