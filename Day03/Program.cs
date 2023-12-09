namespace Day03;

internal static class Day03
{
    private const string InputFileName = "./Inputs/FullInput.txt";
    
    private static void Main(string[] args)
    {
        var text = File.ReadAllText(InputFileName);
        
        var visits = new Dictionary<(int x, int y), int>
        {
            [(0, 0)] = 1
        };
        (int x, int y) pos = (0, 0);
        
        foreach (var c in text)
        {
            switch (c)
            {
                case '<':
                    pos.x -= 1;
                    break;
                case '^':
                    pos.y += 1;
                    break;
                case '>':
                    pos.x += 1;
                    break;
                case 'v':
                    pos.y -= 1;
                    break;
            }

            visits[pos] = visits.GetValueOrDefault(pos, 0) + 1;
        }
        Console.WriteLine($"Houses visited: {visits.Keys.Count}");
    }
}
