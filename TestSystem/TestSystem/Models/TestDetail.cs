using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class TestDetail
    {
        public int Id { get; set; }

        [MinLength(10), MaxLength(255)]
        [Required(ErrorMessage = "Câu hỏi không được để trống")]
        [Display(Name = "Câu hỏi")]
        public string Question { get; set; }

        [MinLength(5), MaxLength(100)]
        [Required(ErrorMessage = "Đáp án A không được để trống")]
        [Display(Name = "Đáp án A")]
        public string AnswerA { get; set; }

        [MinLength(5), MaxLength(100)]
        [Required(ErrorMessage = "Đáp án B không được để trống")]
        [Display(Name = "Đáp án B")]
        public string AnswerB { get; set; }

        [MinLength(5), MaxLength(100)]
        [Required(ErrorMessage = "Đáp án C không được để trống")]
        [Display(Name = "Đáp án C")]
        public string AnswerC { get; set; }

        [MinLength(5), MaxLength(100)]
        [Required(ErrorMessage = "Đáp án D không được để trống")]
        [Display(Name = "Đáp án D")]
        public string AnswerD { get; set; }

        [MinLength(5), MaxLength(100)]
        [Display(Name = "Đáp án của người dùng")]
        public string UserAnswer { get; set; }

        [MinLength(5), MaxLength(100)]
        [Display(Name = "Đáp án đúng")]
        public string CorrectAnswer { get; set; }

        [Required(ErrorMessage = "Loại câu hỏi không được để trống")]
        [Display(Name = "Loại câu hỏi")]
        public int TypeOfQuestion { get; set; }

        [Required(ErrorMessage = "Điểm câu hỏi không được để trống")]
        [Display(Name = "Điểm câu hỏi ")]
        public double Point { get; set; }

        public string UserId { get; set; }

        public Guid TestChildSubjectId { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}