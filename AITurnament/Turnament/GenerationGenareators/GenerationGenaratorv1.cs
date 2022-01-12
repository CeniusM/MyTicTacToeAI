using CS_TicTacToeAI;

namespace TTT_Turnament
{
    class GenerationGenaratorv1
    {
        public static void NewGenerationvA(List<TicTacToeAIv3> players, List<TicTacToeAIv3> _winners)
        {
            int winnerIndex = 0; // winner
            int value = players[0].fitnessScore;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].fitnessScore > value)
                {
                    winnerIndex = i;
                    value = players[i].fitnessScore;
                }
            }

            TicTacToeAIv3 winner = players[winnerIndex].GetClone();
            _winners.Add(winner);

            for (int i = 0; i < players.Count; i++)
            {
                players[i] = winner.GiveBirth();
            }
        }
    }
}