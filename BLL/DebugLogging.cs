using System;
using System.IO;

namespace DirectoryScanner
{
    /*
     * Created by Cole Lamers 
     * Date: 11/22/2020
     * Version 1.0
     * 
     * Changes: (date, initials, alteration)
    */
    public class DebugLogging
    {
        static string LogFilePath { get; set; }
        static string LogFileName { get; set; }
        static string LogFilePathAndName { get; set; }

        /* Commented out constructor because I'm calling the CreateDebugLogger() instead to initialize it
        public DebugLogging()
        {
            CreateDebugLogger();
        }
        */

        public static void CreateDebugLogger()
        {
            LogFilePath = @"..\Debug\Logs\";
            LogFileName = $"{DateTime.Now.ToString("yyyyMMdd")}_Log.txt";
            LogFilePathAndName = Path.Combine(LogFilePath, LogFileName);

            if (!Directory.Exists(LogFilePath))
            {
                Directory.CreateDirectory(LogFilePath);
            }//creates the log directory if it doesn't exist

            if (!File.Exists(Path.GetFullPath(LogFilePathAndName)))
            {
                using (StreamWriter sw = File.CreateText(LogFilePathAndName)) { }//just creates and closes the file if it does not exist
            }//creates the debug file for specific day the program is run
        }

        public static void LogActivity(string status)
        {
            using (StreamWriter streamWriter = File.AppendText(Path.GetFullPath(LogFilePathAndName)))
            {
                streamWriter.WriteLine($"{DateTime.Now:yyyy:MM:dd HH:mm:ss.ffff}, {status}");
            }
        }//writes to the debug logging file
    }
}
