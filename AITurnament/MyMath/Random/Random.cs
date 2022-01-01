namespace CS_Math
{
    class MyRandom
    {
        private static Random rnd = new Random();
        public static float[,] RandomInputs2D(int batchSize, int inputNodes)
        {
            float[,] radnomSet = new float[batchSize, inputNodes];
            for (int i = 0; i < batchSize; i++)
            {
                for (int j = 0; j < inputNodes; j++)
                {
                    radnomSet[i,j] = GetRandomFloat();
                }
            }
            return radnomSet;
        }
        public static float GetRandomFloat() // int min, int max
        {
            float val = (float)rnd.NextDouble();

            if (rnd.Next(0, 2) == 1)
                val *= -1;

            // if (rnd.Next(0, 2) == 1)
            // {
            //     val += (float)rnd.NextDouble();
            //     val += (float)rnd.NextDouble();
            // }
            // else
            // {
            //     val -= (float)rnd.NextDouble();
            //     val -= (float)rnd.NextDouble();
            // }

            return val;
        }
    }
}