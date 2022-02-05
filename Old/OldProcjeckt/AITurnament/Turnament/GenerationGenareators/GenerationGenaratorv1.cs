// using CS_TicTacToeAI;

// namespace TTT_Turnament
// {
//     class GenerationGenaratorv1
//     {
//         public static void NewGenerationvA(List<TicTacToeAIv3> players, List<TicTacToeAIv3> _winners)
//         {
//             Random rnd = new Random();
//             int winnerIndex = 0; // winner
//             int value = players[0].fitnessScore;
//             for (int i = 0; i < players.Count; i++)
//             {
//                 if (players[i].fitnessScore > value)
//                 {
//                     winnerIndex = i;
//                     value = players[i].fitnessScore;
//                 }
//             }

//             TicTacToeAIv3 winner = players[winnerIndex].GetClone();
//             _winners.Add(winner);

//             for (int i = 0; i < players.Count; i++)
//             {
//                 if (rnd.Next(0, 10) == 1)
//                     players[i] = players[i].GiveBirth();
//                 else
//                     players[i] = winner.GiveBirth();
//             }
//         }

//         public static void NewGenerationvB(List<TicTacToeAIv3> players, List<TicTacToeAIv3> _winners)
//         {

//         }
//     }
// }