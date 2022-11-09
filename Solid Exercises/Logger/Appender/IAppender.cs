using Logger.ILogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appender
{
    public interface IAppender
    {
       ILayout Layouts { get; }
        void Append(DateTime dateTime, string errorLevel, string message);
        
    }
}
