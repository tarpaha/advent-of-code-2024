namespace day_2024_12_05;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var lineIndex = 0;
        
        var rules = new List<Rule>();
        for (; lineIndex < lines.Length; lineIndex++)
        {
            var pair = lines[lineIndex].Split('|');
            if (pair.Length != 2)
                break;
            rules.Add(new Rule(int.Parse(pair[0]), int.Parse(pair[1])));
        }
        
        var updates = new List<Update>();
        for (; lineIndex < lines.Length; lineIndex++)
        {
            updates.Add(new Update(lines[lineIndex].Split(',').Select(int.Parse).ToList()));
        }
        
        return new Data(rules, updates);
    }
}