namespace Day01;

internal static class Day01
{
    private static void Main()
    {
        const string inputFileName = "./Inputs/FullInput.txt";
        var text = File.ReadAllText(inputFileName);

        var floor = 0;
        var positionOfEnteringBasement = -1;

        for (var i = 0; i < text.Length; ++i)
        {
            var c = text[i];
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

        Console.WriteLine($"Final floor: {floor}\nPosition of entering basement: {positionOfEnteringBasement}");
    }
}
