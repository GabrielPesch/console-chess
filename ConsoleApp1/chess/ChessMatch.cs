using board;
using System;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool isMatchOver { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isMatchOver = false;
            createBoard();
        }

        public void movePiece(Position startPosition, Position endPosition)
        {
            Piece movingPiece = board.removePiece(startPosition);
            movingPiece.addNumberOfMoves();
            Piece capturedPiece = board.removePiece(endPosition);
            board.setPiecePosition(movingPiece, endPosition);
        }

        private void createBoard()
        {
            board.setPiecePosition(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
        }
    }
}
