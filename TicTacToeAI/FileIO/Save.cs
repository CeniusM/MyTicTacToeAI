using System.Text.Json;

namespace TicTacToeAI.IO
{
    class Save
    {
        private const string SaveFolder = @"TicTacToeAI\FileIO\Saves";
        public static void SaveAI(TicTacToeAI aI)
        {
            string newPath = SaveFolder + GetFileNameToSave();
            var x = JsonSerializer.Serialize(aI);
            List<string> lines = new List<string>();
            lines.Add(x);
            File.WriteAllLines(newPath, lines);
        }

        public static void SaveAIs(List<TicTacToeAI> aIs)
        {
            string newPath = SaveFolder + GetFileNameToSave();

            List<string> lines = new List<string>();
            foreach (TicTacToeAI aI in aIs)
            {
                var x = JsonSerializer.Serialize(aI);
                lines.Add(x);
            }

            File.WriteAllLines(newPath, lines);
        }

        private static string GetFileNameToSave()
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(SaveFolder + @"\num.txt").ToList();
            lines[0] = "" + (Int32.Parse(lines[0]) + 1);
            File.WriteAllLines(SaveFolder + @"\num.txt", lines);
            return @"\Save" + lines[0] + ".txt";
        }
    }
}