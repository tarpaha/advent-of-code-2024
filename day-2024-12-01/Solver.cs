namespace day_2024_12_01;

public static class Solver
{
    public static object Part1(Data data)
    {
        int[] left = null!;
        int[] right = null!;

        Parallel.Invoke(
            () => { left = data.Left.OrderBy(n => n).ToArray(); },
            () => { right = data.Right.OrderBy(n => n).ToArray(); }
        );
        
        return Enumerable
            .Range(0, left.Length)
            .AsParallel()
            .Select(index => Math.Abs(left[index] - right[index]))
            .Sum();
    }

    public static object Part2(Data data)
    {
        var rightFrequency = data.Right
            .GroupBy(n => n)
            .ToDictionary(g => g.Key, g => g.Count());

        return data.Left
            .AsParallel()
            .Select(number => number * rightFrequency.GetValueOrDefault(number, 0))
            .Sum();
    }
}