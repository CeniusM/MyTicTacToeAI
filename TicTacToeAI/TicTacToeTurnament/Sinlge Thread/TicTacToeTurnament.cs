using TicTacToe;

namespace TicTacToeAI
{
    class TTT_Turnament
    {
        public TurnamentStats turnyStats = new TurnamentStats();
        public List<TicTacToeAI> winners { get; private set; } = new List<TicTacToeAI>();
        public bool _isRunning { get; private set; } = false;
        private List<TicTacToeAI> _players = new List<TicTacToeAI>();
        public event EventHandler? genarationDone;
        private int generationAmount;
        private int playerAmount;
        public TTT_Turnament(int players, int generations, int threads) // threads not used
        {
            generationAmount = generations;
            playerAmount = players;
            for (int i = 0; i < players; i++)
            {
                _players.Add(new TicTacToeAI());
            }
        }
        public TTT_Turnament(List<TicTacToeAI> players, int generations, int threads) // threads not used
        {
            generationAmount = generations;
            playerAmount = players.Count;
            _players = players;
        }

        public void Run()
        {
            Start();

            int generation = generationAmount;

            while (generation > 0 && _isRunning)
            {
                RunNewGeneration();

                PrintStats(generationAmount - generation);

                BestAIPlay();

                genarationDone!.Invoke(this, EventArgs.Empty);

                generation--;
            }

            // while (_isRunning)
            // {
            //     winners.Add(new TicTacToeAI());
            //     winners[winners.Count() - 1].brain.Randomize(8);
            //     genarationDone!.Invoke(this, EventArgs.Empty);
            //     Thread.Sleep(1000);
            // }
        }

        public void RunNewGeneration()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                for (int j = 0; j < _players.Count; j++)
                {
                    PlayRound(_players[i], _players[j]);
                }
            }

            winners.Add(_players[Generations.GetWinner(_players)]);
            _players = Generations.NewGenerationV2(_players, 10); // still being teseted

            // _players = Generations.NewGeneration(_players);
            // winners.Add(_players[_players.Count - 1]);
            // _players.Remove(_players[_players.Count - 1]);
        }

        public void PlayRound(TicTacToeAI AI1, TicTacToeAI AI2)
        {
            TTTGame tttGame = new TTTGame();

            while (!tttGame.isGameOver)
            {
                if (tttGame.player == 1)
                {
                    tttGame.MakeMove(AI1.MakeMove(tttGame.board, 1));
                }
                else
                {
                    tttGame.MakeMove(AI2.MakeMove(tttGame.board, 2));
                }
            }

            if (tttGame.winner == 1)
            {
                AI1.fitness += 7;
                turnyStats.player1wins++;
            }
            else if (tttGame.winner == 2)
            {
                AI2.fitness += 9;
                turnyStats.player2wins++;
            }
            else
            {
                AI1.fitness += 2;
                AI2.fitness += 3;
                turnyStats.ties++;
            }
        }
        private void PrintStats(int generation)
        {
            string Data = $"wins: {turnyStats.player1wins}\n" + $"losses: {turnyStats.player2wins}\n" + $"ties: {turnyStats.ties}\n";
            Data += $"{(generation + 1)}/{generationAmount}";

            // string Data = $"{turnyStats.ties}";

            // in %
            // int procent = (int)(((float)(float)turnyStats.ties / (float)(turnyStats.player1wins + turnyStats.player2wins + turnyStats.ties)) * 100);
            // string Data = $"{procent}";

            Data += "\n";
            turnyStats = new TurnamentStats();
            CS_MyConsole.MyConsole.WriteLine(Data);
        }

        public void BestAIPlay()
        {
            int Games = 10000; // 10k, behøver nok ikke mere end like 100k

            TurnamentStats gamesStats = new TurnamentStats();
            TicTacToeAI AI = winners[winners.Count - 1].GetClone();

            Random rnd = new Random();

            for (int i = 0; i < Games; i++)
            {
                TTTGame tttGame = new TTTGame();
                while (!tttGame.isGameOver)
                {
                    if (tttGame.player == 1)
                    {
                        tttGame.MakeMove(AI.MakeMove(tttGame.board, 1));
                    }
                    else
                    {
                        tttGame.MakeMove(rnd.Next(0, 9));
                    }
                }
                if (tttGame.winner == 1)
                {
                    gamesStats.player1wins++;
                }
                else if (tttGame.winner == 2)
                {
                    gamesStats.player2wins++;
                }
                else
                {
                    gamesStats.ties++;
                }
            }


            string Data = $"Best player stats vs random: wins: {gamesStats.player1wins}, " + $"losses: {gamesStats.player2wins}, " + $"ties: {gamesStats.ties}";
            Data += "\n";
            CS_MyConsole.MyConsole.WriteLine(Data);
        }
        public void Start() => _isRunning = true;
        public void Stop() => _isRunning = false;
    }
}