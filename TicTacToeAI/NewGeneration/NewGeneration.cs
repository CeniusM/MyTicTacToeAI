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

            ResetFitnessValue(players);

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
                players.Add(bestPlayers[i]);
            }

            ResetFitnessValue(players);

            return players;
        }

        public static List<TicTacToeAI> NewGenerationV3(List<TicTacToeAI> players)
        {
            int playerAmount = players.Count;

            int player = playerAmount;

            for (int i = 0; i < player; i++)
            {
                if (players[i].fitness < 0)
                {
                    players.RemoveAt(i);
                    player--;
                }
            }

            for (int i = players.Count; i < playerAmount; i++)
            {
                if (rnd.Next(0, 4) != 1)
                {
                    players.Add(players[rnd.Next(0, players.Count)].GiveBirth());
                }
                else
                {
                    players.Add(new TicTacToeAI());
                    players[players.Count - 1].Mutate();
                }
            }

            ResetFitnessValue(players);

            // CS_MyConsole.MyConsole.WriteLine(players.Count + "/" + playerAmount);

            return players;
        }

        public static void ResetFitnessValue(List<TicTacToeAI> players)
        {
            foreach (TicTacToeAI player in players)
            {
                player.fitness = 0;
            }
        }

        public static int GetWinner(List<TicTacToeAI> players)
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