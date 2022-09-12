public class Blue : Jewel, IRechargeable
{
    public Blue(int x, int y) : base(new Position(x, y)) { }

    public override string ToString()
    {
        return "JB";
    }
    public override int GetValue()
    {
        return 10;
    }

    public void Recharge(Robot robot)
    {
        robot.AddHealth(5);
    }
}