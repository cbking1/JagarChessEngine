using ChessEngineContracts;
using JagarEngineContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    public class PositionCommand : IUciInputCommand
    {
        private string _fen;

        IEnumerable<IMove> _moves;
        private IEnumerable<string> enumerable;

        public PositionCommand(string fen, IEnumerable<IMove> moves)
        {
            _fen = fen;
            _moves = moves;
        }

        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            if (_fen == "")
            {
                engine.SetStartPosition();
            }
            else
            {
                engine.SetPosition(_fen);
            }
            foreach (IMove move in _moves)
            {
                engine.Play(move);
            }
        }
    }
}