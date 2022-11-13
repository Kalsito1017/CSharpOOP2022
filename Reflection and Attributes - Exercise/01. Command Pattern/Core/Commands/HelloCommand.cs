using System.Diagnostics.Contracts;

namespace CommandPattern.Core.Commands
{
    using ICommand = Contracts.ICommand;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}