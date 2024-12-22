namespace day_2024_12_03.tests;

public class SolverTests
{
    private const string Data = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(161));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}