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

    public Jewel[] TakeJewels(Position position) {
        Jewel[] jewels = new Jewel[4];
        int size = 0;
        Entity up = grid[position.X, position.Y - 1];
        Entity left = grid[position.X - 1, position.Y];
        Entity down = grid[position.X, position.Y + 1];
        Entity right = grid[position.X + 1, position.Y];
        if (up is Jewel) {
            jewels[size++] = (Jewel) up;
            grid[position.X, position.Y - 1] = new Empty(position.X, position.Y - 1);
        }
        if (left is Jewel) {
            jewels[size++] = (Jewel) left;
            grid[position.X - 1, position.Y] = new Empty(position.X - 1, position.Y);
        }
        if (down is Jewel) {
            jewels[size++] = (Jewel) down;
            grid[position.X, position.Y + 1] = new Empty(position.X, position.Y + 1);
        }
        if (right is Jewel) {
            jewels[size++] = (Jewel) right;
            grid[position.X + 1, position.Y] = new Empty(position.X + 1, position.Y);
        }
        return jewels;
    }
}
