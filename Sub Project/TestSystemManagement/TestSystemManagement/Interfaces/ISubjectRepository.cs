using System.Web.Http;
using TestSystemManagement.Models;

namespace TestSystemManagement.Interfaces
{
    public interface ISubjectRepository
    {
        IHttpActionResult NewSubject(TestSubject dataTestSubject);
    }
}