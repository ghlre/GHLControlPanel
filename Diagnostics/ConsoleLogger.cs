using System;

namespace GHLCP.Diagnostics
{
    public class ConsoleLogger : ILogger
    {
        public LoggerType Type
        {
            get
            {
                return LoggerType.Console;
            }
        }

        public void Error(string message)
        {
            Console.WriteLine("Error: {0}", message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("Warning: {0}", message);
        }
        public void Debug(string message)
        {
            Console.WriteLine("Debug: {0}", message);
        }

        public void Trace(string message)
        {
            Console.WriteLine("Trace: {0}", message);
        }
    }
}
