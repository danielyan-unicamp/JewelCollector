public class Empty : Entity
{
    public Empty(int x, int y): base(x, y) {

    }
    public Empty(Position position): base(position) {

    }
    
    public override string ToString()
    {
        return "--";
    }
}