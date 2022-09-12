
public class Position
{
    public int X { get; }
    public int Y { get; }
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Position operator +(Position a, Position b)
    {
        return new Position(a.X + b.X, a.Y + b.Y);
    }


    public bool IsOutOfBounds(int x, int y)
    {
        return X >= x || X < 0 || Y >= y || Y < 0;
    }

    public IEnumerable<Position> GetNearby()
    {
        yield return new Position(X + 0, Y - 1);
        yield return new Position(X - 1, Y + 0);
        yield return new Position(X + 0, Y + 1);
        yield return new Position(X + 1, Y + 0);
    }

    public static IEnumerable<(Position, string)> LoopAll(int width, int height)
    {

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                yield return (new Position(j, i), j == width - 1 ? "\n" : " ");
            }
        }
    }


}