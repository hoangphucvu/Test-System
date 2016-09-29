using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class TestMap
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [MinLength(3), MaxLength(50)]
        public string SubjectCode { get; set; }

        public Users User { get; set; }
        public ICollection<TestDetail> TestDetail { get; set; }
        public Result Result { get; set; }
    }
}