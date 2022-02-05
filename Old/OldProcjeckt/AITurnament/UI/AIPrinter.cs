// // this is used to print difrent ways of showing the neruol networks
// using CS_TicTacToeAI;

// namespace CS_MyAI
// {
//     class AIPrinter
//     {
//         private winForm.Form1 _Form;
//         private MyGame.GUI _GUI;
//         private List<TicTacToeAIv3> AI_To_Print;
//         private bool IsRunning = false;
//         public AIPrinter(winForm.Form1 _Form)
//         {
//             this._Form = _Form;
//             _GUI = new MyGame.GUI(_Form);
//             AI_To_Print = new List<TicTacToeAIv3>();
//         }

//         public void AddAI(TicTacToeAIv3 ai)
//         {
//             AI_To_Print.Add(ai);
//             if (!IsRunning)
//             {
//                 Start();
//                 BackEnd();
//             }
//         }

//         public void Start()
//         {
//             IsRunning = true;
//         }

//         public void Stop()
//         {
//             IsRunning = false;
//         }

//         private void BackEnd() // also disblay stats like genaration out of total genarations, games played and so on
//         {
//             while (IsRunning)
//             {
//                 if (AI_To_Print.Count != 0)
//                     PrintAI();
//                 else
//                     IsRunning = false;
//             }
//         }

//         private void PrintAI()
//         {

//         }
//     }
// }