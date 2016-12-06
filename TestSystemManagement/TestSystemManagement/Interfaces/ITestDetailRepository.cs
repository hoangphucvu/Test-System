using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestSystemManagement.Models;

namespace TestSystemManagement.Interfaces
{
    public interface ITestDetailRepository
    {
        JsonResult UploadTextFile(string file);

        JsonResult UploadWordFile(string file);

        JsonResult UploadExcelFile(string file);

        JsonResult ImportTextQuestion(string testDetail);

        JsonResult QuestionSearch(string id);

        JsonResult DeleteQuestion(string id);

        JsonResult QuestionDetailSearch(string id);

        JsonResult UpdateTextQuestion(int id, string testDetail);

        JsonResult DownloadQuestion(List<TestDetail> testDetail);
    }
}