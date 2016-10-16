using TestSystem.Models;

namespace TestSystemManagement.Core.Interfaces
{
    public interface IUsersRepository
    {
        Users Login(string userName, string passWord);
    }
}