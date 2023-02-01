using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool InProgress { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            InProgress = true;
            Pieces = new HashSet<Piece>(); 
            CapturedPieces = new HashSet<Piece>();
            SetPieces();
        }

        public void MovePiece(Position startPosition, Position endPosition)
        {
            Piece movingPiece = Board.RemovePiece(startPosition);
            movingPiece.AddNumberOfMoves();
            Piece capturedPiece = Board.RemovePiece(endPosition);
            Board.SetPiecePosition(movingPiece, endPosition);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
        }

        public void PerformMove(Position startPosition, Position endPosition)
        {
            MovePiece(startPosition, endPosition);
            Turn++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == Color.White
                ? Color.Black
                : Color.White;
        }

        public void ValidateStartPosition(Position startPosition)
        {
            if (Board.Piece(startPosition) == null)
            {
                throw new BoardException("There is no piece in the selected position!");
            }

            if (CurrentPlayer != Board.Piece(startPosition).Color)
            {
                throw new BoardException("The chosen piece belongs to your opponent!");
            }

            if (!Board.Piece(startPosition).hasValidMoves())
            {
                throw new BoardException("There are no possible moves for the selected piece!");
            }
        }

        public void ValidateEndPosition(Position startPosition, Position endPosition)
        {
            if (!Board.Piece(startPosition).CanMoveTo(endPosition))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            return new HashSet<Piece>(CapturedPieces.Where(piece => piece.Color == color));
        }

        public HashSet<Piece> PiecesInPlayByColor(Color color)
        {
            return new HashSet<Piece>(Pieces.Where(piece => piece.Color == color && !CapturedPieces.Contains(piece)));
        }

        public void SetNewPiece(char column, int line, Piece piece)
        {
            Board.SetPiecePosition(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void SetPieces()
        {
            SetNewPiece('a', 1, new Rook(Board, Color.White));
            SetNewPiece('h', 1, new Rook(Board, Color.White));
            SetNewPiece('d', 1, new King(Board, Color.White));


            SetNewPiece('a', 8, new Rook(Board, Color.Black));
            SetNewPiece('h', 8, new Rook(Board, Color.Black));
        }
    }
}
