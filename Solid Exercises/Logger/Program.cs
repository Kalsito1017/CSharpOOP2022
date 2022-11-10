

namespace Logger
{
    using System;
    using Logger.Appender;
    using Logger.Loggers;
   
    using Logger.ILogger;
    using Logger.Layouts;
    using Logger.LogFiles;
    using Logger.ReportLevels;
    using System.Net.NetworkInformation;
    using Logger.Factories;
    using System.Collections.Generic;

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
            //ILayout simpleLayout = new SimpleLayout();

            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            //ILogFile file = new LogFile();
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //IAppender fileAppender = new FileAppender(simpleLayout, file);
            //var logger = new Logger(consoleAppender, fileAppender);

            //logger.Error("Error parsing JSON.");

            //logger.Info("User Pesho successfully registered.");
            //logger.Warning("WARNING WARNING ");
            //||---------------------------------------------------------------||
            //Input type 
            //Output ...
            // "<appender type> <layout type> <REPORT LEVEL>"
            //"<appender type> <layout type>"
            //"<REPORT LEVEL>|<time>|<message>"
            //2

            //ConsoleAppender SimpleLayout CRITICAL

            //FileAppender XmlLayout

            //INFO | 3 / 26 / 2015 2:08:11 PM | Everything seems fine

            //WARNING | 3 / 26 / 2015 2:22:13 PM | Warning: ping is too high - disconnect imminent

            //ERROR | 3 / 26 / 2015 2:32:44 PM | Error parsing request

            //CRITICAL | 3 / 26 / 2015 2:38:01 PM | No connection string found in App.config

            //FATAL | 3 / 26 / 2015 2:39:19 PM | mscorlib.dll does not respond

            //END
            List<IAppender> appenders = new List<IAppender>();
            int appendersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderType = Console.ReadLine()
                    .Split();
                string type = appenderType[0];
                string layoutType = appenderType[1];
                ReportLevel reportLevel = appenderType.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderType[2], true)
                    : ReportLevel.Info;               
                ILayout layout = LayoutFactory.CreateLayout(layoutType);             
                IAppender appender = AppenderFactory.CreateAppender(type, layout);
                appenders.Add(appender);
            }
            ILoggers logger = new Logger(appenders.ToArray());
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] messageInfo = command.Split('|');
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(messageInfo[0], true);        
                string message = messageInfo[2];
                switch(reportLevel)
                {
                    case ReportLevel.Fatal: logger.Fatal(message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(message);
                        break;
                    default: logger.Info(message);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Logger info");
            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
