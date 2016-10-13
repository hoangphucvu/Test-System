using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Repository.Repository
{
    public class TestDetailRepository
    {
        private readonly TestSystemManagementEntities _context = new TestSystemManagementEntities();

        public string ImportTextData(string file)
        {
            return "ok";
        }
    }
}