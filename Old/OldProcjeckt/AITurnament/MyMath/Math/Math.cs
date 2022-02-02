namespace CS_Math
{
    class MyMath
    {
        public static float[] GetFloatArr(int[] input)
        {
            float[] fInput = new float[input.GetLength(0)];
            for (int i = 0; i < input.GetLength(0); ++i)
            {
                fInput[i] = (float)input[i];
            }
            return fInput;
        }

        /// <summary>
        /// This returns the index of the heights value
        /// </summary>
        public static int GetHeighsValue(int[] input)
        {
            int[] valueAndIndex = { input[0], 0 };

            for (int i = 0; i < input.GetLength(0); i++)
            {
                if (input[i] > valueAndIndex[i])
                {
                    valueAndIndex[0] = input[i];
                    valueAndIndex[1] = i;
                }
            }

            return valueAndIndex[1];
        }

        /// <summary>
        /// This returns the index of the heights value
        /// </summary>
        public static int GetHeighsValue(float[] input)
        {
            float[] valueAndIndex = { input[0], 0 };

            for (int i = 0; i < input.GetLength(0); i++)
            {
                if (input[i] > valueAndIndex[0])
                {
                    valueAndIndex[0] = input[i];
                    valueAndIndex[1] = i;
                }
            }

            return (int)valueAndIndex[1];
        }
    }
}