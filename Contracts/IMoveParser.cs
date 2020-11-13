using ChessEngineContracts;
using System.Collections.Generic;

namespace JagarEngineContracts
{
    public interface IMoveParser
    {
        IMove LastParsedMove { get; }

        IEnumerable<IMove> ParseMoves(IEnumerable<string> moveStrings);
        bool IsMove(string move);
    }
}