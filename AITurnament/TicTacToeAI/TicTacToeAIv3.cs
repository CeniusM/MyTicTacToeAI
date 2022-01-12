// implements
// the ai making its own nerons
// hot fixes
// basicly, make it work plz
// implement logistic curves. learn it

namespace CS_TicTacToeAI
{
    class TicTacToeAIv3
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
        public TicTacToeAIv3()
        {
            _mutability = _rnd.Next(4, 15);
            _w1 = NewWeights(9, 9); // needs mutability
            _w2 = NewWeights(9, 9);
            _w3 = NewWeights(9, 9);
        }

        public TicTacToeAIv3(float[,] w1, float[,] w2, float[,] w3, int mutability)
        {
            _mutability = mutability;
            _w1 = w1;
            _w2 = w2;
            _w3 = w3;
        }
        public int GetMove(int[] input, int playerNum)
        {
            for (int i = 0; i < 9; i++)
            {
                if (input[i] == playerNum)
                    _input[i] = 1;
                else if (input[i] == 0)
                    _input[i] = 0;
                else
                    _input[i] = -1;


            }
            return RunSim(_input);
        }
        private int RunSim(float[] input)
        {
            //code
            _hidden_layer1 = MyMatrixMult(input, _w1);
            _hidden_layer2 = MyMatrixMult(_hidden_layer1, _w2);
            _output = MyMatrixMult(_hidden_layer2, _w3);

            return GetOutput(input);
        }

        private float[] MyMatrixMult(float[] input, float[,] w)
        {
            float[] newNeruons = new float[w.GetLength(0)];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    newNeruons[i] += input[j] * w[i,j];
                }
                newNeruons[i] = CS_Math.Logistic_Curve_Math.GetLogisticCurve(newNeruons[i]);
            }

            return newNeruons;
        }

        private int GetOutput(float[] input) // returns an index for the output arr. chooses a random if the heights calues are the same
        {
            List<int> _outputIndex = new List<int>();
            float highestValue = -10;
            for (int i = 0; i < 9; i++)
            {
                if (input[i] != 0) continue; // checks if the move is even valid
                if (_output[i] == highestValue)
                {
                    _outputIndex.Add(i);
                }
                else if (_output[i] > highestValue)
                {
                    _outputIndex = new List<int>();
                    _outputIndex.Add(i);
                    highestValue = _output[i];
                }
            }
            return _outputIndex[_rnd.Next(0, _outputIndex.Count)];
        }

        public TicTacToeAIv3 GiveBirth()
        {
            float[,] w1 = MutateWeight(_w1);
            float[,] w2 = MutateWeight(_w2);
            float[,] w3 = MutateWeight(_w3);
            int mutability = _mutability;

            if (_rnd.Next(0, 2) == 1)
                mutability++;
            else
                mutability--;

            return new TicTacToeAIv3(w1, w2, w3, mutability);
        }

        internal TicTacToeAIv3 GetClone()
        {
            return new TicTacToeAIv3(_w1, _w2, _w3, _mutability);
        }

        private float[,] MutateWeight(float[,] w)
        {
            float changeValue = 0;
            for (int i = 0; i < _mutability; i++)
            {
                changeValue = _rnd.NextSingle();
                if (_rnd.Next(0, 2) == 1)
                    changeValue *= -1;

                w[_rnd.Next(0, w.GetLength(0)), _rnd.Next(0, w.GetLength(1))] += changeValue;
            }

            return w;
        }

        private float[,] NewWeights(int v1, int v2)
        {
            float[,] NewWeights = new float[v1, v2];

            for (int i = 0; i < _mutability; i++)
            {
                NewWeights[_rnd.Next(0, v1), _rnd.Next(0, v2)] = _rnd.NextSingle();
            }

            return NewWeights;
        }
    }
}