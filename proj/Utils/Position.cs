
public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Position(int x, int y) {
        this.X = x;
        this.Y = y;
    }

    public static Position operator +(Position a, Position b) {
        return new Position(a.X + b.X, a.Y + b.Y);
    }

    public bool Equals(Position other)
    {
        return (X == other.X) && (Y == other.Y);
    }

    public bool IsOutOfBounds(int x, int y) {
        return this.X >= x || this.X < 0 || this.Y >= y || this.Y < 0;
    }

    public IEnumerable<Position> GetNearby() {
        yield return new Position(this.X + 0, this.Y - 1);
        yield return new Position(this.X - 1, this.Y + 0);
        yield return new Position(this.X + 0, this.Y + 1);
        yield return new Position(this.X + 1, this.Y + 0);
    }

    public static IEnumerable<(Position, string)> LoopAll(int width, int height) {

        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                yield return (new Position(i, j), j == width - 1 ? "\n" : " ");
            }
        }
    }
    

}