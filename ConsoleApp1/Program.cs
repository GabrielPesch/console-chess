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
                ChessMatch match = new ChessMatch();

                while (match.isMatchOver == false)
                {
                    Console.Clear();
                    Screen.printBoard(match.board);
                    Console.WriteLine("");

                    Console.Write("Choose a piece to move: ");
                    Position startPosition = Screen.readChessPosition().toPosition();

                    Console.Write("Where do you want to move this piece? ");
                    Position endPosition = Screen.readChessPosition().toPosition();

                    match.movePiece(startPosition, endPosition);

                }
            }
            catch (BoardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}