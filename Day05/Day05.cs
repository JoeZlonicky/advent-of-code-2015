namespace Day05;


internal static class Day05
{
    private const string InputFileName = "Inputs/Puzzle.txt";
    
    private static void Main()
    {
        string[] lines = File.ReadAllLines(InputFileName);
        
        int nValidPart1 = lines.Aggregate(0, (n, s) =>
        {
            bool isValid = Part1Requirements.ContainsAtLeastNVowels(s, 3);
            isValid &= Part1Requirements.ContainsAtLeastNRepeatedLetters(s, 2);
            isValid &= Part1Requirements.DoesNotContainAnyOf(s, "ab", "cd", "pq", "xy");
            return isValid ? n + 1 : n;
        });
        
        int nValidPart2 = lines.Aggregate(0, (n, s) =>
        {
            bool isValid = Part2Requirements.ContainsTwoPairsNonOverlapping(s);
            isValid &= Part2Requirements.ContainsRepeatedLetterWithOneBetween(s);
            return isValid ? n + 1 : n;
        });
        
        Console.WriteLine($"N valid strings for part 1: {nValidPart1}");
        Console.WriteLine($"N valid strings for part 2: {nValidPart2}");
    }

    

    
}