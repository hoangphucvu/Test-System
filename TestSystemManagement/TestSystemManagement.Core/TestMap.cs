using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class TestMap
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string SubjectCode { get; set; }

        public Users User { get; set; }
        public ICollection<TestDetail> TestDetail { get; set; }
        public Result Result { get; set; }
    }
}