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
        public static void WriteToLog(string projectName, string funcName, string message)
        {
            {
                string folderPath = GetLogDir();
                string filePath = GetLogFile();
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {

                    }
                }
                string logLine = $"{DateTime.Now}\t{projectName}.{funcName}:\t{message}{Environment.NewLine}";
                File.AppendAllText(filePath, logLine);
            }
        }
        public static void CleanOldLogs()
        {
            if (!Directory.Exists(LogDir))
                return;
            string[] directories = Directory.GetDirectories(LogDir);
            DateTime twoMonthAgo = DateTime.Now.AddMonths(-2);
            foreach (string dir in directories)
            {
                if (DateTime.TryParse(dir, out DateTime folderDate))
                {
                    if (folderDate < twoMonthAgo)
                    {
                        Directory.Delete(dir, true);
                    }
                }
            }
        }
    }
}
