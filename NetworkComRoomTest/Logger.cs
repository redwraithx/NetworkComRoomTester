using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NetworkComRoomTest
{
    public enum LogTarget
    {
        File,
        ErrorFile
    }


    public abstract class Logger
    {
        public abstract void Log(string message);
    }

    public class FileLogger : Logger
    {
        public string filePath = @".\ActivityLog.txt";
        public override void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }

    public class ErrorLogger : Logger
    {
        public string filePath = @".\ErrorLog.txt";
        public override void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }

    // helper class
    public static class LogHelper
    {
        private static Logger logger = null;
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    {
                        logger = new FileLogger();
                        logger.Log(message);

                        break;
                    }
                case LogTarget.ErrorFile:
                    {
                        logger = new ErrorLogger();
                        logger.Log(message);

                        break;
                    }
                default:
                    break;
            }
        }
    }
}
