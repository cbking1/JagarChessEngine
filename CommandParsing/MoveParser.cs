using ChessEngineContracts;
using JagarEngineContracts;
using System;
using System.Collections.Generic;
using ChessMove;
using System.Text;

namespace CommandParsing
{
    class MoveParser : IMoveParser
    {
        public IMove LastParsedMove { get; private set; }

        public bool IsMove(string move)
        {
            try
            {
                LastParsedMove = ParseMove(move);
                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }

        }

        private static IMove ParseMove(string move)
        {
            if (move.Length < 4 || move.Length > 5)
            {
                throw new ArgumentException("The move {0} cannot be parsed as a chess move");
            }
            ChessFile startFile = (ChessFile)Enum.Parse(typeof(ChessFile), move[0].ToString());
            ChessRow startRow = (ChessRow)Enum.Parse(typeof(ChessRow), move[1].ToString());

            ChessFile endFile = (ChessFile)Enum.Parse(typeof(ChessFile), move[2].ToString());
            ChessRow endRow = (ChessRow)Enum.Parse(typeof(ChessRow), move[3].ToString());

            ChessPiece promotionPiece;
            if (move.Length == 5)
            {
                promotionPiece = (ChessPiece)Enum.Parse(typeof(ChessPiece), move[5].ToString());
            }
            else
            {
                promotionPiece = ChessPiece.noPromotion;
            }

            Square startSquare = new Square(startFile, startRow);
            Square endSquare = new Square(endFile, endRow);

            return new Move(startSquare, endSquare, promotionPiece);
        }

        public IEnumerable<IMove> ParseMoves(IEnumerable<string> moveStrings)
        {
            throw new NotImplementedException();
        }
    }
}
