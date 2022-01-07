namespace CS_Math
{
    class Logistic_Curve_Math
    {
        const double E = 2.7182818284590451;
        public static float GetLogisticCurve(float X)
        {
            float L = 2;
            float K = 1;

            float power = (float)Math.Pow(E, -K * (X));

            L /= (1 + power);
            L--;

            Console.WriteLine(L - 1);
            return (L - 1);
        }

    }
}