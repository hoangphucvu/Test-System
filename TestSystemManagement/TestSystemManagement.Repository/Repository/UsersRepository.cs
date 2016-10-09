using System;
using System.Linq;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Interfaces;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Repository.Repository
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

            var currentUser = _context.Users.Where(x => x.Username.Equals(userName) && x.Password.Equals(passWord)).FirstOrDefault();
            return currentUser;
        }
    }
}