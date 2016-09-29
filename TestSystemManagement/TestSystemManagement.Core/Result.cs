using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class Result
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(50)]
        [Required(ErrorMessage = "Mã môn không được để trống")]
        public string SubjectCode { get; set; }

        [Required(ErrorMessage = "Mã người dùng không được để trống")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Ngày kiểm tra không được để trống")]
        public DateTime TestDate { get; set; }

        public double Total { get; set; }
        public Users User { get; set; }
        public ICollection<TestDetail> TestDetail { get; set; }
        public ICollection<TestMap> TestMap { get; set; }
    }
}