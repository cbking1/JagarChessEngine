using JagarEngineContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandParsing
{
    public class DebugCommand : IUciInputCommand
    {
        private readonly bool _debugOn;

        public DebugCommand(bool debugOn)
        {
            _debugOn = debugOn;
        }

        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            return;
        }
    }
}