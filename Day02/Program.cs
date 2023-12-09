namespace Day02;

internal static class Day02
{
    private static void Main()
    {
        const string inputFileName = "./Inputs/FullInput.txt";

        var boxes = (from line in File.ReadAllLines(inputFileName) where line != "" select new Box(line)).ToArray();
        var totalWrappingPaper = boxes.Aggregate(0, (total, box) => total + box.CalcRequiredWrappingPaper());
        var totalRibbon = boxes.Aggregate(0, (total, box) => total + box.CalcRequiredRibbon());

        Console.WriteLine($"Total wrapping paper: {totalWrappingPaper}\nTotal ribbon: {totalRibbon}");
    }
}
