using JagarEngineContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandParsing
{
    public class DebugCommand : IUciInputCommand
    {
        private readonly bool _debugOn;

        public DebugCommand(IEnumerable<string> parameters)
        {
            switch (parameters.First())
            {
                case "on":
                    _debugOn = true;
                    break;
                case "off":
                    _debugOn = false;
                    break;
                default:
                    throw new ArgumentException("Cannot parse arguments for Debug command, expected syntax is  debug [ on | off ]");
            }
        }

        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            return;
        }
    }
}