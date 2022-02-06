namespace TicTacToeAI
{
    class AIBrain
    {
        private Random rnd = new Random();
        public readonly int hLayers = 2;
        public readonly int range = 1; // what the values of the weights can be between (range*-1) to range
        public float[,] w1;
        public float[] h1 = new float[9];
        public float[,] w2;
        public float[] h2 = new float[9];
        public float[,] w3;
        public AIBrain()
        {
            w1 = new float[9, 9];
            w2 = new float[9, 9];
            w3 = new float[9, 9];
            Randomize(5);
        }
        public AIBrain(float[,] W1, float[,] W2, float[,] W3)
        {
            w1 = W1;
            w2 = W2;
            w3 = W3;
        }
        public AIBrain(AIBrain brain)
        {
            w1 = brain.w1;
            w2 = brain.w2;
            w3 = brain.w3;
        }

        public void Mutate(int mutability, int chance) // mutate weights
        {
            for (int i = 0; i < mutability; i++)
            {
                if (rnd.Next(0, chance + 1) != 0) continue;

                int x = rnd.Next(0, 9);
                int y = rnd.Next(0, 9);
                int weight = rnd.Next(0, 3);
                if (weight == 0)
                    w1[x, y] = MutateWeight(w1[x, y]);
                else if (weight == 1)
                    w2[x, y] = MutateWeight(w2[x, y]);
                else
                    w3[x, y] = MutateWeight(w3[x, y]);
            }
        }

        public float MutateWeight(float wValue)
        {
            float value = rnd.NextSingle() / 2;
            if (rnd.Next(0, 2) == 1)
                value *= -1;

            wValue += value;

            if (wValue > 1) wValue *= 0.9f;
            if (wValue > -1) wValue *= 0.9f;

            return wValue;
        }

        public float[] RunSim(float[] input) // needs to be optimised, alooot, maby use the grapichs card ;) with the multi kernel stuff
        {
            float[] output = new float[9];

            for (int i = 0; i < 9; i++) // h1
            {
                for (int j = 0; j < 9; j++)
                {
                    h1[i] += input[j] * w1[i, j];
                }
                h1[i] = GetLogisticCurve(h1[i]);
            }

            for (int i = 0; i < 9; i++) // h2
            {
                for (int j = 0; j < 9; j++)
                {
                    h2[i] += h1[j] * w2[i, j];
                }
                h2[i] = GetLogisticCurve(h2[i]);
            }

            for (int i = 0; i < 9; i++) // output
            {
                for (int j = 0; j < 9; j++)
                {
                    output[i] += h2[j] * w3[i, j];
                }
                output[i] = GetLogisticCurve(output[i]);
            }

            return output;
        }

        public void Randomize(int chance)
        {
            w1 = GetRandomWeights(chance);
            w2 = GetRandomWeights(chance);
            w3 = GetRandomWeights(chance);
        }

        public float[,] GetRandomWeights(int chance)
        {
            float[,] w = new float[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (rnd.Next(0, chance + 1) != 0) continue;

                    float value = rnd.NextSingle();
                    if (rnd.Next(0, 2) == 1)
                        value *= -1;
                    w[i, j] = value;
                }
            }

            return w;
        }

        public static float GetLogisticCurve(float X) // make a math folder for it self
        {
            // const double E = 2.7182818284590451; // make float
            const int E = 3; // close enough... i hope

            float L = 2; // range, so like from 0-2
            float K = 1; // how fast it goes to 1 or -1

            float power = (float)Math.Pow(E, -K * (X)); // use float

            L /= (1 + power);
            L--;

            return (L - 1); // the minus makes it go from (-1) to 1
        }
    }
}