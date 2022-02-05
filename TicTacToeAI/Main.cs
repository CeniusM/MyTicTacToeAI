using AIGUI;
using winForm;

namespace TicTacToeAI
{
    class Main
    {
        public NetworkPrinter _networkPrinter;
        public TTT_Turnament TTTturnament;
        public bool _isRunning = false;
        private bool _isPrinting = false;
        public Form1 form;
        public Main(Form1 form)
        {
            this.form = form;
            TTTturnament = new TTT_Turnament(100, 100, 2);
            _networkPrinter = new NetworkPrinter(this.form);

            TTTturnament.genarationDone += PrintWinner;
            form.KeyPress += KeyPress;
        }

        public void Start()
        {
            TTTturnament.Run();
        }

        private void PrintWinner(object? sender, EventArgs e)
        {
            if (_isPrinting) return;
            _isPrinting = true;
            _networkPrinter.PrintBrain(TTTturnament.winners[TTTturnament.winners.Count()-1].brain);
            _isPrinting = false;
        }

        private void KeyPress(object? sender, KeyPressEventArgs e)
        {

        }

        public void Stop() { TTTturnament.Stop(); _isRunning = false; }
    }
}