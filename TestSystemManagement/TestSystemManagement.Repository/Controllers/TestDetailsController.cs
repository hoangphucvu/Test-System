using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Repository;

namespace TestSystemManagement.Repository.Controllers
{
    public class TestDetailsController : ApiController
    {
        private readonly TestDetailRepository _repo = new TestDetailRepository();

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(List<TestDetail> testDetail)
        {
            if (testDetail == null)
            {
                return BadRequest("Data is empty");
            }
            else
            {
                _repo.ImportTextQuestion(testDetail);
            }
            return Ok("success");
        }
    }
}