using CS_TicTacToeAI;
using CS_MyConsole;

namespace CS_TicTacToeAI
{
    class SaveingSystem // save one to begin with
    {
        public static string path = @"C:\GitHub\TicTacToeAI\AITurnament\SaveSystem\AISaves\Save1.txt";
        public static void SaveAI(TicTacToeAIv3 AI) // make it so it just takes the weights and mutatebility and not the ai class
        {
            string Data = "";
            Data += "Weights\n";
            Data += "w1\n";
            for (int i = 0; i < AI._w1.GetLength(0); i++)
            {
                for (int j = 0; j < AI._w1.GetLength(1); j++)
                {
                    Data += AI._w1[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "w2\n";
            for (int i = 0; i < AI._w2.GetLength(0); i++)
            {
                for (int j = 0; j < AI._w2.GetLength(1); j++)
                {
                    Data += AI._w2[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "w3\n";
            for (int i = 0; i < AI._w3.GetLength(0); i++)
            {
                for (int j = 0; j < AI._w3.GetLength(1); j++)
                {
                    Data += AI._w3[i, j] + ",";
                }
                Data += "\n";
            }
            Data += "mutability \n";
            Data += AI._mutability + "\n";

            Data += "fitnessScore \n";
            Data += AI.fitnessScore + "\n";

            MyConsole.WriteLine(Data, path);
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