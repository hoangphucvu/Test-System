using System;
using System.IO;
using System.Web.Mvc;
using TestSystemManagement.Repository.Repository;

namespace TestSystemManagement.Repository.Controllers
{
    [AllowCrossSite]
    public class TestDetailController : Controller
    {
        private TestDetailRepository _repository = new TestDetailRepository();

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
                    return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult UploadExcelFile()
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
                    _repository.UploadExcelFile(path);
                }
                catch (Exception ex)
                {
                    return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}