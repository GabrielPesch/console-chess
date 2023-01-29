namespace board
{
    internal class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position position)
        {
            return pieces[position.line, position.column];
        }

        public void setPiecePosition(Piece piece, Position position)
        {
            if (isOcuppiedPosition(position))
            {
                throw new BoardException("A piece already occupies this postion!");
            }
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }

        public bool isOcuppiedPosition(Position position) {
            validatePosition(position);
            return piece(position) != null;
        }

        public bool isValidPosition(Position position)
        {
            return !(position.line < 0 || position.line >= lines || position.column < 0 || position.column >= columns);
        }

        public void validatePosition(Position position)
        {
            if (isValidPosition(position) == false)
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
