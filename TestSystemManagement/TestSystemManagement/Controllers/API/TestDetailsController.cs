using Newtonsoft.Json;
using System;
using System.Web.Http;
using TestSystemManagement.Models;
using TestSystemManagement.Repository;

namespace TestSystemManagement.Controllers.API
{
    public class TestDetailsController : ApiController
    {
        private readonly TestDetailRepository _repo = new TestDetailRepository();

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var searchData = _repo.QuestionSearch(id);
            return Ok(searchData);
        }

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]string testDetail)
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