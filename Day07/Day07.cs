using System.Text.RegularExpressions;

namespace Day07;

internal static class Day07
{
    private const string InputFileName = "Inputs/Example.txt";
    // (LHS?)(AND|OR|LSHIFT|RSHIFT|NOT)?(RHS?)->(OUTPUT)
    private const string CommandPattern = @"([a-z\d]*)(?: *)(AND|OR|RSHIFT|LSHIFT|NOT)?(?: *)([a-z\d]*)(?: *)->(?: *)([a-z]*)";
    private static void Main()
    {
        string[] lines = File.ReadAllLines(InputFileName);
        var re = new Regex(CommandPattern, RegexOptions.IgnoreCase);
        var emulator = new Emulator();
        
        foreach (string line in lines)
        {
            var match = re.Match(line);
            if (!match.Success) continue;
            
            string leftOperand = match.Groups[1].Value.Trim();
            string operation = match.Groups[2].Value.Trim();
            string rightOperand = match.Groups[3].Value.Trim();
            string output = match.Groups[4].Value.Trim();
            if (leftOperand == "NOT")
            {
                operation = leftOperand;
                leftOperand = "";
            }
            
            emulator.ExecuteCommand(leftOperand, operation, rightOperand, output);
        }
        
        Console.WriteLine(emulator.GetVariableValue("a"));
    }
}