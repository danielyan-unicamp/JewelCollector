public class Map
{
    public int Width { get; }
    public int Height { get; }
    private Entity[,] grid;
    private Robot robot;
    public Map(int width, int height, Robot robot) {
        this.Width = width;
        this.Height = height;
        this.grid = new Entity[100, 100];
        this.robot = robot;
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                this.grid[j, i] = new Empty(j, i);
                if (this.robot.Position.Equals(new Position(j, i))) {
                    this.grid[j, i] = this.robot;
                }
            }
        }

    }
    public void MoveRobotUp() {
        if ((this.robot.Position + new Position(0, -1)).IsOutOfBounds(this.Width, this.Height)) {
            throw new OutOfBoundsException();
        }
        this.grid[this.robot.GetX(), this.robot.GetY()] = new Empty(this.robot.Position);
        this.robot.MoveUp();
        this.grid[this.robot.GetX(), this.robot.GetY()] = this.robot;
    }
    public void MoveRobotLeft() {
        if ((this.robot.Position + new Position(-1, 0)).IsOutOfBounds(this.Width, this.Height)) {
            throw new OutOfBoundsException();
        }
        this.grid[this.robot.GetX(), this.robot.GetY()] = new Empty(this.robot.Position);
        this.robot.MoveLeft();
        this.grid[this.robot.GetX(), this.robot.GetY()] = this.robot;
    }
    public void MoveRobotDown() {

        if ((this.robot.Position + new Position(0, 1)).IsOutOfBounds(this.Width, this.Height)) {
            throw new OutOfBoundsException();
        }

        this.grid[this.robot.GetX(), this.robot.GetY()] = new Empty(this.robot.Position);
        this.robot.MoveDown();
        this.grid[this.robot.GetX(), this.robot.GetY()] = this.robot;
    }
    public void MoveRobotRight() {
        if ((this.robot.Position + new Position(1, 0)).IsOutOfBounds(this.Width, this.Height)) {
            throw new OutOfBoundsException();
        }
        this.grid[this.robot.GetX(), this.robot.GetY()] = new Empty(this.robot.Position);
        this.robot.MoveRight();
        this.grid[this.robot.GetX(), this.robot.GetY()] = this.robot;
    }
    public void Insert(Entity e) {
        this.grid[e.Position.X, e.Position.Y] = e;
    }

    public void Print(Robot robot, Jewel[] jewels) {
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                Console.Write(this.grid[j, i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        // Print UI
        Console.WriteLine(robot.BagInfo());
    }

    public Jewel[] TakeJewels(Position position) {
        Jewel[] jewels = new Jewel[4];
        int size = 0;
        if (!(position + new Position(0, -1)).IsOutOfBounds(this.Width, this.Height)) {
            Entity up = grid[position.X, position.Y - 1];

            if (up is Jewel) {
                jewels[size++] = (Jewel) up;
                grid[position.X, position.Y - 1] = new Empty(position.X, position.Y - 1);
            }
        }
        if (!(position + new Position(-1, 0)).IsOutOfBounds(this.Width, this.Height)) {
            Entity left = grid[position.X - 1, position.Y];

            if (left is Jewel) {
                jewels[size++] = (Jewel) left;
                grid[position.X - 1, position.Y] = new Empty(position.X - 1, position.Y);
            }
        }
        if (!(position + new Position(0, 1)).IsOutOfBounds(this.Width, this.Height)) {
            Entity down = grid[position.X, position.Y + 1];

            if (down is Jewel) {
                jewels[size++] = (Jewel) down;
                grid[position.X, position.Y + 1] = new Empty(position.X, position.Y + 1);
            }
        }
        if (!(position + new Position(1, 0)).IsOutOfBounds(this.Width, this.Height)) {
            Entity right = grid[position.X + 1, position.Y];
            if (right is Jewel) {
                jewels[size++] = (Jewel) right;
                grid[position.X + 1, position.Y] = new Empty(position.X + 1, position.Y);
            }
        }
        return jewels;
    }
}
