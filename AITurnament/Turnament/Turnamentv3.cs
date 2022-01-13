// have a set of ai's that only plays as player 1, and another set of ai's that only plays player 2
// make hot fixes and make it all faster
// make it work plz ;,)

using MyTicTacToe;
using CS_TicTacToeAI;
using CS_MyConsole;
using winForm;




/*

graph all of the ties in like exel or something

*/



namespace TTT_Turnament
{
    class Turnamentv3
    {
        private winForm.Form1 _Form;
        public List<TurnamentStats> stats;
        private int _playerAmount;
        private int _generationAmount;
        private List<TicTacToeAIv3> _winners;
        private List<TicTacToeAIv3> _players;
        private CS_MyAI.AIPrinter _AIPrinter;
        public bool isRunning { get; private set; }
        public Turnamentv3(int playerAmount, int generationAmount, winForm.Form1 _Form)
        {
            this._Form = _Form;
            stats = new List<TurnamentStats>();
            _playerAmount = playerAmount;
            _generationAmount = generationAmount;
            _winners = new List<TicTacToeAIv3>();
            _players = new List<TicTacToeAIv3>();
            for (int i = 0; i < _playerAmount; i++)
            {
                _players.Add(new TicTacToeAIv3());
            }
            _AIPrinter = new CS_MyAI.AIPrinter(_Form);
            _Form.KeyPress += MyKeyPress;
        }

        public Turnamentv3(List<TicTacToeAIv3> _players, int generationAmount, winForm.Form1 _Form)
        {
            this._Form = _Form;
            stats = new List<TurnamentStats>();
            _playerAmount = _players.Count;
            _generationAmount = generationAmount;
            _winners = new List<TicTacToeAIv3>();
            this._players = _players;
            _AIPrinter = new CS_MyAI.AIPrinter(_Form);
            _Form.KeyPress += MyKeyPress;
        }

        private void MyKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                isRunning = false;
            }
        }

        public void Start()
        {
            isRunning = true;
            for (int i = 0; i < _generationAmount; i++)
            {
                if (!isRunning)
                {
                    break;
                }
                else
                {
                    PlayGame();
                }
            }
        }

        private void PlayGame()
        {
            TurnamentStats turnyStats = new TurnamentStats(); // just used for the game
            for (int i = 0; i < _playerAmount; i++)
            {
                for (int j = 0; j < _playerAmount; j++)
                {
                    if (i == j) continue;
                    PlayRound(_players[i], _players[j], turnyStats);
                }
            }

            PrintGameStats(turnyStats);

            GenerationGenaratorv1.NewGenerationvA(_players, _winners);
        }

        private void PlayRound(TicTacToeAIv3 AI1, TicTacToeAIv3 AI2, TurnamentStats turnyStats)
        {
            TicTacToe game = new TicTacToe();
            while (game.running)
            {
                if (game.playerTurn == 1)
                {
                    game.MakeMove(AI1.GetMove(game.board, 1));
                }
                else
                {
                    game.MakeMove(AI2.GetMove(game.board, 2));
                }
            }
            if (game.winner == 1)
            {
                AI1.fitnessScore += 2;
                turnyStats.player1wins++;
            }
            else if (game.winner == 2)
            {
                AI2.fitnessScore += 2;
                turnyStats.player2wins++;
            }
            else
            {
                AI1.fitnessScore++;
                AI2.fitnessScore++;
                turnyStats.ties++;
            }
        }

        private void PrintGameStats(TurnamentStats s)
        {
            string data = "";
            data += "Game at " + (_winners.Count + 1) + "/" + _generationAmount + ". p1Winns" + s.player1wins + ". p2Winns" + s.player2wins + ". ties" + s.ties + ". \n";
            MyConsole.WriteLine(data);
        }
    }
}