using ChessEngineContracts;
using System.Collections.Generic;

namespace JagarEngineContracts
{
    public interface IMoveParser
    {
        IEnumerable<IMove> ParseMoves(IEnumerable<string> moveStrings);
    }
}