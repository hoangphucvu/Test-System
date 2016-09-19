using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace TestSystemManagement.Core
{
    public class Logger
    {
        //private StreamWriter log;
        private string logAccessPath = "~/Log/AccessLog.txt";

        public void WriteAuthLog(string userName, string action)
        {
            string path = HttpContext.Current.Server.MapPath(logAccessPath);
            if (!File.Exists(path))
            {
                using (StreamWriter log = File.CreateText(path))
                {
                    WriteLog(log, userName, action);
                }
            }
            else if (File.Exists(path))
            {
                using (StreamWriter log = File.AppendText(path))
                {
                    WriteLog(log, userName, action);
                }
            }
        }

        public void WriteLog(StreamWriter log, string userName, string action)
        {
            log.WriteLine("Datetime: {0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
            log.WriteLine("User" + userName + " :" + action);
            log.WriteLine("............");
            log.Close();
        }
    }
}