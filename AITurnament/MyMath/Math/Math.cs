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
            return 0;
        }

        /// <summary>
        /// This returns the index of the heights value
        /// </summary>
        public static int GetHeighsValue(float[] input)
        {
            return 0;
        }
    }
}