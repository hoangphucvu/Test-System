using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestSystem.Models;

namespace TestSystemManagement.Infrastructure.Interfaces
{
    public interface ISubjectRepository
    {
        IHttpActionResult NewSubject(TestSubject dataTestSubject);
    }
}
