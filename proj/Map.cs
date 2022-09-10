public class Map
{
    private int Width { get => this.grid.Width; }
    private int Height { get => this.grid.Height; }
    private Grid<Entity> grid;
    private Robot robot;
    public Map(int width, int height, Robot robot) {
        this.grid = new Grid<Entity>(width, height);
        this.robot = robot;
        this.grid.Set(this.robot.Position, this.robot);
    }


    public void MoveRobot(Position deltaPosition) {

        Position nextPosition = this.robot.Position + deltaPosition;
        if (nextPosition.IsOutOfBounds(this.Width, this.Height)) throw new OutOfBoundsException();
        if (this.grid.Get(nextPosition) != null) throw new CollisionException();
        this.grid.Set(this.robot.Position, null);
        this.robot.Move(deltaPosition);
        this.grid.Set(this.robot.Position, this.robot);
    }

    public void MoveRobotUp() {
        this.MoveRobot(new Position(0, -1));
    }
    public void MoveRobotLeft() {
        this.MoveRobot(new Position(-1, 0));
    }
    public void MoveRobotDown() {
        this.MoveRobot(new Position(0, 1));
    }
    public void MoveRobotRight() {
        this.MoveRobot(new Position(1, 0));
    }

    public void Insert(Entity e) {
        this.grid.Set(e.Position, e);
    }

    public void Print() {
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                Entity? e = this.grid.Get(j, i);
                if (e == null) {
                    Console.Write("--");
                } else {
                    Console.Write(e);
                } 
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        // Print UI
        Console.WriteLine(this.robot.BagInfo());
    }

    public List<Jewel> TakeJewels(Position position) {
        List<Entity> entities = this.grid.GetNearby(position);
        return entities.OfType<Jewel>().ToList();
    }
}
