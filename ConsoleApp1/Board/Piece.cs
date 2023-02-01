namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public Board Board { get; protected set; }


        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfMoves = 0;
        }

        public void AddNumberOfMoves()
        {
            NumberOfMoves++;
        }

        public void DecreaseNumberOfMoves()
        {
            NumberOfMoves--;
        }

        public bool hasValidMoves()
        {
            bool[,] AvailablemMovesMatrix = AvailableMoves();
            for (int row = 0; row < Board.Lines; row++)
            {
                for (int col = 0; col < Board.Columns; col++)
                {
                    if (AvailablemMovesMatrix[row, col])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return AvailableMoves()[position.Line, position.Column];
        }

        public abstract bool[,] AvailableMoves();
    }
}
