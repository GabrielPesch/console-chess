using board;
using chess;
using System;

namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.setPiece(new Rook(board, Color.Black), new Position(0, 0));
            board.setPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.setPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.printBoard(board);

            Console.ReadLine();
        }
    }
}