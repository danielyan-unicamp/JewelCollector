public class Tree : Obstacle
{
    public Tree(int x, int y): base(new Position(x, y)) {}
    
    public override string ToString()
    {
        return "$$";
    }

}