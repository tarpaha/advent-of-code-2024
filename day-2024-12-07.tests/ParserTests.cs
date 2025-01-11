namespace day_2024_12_07.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Parser.Parse(""), Is.Not.Null);
    }
}