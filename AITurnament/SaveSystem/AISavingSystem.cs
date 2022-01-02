using CS_TicTacToeAI;
using CS_MyConsole;

namespace CS_TicTacToeAI
{
    class SaveingSystem // save one to begin with
    {
        public static string path = @"C:\GitHub\TicTacToeAI\AITurnament\SaveSystem\AISaves\Save1.txt";
        public static void SaveAI(TicTacToeAIv2b AI)
        {
            string Data = "";
            Data += "Weights\n";
            Data += "w1\n";
            for (int i = 0; i < AI.w1.GetLength(0); i++)
            {
                for (int j = 0; j < AI.w1.GetLength(1); j++)
                {
                    Data += AI.w1[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "w2\n";
            for (int i = 0; i < AI.w2.GetLength(0); i++)
            {
                for (int j = 0; j < AI.w2.GetLength(1); j++)
                {
                    Data += AI.w2[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "w3\n";
            for (int i = 0; i < AI.w3.GetLength(0); i++)
            {
                for (int j = 0; j < AI.w3.GetLength(1); j++)
                {
                    Data += AI.w3[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "w4\n";
            for (int i = 0; i < AI.w4.GetLength(0); i++)
            {
                for (int j = 0; j < AI.w4.GetLength(1); j++)
                {
                    Data += AI.w4[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "mutability \n";
            Data += AI.mutability + "\n";

            Data += "fitnessScore \n";
            Data += AI.fitnessScore + "\n";

            MyConsole.WriteLine(Data, path);
        }
        public static TicTacToeAIv2b GetAIv2b(string path)
        {
            // split the the string and convert it to the ai

            // after this, test it by saving it again and compare if its the exact same

            return new TicTacToeAIv2b();
        }
        private static void WriteLine(string text)
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            lines.Add(text);
            File.WriteAllLines(path, lines);
        }
        private static void Write(string text)
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            lines[lines.Count() - 1] = lines[lines.Count() - 1] + text;
            File.WriteAllLines(path, lines);
        }
    }
}