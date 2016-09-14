using System;
using System.Web.Http;
using System.Web.Mvc;
using TestSystem.Models;
using TestSystem.Repository;

namespace TestSystem.Controllers.API
{
    public class AdminManageController : ApiController
    {
        private TestSystemManagementContext db = new TestSystemManagementContext();

        [System.Web.Http.HttpPost]
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

            //var currentUser = repo.Login(userName, passWord);
            ////if (currentUser != null)
            ////{
            ////    //Session["user"] = new Users { Username = userName, Level = 1 };
            ////    Session.Add(Constant.UserSession, currentUser);
            ////}
            var currentUser = db.Users.Where(x => x.Username.Equals(userName) && x.Password.Equals(passWord)).FirstOrDefault();
            if (currentUser != null)
            {
                //Session["user"] = new Users { Username = userName, Level = 1 };
                //Session.Add(Constant.UserSession, currentUser);
            }
            return new JsonResult { Data = currentUser, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}