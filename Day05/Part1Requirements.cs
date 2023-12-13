namespace Day05;

internal static class Part1Requirements
{
    private const string Vowels = "aeiou";
    
    internal static bool ContainsAtLeastNVowels(string s, int nVowels)
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

    internal static bool ContainsAtLeastNRepeatedLetters(string s, int nRepeated)
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
    
    internal static bool DoesNotContainAnyOf(string s, params string[] invalids)
    {
        return invalids.All(invalid => !s.Contains(invalid));
    }
}