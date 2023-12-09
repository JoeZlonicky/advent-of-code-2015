using System.Diagnostics;

namespace Day04;


internal static class Day04
{
    internal static void Main()
    {
        const string startString = "yzbqklnj";
        var startsWithFiveZeros = CalcFirstIntegerAppendedHash(startString, s => StartsWithNZeroes(s, 5));
        var startsWithSixZeros = CalcFirstIntegerAppendedHash(startString, s => StartsWithNZeroes(s, 6));
        Console.WriteLine($"Answer for 5 zeros: {startsWithFiveZeros}\nAnswer for 6 zeros: {startsWithSixZeros}");
    }

    private static int CalcFirstIntegerAppendedHash(string prefix, Func<string, bool> predicate)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        
        for (var n = 0; ; ++n)
        {
            var testString = prefix + n.ToString();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(testString);
            var hashBytes = md5.ComputeHash(inputBytes);

            var hash = Convert.ToHexString(hashBytes);
            if (!predicate(hash)) continue;

            return n;
        }
    }

    private static bool StartsWithNZeroes(string s, int nZeroes)
    {
        if (s.Length < nZeroes) return false;
        
        for (var i = 0; i < nZeroes; ++i)
        {
            if (s[i] != '0') return false;
        }

        return true;
    } 
}