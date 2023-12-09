namespace Day02;

internal class Box
{
    private int Width { get; }
    private int Height { get; }
    private int Depth { get; }

    public Box(int width, int height, int depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public Box(string line)
    {
        var dimensions = from dimension in line.Split('x') select int.Parse(dimension);
        var enumerable = dimensions as int[] ?? dimensions.ToArray();
        Width = enumerable[0];
        Height = enumerable[1];
        Depth = enumerable[2];
    }
    
    public int CalcRequiredWrappingPaper()
    {
        var wh = Width * Height;
        var wd = Width * Depth;
        var hd = Height * Depth;
        var required = wh * 2 + wd * 2 + hd * 2;
        required += CalcSmallest(wh, wd, hd);
        return required;
    }

    public int CalcRequiredRibbon()
    {
        var wh = 2 * (Width + Height);
        var wd = 2 * (Width + Depth);
        var hd = 2 * (Height + Depth);

        var required = CalcSmallest(wh, wd, hd);
        required += Width * Height * Depth;
        return required;
    }
    
    private static int CalcSmallest(params int[] n)
    {
        return n.Min();
    }
}