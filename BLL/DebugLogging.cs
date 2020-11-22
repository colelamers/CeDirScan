using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScanner
{
    public static class DebugLogging
    {
        static string LogFilePath { get; set; }
        static string LogFileName { get; set; }
        static string LogFilePathAndName { get; set; }

        static DebugLogging()
        {
            LogFilePath = @"..\Debug\Logs\";
            LogFileName = $"{DateTime.Now.ToString("yyyyMMdd")}_Log.txt";
            LogFilePathAndName = Path.Combine(LogFilePath, LogFileName);
            CreateDebugLogger();
        }

        public static void CreateDebugLogger()
        {
            if (!Directory.Exists(LogFilePath))
            {
                Directory.CreateDirectory(LogFilePath);
            }//creates the log directory if it doesn't exist

            if (!File.Exists(Path.GetFullPath(LogFilePathAndName)))
            {
                using (StreamWriter sw = File.CreateText(LogFilePathAndName)) { }//just creates and closes the file if it exists
            }//creates the debug file for specific day the program is run
        }

        public static void LogActivity(string status)
        {
            using (StreamWriter streamWriter = File.AppendText(Path.GetFullPath(LogFilePathAndName)))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss.ffff")}, {status}");
            }
        }//writes to the debug logging file
    }
}
