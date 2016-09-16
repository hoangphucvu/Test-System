using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class TestSubject
    {
        public Guid Id { get; set; }

        [MinLength(5), MaxLength(50)]
        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [Display(Name = "Tên Môn Học")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Mã môn học không được để trống")]
        [Display(Name = "Mã Môn Học")]
        public Guid SubjectCode { get; set; }

        [MinLength(5), MaxLength(10)]
        [Required(ErrorMessage = "Mã bí mật không được để trống")]
        [Display(Name = "Mã Bí Mật")]
        public string SecretCode { get; set; }

        [Required(ErrorMessage = "Số lượng câu hỏi dễ không được để trống")]
        [Display(Name = "Số lượng câu hỏi dễ")]
        public int NoOfEasyQuestion { get; set; }

        [Required(ErrorMessage = "Số lượng câu hỏi trung bình không được để trống")]
        [Display(Name = "Số lượng câu hỏi trung bình")]
        public int NoOfMediumQuestion { get; set; }

        [Required(ErrorMessage = "Số lượng câu hỏi khó không được để trống")]
        [Display(Name = "Số lượng câu hỏi khó")]
        public int NoOfHardQuestion { get; set; }

        [Required(ErrorMessage = "Ngày kiểm tra không được để trống")]
        [Display(Name = "Ngày kiểm tra")]
        public DateTime TestDate { get; set; }

        [Timestamp]
        [Required(ErrorMessage = "Thời lượng kiểm tra không được để trống")]
        [Display(Name = "Thời lượng kiểm tra")]
        public Byte[] TestTime { get; set; }

        public ICollection<TestChildSubject> TestChildSubject { get; set; }
    }
}