public class Grid<T> where T : class
{
    public int Width { get; }
    public int Height { get; }
    private T?[,] grid;
    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        grid = new T?[width, height];
    }

    public void Set(Position position, T? obj)
    {
        grid[position.X, position.Y] = obj;
    }

    public T? Get(Position position)
    {
        return grid[position.X, position.Y];
    }
    public List<T> GetNearby(Position position)
    {
        List<T> objs = new List<T>();
        foreach (Position p in position.GetNearby())
        {
            if (!p.IsOutOfBounds(Width, Height))
            {
                T? obj = Get(p);
                if (obj != null) objs.Add(obj);
            }
        }
        return objs;
    }
}