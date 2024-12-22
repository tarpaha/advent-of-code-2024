namespace day_2024_12_02;

public static class Solver
{
    public static object Part1(Data data)
    {
        return data
            .Reports
            .AsParallel()
            .Count(report => IsReportSafe(report));
    }

    public static object Part2(Data data)
    {
        return data
            .Reports
            .AsParallel()
            .Count(IsReportSafeWithDampener);
    }

    public static bool IsReportSafeWithDampener(Report report)
    {
        var isSafe = IsReportSafe(report);
        for(var index = 0; index < report.Levels.Length && !isSafe; index++)
        {
            isSafe |= IsReportSafe(report, index);
        }
        return isSafe;
    }

    public static bool IsReportSafe(Report report, int? exceptIndex = null)
    {
        var increasing = false;
        var decreasing = false;
        var (previous, start) = exceptIndex == 0
            ? (report.Levels[1], 2)
            : (report.Levels[0], 1);
        for (var index = start; index < report.Levels.Length; index++)
        {
            if(exceptIndex == index)
                continue;
            var diff = report.Levels[index] - previous;
            increasing |= diff > 0;
            decreasing |= diff < 0;
            if(diff == 0 || Math.Abs(diff) > 3 || (increasing && decreasing))
                return false;
            previous = report.Levels[index];
        }
        return true;
    }
}