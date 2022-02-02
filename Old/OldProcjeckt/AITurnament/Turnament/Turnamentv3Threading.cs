// // just turnyv3, but with multi threading.
// // either do the games in difrent threads and then combine once in a while,
// //or run the rounds in difrent threads 

// // have a set of ai's that only plays as player 1, and another set of ai's that only plays player 2
// // make hot fixes and make it all faster
// // make it work plz ;,)

// using MyTicTacToe;
// using CS_TicTacToeAI;
// using CS_MyConsole;
// using winForm;




// /*

// graph all of the ties in like exel or something

// */



// namespace TTT_Turnament
// {
//     class Turnamentv3Threading
//     {
//         private winForm.Form1 _Form;
//         public List<TurnamentStats> stats;
//         private int _playerAmount;
//         private int _generationAmount;
//         private List<TicTacToeAIv3> _winners;
//         private List<List<TicTacToeAIv3>> _players;
//         private List<TicTacToeAIv3> _allPlayers;
//         private CS_MyAI.AIPrinter _AIPrinter;
//         private int _threadAmount;
//         public bool isRunning { get; private set; }
//         public Turnamentv3Threading(int playerAmount, int generationAmount, winForm.Form1 _Form, int threads)
//         {
//             this._Form = _Form;
//             stats = new List<TurnamentStats>();
//             _playerAmount = playerAmount;
//             _generationAmount = generationAmount;
//             _winners = new List<TicTacToeAIv3>();
//             _players = new List<List<TicTacToeAIv3>>();
//             for (int i = 0; i < threads; i++)
//             {
//                 _players.Add(new List<TicTacToeAIv3>());
//                 for (int j = 0; j < _playerAmount / threads; j++)
//                 {
//                     _players[i].Add(new TicTacToeAIv3());
//                 }
//             }
//             _AIPrinter = new CS_MyAI.AIPrinter(_Form);

//             _allPlayers = new List<TicTacToeAIv3>();
//             for (int i = 0; i < threads; i++)
//             {
//                 for (int j = 0; j < _players[i].Count; j++)
//                 {
//                     _allPlayers.Add(_players[i][j]);
//                 }
//             }

//             _threadAmount = threads;

//             _Form.KeyPress += MyKeyPress;
//         }

//         public Turnamentv3Threading(List<List<TicTacToeAIv3>> _players, int generationAmount, winForm.Form1 _Form, int threads)
//         {
//             this._Form = _Form;
//             stats = new List<TurnamentStats>();
//             _playerAmount = _players.Count;
//             _generationAmount = generationAmount;
//             _winners = new List<TicTacToeAIv3>();
//             this._players = _players;
//             _AIPrinter = new CS_MyAI.AIPrinter(_Form);

//             _allPlayers = new List<TicTacToeAIv3>();
//             for (int i = 0; i < threads; i++)
//             {
//                 for (int j = 0; j < _players[i].Count; j++)
//                 {
//                     _allPlayers.Add(_players[i][j]);
//                 }
//             }

//             _threadAmount = threads;

//             _Form.KeyPress += MyKeyPress;
//             _Form.FormClosing += StopRunning;
//         }

//         private void StopRunning(object? sender, FormClosingEventArgs e)
//         {
//             isRunning = false;
//         }

//         private void MyKeyPress(object? sender, KeyPressEventArgs e)
//         {
//             if (e.KeyChar == 'c')
//             {
//                 isRunning = false;
//             }
//         }

//         public void Start()
//         {


//             isRunning = true;
//             for (int i = 0; i < _generationAmount; i++)
//             {
//                 if (!isRunning)
//                 {
//                     break;
//                 }
//                 else
//                 {
//                     StartGames();
//                     // _AIPrinter.PrintStanderdNetwork(_winners[_winners.Count - 1]); // make it its own class and thread where it can queue prints
//                 }
//             }

//             SaveingSystem.SaveAI(_winners[_winners.Count - 1]);
//         }

//         public void StartGames()
//         {
//             TurnamentStats turnyStats = new TurnamentStats(); // just used for the game


//             List<Gamev3> games = new List<Gamev3>();
//             for (int i = 0; i < _threadAmount; i++)
//             {
//                 games.Add(new Gamev3(_players[i]));
//             }

//             for (int i = 0; i < _threadAmount; i++)
//             {
//                 games[i].StartGame();
//             }

//             for (int i = 0; i < _threadAmount; i++)
//             {
//                 if (games[i].threadRunning)
//                 {
//                     i = 0;
//                     Thread.Sleep(100);
//                 }
//             }

//             for (int i = 0; i < _threadAmount; i++)
//             {
//                 turnyStats.player1wins += games[i].turnyStats.player1wins;
//                 turnyStats.player2wins += games[i].turnyStats.player2wins;
//                 turnyStats.ties += games[i].turnyStats.ties;
//                 games[i]._thread.Join();
//             }



//             PrintGameStats(turnyStats);

//             // // gets one winner per thread
//             // for (int i = 0; i < _threadAmount; i++)
//             // {
//             //     GenerationGenaratorv1.NewGenerationvA(_players[i], _winners);
//             // }
//             // _allPlayers = new List<TicTacToeAIv3>();
//             // for (int i = 0; i < _players.Count; i++)
//             // {
//             //     for (int j = 0; j < _players[i].Count; j++)
//             //     {
//             //         _allPlayers.Add(_players[i][j]);
//             //     }
//             // }

//             //------------! never have bot on...

//             // gets one winner out of all threads
//             GenerationGenaratorv1.NewGenerationvA(_allPlayers, _winners);
//             for (int i = 0; i < _threadAmount; i++)
//             {
//                 for (int j = 0; j < _allPlayers.Count / _threadAmount; j++)
//                 {
//                     _players[i][j] = _allPlayers[(i * (_allPlayers.Count / _threadAmount) + j)];
//                 }
//             }
//         }


//         public void PrintGameStats(TurnamentStats s)
//         {
//             string data = "";
//             // data += "Game at " + (_winners.Count + 1) + "/" + _generationAmount + ". p1Winns" + s.player1wins + ". p2Winns" + s.player2wins + ". ties" + s.ties + ". \n";
//             int Total = s.player1wins + s.player2wins + s.ties;
//             int procent = (int)(((float)(float)s.ties / (float)Total) * 100);
//             // data += procent+" / 10000";
//             data += procent;
//             MyConsole.WriteLine(data);
//         }
//     }
//     class Gamev3
//     {
//         public Thread _thread;
//         public List<TicTacToeAIv3> _players;
//         public TurnamentStats turnyStats;
//         public bool threadRunning = false;
//         public Gamev3(List<TicTacToeAIv3> _players)
//         {
//             this._players = _players;
//             turnyStats = new TurnamentStats();
//             _thread = new Thread(() => PlayGame());
//         }

//         public void StartGame()
//         {
//             threadRunning = true;
//             _thread.Start();
//         }

//         private void PlayGame()
//         {
//             for (int i = 0; i < _players.Count; i++)
//             {
//                 for (int j = 0; j < _players.Count; j++)
//                 {
//                     if (i == j) continue;
//                     PlayRound(_players[i], _players[j], turnyStats);
//                 }
//             }
//             threadRunning = false;
//         }

//         private void PlayRound(TicTacToeAIv3 AI1, TicTacToeAIv3 AI2, TurnamentStats turnyStats)
//         {
//             TicTacToe game = new TicTacToe();
//             while (game.running)
//             {
//                 if (game.playerTurn == 1)
//                 {
//                     game.MakeMove(AI1.GetMove(game.board, 1));
//                 }
//                 else
//                 {
//                     game.MakeMove(AI2.GetMove(game.board, 2));
//                 }
//             }
//             if (game.winner == 1)
//             {
//                 AI1.fitnessScore += 4;
//                 turnyStats.player1wins++;
//             }
//             else if (game.winner == 2)
//             {
//                 AI2.fitnessScore += 5;
//                 turnyStats.player2wins++;
//             }
//             else
//             {
//                 AI1.fitnessScore += 2;
//                 AI2.fitnessScore += 4;
//                 turnyStats.ties++;
//             }
//         }
//     }
// }