namespace Day01;

internal static class Day01
{
    private const string InputFileName = "./Inputs/FullInput.txt";
    private static void Main()
    {
        string text = File.ReadAllText(InputFileName);

        (int finalFloor, int positionOfEnteringBasement) result = NavigateBuilding(text);
        
        Console.WriteLine($"Final floor: {result.finalFloor}");
        Console.WriteLine($"Position of entering basement: {result.positionOfEnteringBasement}");
    }

    private static (int finalFloor, int positionOfEnteringBasement) NavigateBuilding(string directions)
    {
        int floor = 0;
        int positionOfEnteringBasement = -1;
        for (int i = 0; i < directions.Length; ++i)
        {
            char c = directions[i];
            switch (c)
            {
                case '(':
                    floor += 1;
                    break;
                case ')':
                    floor -= 1;
                    if (floor == -1 && positionOfEnteringBasement == -1)
                    {
                        positionOfEnteringBasement = i + 1;
                    }
                    break;
            }
        }

        return (floor, positionOfEnteringBasement);
    }
}
