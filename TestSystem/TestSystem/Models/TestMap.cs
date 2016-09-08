using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class TestMap
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SubjectCode { get; set; }

        public ICollection<Users> Users { get; set; }
        public ICollection<TestSubject> TestSubject { get; set; }
    }
}