﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestSystemManagement.Repository.Interfaces
{
    public interface ITestDetailRepository
    {
        JsonResult UploadTextFile(string file);

        JsonResult UploadWordFile();

        JsonResult UploadExcelFile();
    }
}