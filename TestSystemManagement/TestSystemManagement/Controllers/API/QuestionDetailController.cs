using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestSystemManagement.Repository;

namespace TestSystemManagement.Controllers.API
{
    public class QuestionDetailController : ApiController
    {
        private readonly TestDetailRepository _repo = new TestDetailRepository();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var searchData = _repo.QuestionDetailSearch(id);
            return Ok(searchData);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            if (value == null)
            {
                return BadRequest("Data is empty");
            }
            else
            {
                _repo.UpdateTextQuestion(id, value);
            }

            return Ok("success");
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest("Data is empty");
            }
            else
            {
                _repo.DeleteQuestion(id);
            }

            return Ok("success");
        }
    }
}