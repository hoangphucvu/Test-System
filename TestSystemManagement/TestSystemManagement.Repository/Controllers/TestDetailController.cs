using System;
using System.Web.Http;
using System.Web.Mvc;
using TestSystemManagement.Repository.Interfaces;
using TestSystemManagement.Repository.Repository;

namespace TestSystemManagement.Repository.Controllers
{
    public class TestDetailController : ApiController, ITestDetailRepository
    {
        private readonly TestDetailRepository _repository = new TestDetailRepository();

        [System.Web.Http.HttpPost]
        public JsonResult UploadTextFile()
        {
            _repository.ImportTextData("123");
            return new JsonResult { Data = new { Message = "ok" } };
        }
    }
}