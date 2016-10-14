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

        public string TestDetailId { get; set; }
        public string ResultId { get; set; }
        public string TestMapId { get; set; }
    }
}