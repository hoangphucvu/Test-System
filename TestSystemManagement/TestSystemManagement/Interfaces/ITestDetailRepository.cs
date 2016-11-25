using System.Web.Mvc;

namespace TestSystemManagement.Interfaces
{
    public interface ITestDetailRepository
    {
        JsonResult UploadTextFile(string file);

        JsonResult UploadWordFile(string file);

        JsonResult UploadExcelFile(string file);

        JsonResult ImportTextQuestion(string testDetail);
    }
}