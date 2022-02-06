using TicTacToeAI.MyMath;

namespace TicTacToeAI
{
    class TicTacToeAI
    {
        public int fitness = 0;
        public const int chance = 50;
        private Random _rnd = new Random();
        public AIBrain brain;
        public int mutability = 10;
        public TicTacToeAI()
        {
            brain = new AIBrain();
        }
        public TicTacToeAI(AIBrain newBrain, int mutability)
        {
            brain = newBrain;
            this.mutability = mutability;
        }

        public int MakeMove(int[] board, int player)
        {
            float[] input = new float[9];

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == player)
                    input[i] = 1;
                else if (board[i] == 0)
                    input[i] = 0;
                else
                    input[i] = -1;
            }

            float[] output = brain.RunSim(input);

            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 0) output[i] = float.MinValue;
            }

            return Highest.GetHighestValue(output);
        }

        public void Mutate()
        {
            brain.Mutate(mutability, chance);
            if (_rnd.Next(0, 2) == 0)
                mutability++;
            else
                mutability--;
            if (mutability < 0) mutability = 1;
            if (mutability > 20) mutability = 20;
        }

        public TicTacToeAI GiveBirth()
        {
            AIBrain newBrain = new AIBrain(brain.w1, brain.w2, brain.w3);
            newBrain.Mutate(mutability, chance);

            int newMutability = mutability;

            if (_rnd.Next(0, 2) == 0)
                newMutability++;
            else
                newMutability--;
            if (newMutability < 0) newMutability = 1;
            if (newMutability > 20) newMutability = 20;

            TicTacToeAI newAi = new TicTacToeAI(newBrain, newMutability);
            return newAi;
        }

        public TicTacToeAI GetClone()
        {
            AIBrain newBrain = new AIBrain(brain.w1, brain.w2, brain.w3);
            TicTacToeAI newAi = new TicTacToeAI(newBrain, mutability);
            return newAi;
        }
    }
}