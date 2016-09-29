using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystem.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        public int AccessLevel { get; set; }

        public ICollection<TestDetail> TestDetail { get; set; }
        public ICollection<Result> Result { get; set; }
        public ICollection<TestMap> TestMap { get; set; }
    }
}