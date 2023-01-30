using board;

namespace chess
{
    internal class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
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
