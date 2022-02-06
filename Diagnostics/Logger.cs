namespace GHLCP.Diagnostics
{
    public class Logger
    {
        private static ILogger instance;

        public static ILogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleLogger();
                }

                return instance;
            }
        }
    }
}
