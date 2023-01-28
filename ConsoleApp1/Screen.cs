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
                for (int currentColumn = 0; currentColumn < board.columns; currentColumn++)
                {
                    if (board.piece(currentLine, currentColumn) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(currentLine, currentColumn) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
