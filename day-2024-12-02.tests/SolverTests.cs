namespace day_2024_12_02.tests;

public class SolverTests
{
    private const string Data = """
                                7 6 4 2 1
                                1 2 7 8 9
                                9 7 6 2 1
                                1 3 2 4 5
                                8 6 4 4 1
                                1 3 6 7 9
                                """;

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(2));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }

    [TestCase(0, true)]
    [TestCase(1, false)]
    [TestCase(2, false)]
    [TestCase(3, false)]
    [TestCase(4, false)]
    [TestCase(5, true)]
    public void IsReportSafe_Works_Correctly(int reportIndex, bool expected)
    {
        var data = Parser.Parse(Data);
        Assert.That(Solver.IsReportSafe(data.Reports[reportIndex]), Is.EqualTo(expected));
    }
}