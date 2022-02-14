/*
To-do List:

implement a good! saving and loading sytem
implement a good way to see the improvement of the best player
improve the newGeneartion methods

*/
using AIGUI;
using winForm;

namespace TicTacToeAI
{
    class Main
    {
        public NetworkPrinter _networkPrinter;
        public TTT_TurnamentT TTTturnament;
        public bool _isRunning = false;
        private bool _isPrinting = false;
        public Form1 form;
        public Main(Form1 form)
        {
            this.form = form;
            TTTturnament = new TTT_TurnamentT(100, 1000000, 6);
            _networkPrinter = new NetworkPrinter(this.form);

            TTTturnament.genarationDone += PrintWinner;
            form.KeyPress += KeyPress;
        }

        public void Start()
        {
            TTTturnament.Run();
        }

        private void PrintWinner(object? sender, EventArgs e) // idk when this is called if it runs on a separete thread from the turnament,
                                                              // but if not, make it into its own thread
        {
            if (_isPrinting) return;
            _isPrinting = true;
            _networkPrinter.PrintBrain(TTTturnament.winners[TTTturnament.winners.Count() - 1].brain);
            _isPrinting = false;
        }

        private void KeyPress(object? sender, KeyPressEventArgs e)
        {
            return; // the code dosent work :D
            if (e.KeyChar == 'w')
            {
                TTTturnament.SetThreadAmout(TTTturnament.threadAmount + 1);
            }
            else if (e.KeyChar == 's')
            {
                TTTturnament.SetThreadAmout(TTTturnament.threadAmount - 1);
            }
        }

        public void Stop()
        {
            TTTturnament.Stop(); _isRunning = false;

            // save the players
            IO.Save.SaveAI(TTTturnament.winners[TTTturnament.winners.Count - 1]); // just the best player for now


            // also make it so it takes the data from Console and gets it into a new txt called log + what ever the last one was +1
        }
    }
}