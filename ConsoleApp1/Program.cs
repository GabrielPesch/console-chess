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


                while (match.InProgress)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Choose a piece to move: ");
                        Position startPosition = Screen.ReadChessPosition().ToPosition();
                        match.ValidateStartPosition(startPosition);

                        bool[,] availablePossitions = match.Board.Piece(startPosition).AvailableMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, availablePossitions);

                        Console.WriteLine();
                        Console.Write("Where do you want to move this piece? ");
                        Position endPosition = Screen.ReadChessPosition().ToPosition();
                        match.ValidateEndPosition(startPosition, endPosition);

                        match.PerformMove(startPosition, endPosition);
                    }
                    catch (BoardException exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch (BoardException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
            Console.ReadLine();

        }
    }
}