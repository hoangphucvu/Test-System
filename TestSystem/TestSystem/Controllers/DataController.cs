using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSystem.Models;

namespace TestSystem.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult UserLogin(Users data)
        {
            using (TestSystemManagementContext db = new TestSystemManagementContext())
            {
                var user = db.Users.Where(a => a.Username.Equals(data.Username)
                && a.Password.Equals(data.Password)).FirstOrDefault();
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}