// implements
// the ai making its own nerons
// hot fixes
// basicly, make it work plz
// implement logistic curves. learn it

namespace CS_TicTacToeAI
{
    class TicTacToeAIv3
    {
        private Random _rnd = new Random();
        private float[] _input = new float[9];
        private float[,] _w1 = new float[9, 9];
        private float[] _hidden_layer1 = new float[9];
        private float[,] _w2 = new float[9, 9];
        private float[] _hidden_layer2 = new float[9];
        private float[,] _w3 = new float[9, 9];
        private float[] _output = new float[9];
        private int _mutability = 10;
        public TicTacToeAIv3()
        {

        }
        public TicTacToeAIv3(float[,] w1, float[,] w2, float[,] w3, int mutability)
        {
            _w1 = w1;
            _w2 = w2;
            _w3 = w3;
            _mutability = mutability;
        }
        public int Getmove(int input)
        {
            //code

            return GetOutput();
        }

        private int GetOutput() // returns an index for the output arr. chooses a random if the heights calues are the same
        {
            List<int> _outputIndex = new List<int>();
            float heighsValue;
            heighsValue = _output[0];
            for (int i = 0; i < 9; i++)
            {
                if (_output[i] == heighsValue)
                {
                    _outputIndex.Add(i);
                }
                else if (_output[i] > heighsValue)
                {
                    _outputIndex = new List<int>();
                    _outputIndex.Add(i);
                    heighsValue = _output[i];
                }
            }
            return _outputIndex[_rnd.Next(0, _outputIndex.Count)];
        }

        public TicTacToeAIv3 GiveBirth()
        {
            float[,] w1 = _w1;
            float[,] w2 = _w2;
            float[,] w3 = _w3;
            int mutability = _mutability;

            

            return new TicTacToeAIv3();
        }
    }
}