using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using TestSystemManagement.Repository.Interfaces;
using TestSystemManagement.Repository.Repository;

namespace TestSystemManagement.Repository.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestDetailController : Controller
    {
        private TestDetailRepository _repository = new TestDetailRepository();

        public JsonResult UploadExcelFile()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public JsonResult UploadTextFile()
        {
            string message;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/App_Data"), fileName));
                    var path = Server.MapPath("~/App_Data/" + fileName);
                    _repository.UploadTextFile(path);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //message = "File upload failed! Please try again";
                    //return new JsonResult { Data = new { Message = message } };
                }
            }
            return new JsonResult { Data = new { Message = "ok" } };
        }
    }
}