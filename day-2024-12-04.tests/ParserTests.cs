namespace day_2024_12_04.tests;

public class ParserTests
{
    [Test]
    public void Parser_ForEmptyString_ReturnsZeroDimensions()
    {
        var data = Parser.Parse("");
        Assert.Multiple(() =>
        {
            Assert.That(data.Width, Is.Zero);
            Assert.That(data.Height, Is.Zero);
        });
    }
    
    [Test]
    public void Parser_Works_Correctly()
    {
        const int width = 4;
        const int height = 3;
        
        var rnd = new Random(DateTime.Now.Millisecond);
        var lines = Enumerable
            .Range(0, height)
            .Select(_ =>
                new string(Enumerable
                    .Range(0, width)
                    .Select(_ => (char)('A' + rnd.Next() % ('Z' - 'A' + 1)))
                    .ToArray()))
            .ToArray();
        
        var data = Parser.Parse(string.Join(Environment.NewLine, lines));
        
        Assert.Multiple(() =>
        {
            Assert.That(data.Width, Is.EqualTo(width));
            Assert.That(data.Height, Is.EqualTo(height));
        });

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                Assert.That(data.Letters[x, y], Is.EqualTo(lines[y][x]));
            }
        }
    }
}