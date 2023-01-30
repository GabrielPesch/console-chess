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
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine("");
                    Console.Write("Choose a piece to move: ");
                    Position startPosition = Screen.ReadChessPosition().ToPosition();

                    bool[,] availablePossitions = match.Board.Piece(startPosition).AvailableMoves();

                    Console.Clear();

                    Screen.PrintBoard(match.Board, availablePossitions);

                    Console.WriteLine();
                    Console.Write("Where do you want to move this piece? ");
                    Position endPosition = Screen.ReadChessPosition().ToPosition();

                    match.MovePiece(startPosition, endPosition);

                }
            }
            catch (BoardException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine();
        }
    }
}