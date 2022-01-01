namespace CS_TicTacToeAI
{
    class TicTacToeAIv1
    {
        private int _iNodes;
        private int _oNodes;
        private int _hNodes;
        private int batch_size;
        // public int[,] Input = new int[3, 3];
        public TicTacToeAIv1(int iNodes, int oNodes, int hNodes)
        {
            _iNodes = iNodes;
            _oNodes = oNodes;
            _hNodes = hNodes;
            batch_size = 10; // idk what this is
        }
        public TicTacToeAIv1 GiveBirth()
        {
            // change the neruons a bid
            return new TicTacToeAIv1(_iNodes, _oNodes, _hNodes);
        }
    }
}
/*
i = input
o = output
h = hidden
*/