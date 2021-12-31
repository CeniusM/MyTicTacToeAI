namespace winForm;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Form1 myForm = new Form1();

        var gameThread = new Thread(() => GameThread(myForm));

        myForm.Shown += (s, a) =>
        {
            gameThread.Start();
        };
        myForm.FormClosing += (s, a) => gameThread.Join();


        //for now
        Application.Run(myForm);



        

        // CS_TicTacToeAI.TicTacToeAI tttAI = new CS_TicTacToeAI.TicTacToeAI(myForm);

        // tttAI.Testing();
    }
    private static void GameThread(Form1 myForm)
    {
        // PlayTTT.TTTgame game = new PlayTTT.TTTgame(myForm);

        // game.Start();

        // TTT_Turnament.Turnament trunament = new TTT_Turnament.Turnament(myForm);

        // trunament.Start();
    }
}