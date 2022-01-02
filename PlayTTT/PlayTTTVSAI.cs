using CS_TicTacToe;
using CS_TicTacToeAI;
using winForm;

namespace PlayTTTVSAI
{
    class TTTgame
    {
        private Form1 _Form;
        private TicTacToe _TicTacToe;
        private MyGame.GUI _GUI;
        private TicTacToeAIv2 _AI;
        private TicTacToeAIv2b _AIb;
        private int PlayerWhosPlayer1 = 1;
        private bool Running = true;
        public TTTgame(Form1 _Form, TicTacToeAIv2 AI)
        {
            this._Form = _Form;
            _TicTacToe = new TicTacToe();
            _Form.MouseClick += MyMouseClick;
            _GUI = new MyGame.GUI(_Form);
            _AI = AI;
            _AIb = new TicTacToeAIv2b();

            _Form.FormClosing += Stop;
        }
        public TTTgame(Form1 _Form, TicTacToeAIv2b AI)
        {
            this._Form = _Form;
            _TicTacToe = new TicTacToe();
            _Form.MouseClick += MyMouseClick;
            _GUI = new MyGame.GUI(_Form);
            _AI = new TicTacToeAIv2();
            _AIb = AI;

            _Form.FormClosing += Stop;
        }

        private void Stop(object? sender, FormClosingEventArgs e)
        {
            Running = false;
        }


        private void MyMouseClick(object? sender, MouseEventArgs e) // winform board = 800 x 800
        {
            int x = 0;
            int y = 0;

            if (533 < e.X) // right colum
            {
                x = 2;
            }
            else if (e.X < 233)
            {
                x = 0;
            }
            else x = 1;



            if (533 < e.Y) // butom colum
            {
                y = 2;
            }
            else if (e.Y < 233)
            {
                y = 0;
            }
            else y = 1;

            if (_TicTacToe.playerTurn != PlayerWhosPlayer1)
            {
                _TicTacToe.MakeMove(x, y);
            }
        }

        public void Start()
        {
            while (Running)
            {
                if (_TicTacToe.playerTurn == PlayerWhosPlayer1)
                {
                    _TicTacToe.MakeMove(_AIb.Getmove(_TicTacToe.Board, PlayerWhosPlayer1));
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        PrintAPI(i, j, _TicTacToe.Board[i, j]);
                    }
                }
                if (!_TicTacToe.gameRunning)
                {
                    if (PlayerWhosPlayer1 == 1) PlayerWhosPlayer1 = 2;
                    else PlayerWhosPlayer1 = 1;


                    Color color = Color.White;

                    if (_TicTacToe.winner == 0)
                    {
                        color = Color.Yellow;
                    }
                    else if (_TicTacToe.winner == 1)
                    {
                        color = Color.Red;
                    }
                    else if (_TicTacToe.winner == 2)
                    {
                        color = Color.Blue;
                    }

                    _GUI.DrawLine(1, 1, 700, 700, color, 2);

                    _GUI.Print();
                    Thread.Sleep(1000);
                    _TicTacToe = new TicTacToe();
                    _GUI.Resetv2();
                    _GUI.Print();
                }
                if (_TicTacToe.gameRunning)
                    _GUI.Print();
                Thread.Sleep(100);
            }
        }

        private void PrintAPI(int i, int j, int value)
        {
            int x = GetCoord(i);
            int y = GetCoord(j);

            if (value == 1)
            {
                _GUI.DrawCrosse(x + 800 / 3 / 2, y + 800 / 3 / 2, 100, 10, Color.Red);
            }
            else if (value == 2)
            {
                _GUI.DrawNought(x, y, 200, 10, Color.Blue);
            }
        }

        private int GetCoord(int i)
        {
            int reselution = 800;
            // int value = reselution / 3 / 2;
            int value = 0;

            if (i == 1)
                value += reselution / 3;
            else if (i == 2)
                value += (reselution / 3) * 2;

            return value;
        }
    }
}