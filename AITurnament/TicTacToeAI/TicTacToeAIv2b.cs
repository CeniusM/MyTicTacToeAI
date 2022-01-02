/*
Things to add onto this ai

we need Logistic curves for each nerun (not the weights) when it has been given a value

we need to make the input 1 or -1 and make the ai what player it is.
so if the ai is player 1, the x is 1 as input, and the o is -1. and if its player 2, the o is 1 and the x is -1


*/
using CS_Math;

namespace CS_TicTacToeAI
{
    class TicTacToeAIv2b // this implements values to be form (-1) - 1 indstead of 1-2
                         // and logistic curves---- not done
    {
        public float fitnessScore = 0;

        private int i_Nodes = 9;
        private int h_Nodes1 = 9;
        // private int h_Nodes2 = 9; // not used, maby in v3
        // private int h_Nodes3 = 9; // not used, maby in v3
        // private int o_Nodes = 9;

        /* ---
        each w1-3 has a col(the first cord) to store wich neron it goes from and to(data in the rows)*/
        public float[,] w1; // input to h_nodes
        public float[,] w2; // h_nodes to h_nodes2
        public float[,] w3; // h_nodes2 to h_nodes3
        public float[,] w4; // h_nodes3 to output
        //---

        public int mutability = 20; // how many times the ai wants to mutate, this in of it self could be mutated

        public TicTacToeAIv2b()
        {
            w1 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1); // creates the grid for all the weights between the input nodes to the hidden nodes1
            w2 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1);
            w3 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1);
            w4 = MyRandom.RandomInputs2D(i_Nodes, h_Nodes1);
        }

        public TicTacToeAIv2b(float[,] w1, float[,] w2, float[,] w3, float[,] w4) // for inheriten
        {
            this.w1 = w1;
            this.w2 = w2;
            this.w3 = w3;
            this.w4 = w4;
        }

        public TicTacToeAIv2b(float[,] w1, float[,] w2, float[,] w3, float[,] w4, int mutability) // for inheriten
        {
            this.w1 = w1;
            this.w2 = w2;
            this.w3 = w3;
            this.w4 = w4;
            this.mutability = mutability;
        }

        public int[] Getmove(int[,] input, int playerNum) // an array of the board. 1*9 insted of 3x3 and gets what player it is to make the nums form -1 to 1
        {
            // turns the input to float

            int[] newInput = new int[9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (input[i, j] == playerNum)
                        newInput[(i * 3) + j] = 1;
                    else if (input[i, j] == 0)
                        newInput[(i * 3) + j] = 0;
                    else
                        newInput[(i * 3) + j] = -1;
                }
            }

            return Getmove(newInput);
        }

        private int[] Getmove(int[] input) // an array of the board. 1*9 insted of 3x3
        {
            // turns the input to float
            float[] fInput = MyMath.GetFloatArr(input);

            //first layer of nerourns
            float[] h_Nodes1Values = GetLayer(fInput, w1);

            //second layer of nerourns
            float[] h_Nodes2Values = GetLayer(h_Nodes1Values, w2);

            //third layer of nerourns
            float[] h_Nodes3Values = GetLayer(h_Nodes2Values, w3);

            //thorth aka last layer of nerourns
            float[] o_Nodes = GetLayer(h_Nodes2Values, w4);

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

        public TicTacToeAIv2b GiveBirth()
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

            return new TicTacToeAIv2b(w1, w2, w3, w4, mutability);
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