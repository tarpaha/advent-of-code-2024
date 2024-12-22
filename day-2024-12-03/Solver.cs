namespace day_2024_12_03;

public static class Solver
{
    public static object Part1(Data data)
    {
        return GetMulInstructions(data.Memory)
            .Select(numbers => numbers.firstNumber * numbers.secondNumber)
            .Sum();
    }

    public static object Part2(Data data)
    {
        return null!;
    }

    private static IEnumerable<(int firstNumber, int secondNumber)> GetMulInstructions(string memory)
    {
        var state = State.Start;
        var firstNumber = 0;
        var secondNumber = 0;
        foreach (var ch in memory)
        {
            switch (state)
            {
                case State.Start:
                    state = ch == 'm' ? State.M : State.Start;
                    break;
                case State.M:
                    state = ch == 'u' ? State.U : State.Start;
                    break;
                case State.U:
                    state = ch == 'l' ? State.L : State.Start;
                    break;
                case State.L:
                    state = ch == '(' ? State.Open : State.Start;
                    break;
                case State.Open:
                    if (char.IsDigit(ch))
                    {
                        state = State.FirstNumber;
                        firstNumber = ch - '0';
                    }
                    else
                        state = State.Start;
                    break;
                case State.FirstNumber:
                    if (char.IsDigit(ch))
                        firstNumber = firstNumber * 10 + ch - '0';
                    else if(ch == ',')
                        state = State.Comma;
                    else
                        state = State.Start;
                    break;
                case State.Comma:
                    if (char.IsDigit(ch))
                    {
                        state = State.SecondNumber;
                        secondNumber = ch - '0';
                    }
                    else
                        state = State.Start;
                    break;
                case State.SecondNumber:
                    if (char.IsDigit(ch))
                        secondNumber = secondNumber * 10 + ch - '0';
                    else if (ch == ')')
                    {
                        state = State.Close;
                    }
                    else
                        state = State.Start;
                    break;
            }

            if (state == State.Close)
            {
                yield return (firstNumber, secondNumber);
                state = State.Start;
            }
        }
    }

    private enum State
    {
        Start,
        M, U, L,
        Open,
        FirstNumber, Comma, SecondNumber,
        Close
    }
}