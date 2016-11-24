using TestSystemManagement.Models;

namespace TestSystemManagement.Interfaces
{
    public interface IUsersRepository
    {
        Users Login(string userName, string passWord);
    }
}