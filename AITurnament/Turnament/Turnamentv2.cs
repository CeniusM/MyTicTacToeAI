using CS_TicTacToe;
using CS_TicTacToeAI;
using CS_MyConsole;

namespace TTT_Turnament
{
    class Turnamentv2
    {
        public int playerAmout; // players playing at any given time
        public int roundsPerGame; // how many rounds in a game
        public int gameAmount; // games per turnament, and inbetween each game you need to mutate and kill the weak
        public List<TicTacToeAIv2> winnerOgEachGame; // 0 - (gameAmount-1)
        public List<TicTacToeAIv2> Players;
        public Turnamentv2(int playerAmout = 100, int roundsPerGame = 100, int gameAmount = 100)
        {
            this.playerAmout = playerAmout;
            this.roundsPerGame = roundsPerGame;
            this.gameAmount = gameAmount;
            winnerOgEachGame = new List<TicTacToeAIv2>();
            Players = new List<TicTacToeAIv2>();
            for (int i = 0; i < playerAmout; i++)
            {
                Players.Add(new TicTacToeAIv2());
            }
        }

        public void Start()
        {


            PlayTurnament();


        }

        private void PlayTurnament()
        {
            for (int i = 0; i < gameAmount; i++)
            {
                PlayGame();
            }

            string data = "Amount of game winners: " + winnerOgEachGame.Count();
            MyConsole.WriteLine(data);
        }

        private void PlayGame() // make all the AIs play each other and kill the loosers, and make some of the winners mutate
        {
            for (int i = 0; i < roundsPerGame; i++) // player the game
            {
                for (int j = 0; j < roundsPerGame; j++)
                {
                    if (i < j)
                    {
                        PlayRound(Players[i], Players[j]);
                    }
                }
            }

            int indexOfwinner = 0;
            float value = -1;
            for (int i = 0; i < Players.Count; i++) // finds the winner
            {
                if (Players[i].fitnessScore > value)
                    indexOfwinner = i;
            }
            winnerOgEachGame.Add(Players[indexOfwinner]);

            for (int i = 0; i < Players.Count; i++) // mutate the players and kill some
            {
                if (Players[i].fitnessScore < 0)
                {
                    Players[i] = new TicTacToeAIv2();
                }
                else if (Players[i].fitnessScore > 0)
                {
                    Players[i] = Players[i].GiveBirth();
                }
            }
        }

        private void PlayRound(TicTacToeAIv2 AI1, TicTacToeAIv2 AI2) // Wil play a ttt game and determan fitness
        {
            TicTacToe ttt = new TicTacToe();
            while (ttt.gameRunning)
            {
                if (ttt.playerTurn == 1)
                {
                    ttt.MakeMove(AI1.Getmove(ttt.Board));
                }
                else
                {
                    ttt.MakeMove(AI2.Getmove(ttt.Board));
                }
            }
            if (ttt.winner == 1)
            {
                AI1.fitnessScore += 0.2f;
                AI2.fitnessScore -= 0.2f;
            }
            else if (ttt.winner == 2)
            {
                AI1.fitnessScore -= 0.2f;
                AI2.fitnessScore += 0.2f;
            }
        }
    }
}