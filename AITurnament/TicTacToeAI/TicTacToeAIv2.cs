using CS_Math;

namespace CS_TicTacToeAI
{
    class TicTacToeAIv2 
    // reason this dosent work is becous of the fackt that the inputs is 1 or 2, depending on
    // so it dosent know anything about what it should do with 1 or 2s. its dosent even knpw what player it is

    {
        public float fitnessScore = 0;

        private int i_Nodes = 9;
        private int h_Nodes1 = 9;
        // private int h_Nodes2 = 9; // not used, maby in v3
        // private int o_Nodes = 9;

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

        public int[] Getmove(int[,] input) // an array of the board. 1*9 insted of 3x3
        {
            // turns the input to float

            int[] newInput = new int[9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    newInput[(i * 3) + j] = input[i, j];
                }
            }

            return Getmove(newInput);
        }

        public int[] Getmove(int[] input) // an array of the board. 1*9 insted of 3x3
        {
            // turns the input to float
            float[] fInput = MyMath.GetFloatArr(input);

            //first layer of nerourns
            float[] h_Nodes1Values = GetLayer(fInput, w1);

            //second layer of nerourns
            float[] h_Nodes2Values = GetLayer(h_Nodes1Values, w2);

            //third aka last layer of nerourns
            float[] o_Nodes = GetLayer(h_Nodes2Values, w3);

            // makes it so only the outputs where you can get a output is there, tho the ai needs to learn this it self in the futrure by gett PUNISHED
            for (int i = 0; i < input.GetLength(0); i++)
            {
                if (input[i] != 0)
                    o_Nodes[i] = -100;
            }

            int feild = MyMath.GetHeighsValue(o_Nodes);

            return CS_TicTacToe.TicTacToe.Get2DField(feild); // returns the 2d representation of a peice in ttt
        }

        /// <summary>
        // returns a float arr after getting the input values and using the weights
        /// <summary>
        public float[] GetLayer(float[] input, float[,] weights) // get layer also need to make alll the negativ numbers to 0
        {
            float[] output = new float[input.GetLength(0)];

            //code
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    output[i] += input[j] * weights[i, j];
                }
            }

            // ReLU.maximum(output, 0); // idk if its needed

            return output;
        }

        public TicTacToeAIv2 GiveBirth()
        {
            Random rnd = new Random();

            // change the neruon weights a bid and the mutability

            w1 = MutateWeight(w1, mutability);
            w2 = MutateWeight(w2, mutability);
            w2 = MutateWeight(w3, mutability);

            if (rnd.Next(0, 2) == 1)
                mutability += 1;
            else
                mutability -= 1;

            if (mutability < 0)
                mutability = 1;
            if (mutability > 50)
                mutability = 50;

            return new TicTacToeAIv2(w1, w2, w3, mutability);
        }

        private float[,] MutateWeight(float[,] weight, int mutability)
        {
            Random rnd = new Random();
            for (int i = 0; i < mutability; i++)
            {
                float change = 0;
                change = (float)rnd.NextDouble() / 4;
                if (rnd.Next(0, 0) == 1)
                    change *= -1;
                weight[rnd.Next(0, weight.GetLength(0)), rnd.Next(0, weight.GetLength(1))] = 0;
            }
            return weight; // i had written new float[1,1] lol. i jinxed my self
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