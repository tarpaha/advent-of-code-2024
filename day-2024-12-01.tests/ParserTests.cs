namespace day_2024_12_01.tests;

public class ParserTests
{
    [TestCase("""
              3   4
              4   3
              2   5
              1   3
              3   9
              3   3
              """, 6)]
    public void Parser_Works_Correctly(string input, int count)
    {
        var data = Parser.Parse(input);
        Assert.Multiple(() =>
        {
            Assert.That(data.Left.Count(), Is.EqualTo(count));
            Assert.That(data.Right.Count(), Is.EqualTo(count));
        });
    }
}