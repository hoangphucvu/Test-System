using System.Web.Mvc;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Interfaces;

namespace TestSystemManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository _repo;
        private readonly Logger _loggger = new Logger();

        public AccountController(IUsersRepository repo)
        {
            this._repo = repo;
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
            var currentUser = _repo.Login(userName, passWord);
            if (currentUser != null)
            {
                Session[Constant.UserSession] = currentUser;
                _loggger.WriteAuthLog(userName, "login");
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