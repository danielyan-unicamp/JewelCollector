public class Tree : Obstacle, IRechargeable
{
    public Tree(int x, int y): base(new Position(x, y)) {}
    
    public override string ToString()
    {
        return "$$";
    }

    public void Interact(Robot robot) {
        robot.AddHealth(3);
    }

}