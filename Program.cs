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


        //-----------------
        // //test
        // Random rnd = new Random();
        // int amout = 0;
        // for (int i = 0; i < 100; i++)
        // {
        //     if (rnd.Next(0, 2) == 1)
        //         amout++;
        // }
        // CS_MyConsole.MyConsole.WriteLine(amout.ToString());

        // float[,] myFlaots = CS_Random.MyRandom.RandomInputs2D(10, 2);
        // for (int i = 0; i < 10; i++)
        // {
        //     // for (int j = 0; j < 2; j++)
        //     // {
        //     //     CS_MyConsole.MyConsole.WriteLine(myFlaots[i,j].ToString());
        //     // }

        //     CS_MyConsole.MyConsole.WriteLine(myFlaots[i, 0].ToString() + ":" + myFlaots[i, 1].ToString());
        // }

        //-----------------



        // start again later
        Application.Run(myForm);





        // CS_TicTacToeAI.TicTacToeAI tttAI = new CS_TicTacToeAI.TicTacToeAI(myForm);

        // tttAI.Testing();
    }
    private static void GameThread(Form1 myForm)
    {
        PlayTTT.TTTgame game = new PlayTTT.TTTgame(myForm);

        game.Start();

        // TTT_Turnament.Turnament trunament = new TTT_Turnament.Turnament(myForm);

        // trunament.Start();

        /*
        CS_MyAI.MyAI myAI = new CS_MyAI.MyAI(myForm);

        myAI.Start();
        */
    }
}