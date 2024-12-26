namespace day_2024_12_06.tests;

public class ParserTests
{
    [TestCase("""
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
              """, 10, 10, 4, 6)]
    public void Parser_Works_Correctly(
        string input,
        int expectedWidth, int expectedHeight,
        int expectedStartX, int expectedStartY)
    {
        var data = Parser.Parse(input);
        Assert.Multiple(() =>
        {
            Assert.That(data.Width, Is.EqualTo(expectedWidth));
            Assert.That(data.Height, Is.EqualTo(expectedHeight));
            Assert.That(data.StartX, Is.EqualTo(expectedStartX));
            Assert.That(data.StartY, Is.EqualTo(expectedStartY));
        });
    }
}