using board;

namespace chess
{
    internal class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            bool invalidColumn = column < 'a' || column > 'h';

            if (invalidColumn)
            {
                throw new BoardException("Invalid column value.");
            }

            bool invalidLine = line < 1 || line > 8;

            if (invalidLine)
            {
                throw new BoardException("Invalid line value.");
            }

            Column = column;
            Line = line;
        }

        public Position ToPosition()
        {
            int normalizedLine = 8 - Line;
            int normalizedColumn = Column - 'a';

            return new Position(normalizedLine, normalizedColumn);
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
