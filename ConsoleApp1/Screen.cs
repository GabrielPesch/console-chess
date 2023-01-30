using board;
using System;

namespace chess
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int currentLine = 0; currentLine < board.Lines; currentLine++)
            {
                Console.Write(8 - currentLine + " ");
                for (int currentColumn = 0; currentColumn < board.Columns; currentColumn++)
                {
                    PrintPiece(board.Piece(currentLine, currentColumn));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] availableMoves)
        {

            ConsoleColor defaultBackground = Console.BackgroundColor;
            ConsoleColor availableMoveBackground = ConsoleColor.DarkGray;

            for (int currentLine = 0; currentLine < board.Lines; currentLine++)
            {
                Console.Write(8 - currentLine + " ");
                for (int currentColumn = 0; currentColumn < board.Columns; currentColumn++)
                {
                    if (availableMoves[currentLine, currentColumn])
                    {
                        Console.BackgroundColor = availableMoveBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackground;
                    }
                    PrintPiece(board.Piece(currentLine, currentColumn));
                    Console.BackgroundColor = defaultBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = defaultBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string moveInput = Console.ReadLine();
            char column = moveInput[0];
            int line = int.Parse(moveInput[1] + "");

            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
