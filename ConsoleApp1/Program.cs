using board;
using chess;
using System;

namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.setPiecePosition(new Rook(board, Color.Black), new Position(0, 0));
                board.setPiecePosition(new Rook(board, Color.Black), new Position(1, 3));
                board.setPiecePosition(new King(board, Color.Black), new Position(2, 4));


                board.setPiecePosition(new Rook(board, Color.White), new Position(3,2));
                board.setPiecePosition(new Rook(board, Color.White), new Position(4, 6));
                board.setPiecePosition(new King(board, Color.White), new Position(5, 7));
                Screen.printBoard(board);

                Console.ReadLine();
            }
            catch (BoardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}