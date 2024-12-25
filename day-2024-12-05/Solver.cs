namespace day_2024_12_05;

public static class Solver
{
    public static object Part1(Data data)
    {
        var deniedCombinations = data.Rules
            .Select(rule => (rule.Right, rule.Left))
            .ToHashSet();

        return data.Updates
            .Where(update => UpdateIsCorrect(update, deniedCombinations))
            .Sum(update => update.Numbers[update.Numbers.Count / 2]);
    }

    public static object Part2(Data data)
    {
        return null!;
    }
    
    private static bool UpdateIsCorrect(Update update, HashSet<(int, int)> deniedCombinations)
    {
        for (var left = 0; left < update.Numbers.Count; left++)
        {
            for (var right = left + 1; right < update.Numbers.Count; right++)
            {
                if (deniedCombinations.Contains((update.Numbers[left], update.Numbers[right])))
                    return false;
            }
        }
        return true;
    }
}