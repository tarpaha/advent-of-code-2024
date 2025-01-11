namespace day_2024_12_07.tests;

public class ParserTests
{
    [TestCase("190: 10 19", new [] { 10, 19 }, 190)]
    [TestCase("21037: 9 7 18 13", new [] { 9, 7, 18, 13 }, 21037)]
    public void ParseEquation_Works_Correctly(string input, int[] expectedNumbers, long expectedResult)
    {
        var equation = Parser.ParseEquation(input);
        Assert.Multiple(() =>
        {
            Assert.That(equation.Numbers, Is.EquivalentTo(expectedNumbers));
            Assert.That(equation.Result, Is.EqualTo(expectedResult));
        });
    }

    [TestCase("""
              190: 10 19
              3267: 81 40 27
              83: 17 5
              156: 15 6
              7290: 6 8 6 15
              161011: 16 10 13
              192: 17 8 14
              21037: 9 7 18 13
              292: 11 6 16 20
              """, 9)]
    public void Parser_Works_Correctly(string input, int expectedLength)
    {
        Assert.That(Parser.Parse(input).Equations, Has.Count.EqualTo(expectedLength));
    }
}