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
    public void Add(Position position) {
        this.X += position.X;
        this.Y += position.Y;
    }
    public void Add(int x, int y) {
        this.X += x;
        this.Y += y;
    }

    public bool IsOutOfBounds(int x, int y) {
        return this.X >= x || this.X < 0 || this.Y >= y || this.Y < 0;
    }

    public Position[] GetNearby() {
        Position[] pos = new Position[4];
        pos[0] = new Position(this.X + 0, this.Y - 1);
        pos[1] = new Position(this.X - 1, this.Y + 0);
        pos[2] = new Position(this.X + 0, this.Y + 1);
        pos[3] = new Position(this.X + 1, this.Y + 0);
        return pos;
    }

}