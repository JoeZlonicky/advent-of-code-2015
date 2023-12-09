namespace Day03;

internal static class Day03
{
    private const string InputFileName = "./Inputs/PuzzleInput.txt";

    private static void Main(string[] args)
    {
        var text = File.ReadAllText(InputFileName);
        var nVisited = CountHousesVisited(ref text);
        var nVisitedWithRoboSanta = CountHousesVisited(ref text, 2);
        Console.WriteLine($"Houses visited with just one Santa: {nVisited}");
        Console.WriteLine($"Houses visited with Santa and Robo-Santa: {nVisitedWithRoboSanta}");
    }
    
    private static int CountHousesVisited(ref string text, int nSantas=1)
    {
        var visits = new Dictionary<(int x, int y), int>
        {
            [(0, 0)] = nSantas
        };
        var santaPositions = new (int x, int y)[nSantas];
        var currentSanta = 0;
        
        foreach (var c in text)
        {
            ref var pos = ref santaPositions[currentSanta];
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
            currentSanta = (currentSanta + 1) % nSantas;
        }

        return visits.Keys.Count;
    }
}
