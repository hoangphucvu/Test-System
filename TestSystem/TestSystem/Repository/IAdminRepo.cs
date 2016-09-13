using TestSystem.Models;

namespace TestSystem.Repository
{
    public interface IAdminRepo
    {
        Users Login(string userName, string passWord);
    }
}