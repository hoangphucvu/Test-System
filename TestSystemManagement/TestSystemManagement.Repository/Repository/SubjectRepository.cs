using System;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Repository.Repository
{
    public class SubjectRepository
    {
        private readonly TestSystemManagementEntities _context = new TestSystemManagementEntities();

        public void AddSubject(TestSubject dataTestSubject)
        {
            try
            {
                _context.TestSubjects.Add(dataTestSubject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}