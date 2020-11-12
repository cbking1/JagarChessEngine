using JagarEngineContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    public class PositionCommand : IUciInputCommand
    {
        private string _fen;

        List<string> _moves;

        public PositionCommand(List<string> parameters)
        {
            switch (parameters.First())
            {
                case "fen":
                    parameters.RemoveAt(0);
                    _fen = parameters.First();
                    parameters.RemoveAt(0);
                    break;
                case "startpos":
                    parameters.RemoveAt(0);
                    break;
                    _moves = parameters; //assumed to be valid
                default:
                    throw new ArgumentException("Cannot parse arguments for position command. Expected syntax is position [fen <fenstring> | startpos ]  moves <move1> .... <movei>");
            }
        }

        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}