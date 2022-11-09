

namespace Logger
{
    using System;
    using Logger.Appender;
    using Logger.Loggers;
   
    using Logger.ILogger;
    using Logger.Layouts;
    using Logger.LogFiles;

    internal class Program
    {
        static void Main(string[] args)
        {
            //ILayout simpleLayout = new SimpleLayout(); //XmlLayout

            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);          
            //Console, File
            //ILoggers logger = new Logger(consoleAppender); //Error, Info

            //logger.Error("Error parsing JSON.");
            //logger.Info("User Pesho  successfully registered.");
            ILayout simpleLayout = new SimpleLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            ILogFile file = new LogFile();

            IAppender fileAppender = new FileAppender(simpleLayout, file);

            var logger = new Logger(consoleAppender, fileAppender);

            logger.Error("Error parsing JSON.");

            logger.Info("User Pesho successfully registered.");
        }
    }
}
