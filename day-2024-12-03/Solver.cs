namespace day_2024_12_03;

public static class Solver
{
    public static object Part1(Data data)
    {
        return GetMulInstructions(data.Memory, false)
            .Select(numbers => numbers.firstNumber * numbers.secondNumber)
            .Sum();
    }

    public static object Part2(Data data)
    {
        return GetMulInstructions(data.Memory, true)
            .Select(numbers => numbers.firstNumber * numbers.secondNumber)
            .Sum();
    }

    private static IEnumerable<(int firstNumber, int secondNumber)> GetMulInstructions(string memory, bool useEnabled)
    {
        var mulState = MulState.Start;
        var firstNumber = 0;
        var secondNumber = 0;

        var enablerState = EnablerState.Start;
        var enableValueToSet = false;
        var enabled = true;
        
        foreach (var ch in memory)
        {
            switch (enablerState)
            {
                case EnablerState.Start:
                    enablerState = ch == 'd' ? EnablerState.D : EnablerState.Start;
                    break;
                case EnablerState.D:
                    enablerState = ch == 'o' ? EnablerState.O : EnablerState.Start;
                    break;
                case EnablerState.O:
                    switch (ch)
                    {
                        case '(':
                            enablerState = EnablerState.Open;
                            enableValueToSet = true;
                            break;
                        case 'n':
                            enablerState = EnablerState.N;
                            break;
                        default:
                            enablerState = EnablerState.Start;
                            break;
                    }
                    break;
                case EnablerState.Open:
                    enablerState = ch == ')' ? EnablerState.Close : EnablerState.Start;
                    break;
                case EnablerState.N:
                    enablerState = ch == '\'' ? EnablerState.Apostrophe : EnablerState.Start;
                    break;
                case EnablerState.Apostrophe:
                    enablerState = ch == 't' ? EnablerState.T : EnablerState.Start;
                    break;
                case EnablerState.T:
                    if (ch == '(')
                    {
                        enablerState = EnablerState.Open;
                        enableValueToSet = false;
                    }
                    else
                        enablerState = EnablerState.Start;
                    break;
            }

            if (enablerState == EnablerState.Close)
            {
                enabled = enableValueToSet;
                enablerState = EnablerState.Start;
            }

            switch (mulState)
            {
                case MulState.Start:
                    mulState = ch == 'm' ? MulState.M : MulState.Start;
                    break;
                case MulState.M:
                    mulState = ch == 'u' ? MulState.U : MulState.Start;
                    break;
                case MulState.U:
                    mulState = ch == 'l' ? MulState.L : MulState.Start;
                    break;
                case MulState.L:
                    mulState = ch == '(' ? MulState.Open : MulState.Start;
                    break;
                case MulState.Open:
                    if (char.IsDigit(ch))
                    {
                        mulState = MulState.FirstNumber;
                        firstNumber = ch - '0';
                    }
                    else
                        mulState = MulState.Start;
                    break;
                case MulState.FirstNumber:
                    if (char.IsDigit(ch))
                        firstNumber = firstNumber * 10 + ch - '0';
                    else if(ch == ',')
                        mulState = MulState.Comma;
                    else
                        mulState = MulState.Start;
                    break;
                case MulState.Comma:
                    if (char.IsDigit(ch))
                    {
                        mulState = MulState.SecondNumber;
                        secondNumber = ch - '0';
                    }
                    else
                        mulState = MulState.Start;
                    break;
                case MulState.SecondNumber:
                    if (char.IsDigit(ch))
                        secondNumber = secondNumber * 10 + ch - '0';
                    else if (ch == ')')
                    {
                        mulState = MulState.Close;
                    }
                    else
                        mulState = MulState.Start;
                    break;
            }

            if (mulState == MulState.Close)
            {
                if(!useEnabled || enabled)
                    yield return (firstNumber, secondNumber);
                mulState = MulState.Start;
            }
        }
    }

    private enum MulState
    {
        Start,
        M, U, L,
        Open,
        FirstNumber, Comma, SecondNumber,
        Close
    }

    private enum EnablerState
    {
        Start,
        D, O, Open, Close,
        N, Apostrophe, T,
    }
}