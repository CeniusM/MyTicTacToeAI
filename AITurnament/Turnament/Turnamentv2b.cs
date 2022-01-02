using CS_TicTacToe;
using CS_TicTacToeAI;
using CS_MyConsole;
using winForm;

namespace TTT_Turnament
{
    class Turnamentv2b
    {
        public int playerAmout; // players playing at any given time
        // public int roundsPerPlayer; // how many rounds in a game//nots used
        public int gameAmount; // games per turnament, and inbetween each game you need to mutate and kill the weak
        public List<TicTacToeAIv2b> winnerOgEachGame; // 0 - (gameAmount-1)
        public List<TicTacToeAIv2b> Players;
        public List<TurnamentStats> stats;
        public Form1 myForm;
        public Turnamentv2b(int playerAmout, int roundsPerPlayer, int gameAmount, Form1 myForm)
        {
            this.playerAmout = playerAmout;
            // this.roundsPerPlayer = roundsPerPlayer; // no use right now
            this.gameAmount = gameAmount;
            winnerOgEachGame = new List<TicTacToeAIv2b>();
            Players = new List<TicTacToeAIv2b>();
            for (int i = 0; i < playerAmout; i++)
            {
                Players.Add(new TicTacToeAIv2b());
            }
            stats = new List<TurnamentStats>();
            this.myForm = myForm;
        }

        public void Start()
        {


            PlayTurnament();

            PlayTTTVSAI.TTTgame tTTgame = new PlayTTTVSAI.TTTgame(myForm, winnerOgEachGame[winnerOgEachGame.Count - 1]);

            tTTgame.Start();
        }

        private void PlayTurnament()
        {
            for (int i = 0; i < gameAmount; i++)
            {
                PlayGame();
            }

            // string data = string.Empty;
            // foreach (TurnamentStats stat in stats)
            // {
            //     data += "p1Winns" + stat.player1wins + ". p2Winns" + stat.player2wins + ". ties" + stat.ties + ". \n";
            // }
            // MyConsole.WriteLine(data);

            string dataStr = string.Empty;
            TurnamentStats stat = new TurnamentStats();
            foreach (TurnamentStats i in stats)
            {
                stat.player1wins += i.player2wins;
                stat.player2wins += i.player1wins;
                stat.ties += i.ties;
            }
            dataStr += "the whole turny. p1Winns" + stat.player1wins + ". p2Winns" + stat.player2wins + ". ties" + stat.ties + ". \n";
            dataStr += "firstGame. p1Winns" + stats[0].player1wins + ". p2Winns" + stats[0].player2wins + ". ties" + stats[0].ties + ". \n";
            dataStr += "lastGame. p1Winns" + stats[gameAmount - 1].player1wins + ". p2Winns" + stats[gameAmount - 1].player2wins + ". ties" + stats[gameAmount - 1].ties + ".";

            MyConsole.WriteLine(dataStr);
        }

        private void PlayGame() // make all the AIs play each other and kill the loosers, and make some of the winners mutate
        {
            // stats.Add(new TurnamentStats());
            TurnamentStats thisGameStats = new TurnamentStats();

            for (int i = 0; i < Players.Count(); i++) // player the game
            {
                for (int j = 0; j < Players.Count(); j++)
                {
                    if (i != j)
                    {
                        PlayRound(Players[i], Players[j], thisGameStats);
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

            NewGenareation();

            string data = string.Empty;
            data += "p1Winns" + thisGameStats.player1wins + ". p2Winns" + thisGameStats.player2wins + ". ties" + thisGameStats.ties + ". \n";
            MyConsole.WriteLine(data);

            stats.Add(thisGameStats);
        }

        private void PlayRound(TicTacToeAIv2b AI1, TicTacToeAIv2b AI2, TurnamentStats roundStats) // Wil play a ttt game and determan fitness
        {
            TicTacToe ttt = new TicTacToe();
            while (ttt.gameRunning)
            {
                if (ttt.playerTurn == 1)
                {
                    ttt.MakeMove(AI1.Getmove(ttt.Board, 1));
                }
                else
                {
                    ttt.MakeMove(AI2.Getmove(ttt.Board, 2));
                }
            }
            if (ttt.winner == 1)
            {
                AI1.fitnessScore += 1f;
                AI2.fitnessScore -= 0.1f;
                roundStats.player1wins++;
            }
            else if (ttt.winner == 2)
            {
                AI2.fitnessScore += 1f;
                AI1.fitnessScore -= 0.1f;
                roundStats.player2wins++;
            }
            else roundStats.ties++;

            //test
            // NewGenareation();
        }

        private void NewGenareation()// shit code, needs work
        {
            Random rnd = new Random();
            int killed = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].fitnessScore < 0)
                {
                    Players.RemoveAt(i);
                    killed++;
                }
            }

            // int randomAIs = 10;
            // while (randomAIs > 0)
            // {
            //     Players.RemoveAt(rnd.Next(0,Players.Count()-1));
            //     killed++;
            //     randomAIs--;
            // }

            float minFitness = 100000;
            for (int i = 0; i < killed; i++) // lets the top AIs give birth
            {
                bool killedAAI = false;
                for (int j = 0; j < Players.Count; j++)
                {
                    if (rnd.Next(0,2) == 1)
                    {
                        Players.Add(new TicTacToeAIv2b());
                        killedAAI = true;
                        break;
                    }
                    else if (Players[j].fitnessScore > minFitness)
                    {
                        Players.Add(Players[j].GiveBirth());
                        killedAAI = true;
                        break;
                    }
                }
                if (!killedAAI)
                {
                    i--;
                    minFitness -= 1f;
                }

                ResetFitnessValues();
            }

            // for (int i = 0; i < Players.Count; i++) // mutate the players and kill some
            // {
            //     if (Players[i].fitnessScore < 0)
            //     {
            //         Players.RemoveAt(i);
            //     }
            //     else if (Players[i].fitnessScore > 0)
            //     {
            //         Players.Add(Players[i].GiveBirth());
            //     }
            // }
        }
        private void ResetFitnessValues()
        {
            for (int i = 0; i < Players.Count(); i++)
            {
                Players[i].fitnessScore = 0;
            }
        }
    }
}