using board;
using System;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool InProgress { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            InProgress = true;
            SetPieces();
        }

        public void MovePiece(Position startPosition, Position endPosition)
        {
            Piece movingPiece = Board.RemovePiece(startPosition);
            movingPiece.AddNumberOfMoves();
            Piece capturedPiece = Board.RemovePiece(endPosition);
            Board.SetPiecePosition(movingPiece, endPosition);
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
            if(Board.Piece(startPosition) == null)
            {
                throw new BoardException("There is no piece in the selected position!");
            }

            if(CurrentPlayer != Board.Piece(startPosition).Color)
            {
                throw new BoardException("The chosen piece belongs to your opponent!");
            }

            if(!Board.Piece(startPosition).hasValidMoves())
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

        private void SetPieces()
        {
            Board.SetPiecePosition(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.SetPiecePosition(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.SetPiecePosition(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.SetPiecePosition(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.SetPiecePosition(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
