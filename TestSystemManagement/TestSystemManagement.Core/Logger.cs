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
        private static StreamWriter log;

        public static void WriteAuthLog(string userName, string action)
        {
            if (!File.Exists("Log/AuthLog.txt"))
            {
                log = new StreamWriter("~/Log/AuthLog.txt");
            }
            else
            {
                log = File.AppendText("~/Log/AuthLog.txt");
            }

            log.WriteLine("...........");
            log.WriteLine("Time" + DateTime.Now.ToShortDateString());
            log.WriteLine("User" + userName + " :" + action);
            log.WriteLine("............");
            log.Close();
        }
    }
}