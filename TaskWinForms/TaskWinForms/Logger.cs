using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWinForms
{
    public static class Logger
    {
        private static readonly string logFilePath = "deliveryLog.csv";

        public static void Log(string message)
        {
            WriteLog("INFO", message);
        }

        public static void LogError(string message)
        {
            WriteLog("ERROR", message);
        }

        private static void WriteLog(string logType, string message)
        {
            try
            {
                using (var writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},{logType},{message}");
                }
            }
            catch
            {
                
            }
        }
    }
}
