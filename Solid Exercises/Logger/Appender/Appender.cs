
namespace Logger.Appender
{

    using System;
    using ILogger;
    using ReportLevels;
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
            
        {
            this.Layouts = layout;
        }
        public ReportLevel ReportLevel { get; set; }
        public int AppendedMessages { get; protected set; }

        public ILayout Layouts { get; }
        public abstract void Append(DateTime dateTime, ReportLevel reportLevel, string message);
        public override string ToString()
        => $@"Appender type: {this.GetType().Name}, Layout type: {this.GetType().Name}, Report level: {this.ReportLevel}, Messages
                   appended: {this.AppendedMessages}";
    }
}
