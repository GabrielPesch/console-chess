using board;
using System.Runtime.ConstrainedExecution;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color): base(board, color) { }

        public override string ToString()
        {
            return "R";
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
            while (Board.IsValidPosition(currentPosition) && CanMove(currentPosition)) {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                if (Board.Piece(currentPosition) != null && Board.Piece(currentPosition).Color != Color ) {
                    break;
                }
                currentPosition.Line--;
            }

            // s
            currentPosition.SetValues(Position.Line + 1, Position.Column);
            while (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                if (Board.Piece(currentPosition) != null && Board.Piece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Line++;
            }

            // e
            currentPosition.SetValues(Position.Line, Position.Column + 1);
            while (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                if (Board.Piece(currentPosition) != null && Board.Piece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Column++;
            }

            // w
            currentPosition.SetValues(Position.Line, Position.Column - 1);
            while (Board.IsValidPosition(currentPosition) && CanMove(currentPosition))
            {
                availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                if (Board.Piece(currentPosition) != null && Board.Piece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Column--;
            }

            return availableMovesMatrix;

        }
    }
}
