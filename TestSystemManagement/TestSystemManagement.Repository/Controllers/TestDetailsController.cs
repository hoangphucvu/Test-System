using Microsoft.Vbe.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Models;
using TestSystemManagement.Repository.Repository;

namespace TestSystemManagement.Repository.Controllers
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