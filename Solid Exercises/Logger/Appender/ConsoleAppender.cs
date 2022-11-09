


namespace Logger.Appender
{
    using System;
    using Logger.ILogger;
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {

        }
        public override void Append(DateTime dateTime, string errorLevel, string message)
        {
            string output = string.Format(this.Layouts.Format, dateTime, errorLevel, message);
            Console.WriteLine(output);
        }
    }
}
