using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Guid SubjectCode { get; set; }
        public string UserId { get; set; }
        public DateTime TestDate { get; set; }
        public double Total { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<TestSubject> TestSubject { get; set; }
    }
}