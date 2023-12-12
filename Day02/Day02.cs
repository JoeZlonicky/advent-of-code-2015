namespace Day02;

internal static class Day02
{
    private const string InputFileName = "./Inputs/FullInput.txt";
    private static void Main()
    {
        var boxes = (from line in File.ReadAllLines(InputFileName) where line != "" select new Box(line)).ToArray();
        int totalWrappingPaper = boxes.Aggregate(0, (total, box) => total + box.CalcRequiredWrappingPaper());
        int totalRibbon = boxes.Aggregate(0, (total, box) => total + box.CalcRequiredRibbon());

        Console.WriteLine($"Total wrapping paper: {totalWrappingPaper}");
        Console.WriteLine($"Total ribbon: {totalRibbon}");
    }
}
