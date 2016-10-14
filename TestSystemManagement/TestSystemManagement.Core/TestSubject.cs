using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class TestSubject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public string SecretCode { get; set; }

        public int NoOfEasyQuestion { get; set; }

        public int NoOfMediumQuestion { get; set; }

        public int NoOfHardQuestion { get; set; }

        public DateTime TestDate { get; set; }

        public DateTime FinishTime { get; set; }

        public string TestChildSubjectId { get; set; }
    }
}