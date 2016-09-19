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
                File.Create(path);
                TextWriter log = new StreamWriter(path);
                log.WriteLine("Datetime: {0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                log.WriteLine("User" + userName + " :" + action);
                log.WriteLine("............");
                log.Close();
            }
            else if (File.Exists(path))
            {
                //true append to file,false overwrite file
                using (StreamWriter log = File.AppendText(path))
                {
                    log.WriteLine("Datetime: {0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                    log.WriteLine("User" + userName + " :" + action);
                    log.WriteLine("............");
                    log.Close();
                }
            }
        }

        //public void WriteActionLog(TextWriter log,string userName, string action)
        //{
        //    log.WriteLine("Datetime: {0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
        //    log.WriteLine("User" + userName + " :" + action);
        //    log.WriteLine("............");
        //    log.Close();
        //}
    }
}