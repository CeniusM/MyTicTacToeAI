using CS_Math;

namespace CS_TicTacToeAI
{
    class TicTacToeAIv1
    {
        public float fitnessScore = 0;
        private int _iNodes;
        private int _oNodes;
        private int _hNodes1;
        private float[] _hNodes1Values = new float[0];
        // private int batch_size; // for now
        private float[,] _w1; // weight 1 for the nerons
        private float[,] _w2; // weight 2
        public TicTacToeAIv1(int iNodes, int oNodes, int hNodes1)
        {
            _iNodes = iNodes;
            _oNodes = oNodes;
            _hNodes1 = hNodes1;
            // batch_size = 10; // idk what this is

            _w1 = MyRandom.RandomInputs2D(_iNodes, _hNodes1);
            _w2 = MyRandom.RandomInputs2D(_iNodes, _hNodes1);
        }

        public TicTacToeAIv1(int iNodes, int oNodes, int hNodes1, float[,] w1, float[,] w2)
        {
            _iNodes = iNodes;
            _oNodes = oNodes;
            _hNodes1 = hNodes1;
            _w1 = w1;
            _w2 = w2;
        }

        public int[] GetTTTMove(int[] iData) // input tictactoe data in an 1d array, and get the ai's move with 2 cords
        {
            // float[] layer1 = myMatrixMul(iData, _w1);

            // layer1 = ReLU.maximum(layer1, 0);

            // float[] layer2 = myMatrixMul(layer1, _w2);

            // layer2 = ReLU.maximum(layer2, 0);

            return new int[0];
        }

        public TicTacToeAIv1 GiveBirth()
        {
            // change the neruon weights a bid


            return new TicTacToeAIv1(_iNodes, _oNodes, _hNodes1);
        }
    }
}
/*
i = input
o = output
h = hidden
*/