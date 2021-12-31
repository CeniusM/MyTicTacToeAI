namespace CS_TicTacToeAI
{
    class TicTacToeAI
    {
        private int _iNodes;
        private int _oNodes;
        private int _hNodes;
        private int batch_size;
        // public int[,] Input = new int[3, 3];
        public TicTacToeAI(int iNodes, int oNodes, int hNodes)
        {
            _iNodes = iNodes;
            _oNodes = oNodes;
            _hNodes = hNodes;
            batch_size = 5; // idk what this is
        }
        public TicTacToeAI GiveBirth()
        {
            // change the neruons a bid
            return new TicTacToeAI(_iNodes, _oNodes, _hNodes);
        }
    }
}
/*
i = input
o = output
h = hidden
*/