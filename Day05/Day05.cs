namespace Day05;


internal static class Day05
{
    private const string InputFileName = "Inputs/Puzzle.txt";
    private const string Vowels = "aeiou";

    private static void Main()
    {
        string[] lines = File.ReadAllLines(InputFileName);
        int nValid = lines.Aggregate(0, (n, s) =>
        {
            bool isValid = ContainsAtLeastNVowels(s, 3);
            isValid &= ContainsAtLeastNRepeatedLetters(s, 2);
            isValid &= DoesNotContainAnyOf(s, "ab", "cd", "pq", "xy");
            return isValid ? n + 1 : n;
        });
        Console.WriteLine($"N valid strings: {nValid}");
    }

    private static bool ContainsAtLeastNVowels(string s, int nVowels)
    {
        if (nVowels == 0) return true;
        
        int vowelCount = 0;
        foreach (char c in s)
        {
            if (Vowels.Contains(c)) ++vowelCount;
            if (vowelCount >= nVowels) return true;
        }

        return false;
    }

    private static bool ContainsAtLeastNRepeatedLetters(string s, int nRepeated)
    {
        if (nRepeated == 0) return true;

        int repeatCount = 0;
        char repeatChar = '\0';
        foreach (char c in s)
        {
            if (repeatChar == '\0')
            {
                repeatChar = c;
                repeatCount = 1;
                if (repeatCount == nRepeated) return true;
            }
            else if (c == repeatChar) {
                ++repeatCount;
                if (repeatCount == nRepeated) return true;
            }
            else
            {
                repeatCount = 1;
                repeatChar = c;
            }
        }

        return false;
    }

    private static bool DoesNotContainAnyOf(string s, params string[] invalids)
    {
        return invalids.All(invalid => !s.Contains(invalid));
    }
}