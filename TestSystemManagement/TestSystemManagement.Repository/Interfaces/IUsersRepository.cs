using TestSystemManagement.Core;

namespace TestSystemManagement.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Users Login(string userName, string passWord);
    }
}