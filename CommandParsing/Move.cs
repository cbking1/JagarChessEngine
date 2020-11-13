using ChessEngineContracts;
using ChessMove;

namespace CommandParsing
{
    internal class Move : IMove
    {
        public ISquare StartSquare {get; private set;}
        public ISquare EndSquare {get; private set;}
        public IPiece PromotionPeice {get; private set;}

        public Move(ISquare startSquare, ISquare endSquare, IPiece promotionPiece)
        {
            StartSquare = startSquare;
            EndSquare = endSquare;
            PromotionPeice = promotionPiece;
        }
    }
}