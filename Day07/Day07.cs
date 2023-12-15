namespace Day07;

internal static class Day07
{
    private const string InputFileName = "Inputs/Puzzle.txt";
    // (LHS?)(AND|OR|LSHIFT|RSHIFT|NOT)?(RHS?)->(OUTPUT)
    private const string CommandPattern = @"([a-z\d]*)(?: *)(AND|OR|RSHIFT|LSHIFT|NOT)?(?: *)([a-z\d]*)(?: *)->(?: *)([a-z]*)";
    private static void Main()
    {
        
    }
}