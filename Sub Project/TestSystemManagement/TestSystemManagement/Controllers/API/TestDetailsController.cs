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
        private TestSystemManagementEntities _db = new TestSystemManagementEntities();

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
                //_repo.ImportTextQuestion(testDetail);
                dynamic data = JsonConvert.DeserializeObject(testDetail);
                TestDetail testDetails = new TestDetail();
                foreach (var item in data)
                {
                    testDetails.Question = item.Question;
                    testDetails.AnswerA = item.AnswerA;
                    testDetails.AnswerB = item.AnswerB;
                    testDetails.AnswerC = item.AnswerC;
                    testDetails.AnswerD = item.AnswerD;
                    testDetails.CorrectAnswer = string.Join(",", item.CorrectAnswer);
                    testDetails.TypeOfQuestion = Convert.ToInt32(item.TypeOfQuestion);
                    _db.TestDetails.Add(testDetails);
                    _db.SaveChanges();
                }
            }

            return Ok("success");
        }
    }
}