using System.Text.RegularExpressions;

namespace Day06;

internal static class Day06
{
    private const string InputFileName = "Inputs/Puzzle.txt";
    private const string InputLineRegex = @"([a-zA-Z ]*)(\d*),(\d*)(?:[a-zA-Z ]*)(\d*),(\d*)";
    
    private const int GridWidth = 1000;
    private const int GridHeight = 1000;
    
    private static void Main()
    {
        var grid = new LightGrid(GridWidth, GridHeight);
        var re = new Regex(InputLineRegex, RegexOptions.IgnoreCase);
        string[] inputsLines = File.ReadAllLines(InputFileName);
        
        foreach (string line in inputsLines)
        {
            var match = re.Match(line);
            if (!match.Success) continue;
            
            string instruction = match.Groups[1].Value.Trim();
            int x1 = int.Parse(match.Groups[2].Value);
            int y1 = int.Parse(match.Groups[3].Value);
            int x2 = int.Parse(match.Groups[4].Value);
            int y2 = int.Parse(match.Groups[5].Value);
            switch (instruction)
            {
                case "toggle":
                    grid.Toggle(x1, y1, x2, y2);
                    break;
                case "turn off":
                    grid.TurnOff(x1, y1, x2, y2);
                    break;
                case "turn on":
                    grid.TurnOn(x1, y1, x2, y2);
                    break;
            }
        }
        
        Console.WriteLine($"Lights on: {grid.GetNTurnedOn()}");
    }
}