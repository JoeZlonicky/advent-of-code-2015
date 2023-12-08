namespace Day02;

public record Box
{
    int width;
    int height;
    int depth;

    public Box(int width, int height, int depth)
    {
        this.width = width;
        this.height = height;
        this.depth = depth;
    }

    public Box(string line)
    {
        var dimensions = from dimension in line.Split('x') select Int32.Parse(dimension);
        var enumerable = dimensions as int[] ?? dimensions.ToArray();
        this.width = enumerable[0];
        this.height = enumerable[1];
        this.depth = enumerable[2];
    }
    
    public int CalcRequiredWrappingPaper()
    {
        var wh = width * height;
        var wd = width * depth;
        var hd = height * depth;
        var required = wh * 2 + wd * 2 + hd * 2;
        required += CalcSmallest(wh, wd, hd);
        return required;
    }

    public int CalcRequiredRibbon()
    {
        var wh = 2 * (width + height);
        var wd = 2 * (width + depth);
        var hd = 2 * (height + depth);

        var required = CalcSmallest(wh, wd, hd);
        required += width * height * depth;
        return required;
    }
    
    private static int CalcSmallest(params int[] n)
    {
        return n.Min();
    }
}