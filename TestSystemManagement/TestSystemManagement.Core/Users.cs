using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class Users
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int AccessLevel { get; set; }

        public ICollection<TestDetail> TestDetail { get; set; }
        public ICollection<Result> Result { get; set; }
        public ICollection<TestMap> TestMap { get; set; }
    }
}