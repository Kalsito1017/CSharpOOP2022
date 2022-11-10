
namespace Logger.Appender
{
    using System;
    using System.IO;
    using Logger.ILogger;
    using Logger.Layouts;
    using Logger.LogFiles;
    using Logger.ReportLevels;

    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;
        private readonly string path;
        public FileAppender(ILayout layout, ILogFile logFile, string path)
            : base(layout) 
        { 
            this.logFile = logFile;
            this.path = path;
        }
        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string outputMeS = string.Format(this.Layouts.Format, dateTime, reportLevel, 
                message + Environment.NewLine);
            this.logFile.Write(outputMeS);
            this.AppendedMessages++;
            File.AppendAllText(path, outputMeS); //can use also html
        }
        public override string ToString()
        =>  base.ToString() + $", File size : {this.logFile.Size}";
        

    }
}
