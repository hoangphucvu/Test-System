using System;
using System.Linq;
using System.Web.Mvc;
using TestSystem.Helpers;
using TestSystem.Models;

namespace TestSystem.Controllers
{
    //[Session]
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}