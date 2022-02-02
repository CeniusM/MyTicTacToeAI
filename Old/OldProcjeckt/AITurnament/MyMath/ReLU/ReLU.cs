namespace CS_Math
{
    class ReLU
    {
        public static float[] maximum(float[] arr, float min)
        {
            int lenght = arr.GetLength(0);
            for (int i = 0; i < lenght; i++)
            {
                if (arr[i] < min)
                    arr[i] = min;
            }
            return arr;
        }
        public static float[,] maximum(float[,] arr, float min)
        {
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (arr[i, j] < min)
                        arr[i, j] = min;
                }
            }
            return arr;
        }
        // public static int[] maximum(int[] arr)
        // {

        // }
        // public static int[,] maximum(int[,] arr)
        // {

        // }
    }
}