namespace TicTacToeAI.MyMath
{
    class Highest
    {
        private static Random rnd = new Random();
        public static int GetHighestValue(int[] arr) // returns the index for the heighst value
        {
            int index = 0;
            int value = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > value)
                {
                    index = i;
                    value = arr[i];
                }
            }

            return index;
        }
        public static int GetHighestValue(float[] arr) // returns the index for the heighst value
        {
            List<int> index = new List<int>();
            float value = float.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > value)
                {
                    index = new List<int>();
                    index.Add(i);
                    value = arr[i];
                }
                else if (arr[i] == value)
                {
                    index.Add(i);
                }
            }

            return index[rnd.Next(0, index.Count)];
        }
    }
}