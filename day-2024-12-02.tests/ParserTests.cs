namespace day_2024_12_02.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse("""
                                7 6 4 2 1
                                1 2 7
                                """);
        Assert.That(data.Reports, Has.Length.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(data.Reports[0].Levels, Has.Length.EqualTo(5));
            Assert.That(data.Reports[1].Levels, Has.Length.EqualTo(3));
        });
    }
}