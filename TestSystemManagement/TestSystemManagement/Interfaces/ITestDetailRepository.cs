﻿using System.Web.Mvc;

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
    }
}