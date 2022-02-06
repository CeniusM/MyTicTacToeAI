using TicTacToeAI.MyMath;

namespace TicTacToeAI
{
    class Generations
    {
        private static Random rnd = new Random();
        public static List<TicTacToeAI> NewGeneration(List<TicTacToeAI> players)
        {
            int index = 0;
            int minValue = int.MinValue;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].fitness > minValue)
                {
                    index = i;
                    minValue = players[i].fitness;
                }
            }

            TicTacToeAI Winner = players[index].GetClone();

            for (int i = 0; i < players.Count; i++)
            {
                if (rnd.Next(0, 5) == 0)
                {
                    players[i] = new TicTacToeAI();
                    players[i].Mutate();
                }
                else
                {
                    players[i] = Winner.GiveBirth();
                }
            }

            players.Add(Winner);

            return players;
        }

        public static List<TicTacToeAI> NewGenerationV2(List<TicTacToeAI> players, int topPlayerAmount)
        {
            List<TicTacToeAI> bestPlayers = new List<TicTacToeAI>();

            for (int i = 0; i < topPlayerAmount; i++) // get the top players
            {
                int index = 0;
                int minValue = int.MinValue;
                for (int j = 0; j < players.Count; j++)
                {
                    if (players[j].fitness > minValue)
                    {
                        index = j;
                        minValue = players[j].fitness;
                    }
                }
                bestPlayers.Add(players[index]);
                players.RemoveAt(index);
            }

            for (int i = 0; i < players.Count; i++)
            {
                if (rnd.Next(0, 5) == 0)
                {
                    players[i] = new TicTacToeAI();
                    players[i].Mutate();
                }
                else
                {
                    players[i] = bestPlayers[rnd.Next(0, topPlayerAmount)].GiveBirth();
                }
            }

            for (int i = 0; i < bestPlayers.Count; i++)
            {
                
            }

            players.Add(players[GetWinner(players)]);

            return players;
        }

        private static int GetWinner(List<TicTacToeAI> players)
        {
            int index = 0;
            int minValue = int.MinValue;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].fitness > minValue)
                {
                    index = i;
                    minValue = players[i].fitness;
                }
            }

            return index;
        }
    }
}