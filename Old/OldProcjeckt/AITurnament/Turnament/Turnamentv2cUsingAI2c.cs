// using CS_TicTacToe;
// using CS_TicTacToeAI;
// using CS_MyConsole;
// using winForm;



// // dosent work. idk why, maby in the loops at 227
// // or in the ai it self
// //... probely the ai


// // this sucks
// // make a new one


// // or this is vey unstable
















// namespace TTT_Turnament
// {
//     class Turnamentv2cUsingAI2c
//     {
//         public int playerAmout; // players playing at any given time
//         // public int roundsPerPlayer; // how many rounds in a game//nots used
//         public int gameAmount; // games per turnament, and inbetween each game you need to mutate and kill the weak
//         public List<TicTacToeAIv2c> winnerOgEachGame; // 0 - (gameAmount-1)
//         public List<TicTacToeAIv2c> Players;
//         public List<TurnamentStats> stats;
//         public Form1 myForm;
//         private bool stopTurny = false;
//         private bool stopAll = false;
//         public Turnamentv2cUsingAI2c(int playerAmout, int roundsPerPlayer, int gameAmount, Form1 myForm)
//         {
//             this.playerAmout = playerAmout;
//             // this.roundsPerPlayer = roundsPerPlayer; // no use right now
//             this.gameAmount = gameAmount;
//             winnerOgEachGame = new List<TicTacToeAIv2c>();
//             Players = new List<TicTacToeAIv2c>();
//             for (int i = 0; i < playerAmout; i++)
//             {
//                 Players.Add(new TicTacToeAIv2c());
//             }
//             stats = new List<TurnamentStats>();
//             this.myForm = myForm;
//             myForm.KeyPress += stop;
//             myForm.FormClosing += forceStop;
//         }

//         public Turnamentv2cUsingAI2c(int playerAmout, int roundsPerPlayer, int gameAmount, Form1 myForm, TicTacToeAIv2c tttAI)
//         {
//             this.playerAmout = playerAmout;
//             // this.roundsPerPlayer = roundsPerPlayer; // no use right now
//             this.gameAmount = gameAmount;
//             winnerOgEachGame = new List<TicTacToeAIv2c>();
//             Players = new List<TicTacToeAIv2c>();
//             for (int i = 0; i < playerAmout; i++)
//             {
//                 Players.Add(tttAI.GiveBirth());
//             }
//             stats = new List<TurnamentStats>();
//             this.myForm = myForm;
//             myForm.KeyPress += stop;
//             myForm.FormClosing += forceStop;
//         }

//         private void forceStop(object? sender, FormClosingEventArgs e)
//         {
//             stopTurny = true;
//             stopAll = true;
//         }

//         private void stop(object? sender, KeyPressEventArgs e)
//         {
//             if (e.KeyChar == 'c')
//                 stopTurny = true;
//             if (e.KeyChar == 'q')
//             {
//                 stopTurny = true;
//                 stopAll = true;
//                 myForm.Close();
//             }
//         }

//         public void Start()
//         {
//             PlayTurnament();

//             SaveingSystem.SaveAI(winnerOgEachGame[winnerOgEachGame.Count - 1]);


//             if (!stopAll)
//             {
//                 PlayTTTVSAI.TTTgame tTTgame = new PlayTTTVSAI.TTTgame(myForm, winnerOgEachGame[winnerOgEachGame.Count - 1]);

//                 tTTgame.Start();
//             }
//         }

//         private void PlayTurnament()
//         {
//             for (int i = 0; i < gameAmount; i++)
//             {
//                 PlayGame(i);
//                 if (stopTurny)
//                     break;
//             }

//             // string data = string.Empty;
//             // foreach (TurnamentStats stat in stats)
//             // {
//             //     data += "p1Winns" + stat.player1wins + ". p2Winns" + stat.player2wins + ". ties" + stat.ties + ". \n";
//             // }
//             // MyConsole.WriteLine(data);

//             string dataStr = string.Empty;
//             TurnamentStats stat = new TurnamentStats();
//             foreach (TurnamentStats i in stats)
//             {
//                 stat.player1wins += i.player2wins;
//                 stat.player2wins += i.player1wins;
//                 stat.ties += i.ties;
//             }
//             dataStr += "the whole turny. p1Winns" + stat.player1wins + ". p2Winns" + stat.player2wins + ". ties" + stat.ties + ". \n";
//             dataStr += "firstGame. p1Winns" + stats[0].player1wins + ". p2Winns" + stats[0].player2wins + ". ties" + stats[0].ties + ". \n";
//             dataStr += "lastGame. p1Winns" + stats[stats.Count - 1].player1wins + ". p2Winns" + stats[stats.Count - 1].player2wins + ". ties" + stats[stats.Count - 1].ties + ".";

//             MyConsole.WriteLine(dataStr);
//         }

//         private void PlayGame(int gameNum) // make all the AIs play each other and kill the loosers, and make some of the winners mutate
//         {
//             // stats.Add(new TurnamentStats());
//             TurnamentStats s = new TurnamentStats();

//             for (int i = 0; i < Players.Count(); i++) // playe the game
//             {
//                 for (int j = 0; j < Players.Count(); j++)
//                 {
//                     if (i != j)
//                     {
//                         PlayRound(Players[i], Players[j], s);
//                     }
//                 }
//             }

//             int indexOfwinner = 0;
//             float value = -1;
//             for (int i = 0; i < Players.Count; i++) // finds the winner
//             {
//                 if (Players[i].fitnessScore > value)
//                 {
//                     indexOfwinner = i;
//                     value = Players[i].fitnessScore;
//                 }
//             }
//             winnerOgEachGame.Add(Players[indexOfwinner].Clone());

//             NewGenareation();

//             string data = "";
//             data += "Game at " + (gameNum + 1) + "/" + gameAmount + ". p1Winns" + s.player1wins + ". p2Winns" + s.player2wins + ". ties" + s.ties + ". \n";
//             MyConsole.WriteLine(data);

//             stats.Add(s);
//         }

//         private void PlayRound(TicTacToeAIv2c AI1, TicTacToeAIv2c AI2, TurnamentStats s) // Wil play a ttt game and determan fitness
//         {
//             TicTacToe ttt = new TicTacToe();
//             while (ttt.gameRunning)
//             {
//                 if (ttt.playerTurn == 1)
//                 {
//                     ttt.MakeMove(AI1.Getmove(ttt.Board, 1));
//                 }
//                 else
//                 {
//                     ttt.MakeMove(AI2.Getmove(ttt.Board, 2));
//                 }
//             }
//             if (ttt.winner == 1)
//             {
//                 AI1.fitnessScore += 1f;
//                 AI2.fitnessScore -= 1f;
//                 s.player1wins++;
//             }
//             else if (ttt.winner == 2)
//             {
//                 AI2.fitnessScore += 1.5f;
//                 AI1.fitnessScore -= 1f;
//                 s.player2wins++;
//             }
//             else
//             {
//                 AI2.fitnessScore += 2f;
//                 AI1.fitnessScore -= 3f;
//                 s.ties++;
//             }

//             //test
//             // NewGenareation();
//         }

//         private void NewGenareation()// shit code, needs work
//         {
//             Random rnd = new Random();
//             int killed = 0;
//             for (int i = 0; i < Players.Count; i++)
//             {
//                 if (Players[i].fitnessScore < 0)
//                 {
//                     Players.RemoveAt(i);
//                     i--;
//                     killed++;
//                 }
//             }

//             // int lowestAIs = (playerAmout / 2) - killed; // kill the lowset some amount
//             // float maxFitness = -10;
//             // while (lowestAIs > 0)
//             // {
//             //     bool killAI = false;
//             //     for (int j = 0; j < Players.Count; j++)
//             //     {
//             //         // if (rnd.Next(0, 2) == 1)
//             //         // {
//             //         //     Players.Add(new TicTacToeAIv2c());
//             //         //     newAI = true;
//             //         //     break;
//             //         // }
//             //         if (Players[j].fitnessScore > minFitness)
//             //         {
//             //             Players.Add(Players[j].GiveBirth()); // if you only have them give birth it should go faster, but. there is a lower diversety
//             //             killAI = true;
//             //             break;
//             //         }
//             //     }
//             //     if (!killAI)
//             //     {
//             //         i--;
//             //         minFitness -= 1f;
//             //     }
//             //     killed++;
//             //     lowestAIs--;
//             // }

//             float minFitness = winnerOgEachGame[winnerOgEachGame.Count - 1].fitnessScore;
//             for (int i = 0; i < killed; i++) // lets the top AIs give birth
//             {
//                 bool newAI = false;
//                 for (int j = 0; j < Players.Count; j++)
//                 {
//                     // if (rnd.Next(0, 2) == 1)
//                     // {
//                     //     Players.Add(new TicTacToeAIv2c());
//                     //     newAI = true;
//                     //     break;
//                     // }
//                     if (Players[j].fitnessScore > minFitness)
//                     {
//                         Players.Add(Players[j].GiveBirth()); // if you only have them give birth it should go faster, but. there is a lower diversety
//                         newAI = true;
//                         break;
//                     }
//                 }
//                 if (!newAI)
//                 {
//                     i--;
//                     minFitness -= 1f;
//                 }
//             }
//             ResetFitnessValues();

//             for (int i = 0; i < Players.Count(); i++)
//             {
//                 Players[i] = Players[i].GiveBirth();
//             }
//         }
//         private void ResetFitnessValues()
//         {
//             for (int i = 0; i < Players.Count(); i++)
//             {
//                 Players[i].fitnessScore = 0;
//             }
//         }
//     }
// }