using board;
using System;

namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position;
            position = new Position(3, 4);

            Console.WriteLine("Test Position: " + position);

            Console.ReadLine();
        }
    }
}