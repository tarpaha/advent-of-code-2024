namespace day_2024_12_07;

public static class Parser
{
    public static Data Parse(string data)
    {
        return new Data(data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(ParseEquation)
            .ToList());
    }

    public static Equation ParseEquation(string str)
    {
        var numbers = str
            .Split([':', ' '], StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();
        return new Equation(numbers[1..], numbers[0]);
    }
}