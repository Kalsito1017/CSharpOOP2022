using System.Diagnostics.Contracts;

namespace CommandPattern.Core.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ');

            string cmdName = cmdArgs[0];
            string[] cmdParams = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.StartsWith(cmdName));

            if (type == null)
            {
                throw new InvalidOperationException("This type is not valid!");
            }

            object typeInstance = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethods().FirstOrDefault(m => m.Name == "Execute");

            string result = (string)method.Invoke(typeInstance, new object[] { cmdParams });

            return result;
        }
    }
}