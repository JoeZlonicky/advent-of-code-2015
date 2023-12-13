namespace Day05;

internal static class Part2Requirements
{
    internal static bool ContainsTwoPairsNonOverlapping(string s)
    {
        var foundPairs = new Dictionary<string, int>();
        for (int i = 0; i < s.Length - 1; ++i)
        {
            string pair = s.Substring(i, 2);
            if (foundPairs.TryGetValue(pair, out var foundPair))
            {
                if (foundPair < i - 1) return true;
            }
            else
            {
                foundPairs[pair] = i;
            }
        }
        return false;
    }

    internal static bool ContainsRepeatedLetterWithOneBetween(string s)
    {
        for (int i = 0; i < s.Length - 2; ++i)
        {
            if (s[i] == s[i + 2]) return true;
        }
        return false;
    }
}