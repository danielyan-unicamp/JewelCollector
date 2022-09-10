public abstract class Jewel : Entity
{
    public Jewel(int x, int y) : base(x, y) {}
    public Jewel(Position position) : base(position) {}

    public abstract int GetValue();
}