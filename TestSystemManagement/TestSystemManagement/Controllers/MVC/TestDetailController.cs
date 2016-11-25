using System;
using System.IO;
using System.Web.Mvc;
using TestSystemManagement.Repository;

namespace TestSystemManagement.Controllers.MVC
{
    public class TestDetailController : Controller
    {
        private readonly TestDetailRepository _repository = new TestDetailRepository();

        [HttpPost]
        public JsonResult UploadFile()
        {
            if (Request.Files == null)
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            var file = Request.Files[0];
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/App_Data"), fileName));
                    var path = Server.MapPath("~/App_Data/" + fileName);
                    if (extension == ".docx")
                        _repository.UploadWordFile(path);
                    if (extension == ".txt")
                        _repository.UploadTextFile(path);
                    if (extension == ".xlsx")
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