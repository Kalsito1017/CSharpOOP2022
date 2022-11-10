

namespace Logger.Factories
{
    using System;
    using Logger.ILogger;
    using Logger.Layouts;
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            switch(type)
            {
                case "SimpleLayout": return new SimpleLayout();
                case "XmlLayout": return new XmlLayout();
                default: throw new InvalidOperationException("Missing type!");
            }
        }
    }
}
