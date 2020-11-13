using ChessEngineContracts;

namespace ChessMove
{
    public class Square
    {
        private ChessFile _startFile;
        private ChessRow _startRow;

        public Square(ChessFile startFile, ChessRow startRow)
        {
            _startFile = startFile;
            _startRow = startRow;
        }
    }
}