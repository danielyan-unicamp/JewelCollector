public abstract class Jewel : Entity, ICollectable
{
    public Jewel(Position position) : base(position) { }

    public abstract int GetValue();

    public void Collect(Robot robot)
    {
        robot.AddToBag(this);
    }
}