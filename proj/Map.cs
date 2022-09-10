public class Map
{
    private Grid<Entity> grid;
    private Robot robot;
    public Map(int width, int height, Robot robot) {
        this.grid = new Grid<Entity>(width, height);
        this.robot = robot;
        this.grid.Set(this.robot.Position, this.robot);

    }

    public int Width() {
        return this.grid.Width;
    }
    public int Height() {
        return this.grid.Height;
    }
    public void MoveRobotUp() {
        if ((this.robot.Position + new Position(0, -1)).IsOutOfBounds(this.Width(), this.Height())) {
            throw new OutOfBoundsException();
        }
        this.grid.Set(this.robot.Position, new Empty(this.robot.Position));
        this.robot.MoveUp();
        this.grid.Set(this.robot.Position, this.robot);
    }
    public void MoveRobotLeft() {
        if ((this.robot.Position + new Position(-1, 0)).IsOutOfBounds(this.Width(), this.Height())) {
            throw new OutOfBoundsException();
        }
        this.grid.Set(this.robot.Position, new Empty(this.robot.Position));

        this.robot.MoveLeft();
        this.grid.Set(this.robot.Position, this.robot);
    }
    public void MoveRobotDown() {

        if ((this.robot.Position + new Position(0, 1)).IsOutOfBounds(this.Width(), this.Height())) {
            throw new OutOfBoundsException();
        }
        this.grid.Set(this.robot.Position, new Empty(this.robot.Position));

        this.robot.MoveDown();
        this.grid.Set(this.robot.Position, this.robot);
    }
    public void MoveRobotRight() {
        if ((this.robot.Position + new Position(1, 0)).IsOutOfBounds(this.Width(), this.Height())) {
            throw new OutOfBoundsException();
        }
        this.grid.Set(this.robot.Position, new Empty(this.robot.Position));
        this.robot.MoveRight();
        this.grid.Set(this.robot.Position, this.robot);
    }
    public void Insert(Entity e) {
        this.grid.Set(e.Position, e);
    }

    public void Print(Robot robot, Jewel[] jewels) {
        for (int i = 0; i < this.Height(); i++) {
            for (int j = 0; j < this.Width(); j++) {
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
        Console.WriteLine(robot.BagInfo());
    }

    public Jewel[] TakeJewels(Position position) {
        Jewel[] jewels = new Jewel[4];
        // int size = 0;
        // if (!(position + new Position(0, -1)).IsOutOfBounds(this.Width, this.Height)) {
        //     Entity up = grid[position.X, position.Y - 1];

        //     if (up is Jewel) {
        //         jewels[size++] = (Jewel) up;
        //         grid[position.X, position.Y - 1] = new Empty(position.X, position.Y - 1);
        //     }
        // }
        // if (!(position + new Position(-1, 0)).IsOutOfBounds(this.Width, this.Height)) {
        //     Entity left = grid[position.X - 1, position.Y];

        //     if (left is Jewel) {
        //         jewels[size++] = (Jewel) left;
        //         grid[position.X - 1, position.Y] = new Empty(position.X - 1, position.Y);
        //     }
        // }
        // if (!(position + new Position(0, 1)).IsOutOfBounds(this.Width, this.Height)) {
        //     Entity down = grid[position.X, position.Y + 1];

        //     if (down is Jewel) {
        //         jewels[size++] = (Jewel) down;
        //         grid[position.X, position.Y + 1] = new Empty(position.X, position.Y + 1);
        //     }
        // }
        // if (!(position + new Position(1, 0)).IsOutOfBounds(this.Width, this.Height)) {
        //     Entity right = grid[position.X + 1, position.Y];
        //     if (right is Jewel) {
        //         jewels[size++] = (Jewel) right;
        //         grid[position.X + 1, position.Y] = new Empty(position.X + 1, position.Y);
        //     }
        // }
        return jewels;
    }
}
