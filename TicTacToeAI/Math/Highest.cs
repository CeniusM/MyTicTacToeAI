namespace TicTacToeAI.MyMath
{
    class Highest
    {
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
            int index = 0;
            float value = float.MinValue;

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
    }
}