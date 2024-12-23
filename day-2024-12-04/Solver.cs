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
        var sum = 0;
        for (var x = 0; x < data.Width; x++)
        for (var y = 0; y < data.Height; y++)
        {
            if (XmasFound(data, x, y))
                sum += 1;
        }
        return sum;
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
    
    private static bool XmasFound(Data data, int x, int y)
    {
        if(data.Letters[x, y] != 'A')
            return false;
        if(x < 1 || x >= data.Width - 1 || y < 1 || y >= data.Height - 1)
            return false;
        var diagonalOne = (data.Letters[x - 1, y - 1] == 'M' && data.Letters[x + 1, y + 1] == 'S') ||
                          (data.Letters[x - 1, y - 1] == 'S' && data.Letters[x + 1, y + 1] == 'M');
        if(!diagonalOne)
            return false;
        var diagonalTwo = (data.Letters[x + 1, y - 1] == 'M' && data.Letters[x - 1, y + 1] == 'S') ||
                          (data.Letters[x + 1, y - 1] == 'S' && data.Letters[x - 1, y + 1] == 'M');
        return diagonalTwo;
    }
}