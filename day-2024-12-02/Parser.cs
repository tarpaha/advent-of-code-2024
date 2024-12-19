namespace day_2024_12_02;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .AsParallel()
            .Select(line => new Report(line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray()))
            .ToArray());
    }
}