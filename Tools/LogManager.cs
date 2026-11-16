using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private const string LogDir = "Log";

        public static string GetLogDir()
        { 
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,LogDir);
        }
        public static string GetLogFile()
        {
            string dirPath= GetLogDir();
            string filePath = $"{DateTime.Now:yyyy-mm-dd}.txt";
            return Path.Combine (dirPath, filePath);
        }

    }
}
