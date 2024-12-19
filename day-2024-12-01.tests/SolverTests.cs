namespace day_2024_12_01.tests;

public class SolverTests
{
    private const string Data = """
                                3   4
                                4   3
                                2   5
                                1   3
                                3   9
                                3   3
                                """;

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(11));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(31));
    }
}