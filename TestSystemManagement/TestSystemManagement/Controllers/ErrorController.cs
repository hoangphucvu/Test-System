using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSystemManagement.Core;

namespace TestSystemManagement.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult HttpError500()
        {
            return View();
        }
    }
}