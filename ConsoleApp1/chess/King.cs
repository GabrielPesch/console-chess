using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position piecePosition)
        {
            Piece piece = Board.Piece(piecePosition);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovesMatrix = new bool[Board.Lines, Board.Columns];

            for (int line = Position.Line - 1; line <= Position.Line + 1; line++)
            {
                for (int column = Position.Column - 1; column <= Position.Column + 1; column++)
                {
                    Position currentPosition = new Position(line, column);
                    if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
                    {
                        availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    }
                }
            }

            return availableMovesMatrix;

        }
    }
}
