namespace CommandPattern
{
    
    using Core;
    using Core.Commands;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(command, reader, writer);
            engine.Run();
        }
    }
}
