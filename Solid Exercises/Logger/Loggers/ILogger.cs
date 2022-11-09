using Logger.Appender;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers
{
    public interface ILoggers
    {
        IAppender[] Appenders { get; }
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}
