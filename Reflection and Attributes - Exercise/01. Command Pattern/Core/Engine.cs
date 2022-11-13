namespace CommandPattern.Core
{
    using System;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;

            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            while (true)
            {
                string cmdArgs = reader.ReadLine();
                string result = String.Empty;

                try
                {
                    result = commandInterpreter.Read(cmdArgs);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }

                writer.WriteLine(result);
            }
        }
    }
}
