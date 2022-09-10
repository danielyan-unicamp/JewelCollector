public class Green : Jewel
{
    public Green(int x, int y): base(new Position(x, y)) {}
    
    public override string ToString()
    {
        return "JG";
    }

    public override int GetValue() {
        return 50;
    }
}