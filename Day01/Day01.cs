namespace Day01;

internal static class Day01
{
    private static void Main()
    {
        const string inputFileName = "./Inputs/FullInput.txt";
        string text = File.ReadAllText(inputFileName);

        int floor = 0;
        int positionOfEnteringBasement = -1;
        for (int i = 0; i < text.Length; ++i)
        {
            char c = text[i];
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

        Console.WriteLine($"Final floor: {floor}");
        Console.WriteLine($"Position of entering basement: {positionOfEnteringBasement}");
    }
}
