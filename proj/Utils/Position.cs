public class Position
{
    private int x;
    private int y;
    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static Position operator +(Position a, Position b) {
        return new Position(a.x + b.x, a.y + b.y);
    }
    public void Add(int x, int y) {
        this.x += x;
        this.y += y;
    }

    public bool IsOutOfBounds(int x, int y) {
        return this.x >= y || this.x < 0 || this.y >= x || this.y < 0;
    }

}