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
        public string path { get; set; }
        private StreamWriter log;

        public Logger(string path)
        {
            this.path = HttpContext.Current.Server.MapPath(path);
        }

        public void WriteAuthLog(string userName, string action)
        {
            if (!File.Exists(path))
            {
                log = new StreamWriter(path);
            }
            else
            {
                using (log = File.AppendText(path))
                {
                    log.WriteLine("Datetime: {0} - {1}" + DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                    log.WriteLine("User" + userName + " :" + action);
                    log.WriteLine("............");
                    log.Close();
                }
            }
        }

        public void WriteActionLog(string userName, string action, string msg)
        {
            if (!File.Exists(path))
            {
                log = new StreamWriter(path);
            }
            else
            {
                using (log = File.AppendText(path))
                {
                    log.WriteLine("Datetime: {0} - {1}" + DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                    log.WriteLine("User" + userName + " :" + action + " " + msg);
                    log.WriteLine("............");
                    log.Close();
                }
            }
        }
    }
}