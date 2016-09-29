using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class TestChildSubject
    {
        public int Id { get; set; }

        [MinLength(5), MaxLength(20)]
        public string TestChildSubjectId { get; set; }

        [MinLength(3), MaxLength(50)]
        [Required(ErrorMessage = "Mã môn học không được để trống")]
        public string SubjectCode { get; set; }

        [MinLength(5), MaxLength(50)]
        [Required(ErrorMessage = "Tên tiểu mục không được để trống")]
        public string TestChildSubjectName { get; set; }

        public TestSubject TestSubject { get; set; }
        public ICollection<TestDetail> TestDetail { get; set; }
    }
}