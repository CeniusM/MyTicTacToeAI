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
            Turnamentv1 trunament = new Turnamentv1(9, 9, 2);

            trunament.Start();
        }
    }
}