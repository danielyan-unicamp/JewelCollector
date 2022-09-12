public class Tree : Obstacle, IRechargeable
{
    public Tree(int x, int y) : base(new Position(x, y)) { }
    public Tree(Position position) : base(position) { }

    public override string ToString()
    {
        return "$$";
    }

    public void Recharge(Robot robot)
    {
        robot.AddHealth(3);
    }

}