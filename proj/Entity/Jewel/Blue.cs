public class Blue : Jewel
{
    public Blue(int x, int y): base(new Position(x, y)) {}
    
    public override string ToString()
    {
        return "JB";
    }
    public override int GetValue() {
        return 10;
    }
}