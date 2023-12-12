namespace Day03;

internal static class Day03
{
    private const string InputFileName = "./Inputs/PuzzleInput.txt";

    private static void Main()
    {
        string text = File.ReadAllText(InputFileName);
        Console.WriteLine($"Houses visited with just one Santa: {CountHousesVisited(text)}");
        Console.WriteLine($"Houses visited with Santa and Robo-Santa: {CountHousesVisited(text, 2)}");
    }
    
    private static int CountHousesVisited(string text, int nSantas=1)
    {
        var visits = new Dictionary<(int x, int y), int>
        {
            [(0, 0)] = nSantas
        };
        var santaPositions = new (int x, int y)[nSantas];
        int currentSanta = 0;
        
        foreach (char c in text)
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
