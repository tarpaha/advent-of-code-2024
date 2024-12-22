namespace day_2024_12_03.tests;

public class SolverTests
{
    [TestCase("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161)]
    public void Part1(string input, int expected)
    {
        Assert.That(Solver.Part1(Parser.Parse(input)), Is.EqualTo(expected));
    }
    
    [TestCase("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48)]
    public void Part2(string input, int expected)
    {
        Assert.That(Solver.Part2(Parser.Parse(input)), Is.EqualTo(expected));
    }
}