public class Grid<T> where T : class
{
    public int Width { get; }
    public int Height { get; }
    private T?[,] grid;
    public Grid(int width, int height) {
        this.Width = width;
        this.Height = height;
        this.grid = new T?[width, height];
    }

    public void Set(Position position, T obj) {
        this.grid[position.X, position.Y] = obj;
    }

    public T? Get(Position position) {
        return this.grid[position.X, position.Y];
    }
    public T? Get(int x, int y) {
        return this.grid[x, y];
    }
}