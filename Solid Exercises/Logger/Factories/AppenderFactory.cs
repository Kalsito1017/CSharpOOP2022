

namespace Logger.Factories
{
    using System;
    using Logger.Appender;
    using Logger.ILogger;
    using Logger.LogFiles;
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(
            string type,
            ILayout layout)
            => type switch
            {
                "ConsoleAppender" => new ConsoleAppender(layout),
                "FileAppender" => new FileAppender(layout, new LogFile(), "../../../log.html"),
                _ => throw new InvalidOperationException("Missing type")
            };

           
    }
}
