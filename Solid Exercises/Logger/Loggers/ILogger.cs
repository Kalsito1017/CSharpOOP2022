using Logger.Appender;

namespace Logger.Loggers
{
    public interface ILoggers
    {
        IAppender[] Appenders { get; }
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Fatal(string message);
        void Critical (string message);
    }
}
