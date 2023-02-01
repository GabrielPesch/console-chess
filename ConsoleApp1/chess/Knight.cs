using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "N";
        }

        private bool CanMove(Position piecePosition)
        {
            Piece piece = Board.Piece(piecePosition);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovesMatrix = new bool[Board.Lines, Board.Columns];

            int[] lineMovement = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] columnMovement = { -1, -2, -2, -1, 1, 2, 2, 1 };

            for (int index = 0; index < 8; index++)
            {
                int line = Position.Line + lineMovement[index];
                int column = Position.Column + columnMovement[index];

                Position currentPosition = new (line, column);
                if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                }
            }

            return availableMovesMatrix;

        }
    }
}
