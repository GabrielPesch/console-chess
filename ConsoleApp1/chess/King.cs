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

            Position currentPosition = new Position(0, 0);

            // n
            currentPosition.SetValues(Position.Line - 1, Position.Column);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // ne
            currentPosition.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // e
            currentPosition.SetValues(Position.Line, Position.Column + 1);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // se
            currentPosition.SetValues(Position.Line + +1, Position.Column + 1);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // s
            currentPosition.SetValues(Position.Line - 1, Position.Column);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // sw
            currentPosition.SetValues(Position.Line + 1, Position.Column);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // w
            currentPosition.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            // nw
            currentPosition.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.IsValidPosition(currentPosition) && CanMove(currentPosition)) {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
            }

            return availableMovesMatrix;

        }
    }
}
