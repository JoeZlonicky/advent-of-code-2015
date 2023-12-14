namespace Day06;

internal class LightGrid
{
    private int Width { get; set; }
    private int Height { get; set; }
    
    private bool[,] Rows { get; set; }
    
    internal LightGrid(int width, int height)
    {
        Width = width;
        Height = height;

        Rows = new bool[width, height];
    }

    internal int GetNTurnedOn()
    {
        return Rows.Cast<bool>().Count(b => b);
    }
    
    // Turns on a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void TurnOn(int x1, int y1, int x2, int y2)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = true;
            }
        }
    }

    // Turns off a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void TurnOff(int x1, int y1, int x2, int y2)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = false;
            }
        }
    }

    // Toggles a rectangle of lights from (x1, y1) to (x2, y2) inclusive
    internal void Toggle(int x1, int y1, int x2, int y2)
    {
        for (int x = x1; x <= x2; ++x)
        {
            for (int y = y1; y <= y2; ++y)
            {
                Rows[x, y] = !Rows[x, y];
            }
        }
    }
}