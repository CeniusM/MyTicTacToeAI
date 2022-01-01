using CS_Math;

namespace CS_TicTacToeAI
{
    class TicTacToeAIv2
    {
        public float fitnessScore = 0;

        private int i_Nodes = 9;
        private int h_Nodes1 = 9;
        private int h_Nodes2 = 9;
        private int o_Nodes = 9;

        /* ---
        each w1-3 has a col(the first cord) to store wich neron it goes from and to(data in the rows)*/
        public float[,] w1; // input to h_nodes
        public float[,] w2; // h_nodes to h_nodes2
        public float[,] w3; // h_nodes2 to output
        //---

        public int mutability = 10; // how many times the ai wants to mutate, this in of it self could be mutated

        public TicTacToeAIv2()
        {
            w1 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1); // creates the grid for all the weights between the input nodes to the hidden nodes1
            w2 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1);
            w3 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1);
        }

        public TicTacToeAIv2(float[,] w1, float[,] w2, float[,] w3) // for inheriten
        {
            this.w1 = w1;
            this.w2 = w2;
            this.w3 = w3;
        }

        public TicTacToeAIv2(float[,] w1, float[,] w2, float[,] w3, int mutability) // for inheriten
        {
            this.w1 = w1;
            this.w2 = w2;
            this.w3 = w3;
            this.mutability = mutability;
        }

        public int[] Getmove(int[] input) // an array of the board. 1*9 insted of 3x3
        {
            // turns the input to float
            float[] fInput = MyMath.GetFloatArr(input);

            float[] h_Nodes1Values = GetLayer(fInput, w1);

            float[] h_Nodes2Values = GetLayer(h_Nodes1Values, w2);

            float[] o_Nodes = GetLayer(h_Nodes2Values, w3);

            int feild = MyMath.GetHeighsValue(o_Nodes);

            return CS_TicTacToe.TicTacToe.Get2DField(feild); // returns the 2d representation of a peice in ttt
        }

        // returns a float arr after getting the input values and using the weights
        public float[] GetLayer(float[] input, float[,] weights)
        {
            return new float[9];
        }

        public TicTacToeAIv2 GiveBirth()
        {
            // change the neruon weights a bid and the mutability

            return new TicTacToeAIv2(w1, w2, w3);
        }
    }
}
/*
input nodes(9)
w1
hidden nodes1(9)
w2
hidden nodes2(9)
w3
output(9)


*/