using CS_MyConsole;
using winForm;
using CS_TicTacToe;
using CS_TicTacToeAI;
using TTT_Turnament;

namespace CS_MyAI
{
    class MyAI
    {
        Form1 _Form;
        MyGame.GUI _GUI;
        public MyAI(Form1 form)
        {
            _Form = form;
            _GUI = new MyGame.GUI(_Form);
        }
        public void Start()
        {
            Turnamentv2 trunament = new Turnamentv2();

            trunament.Start();

            // Test();
        }

        private void Test()
        {
            List<TicTacToeAIv2> Winners = new List<TicTacToeAIv2>();

            Random rnd = new Random();
            int SampleSize = 10;

            string totalTime = "";
            totalTime += MyStopwatch.Measure(() =>
            {

                while (SampleSize > 0)
                {
                    // 100 millioner * 10 samples, spil i alt *før
                    int rounds = 10000;
                    string timeSpend = "";
                    int player1Wins = 0;
                    int player2Wins = 0;
                    int ties = 0;

                    timeSpend += MyStopwatch.Measure(() =>
                    {
                        while (rounds > 0)
                        {
                            TicTacToeAIv2 AI1 = new TicTacToeAIv2();
                            TicTacToeAIv2 AI2 = new TicTacToeAIv2();

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
                                player1Wins++;
                                Winners.Add(AI1);
                            }
                            else if (ttt.winner == 2)
                            {
                                player2Wins++;
                                Winners.Add(AI2);
                            }
                            else
                                ties++;

                            rounds--;
                        }
                    });
                    string dataLog = "Time spend: " + timeSpend + ". p1 wins: " + player1Wins + ". p2 wins: " + player2Wins + ". Ties: " + ties;
                    MyConsole.WriteLine(dataLog);

                    string AI_winners = "AI winners: " + Winners.Count();
                    MyConsole.WriteLine(AI_winners);
                    SampleSize--;
                }
            }, 1);
            MyConsole.WriteLine("Total run time: " + totalTime);

        }
    }
}