using System.Diagnostics;

namespace Day04;


internal static class Day04
{
    private const string InputFileName = "./Inputs/Puzzle.txt";
    internal static void Main()
    {
        string startString = File.ReadAllText(InputFileName);
        int startsWithFiveZeros = CalcFirstHash(startString, s => StartsWithNZeroes(s, 5));
        Console.WriteLine($"First hash with 5 zeros: {startsWithFiveZeros}");
        
        int startsWithSixZeros = CalcFirstHash(startString, s => StartsWithNZeroes(s, 6));
        Console.WriteLine($"First hash with 6 zeros: {startsWithSixZeros}");
    }

    private static int CalcFirstHash(string inputPrefix, Func<string, bool> resultPredicate)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        for (int n = 0; ; ++n)
        {
            string testString = inputPrefix + n;
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(testString);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            string hash = Convert.ToHexString(hashBytes);
            if (!resultPredicate(hash)) continue;

            return n;
        }
    }

    private static bool StartsWithNZeroes(string s, int nZeroes)
    {
        Debug.Assert(nZeroes >= 0);
        if (s.Length < nZeroes) return false;
        
        for (int i = 0; i < nZeroes; ++i)
        {
            if (s[i] != '0') return false;
        }
        return true;
    } 
}