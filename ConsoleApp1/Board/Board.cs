namespace board
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.Line, position.Column];
        }

        public bool IsValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            };
            return true;
        }

        public bool HasPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void SetPieceInPosition(Piece piece, Position position)
        {
            if (IsOcuppiedPosition(position))
            {
                throw new BoardException("A piece already occupies this postion!");
            }
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece removedPiece = Piece(position);
            removedPiece.Position = null;
            pieces[position.Line, position.Column] = null;
            return removedPiece;
        }

        public bool IsOcuppiedPosition(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void ValidatePosition(Position position)
        {
            if (!IsValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
