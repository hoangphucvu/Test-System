using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class TestChildSubject
    {
        public int Id { get; set; }
        public Guid TestChildSubjectId { get; set; }

        [Required(ErrorMessage = "Mã môn học không được để trống")]
        [Display(Name = "Mã môn học")]
        public Guid SubjectCode { get; set; }

        [MinLength(5), MaxLength(10)]
        [Required(ErrorMessage = "Tên tiểu mục không được để trống")]
        [Display(Name = "Tên tiểu mục")]
        public string TestChildSubjectName { get; set; }

        public ICollection<TestDetail> TestDetail { get; set; }
    }
}