namespace day_2024_12_05.tests;

public class ParserTests
{
    [TestCase("""
              47|53
              97|13
              97|61
              97|47
              75|29
              61|13
              75|53
              29|13
              97|29
              53|29
              61|53
              97|53
              61|29
              47|13
              75|47
              97|75
              47|61
              75|61
              47|29
              75|13
              53|13

              75,47,61,53,29
              97,61,53,29,13
              75,29,13
              75,97,47,61,53
              61,13,29
              97,13,75,29,47
              """,
        21,
        new [] { 5, 5, 3, 5, 3, 5})]
    public void Parser_Works_Correctly(
        string input,
        int expectedRulesCount, int[] expectedUpdatesPagesCount)
    {
        var data = Parser.Parse(input);
        Assert.Multiple(() =>
        {
            Assert.That(data.Rules, Has.Count.EqualTo(expectedRulesCount));
            Assert.That(data.Updates.Select(update => update.Numbers.Count), Is.EquivalentTo(expectedUpdatesPagesCount));
        });
    }
}