using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovesMatrix = new bool[Board.Lines, Board.Columns];

            Position currentPosition = new Position(0, 0);

            // nw
            currentPosition.SetValues(Position.Line - 1, Position.Column -1);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Line--;
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

            // ne
            currentPosition.SetValues(Position.Line - 1, Position.Column +1);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Line--;
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

            // sw
            currentPosition.SetValues(Position.Line +1, Position.Column - 1);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Line++;
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

            // se
            currentPosition.SetValues(Position.Line +1, Position.Column  +1);
            while (Board.IsValidPosition(currentPosition))
            {
                if (Board.Piece(currentPosition) == null)
                {
                    availableMovesMatrix[currentPosition.Line, currentPosition.Column] = true;
                    currentPosition.Line++;
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

            return availableMovesMatrix;
        }
    }
}
