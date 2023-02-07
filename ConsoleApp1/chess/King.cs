using board;

namespace chess
{
    class King : Piece
    {

        private readonly ChessMatch Match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }


        public override string ToString()
        {
            return "K";
        }

        public bool IsRookValid(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.NumberOfMoves == 0;
        }

        private bool CanMove(Position piecePosition)
        {
            Piece piece = Board.Piece(piecePosition);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovesMatrix = new bool[Board.Lines, Board.Columns];

            foreach (Position position in GetAdjacentPositions())
            {
                if (Board.IsValidPosition(position) && CanMove(position))
                {
                    availableMovesMatrix[position.Line, position.Column] = true;
                }
            }

            if (NumberOfMoves == 0 && !Match.Check)
            {
                CheckForShortCastle(availableMovesMatrix);
                CheckForLongCastle(availableMovesMatrix);
            }
            return availableMovesMatrix;
        }

        private IEnumerable<Position> GetAdjacentPositions()
        {
            for (int line = Position.Line - 1; line <= Position.Line + 1; line++)
            {
                for (int column = Position.Column - 1; column <= Position.Column + 1; column++)
                {
                    yield return new Position(line, column);
                }
            }
        }
        private void CheckForShortCastle(bool[,] availableMovesMatrix)
        {
            Position shortRookPosition = new(Position.Line, Position.Column + 3);

            if (IsRookValid(shortRookPosition))
            {
                Position firstSidePosition = new(Position.Line, Position.Column + 1);
                Position secondSidePosition = new(Position.Line, Position.Column + 2);

                if (Board.Piece(firstSidePosition) == null && Board.Piece(secondSidePosition) == null)
                {
                    availableMovesMatrix[Position.Line, Position.Column + 2] = true;
                }

            }
        }
        private void CheckForLongCastle(bool[,] availableMovesMatrix)
        {
            Position longRookPosition = new(Position.Line, Position.Column - 4);

            if (IsRookValid(longRookPosition))
            {
                Position firstSidePosition = new(Position.Line, Position.Column - 1);
                Position secondSidePosition = new(Position.Line, Position.Column - 2);
                Position thirdSidePosition = new(Position.Line, Position.Column - 3);


                if (Board.Piece(firstSidePosition) == null && Board.Piece(secondSidePosition) == null && Board.Piece(thirdSidePosition) == null)
                {
                    availableMovesMatrix[Position.Line, Position.Column - 2] = true;
                }

            }
        }

    }
}