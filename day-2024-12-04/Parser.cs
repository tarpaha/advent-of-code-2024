namespace day_2024_12_04;

public static class Parser
{
    public static Data Parse(string data)
    {
        if (string.IsNullOrEmpty(data))
            return new Data(0, 0, new char[0, 0]);
        
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;

        var letters = new char[width, height];
        for (var y = 0; y < height; y++)
        {
            var line = lines[y];
            for (var x = 0; x < width; x++)
            {
                letters[x, y] = line[x];
            }
        }        
        return new Data(width, height, letters);
    }
}