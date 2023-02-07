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

            if (!match.IsOver)
            {
                Console.WriteLine("Current player: " + match.CurrentPlayer);
                if(match.Check)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.Write("XEQUEMATE!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
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
            for (int row = 0; row < board.Lines; row++)
            {
                Console.Write(8 - row + " ");
                for (int col = 0; col < board.Columns; col++)
                {
                    PrintPiece(board.Piece(row, col));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] availableMoves)
        {

            ConsoleColor defaultBackground = Console.BackgroundColor;
            ConsoleColor availableMoveBackground = ConsoleColor.DarkGray;

            for (int row = 0; row < board.Lines; row++)
            {
                Console.Write(8 - row + " ");
                for (int col = 0; col < board.Columns; col++)
                {
                    if (availableMoves[row, col])
                    {
                        Console.BackgroundColor = availableMoveBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = defaultBackground;
                    }
                    PrintPiece(board.Piece(row, col));
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

            int line;
            bool isParsed = int.TryParse(moveInput[1].ToString(), out line);
            if (!isParsed || line < 1 || line > 8)
            {
                throw new BoardException("Invalid position. Line should be a number between 1 and 8.");
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
