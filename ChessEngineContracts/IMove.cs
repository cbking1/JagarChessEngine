namespace ChessEngineContracts
{
    public interface IMove
    {
        ISquare StartSquare { get; }

        ISquare EndSquare { get; }
        
        IPiece PromotionPeice { get; }
    }
}