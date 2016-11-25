using System;
using System.Linq;
using TestSystemManagement.Interfaces;
using TestSystemManagement.Models;

namespace TestSystemManagement.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TestSystemManagementEntities _context = new TestSystemManagementEntities();

        public Users Login(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrEmpty(passWord))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }

            var currentUser = _context.Users.FirstOrDefault(x => x.Username.Equals(userName) && x.Password.Equals(passWord));
            return currentUser;
        }
    }
}