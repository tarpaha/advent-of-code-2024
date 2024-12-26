namespace day_2024_12_06;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;
        var cells = new char[width, height];
        var (startX, startY) = (0, 0);
        for (var y = 0; y < height; y++)
        {
            var line = lines[y];
            for (var x = 0; x < width; x++)
            {
                var ch = line[x];
                cells[x, y] = ch;
                if(ch == '^')
                    (startX, startY) = (x, y);
            }
        }
        return new Data(width, height, cells, startX, startY);
    }
}