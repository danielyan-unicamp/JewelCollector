public abstract class Entity
{
    public Position Position{ get; private set; }

    public Entity(int x, int y) {
        this.Position = new Position(x, y);
    }
    public Entity(Position position) {
        this.Position = new Position(position.X, position.Y);
    }

    public int GetX() {
        return this.Position.X;
    }
    public int GetY() {
        return this.Position.Y;
    }
}
