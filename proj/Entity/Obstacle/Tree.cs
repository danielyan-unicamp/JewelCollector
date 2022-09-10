public class Tree : Obstacle
{
    public Tree(int x, int y): base(x, y) {}
    public Tree(Position position): base(position) {}
    
    public override string ToString()
    {
        return "$$";
    }

}