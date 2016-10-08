using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSystem.Models;

namespace TestSystemManagement.Infrastructure.Repository
{
    public class SubjectRepository
    {
        private TestSystemManagementEntities context = new TestSystemManagementEntities();

        public void AddSubject(TestSubject dataTestSubject)
        {
            try
            {
                context.TestSubjects.Add(dataTestSubject);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}