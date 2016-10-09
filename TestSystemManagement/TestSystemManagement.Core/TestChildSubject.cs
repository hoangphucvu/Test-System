using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class TestChildSubject
    {
        public int Id { get; set; }

        public string TestChildSubjectId { get; set; }

        public string SubjectCode { get; set; }

        public string TestChildSubjectName { get; set; }

        public TestSubject TestSubject { get; set; }
        public ICollection<TestDetail> TestDetail { get; set; }
    }
}