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
        var dimensions = (from dimension in line.Split('x') select int.Parse(dimension)).ToArray();
        Width = dimensions[0];
        Height = dimensions[1];
        Depth = dimensions[2];
    }
    
    public int CalcRequiredWrappingPaper()
    {
        int wh = Width * Height;
        int wd = Width * Depth;
        int hd = Height * Depth;
        int required = wh * 2 + wd * 2 + hd * 2;
        required += Min(wh, wd, hd);
        return required;
    }

    public int CalcRequiredRibbon()
    {
        int wh = 2 * (Width + Height);
        int wd = 2 * (Width + Depth);
        int hd = 2 * (Height + Depth);

        int required = Min(wh, wd, hd);
        required += Width * Height * Depth;
        return required;
    }
    
    private static int Min(params int[] n)
    {
        return n.Min();
    }
}