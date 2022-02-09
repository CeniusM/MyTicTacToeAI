using TicTacToe;

namespace TicTacToeAI
{
    class TTT_TurnamentT
    {
        public event EventHandler? genarationDone;
        public TurnamentStats turnyStats = new TurnamentStats();
        public List<TicTacToeAI> winners { get; private set; } = new List<TicTacToeAI>();
        public bool _isRunning { get; private set; } = false;
        public List<TicTacToeAI> _players = new List<TicTacToeAI>();
        private int generationAmount;
        private int playerAmount;
        public int threadAmount { get; private set; }
        public TTT_TurnamentT(int players, int generations, int threads) // the players is the amount of players per thread
        {
            generationAmount = generations;
            playerAmount = players;
            for (int i = 0; i < (players * threads); i++)
            {
                _players.Add(new TicTacToeAI());
            }
            threadAmount = threads;
        }
        public TTT_TurnamentT(List<TicTacToeAI> players, int generations, int threads) // the players will just be split up
        {
            generationAmount = generations;
            playerAmount = players.Count;
            _players = players;
            threadAmount = threads;
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
        }

        public void RunNewGeneration()
        {
            List<TTT_TurnamentTGame> games = new List<TTT_TurnamentTGame>();

            int thisGameThreadAmout = threadAmount;

            int playersPerGame = _players.Count / thisGameThreadAmout; // isent 100% curreckt

            //     string Data = CS_MyConsole.MyStopwatch.Measure(() =>
            //   {

            for (int i = 0; i < thisGameThreadAmout; i++)
            {
                List<TicTacToeAI> playerList = new List<TicTacToeAI>();

                for (int j = 0; j < playersPerGame; j++)
                {
                    playerList.Add(_players[(i * playersPerGame) + j]);
                }

                games.Add(new TTT_TurnamentTGame(playerList, turnyStats));
            }
            //   }); Data += "<-- is starting the threads \n";


            //     Data += CS_MyConsole.MyStopwatch.Measure(() =>
            // {
            for (int i = 0; i < thisGameThreadAmout; i++)
            {
                if (!games[i].isDone)
                {
                    i = 0;
                    Thread.Sleep(100); // not sure about the amount
                }
            }
            // }); Data += "<-- is the actul ai sim";

            // CS_MyConsole.MyConsole.WriteLine(Data);

            winners.Add(_players[Generations.GetWinner(_players)]);
            _players = Generations.NewGenerationV2(_players, 10); // still being teseted
            // _players = Generations.NewGeneration(_players);
        }

        private void PrintStats(int generation)
        {
            string Data = "";

            // Data += $"wins: {turnyStats.player1wins}\n" + $"losses: {turnyStats.player2wins}\n" + $"ties: {turnyStats.ties}\n";
            // Data += $"{(generation + 1)}/{generationAmount}";
            // Data += "\n";

            // string Data = $"{turnyStats.ties}";

            // in %
            int procent = (int)(((float)(float)turnyStats.ties / (float)(turnyStats.player1wins + turnyStats.player2wins + turnyStats.ties)) * 100);
            Data += $"{procent}";


            turnyStats = new TurnamentStats();
            CS_MyConsole.MyConsole.WriteLine(Data);
        }
        public void SetThreadAmout(int x)
        {
            if (x > 10) x = 10;
            else if (x < 1) x = 1;
            threadAmount = x;
        }
        public void Start() => _isRunning = true;
        public void Stop() => _isRunning = false;
    }
    class TTT_TurnamentTGame
    {
        public Thread game;
        public bool isDone = false;
        private TurnamentStats turnyStats;
        private List<TicTacToeAI> players;
        public TTT_TurnamentTGame(List<TicTacToeAI> players, TurnamentStats stats) // will run imediatly
        {
            turnyStats = stats;
            this.players = players;
            game = new Thread(Play);
            game.Start();
        }

        private void Play()
        {
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    PlayRound(players[i], players[j]);
                }
            }
            isDone = true;
        }

        private void PlayRound(TicTacToeAI AI1, TicTacToeAI AI2)
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

            if (tttGame.winner == 1) // havent figured out the values
            {
                AI1.fitness += 7;
                AI2.fitness -= 7;
                turnyStats.player1wins++;
            }
            else if (tttGame.winner == 2)
            {
                AI2.fitness += 9;
                AI1.fitness -= 9;
                turnyStats.player2wins++;
            }
            else
                turnyStats.ties++;
        }
    }
}