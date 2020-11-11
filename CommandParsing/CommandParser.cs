using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Commands;

namespace CommandParsing
{
    public class CommandParser : ICommandParser
    {

        public ConcurrentQueue<IUciInputCommand> InputQueue { get; private set; }

        public CommandParser()
        {
            InputQueue = new ConcurrentQueue<IUciInputCommand>();
        }

        public void StartParsing()
        {
            bool exit = false;
            while (!exit)
            {
                string commandString = Console.ReadLine();
                IUciInputCommand command = ParseLine(commandString);
            }
        }

        private IUciInputCommand ParseLine(string commandString)
        {
            List<string> parameters = commandString.Split(' ').ToList();
            while (parameters.Any())
            {
                switch (parameters.First())
                {
                    case "uci":
                        return new UciInputCommand();
                    case "isready":
                        return new IsReadyCommand();
                    case "register":
                        return new RegisterCommand();
                }
            }
            return new NullInputCommand();
        }
    }
}
