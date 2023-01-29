using board;

namespace chess
{
    internal class ChessPosition
    {
        public char column { get; set; }
        public int line { get; set; }

        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public override string ToString()
        {
            return "" + column + line;
        }

        public Position toPosition()
        {
            int normalizedLine = 8 - line;
            int normalizedColumn = column - 'a';
            return new Position(normalizedLine, normalizedColumn);
        }
    }
}
