using board;
using System;

namespace chess
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int currentLine = 0; currentLine < board.lines; currentLine++)
            {
                Console.Write(8 - currentLine + " ");
                for (int currentColumn = 0; currentColumn < board.columns; currentColumn++)
                {
                    if (board.piece(currentLine, currentColumn) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(board.piece(currentLine, currentColumn));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece)
        {
            if (piece.color == Color.White)
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
