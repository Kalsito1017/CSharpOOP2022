


namespace Logger.Appender
{
    using System;
    using Logger.ILogger;
    using Logger.Layouts;
    using Logger.ReportLevels;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {

        }
        public override void Append(DateTime dateTime, ReportLevel reportLevel ,string message)
        {
            string output = string.Format(this.Layouts.Format, dateTime, reportLevel, message);
            this.AppendedMessages++;
            Console.WriteLine(output);
        }
       
    }
}
