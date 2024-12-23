namespace day_2024_12_04.tests;

public class SolverTests
{
    private const string Data = """
                                MMMSXXMASM
                                MSAMXMSMSA
                                AMXSXMAAMM
                                MSAMASMSMX
                                XMASAMXAMM
                                XXAMMXXAMA
                                SMSMSASXSS
                                SAXAMASAAA
                                MAMMMXMMMM
                                MXMXAXMASX
                                """;

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(18));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(9));
    }
}