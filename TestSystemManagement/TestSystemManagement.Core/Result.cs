using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class Result
    {
        public int Id { get; set; }

        public string SubjectCode { get; set; }

        public string UserId { get; set; }

        public DateTime TestDate { get; set; }

        public double Total { get; set; }
        public string TestDetailId { get; set; }
        public string TestMapId { get; set; }
    }
}