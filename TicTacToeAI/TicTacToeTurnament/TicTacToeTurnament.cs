namespace TicTacToeAI
{
    class TTT_Turnament
    {
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
                PlayGame();

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

        public void PlayGame()
        {

        }

        public void PlayRound(TicTacToeAI AI1, TicTacToeAI AI2)
        {

        }
        public void Start() => _isRunning = true;
        public void Stop() => _isRunning = false;
    }
}