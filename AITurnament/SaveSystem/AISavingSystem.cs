using CS_TicTacToeAI;

namespace CS_TicTacToeAI.SaveingSystem
{
    class SaveingSystem // save one to begin with
    {
        public static string path = @"C:\GitHub\TicTacToeAI\AITurnament\SaveSystem\AISaves\Save1.txt";
        public static void SaveAI()
        {
            
        }
        public static void GetAI()
        {

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