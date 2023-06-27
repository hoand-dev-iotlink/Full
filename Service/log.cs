using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Service
{
    public static class log
    {
        private static StreamWriter logWriter = File.AppendText("log.txt");

        public static void Log(string message)
        {
            // Get the current date and time
            DateTime currentTime = DateTime.Now;

            // Format the log message
            string logMessage = $"[{currentTime}] {message}";

            // Write the log message to the file
            logWriter.WriteLine(logMessage);

        }
    }
}
