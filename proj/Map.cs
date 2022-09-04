public class Map
{
    private static string EMPTY_TILE = "--";
    private static string ROBOT_TILE = "ME";
    public int Width { get; }
    public int Height { get; }
    public Map(int width, int height) {
        this.Width = width;
        this.Height = height;
    }

    public void print(Robot robot) {
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                if (robot.Position.Equals(new Position(j, i))) {
                    Console.Write(ROBOT_TILE);
                } else {
                    Console.Write(EMPTY_TILE);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
