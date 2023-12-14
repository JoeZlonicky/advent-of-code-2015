namespace Day06;

internal class LightGrid
{
    private int Width { get; set; }
    private int Height { get; set; }
    
    private int[,] Rows { get; set; }
    
    internal LightGrid(int width, int height)
    {
        Width = width;
        Height = height;

        Rows = new int[width, height];
    }

    internal int GetNTurnedOn()
    {
        return Rows.Cast<int>().Count(i => i == 1);
    }
    
    internal int SumLights()
    {
        return Rows.Cast<int>().Aggregate(0, (sum, i) => sum + i);
    }
    
    // Turns on (set to one) a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void TurnOn(int x1, int y1, int x2, int y2)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = 1;
            }
        }
    }

    // Turns off (set to zero) a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void TurnOff(int x1, int y1, int x2, int y2)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = 0;
            }
        }
    }

    // Toggles (0 if > 0, 1 if 0) a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void Toggle(int x1, int y1, int x2, int y2)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = Rows[x, y] == 1 ? 0 : 1;
            }
        }
    }

    // Modifies the value of a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void Modify(int x1, int y1, int x2, int y2, int amount)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = Math.Max(Rows[x, y] + amount, 0);
            }
        }
    }

    internal void Reset()
    {
        TurnOff(0, 0, Width - 1, Height - 1);
    }
}