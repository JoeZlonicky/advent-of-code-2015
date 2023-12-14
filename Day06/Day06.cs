using System.Text.RegularExpressions;

namespace Day06;

internal static class Day06
{
    private const string InputFileName = "Inputs/Puzzle.txt";
    private const string InputLineRegex = @"([a-zA-Z ]*)(\d*),(\d*)(?:[a-zA-Z ]*)(\d*),(\d*)";
    
    private const int GridWidth = 1000;
    private const int GridHeight = 1000;

    private delegate void GridInstructionHandler(LightGrid grid, string instruction, int x1, int y1, int x2, int y2);
    
    private static void Main()
    {
        string[] inputsLines = File.ReadAllLines(InputFileName);
        var grid = new LightGrid(GridWidth, GridHeight);
        PerformInstructionsOnGrid(grid, inputsLines, PartOneInstructions);
        Console.WriteLine($"Lights on: {grid.GetNTurnedOn()}");
        
        grid.Reset();
        PerformInstructionsOnGrid(grid, inputsLines, PartTwoInstructions);
        Console.WriteLine($"---\nTotal value of lights: {grid.SumLights()}");
    }

    private static void PerformInstructionsOnGrid(LightGrid grid, IEnumerable<string> instructions, GridInstructionHandler handler)
    {
        var re = new Regex(InputLineRegex, RegexOptions.IgnoreCase);
        
        foreach (string line in instructions)
        {
            var match = re.Match(line);
            if (!match.Success) continue;
            
            string instruction = match.Groups[1].Value.Trim();
            int x1 = int.Parse(match.Groups[2].Value);
            int y1 = int.Parse(match.Groups[3].Value);
            int x2 = int.Parse(match.Groups[4].Value);
            int y2 = int.Parse(match.Groups[5].Value);

            handler(grid, instruction, x1, y1, x2, y2);
        }
    }
    private static void PartOneInstructions(LightGrid grid, string instruction, int x1, int y1, int x2, int y2)
    {
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
    
    private static void PartTwoInstructions(LightGrid grid, string instruction, int x1, int y1, int x2, int y2)
    {
        switch (instruction)
        {
            case "toggle":
                grid.Modify(x1, y1, x2, y2, 2);
                break;
            case "turn off":
                grid.Modify(x1, y1, x2, y2, -1);
                break;
            case "turn on":
                grid.Modify(x1, y1, x2, y2, 1);
                break;
        }
    }
}