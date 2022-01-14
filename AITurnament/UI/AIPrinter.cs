// this is used to print difrent ways of showing the neruol networks
using CS_TicTacToeAI;

namespace CS_MyAI
{
    class AIPrinter
    {
        private winForm.Form1 _Form;
        private MyGame.GUI _GUI;
        public AIPrinter(winForm.Form1 _Form)
        {
            this._Form = _Form;
            _GUI = new MyGame.GUI(_Form);
        }
        public void PrintStanderdNetwork(float[] _input, float[,] _w1, float[] _hidden_layer1, float[,] _w2, float[] _hidden_layer2, float[,] _w3, float[] _output)
        {
            
        }
        private void PrintLayer()
        {
            
        }
    }
}