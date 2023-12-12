namespace Day04;


internal static class Day04
{
    private const string StartString = "yzbqklnj";
    internal static void Main()
    {
        int startsWithFiveZeros = CalcFirstIntegerPostfixHash(StartString, s => StartsWithNZeroes(s, 5));
        Console.WriteLine($"Answer for 5 zeros: {startsWithFiveZeros}");
        
        int startsWithSixZeros = CalcFirstIntegerPostfixHash(StartString, s => StartsWithNZeroes(s, 6));
        Console.WriteLine($"Answer for 6 zeros: {startsWithSixZeros}");
    }

    private static int CalcFirstIntegerPostfixHash(string prefix, Func<string, bool> predicate)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        for (int n = 0; ; ++n)
        {
            string testString = prefix + n;
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(testString);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            string hash = Convert.ToHexString(hashBytes);
            if (!predicate(hash)) continue;

            return n;
        }
    }

    private static bool StartsWithNZeroes(string s, int nZeroes)
    {
        if (s.Length < nZeroes) return false;
        
        for (int i = 0; i < nZeroes; ++i)
        {
            if (s[i] != '0') return false;
        }
        return true;
    } 
}