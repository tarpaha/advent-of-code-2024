namespace day_2024_12_03.tests;

public class ParserTests
{
    [TestCase("abc")]
    public void Parser_Works_Correctly(string input)
    {
        Assert.That(Parser.Parse(input).Memory, Is.EqualTo(input));
    }
}