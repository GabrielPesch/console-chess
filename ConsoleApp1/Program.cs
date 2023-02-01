using board;
using chess;


namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new();


                while (!match.IsOver)
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

                        match.PerformMovement(startPosition, endPosition);
                    }
                    catch (BoardException exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }
    }
}
