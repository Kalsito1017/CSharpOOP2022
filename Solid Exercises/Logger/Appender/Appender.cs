using Logger.ILogger;
using System;


namespace Logger.Appender
{
    using Logger.ILogger;
    using System;
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
            
        {
            this.Layouts = layout;
        }
        
        public ILayout Layouts { get; }
        public abstract void Append(DateTime dateTime, string errorLevel, string message);
        
    }
}
