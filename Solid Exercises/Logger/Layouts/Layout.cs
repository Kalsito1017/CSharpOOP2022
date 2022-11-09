using Logger.ILogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public abstract class Layout : ILayout
    {
        protected Layout(string format)
        {
            this.Format = format;
        }
        public string Format { get; }
    }
}
