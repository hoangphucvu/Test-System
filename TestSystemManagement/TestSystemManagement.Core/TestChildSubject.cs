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

        public string TestSubjectId { get; set; }
        public string TestDetailId { get; set; }
    }
}