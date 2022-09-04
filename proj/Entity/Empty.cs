public class Empty : Entity
{
    public Empty(int x, int y): base(x, y) {

    }
    
    public override string ToString()
    {
        return "--";
    }
}