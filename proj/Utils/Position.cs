public class Position
{
    private int x;
    private int y;
    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static Position operator +(Position a, Position b) {
        return new Position(a.x + b.x, a.x + b.y);
    }
    
}