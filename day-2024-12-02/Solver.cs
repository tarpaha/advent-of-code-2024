namespace day_2024_12_02;

public static class Solver
{
    public static object Part1(Data data)
    {
        return data
            .Reports
            .AsParallel()
            .Count(IsReportSafe);
    }

    public static object Part2(Data data)
    {
        return null!;
    }

    public static bool IsReportSafe(Report report)
    {
        var increasing = false;
        var decreasing = false;
        for (var i = 1; i < report.Levels.Length; i++)
        {
            var diff = report.Levels[i] - report.Levels[i - 1];
            increasing |= diff > 0;
            decreasing |= diff < 0;
            if(diff == 0 || Math.Abs(diff) > 3 || (increasing && decreasing))
                return false;
        }
        return true;
    }
}