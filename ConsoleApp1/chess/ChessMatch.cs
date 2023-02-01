using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool IsOver { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            IsOver = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            SetPieces();
        }

        public Piece MakeMove(Position startPosition, Position endPosition)
        {
            Piece movingPiece = Board.RemovePiece(startPosition);
            movingPiece.AddNumberOfMoves();
            Piece capturedPiece = Board.RemovePiece(endPosition);
            Board.SetPieceInPosition(movingPiece, endPosition);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMovement(Position startPosition, Position endPosition, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(endPosition);
            piece.DecreaseNumberOfMoves();

            if (capturedPiece != null)
            {
                Board.SetPieceInPosition(capturedPiece, endPosition);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.SetPieceInPosition(piece, startPosition);
        }

        public void PerformMovement(Position startPosition, Position endPosition)
        {
            Piece capturedPiece = MakeMove(startPosition, endPosition);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(startPosition, endPosition, capturedPiece);
                throw new BoardException("Illegal move: Putting yourself in check is not allowed. Please choose another move.");
            }

            Check = (IsInCheck(EnemyPlayer(CurrentPlayer)));

            if (IsCheckMate(EnemyPlayer(CurrentPlayer)))
            {
                IsOver = true;
                return;
            }
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
                throw new BoardException("Invalid endPosition position!");
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

        private static Color EnemyPlayer(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in PiecesInPlayByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = GetKing(color);

            if (king == null)
            {
                throw new BoardException("There is no " + color + " king on the board");
            }

            foreach (Piece piece in PiecesInPlayByColor(EnemyPlayer(color)))
            {
                bool[,] moves = piece.AvailableMoves();
                if (moves[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanEscapeCheck(Piece piece, bool[,] movesMatrix, Color color)
        {
            for (int row = 0; row < Board.Lines; row++)
            {
                for (int col = 0; col < Board.Columns; col++)
                {
                    if (movesMatrix[row, col])
                    {
                        Position startPosition = piece.Position;
                        Position endPosition = new(row, col);
                        Piece capturedPiece = MakeMove(startPosition, endPosition);
                        bool isChecked = IsInCheck(color);
                        UndoMovement(startPosition, endPosition, capturedPiece);

                        if (!isChecked)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsCheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in PiecesInPlayByColor(color))
            {
                bool[,] movesMatrix = piece.AvailableMoves();
                if (CanEscapeCheck(piece, movesMatrix, color))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetNewPiece(char column, int line, Piece piece)
        {
            Board.SetPieceInPosition(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void SetPieces()
        {
            SetNewPiece('a', 1, new Rook(Board, Color.White));
            SetNewPiece('g', 1, new Rook(Board, Color.White));
            SetNewPiece('g', 2, new Rook(Board, Color.White));
            SetNewPiece('d', 1, new King(Board, Color.White));



            SetNewPiece('h', 8, new King(Board, Color.Black));

        }
    }
}

