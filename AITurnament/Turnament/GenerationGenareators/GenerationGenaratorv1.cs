using CS_TicTacToeAI;

namespace TTT_Turnament
{
    class GenerationGenaratorv1
    {
        public static void NewGenerationvA(List<TicTacToeAIv3> players)
        {
            int winnerIndex = 0; // winner
            int value = players[0].fitnessScore;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].fitnessScore > value)
                    winnerIndex = i;
            }

            for (int i = 0; i < players.Count; i++)
            {
                if (i == winnerIndex) continue;
                players[i] = players[winnerIndex].GiveBirth();
            }
        }
    }
}