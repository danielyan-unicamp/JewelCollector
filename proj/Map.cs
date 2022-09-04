public class Map
{
    private static string EMPTY_TILE = "--";
    private static string ROBOT_TILE = "ME";
    public int Width { get; }
    public int Height { get; }
    private Entity[,] grid;
    private Position latestPosition;
    public Map(int width, int height) {
        this.Width = width;
        this.Height = height;
        this.grid = new Entity[100, 100];
        
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                this.grid[j, i] = new Empty(j, i);
            }
        }
        latestPosition = new Position(-1, -1);

    }

    public void Insert(Entity e) {
        this.grid[e.Position.X, e.Position.Y] = e;
        if (e is Robot) latestPosition = e.Position;
    }

    public void Print(Robot robot, Jewel[] jewels) {
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                Console.Write(this.grid[j, i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public void Update(Robot robot) {

        // Remove the robot from the map
        this.grid[latestPosition.X, latestPosition.Y] = new Empty(latestPosition.X, latestPosition.Y);
        latestPosition = robot.Position;
        this.grid[robot.Position.X, robot.Position.Y] = robot;

    }
}
