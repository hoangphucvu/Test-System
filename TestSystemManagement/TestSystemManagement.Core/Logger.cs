using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace TestSystemManagement.Core
{
    public class Logger
    {
        private Logger()
        {
        }

        private static Logger instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Logger getInstace()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }
}