

namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;
    public class Tracker
    {
        public Tracker()
        {

        }
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var aatributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in aatributes)
                    {
                        Console.WriteLine("{0} is written by {1}", method.Name, attribute.Name);
                    }
                }
            }
        }
    }
}
