using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archz.core
{
    public class Logger
    {
        static private string logName = "archz.log"; 
        static public void Log(LogStatus status, string message)
        {
            string fullMessage = CreateLogMessage(status, message);
            File.AppendAllText(logName, fullMessage);
            Console.WriteLine(fullMessage);
        }

        static private string CreateLogMessage(LogStatus status, string message)
        {
            return $"{DateTime.Now} [{status.ToString()}] {message} {Environment.NewLine}";
        }
    }

    public enum LogStatus
    {
        DEBUG,
        INFO,
        WARNING,
        ERROR,
        CRITICAL
    }
}
