// implements
// hot fixes
// make the whole thing faser. get rid of unecesery code
// only have one hidden layer.
// this will be optimised for speed
// implements
// the ai making its own nerons
// hot fixes
// basicly, make it work plz
// implement logistic curves. learn it

namespace CS_TicTacToeAI
{
    class TicTacToeAIv4
    {
        public int fitnessScore = 0;
        private int _mutability;
        private Random _rnd = new Random();
        private float[] _input = new float[9];
        private float[,] _w1;
        private float[] _hidden_layer1 = new float[9];
        private float[,] _w2;
        private float[] _hidden_layer2 = new float[9];

        private float[,] _w3;
        private float[] _output = new float[9];
        public TicTacToeAIv4()
        {
            _mutability = _rnd.Next(4, 15);
            _w1 = NewWeights(9, 9); // needs mutability
            _w2 = NewWeights(9, 9);
            _w3 = NewWeights(9, 9);
        }

        private float[,] NewWeights(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        public TicTacToeAIv4(float[,] w1, float[,] w2, float[,] w3, int mutability)
        {
            _mutability = mutability;
            _w1 = w1;
            _w2 = w2;
            _w3 = w3;
        }

        public int GetMove()
        {
            throw new NotImplementedException("no done :D");
        }
    }
}