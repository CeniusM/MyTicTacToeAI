// this will be used so older saves can be used even if the AI clases will be changed, 
// so we use this to save and then we make our own translater from this into what ever ai is used

namespace TicTacToeAI.IO
{
    class AISaveStandard
    {
        public int mutability = 10;

        // the brain
        public float[,] w1; // make it into a not 2d array cause json serelizeingenwjirgbiwe dosent wanna work :(, unless you use Newtonsoft.Json, but to hard ;D
        public float[] h1 = new float[9];
        public float[,] w2;
        public float[] h2 = new float[9];
        public float[,] w3;
        public AISaveStandard()
        {
            w1 = new float[9, 9];
            w2 = new float[9, 9];
            w3 = new float[9, 9];
        }
        public AISaveStandard(float[,] W1, float[,] W2, float[,] W3)
        {
            w1 = W1;
            w2 = W2;
            w3 = W3;
        }
    }
}