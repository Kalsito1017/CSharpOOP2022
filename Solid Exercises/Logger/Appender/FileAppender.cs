

namespace Logger.Appender
{
    using System;
    using System.IO;
    using Logger.ILogger;
    using Logger.LogFiles;

    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout) 
        { 
            this.logFile = logFile;
        }
        public override void Append(DateTime dateTime, string errorLevel, string message)
        {
            string outputMeS = string.Format(this.Layouts.Format, dateTime, errorLevel, 
                message + Environment.NewLine);
            this.logFile.Write(outputMeS);
            File.AppendAllText("../../../log.txt", outputMeS);
        }

    }
}
