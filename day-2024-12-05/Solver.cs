namespace day_2024_12_05;

public static class Solver
{
    public static object Part1(Data data)
    {
        var deniedCombinations = GetDeniedCombinations(data);
        return data.Updates
            .Where(update => UpdateIsCorrect(update, deniedCombinations))
            .Sum(update => update.Numbers[update.Numbers.Count / 2]);
    }

    public static object Part2(Data data)
    {
        var deniedCombinations = GetDeniedCombinations(data);
        return data.Updates
            .Select(update => FixUpdateAndReturnMiddle(update, deniedCombinations))
            .Sum(result => result ?? 0);
    }
    
    private static HashSet<(int Right, int Left)> GetDeniedCombinations(Data data)
    {
        var deniedCombinations = data.Rules
            .Select(rule => (rule.Right, rule.Left))
            .ToHashSet();
        return deniedCombinations;
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
    
    private static int? FixUpdateAndReturnMiddle(Update update, HashSet<(int, int)> deniedCombinations)
    {
        var numbers = update.Numbers.ToArray();
        var correct = true;
        
        while (true)
        {
            var swapped = false;
            for (var left = 0; !swapped && left < numbers.Length; left++)
            {
                for (var right = left + 1; !swapped && right < numbers.Length; right++)
                {
                    if (deniedCombinations.Contains((numbers[left], numbers[right])))
                    {
                        (numbers[left], numbers[right]) = (numbers[right], numbers[left]);
                        correct = false;
                        swapped = true;
                    }
                }
            }

            if (correct)
                return null;
            
            if(!swapped)
                return numbers[numbers.Length / 2];
        }
    }
}