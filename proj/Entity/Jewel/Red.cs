public class Red : Jewel
{
    public Red(int x, int y): base(x, y) {

    }
    
    public override string ToString()
    {
        return "JR";
    }
    public override int GetValue() {
        return 100;
    }
}