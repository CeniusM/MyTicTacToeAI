namespace CS_Math
{
    class Logistic_Curve_Math
    {
        public static void SmushCruve(float[,] weight, float min, float max) // idfk
        {
            for (int i = 0; i < weight.GetLength(0); i++)
            {
                for (int j = 0; j < weight.GetLength(1); j++)
                {
                    weight[i,j] = max/(max+weight[i,j]);
                }
            }
        }
    }
}