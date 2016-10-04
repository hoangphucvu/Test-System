using TestSystem.Models;

namespace TestSystemManagement.Infrastructure
{
    public interface IUsersRepository
    {
        Users Login(string userName, string passWord);
    }
}