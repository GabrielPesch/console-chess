namespace board
{
    class Piece
    {
        public Color color { get; protected set; }
        public Board board { get; protected set; }
        public Position position { get; set; }
        public int numberOfMoves { get; protected set; }


        public Piece(Board board, Color color)
        {
            this.color = color;
            this.board = board;
            this.position = null;
            this.numberOfMoves = 0;

        }

        public void addNumberOfMoves()
        {
            numberOfMoves++;
        }
    }
}
