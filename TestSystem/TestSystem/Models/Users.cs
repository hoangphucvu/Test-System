using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSystem.Models
{
    public class Users
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [Display(Name = "Tên Đăng Nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        public int Level { get; set; }

        public ICollection<TestDetail> TestDetail { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}