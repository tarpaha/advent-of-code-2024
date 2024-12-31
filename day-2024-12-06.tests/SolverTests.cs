namespace day_2024_12_06.tests;

public class SolverTests
{
    private const string Data = """
                                ....#.....
                                .........#
                                ..........
                                ..#.......
                                .......#..
                                ..........
                                .#..^.....
                                ........#.
                                #.........
                                ......#...
                                """;

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(41));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}