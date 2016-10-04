using System;
using System.Linq;
using TestSystem.Models;

namespace TestSystemManagement.Infrastructure
{
    public class UsersRepository : IUsersRepository
    {
        private TestSystemManagementEntities context = new TestSystemManagementEntities();

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

            var currentUser = context.Users.Where(x => x.Username.Equals(userName) && x.Password.Equals(passWord)).FirstOrDefault();
            return currentUser;
        }
    }
}