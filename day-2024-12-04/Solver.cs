namespace day_2024_12_04;

public static class Solver
{
    private const string StringToSearch = "XMAS";
    
    public static object Part1(Data data)
    {
        var sum = 0;
        for (var x = 0; x < data.Width; x++)
        for (var y = 0; y < data.Height; y++)
        {
            sum += GetStringOccurrences(data, x, y, StringToSearch);
        }
        return sum;
    }

    public static object Part2(Data data)
    {
        return null!;
    }

    private static int GetStringOccurrences(Data data, int x, int y, string str)
    {
        var occurrences = 0;
        for (var dx = -1; dx <= 1; dx++)
        for (var dy = -1; dy <= 1; dy++)
        {
            if(dx == 0 && dy == 0)
                continue;
            if(IsStringPresent(data, x, y, dx, dy, str))
                occurrences += 1;
        }
        return occurrences;
    }

    private static bool IsStringPresent(Data data, int x, int y, int dx, int dy, string str)
    {
        foreach (var ch in str)
        {
            if (x < 0 || x >= data.Width || y < 0 || y >= data.Height)
                return false;
            if (data.Letters[x, y] != ch)
                return false;
            x += dx;
            y += dy;
        }

        return true;
    }
}