using board;
using chess;
using System;

namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos = new ChessPosition('c', 7);

            Console.WriteLine(pos.toPosition());

        }
    }
}