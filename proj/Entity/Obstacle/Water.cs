public class Water : Obstacle
{
    public Water(int x, int y): base(x, y) {}
    public Water(Position position): base(position) {}
    
    public override string ToString()
    {
        return "##";
    }

}