public class Entity
{
    public Position Position{ get; private set; }

    public Entity(int x, int y) {
        this.Position = new Position(x, y);
    }
}
