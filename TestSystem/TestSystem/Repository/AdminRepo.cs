using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSystem.Models;

namespace TestSystem.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private TestSystemManagementContext db = new TestSystemManagementContext();

        public Users Login(string userName, string passWord)
        {
            var result = db.Users.Where(x => x.Username.Equals(userName) && x.Password.Equals(passWord)).FirstOrDefault();
            //var result = db.Users.Find(userName, passWord);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}