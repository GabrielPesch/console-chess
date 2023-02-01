using board;

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

             Position north = new Position(Position.Line - 1, Position.Column);
            currentPosition.SetValues(north);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Line--;
                }
                else
                {
                    if (Board.Piece(currentPosition).Color != Color)
                    {
                        availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    }
                    break;
                }
            }

            // s
            currentPosition.SetValues(Position.Line + 1, Position.Column);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Line++;
                }
                else
                {
                    if (Board.Piece(currentPosition).Color != Color)
                    {
                        availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    }
                    break;
                }
            }

            // e
            currentPosition.SetValues(Position.Line, Position.Column + 1);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Column++;
                }
                else
                {
                    if (Board.Piece(currentPosition).Color != Color)
                    {
                        availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    }
                    break;
                }
            }

            // w
            currentPosition.SetValues(Position.Line, Position.Column - 1);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Column--;
                }
                else
                {
                    if (Board.Piece(currentPosition).Color != Color)
                    {
                        availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    }
                    break;
                }
            }

            return availableMovesMatrix;
        }
    }
}
