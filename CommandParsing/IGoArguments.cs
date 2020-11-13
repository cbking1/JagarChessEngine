using ChessEngineContracts;
using System.Collections.Generic;

namespace CommandParsing
{
    internal interface IGoArguments
    {
        public List<IMove> SearchMoves { get; }
    }
}