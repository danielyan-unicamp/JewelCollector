public abstract class Entity
{
    public Position Position{ get; protected set; }

    public Entity(Position position) {
        this.Position = new Position(position.X, position.Y);
    }

}
