using System.Web.Http;
using TestSystem.Models;
using TestSystemManagement.Infrastructure.Interfaces;
using TestSystemManagement.Infrastructure.Repository;

namespace TestSystemManagement.Infrastructure.Api
{
    public class SubjectController : ApiController, ISubjectRepository
    {
        private SubjectRepository repo = new SubjectRepository();

        [HttpPost]
        public IHttpActionResult NewSubject(TestSubject dataTestSubject)
        {
            if (dataTestSubject == null)
            {
                return BadRequest("Data is empty");
            }
            else
            {
                repo.AddSubject(dataTestSubject);
            }
            return Ok("success");
        }
    }
}