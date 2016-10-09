using System.Web.Http;
using TestSystemManagement.Core;

namespace TestSystemManagement.Repository.Interfaces
{
    public interface ISubjectRepository
    {
        IHttpActionResult NewSubject(TestSubject dataTestSubject);
    }
}