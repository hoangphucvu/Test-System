using System;
using TestSystemManagement.Models;

namespace TestSystemManagement.Repository
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