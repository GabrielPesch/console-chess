using board;


namespace chess
{
    class Screen
    {

        public static void PrintMatch(ChessMatch match)
        {
            Screen.PrintBoard(match.Board);
            Console.WriteLine();

            PrintCapturedPieces(match);

            Console.WriteLine();

            Console.WriteLine("Turn: " + match.Turn);
            Console.WriteLine("Current player: " + match.CurrentPlayer);
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            ConsoleColor defaultForeGroundColor = Console.ForegroundColor;

            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");

            PrintHashSet(match.CapturedPiecesByColor(Color.White));
            Console.WriteLine();

            Console.Write("Black: ");

            Console.ForegroundColor = ConsoleColor.Green;
            PrintHashSet(match.CapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = defaultForeGroundColor;
            Console.WriteLine();
        }

        public static void PrintHashSet(HashSet<Piece> hashSet)
        {
            Console.Write("[");
            foreach (Piece piece in hashSet)
            {
                Console.Write(piece + ", ");
            }
            Console.Write("]");
        }

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
            string moveInput = Console.ReadLine().ToLower();

            if (moveInput.Length != 2)
            {
                throw new BoardException("Invalid position. It should be a letter followed by a number.");
            }

            char column = moveInput[0];

            if (column < 'a' || column > 'h')
            {
                throw new BoardException("Invalid position. Column should be between 'a' and 'h'.");
            }

            int line = int.Parse(moveInput[1] + "");

            if (line < 1 || line > 8)
            {
                throw new BoardException("Invalid position. Line should be between 1 and 8.");
            }

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
