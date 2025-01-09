namespace day_2024_12_06;

public static class Solver
{
    public static object Part1(Data data)
    {
        return GetVisitedPositions(data)!.Count;
    }

    public static object Part2(Data data)
    {
        var loopsCount = 0;
        foreach (var position in GetVisitedPositions(data)!)
        {
            if(position == (data.StartX, data.StartY))
                continue;
            
            data.Cells[position.x, position.y] = '#';
            if(GetVisitedPositions(data) == null)
                loopsCount++;
            data.Cells[position.x, position.y] = '.';
        }
        return loopsCount;
    }

    private static HashSet<(int x, int y)>? GetVisitedPositions(Data data)
    {
        var visited = new HashSet<(int x, int y, Direction direction)>();

        var (x, y) = (data.StartX, data.StartY);
        var direction = Direction.Up;
        
        while (true)
        {
            if (!visited.Add((x, y, direction)))
                return null;

            var (newX, newY) = direction switch
            {
                Direction.Up => (x, y - 1),
                Direction.Right => (x + 1, y),
                Direction.Down => (x, y + 1),
                Direction.Left => (x - 1, y),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (newX < 0 || newX >= data.Width || newY < 0 || newY >= data.Height)
                break;

            if (data.Cells[newX, newY] == '#')
            {
                direction = direction switch
                {
                    Direction.Up => Direction.Right,
                    Direction.Right => Direction.Down,
                    Direction.Down => Direction.Left,
                    Direction.Left => Direction.Up,
                    _ => throw new ArgumentOutOfRangeException()
                };
                continue;
            }
            
            (x, y) = (newX, newY);
        }
        
        return visited.Select(t => (t.x, t.y)).ToHashSet();
    }
    
    private enum Direction { Up, Right, Down, Left }
}