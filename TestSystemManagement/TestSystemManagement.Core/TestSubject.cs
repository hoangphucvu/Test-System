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
        public int Id { get; set; }

        [MinLength(5), MaxLength(50)]
        [Required(ErrorMessage = "Tên môn học không được để trống")]
        public string SubjectName { get; set; }

        [MinLength(3), MaxLength(50)]
        [Required(ErrorMessage = "Mã môn học không được để trống")]
        public string SubjectCode { get; set; }

        [MinLength(5), MaxLength(10)]
        [Required(ErrorMessage = "Mã bí mật không được để trống")]
        public string SecretCode { get; set; }

        [Required(ErrorMessage = "Số lượng câu hỏi dễ không được để trống")]
        public int NoOfEasyQuestion { get; set; }

        [Required(ErrorMessage = "Số lượng câu hỏi trung bình không được để trống")]
        public int NoOfMediumQuestion { get; set; }

        [Required(ErrorMessage = "Số lượng câu hỏi khó không được để trống")]
        public int NoOfHardQuestion { get; set; }

        [Required(ErrorMessage = "Ngày kiểm tra không được để trống")]
        public DateTime TestDate { get; set; }

        [Required(ErrorMessage = "Thời gian kết thúc không được để trống")]
        public DateTime FinishTime { get; set; }

        public ICollection<TestChildSubject> TestChildSubject { get; set; }
    }
}