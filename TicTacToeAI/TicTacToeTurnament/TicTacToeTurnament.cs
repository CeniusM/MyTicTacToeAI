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
        public TTT_Turnament(int players, int generations, int threads)
        {
            generationAmount = generations;
            playerAmount = players;
            for (int i = 0; i < players; i++)
            {
                _players.Add(new TicTacToeAI());
            }
        }
        public TTT_Turnament(List<TicTacToeAI> players, int generations, int threads)
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

            _players = Generations.NewGeneration(_players);
            winners.Add(_players[_players.Count - 1]);
            _players.Remove(_players[_players.Count - 1]);
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
            Data += $"{(generation + 1)}/{generationAmount}\n";
            turnyStats = new TurnamentStats();
            CS_MyConsole.MyConsole.WriteLine(Data);
        }
        public void Start() => _isRunning = true;
        public void Stop() => _isRunning = false;
    }
}