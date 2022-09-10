public class Water : Obstacle
{
    public Water(int x, int y): base(new Position(x, y)) {}
    
    public override string ToString()
    {
        return "##";
    }

}