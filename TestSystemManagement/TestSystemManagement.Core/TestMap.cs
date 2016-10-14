using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class TestMap
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string SubjectCode { get; set; }

        public string TestDetailId { get; set; }
        public string ResultId { get; set; }
    }
}