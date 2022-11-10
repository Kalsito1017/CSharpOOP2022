


namespace Logger.Appender
{
    using System;
    using Logger.ILogger;
    using Logger.ReportLevels;
    public interface IAppender
    {
       ILayout Layouts { get; }
        ReportLevel ReportLevel { get; set; }
        int AppendedMessages { get; }
        void Append(DateTime dateTime, ReportLevel reportLevel, string message);
        
    }
}
