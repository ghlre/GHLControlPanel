namespace GHLCP.Diagnostics
{
    public interface ILogger
    {
        LoggerType Type { get; }

        void Error(string message);

        void Warning(string message);

        void Debug(string message);

        void Trace(string message);
    }
}
