public class Blue : Jewel
{
    public Blue(int x, int y): base(x, y) {}
    public Blue(Position position): base(position) {}
    
    public override string ToString()
    {
        return "JB";
    }
    public override int GetValue() {
        return 10;
    }
}