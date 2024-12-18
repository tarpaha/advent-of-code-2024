namespace day_2024_12_01;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var left = new int[lines.Length];
        var right = new int[lines.Length];

        Parallel.For(0, lines.Length, index =>
        {
            var pair = lines[index].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            left[index] = int.Parse(pair[0]);
            right[index] = int.Parse(pair[1]);
        });

        return new Data(left, right);
    }
}