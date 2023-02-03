using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool HasEnemy(Position piecePosition)
        {
            Piece piece = Board.Piece(piecePosition);
            return piece != null && piece.Color != Color;
        }

        private bool IsEmpty(Position position)
        {
            return Board.Piece(position) == null;
        }

        private bool CanMove(Position piecePosition)
        {
            return Board.IsValidPosition(piecePosition) && IsEmpty(piecePosition);
        }

        private bool CanCapture(Position piecePosition)
        {
            return Board.IsValidPosition(piecePosition) && HasEnemy(piecePosition);
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovesMatrix = new bool[Board.Lines, Board.Columns];

            int direction = Color == Color.White ? -1 : 1;
            Position currentPosition = new Position(Position.Line + direction, Position.Column);

            if (CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;

                currentPosition.SetValues(Position.Line + 2 * direction, Position.Column);
                if (NumberOfMoves == 0 && CanMove(currentPosition))
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                }
            }

            currentPosition.SetValues(Position.Line + direction, Position.Column - 1);
            if (CanCapture(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            currentPosition.SetValues(Position.Line + direction, Position.Column + 1);
            if (CanCapture(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            return availableMovesMatrix;

        }
    }
}
