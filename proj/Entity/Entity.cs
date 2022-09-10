public abstract class Entity
{
    public Position Position{ get; protected set; }

    public Entity(int x, int y) {
        this.Position = new Position(x, y);
    }
    public Entity(Position position) {
        this.Position = new Position(position.X, position.Y);
    }

}
