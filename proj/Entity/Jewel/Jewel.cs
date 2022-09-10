public abstract class Jewel : Entity
{
    public Jewel(Position position) : base(position) {}

    public abstract int GetValue();
}