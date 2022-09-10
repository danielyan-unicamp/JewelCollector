
public class Game
{
    private Map map;
    private Robot robot;

    public Game(int width, int height, int robotX, int robotY) {
        this.robot = new Robot(new Position(robotX, robotY));
        this.map = new Map(width, height, this.robot);
    }
    /// <summary>
    /// Insere uma Entity no jogo
    /// </summary>
    /// <param name="entity">A entidade a ser inserida</param>
    public void Insert(Entity entity) {
        this.map.Insert(entity);
    }

    public void StartLoop() {

        ConsoleKeyInfo keyinfo;
        do
        {
            this.Print();
            keyinfo = Console.ReadKey(true);
            switch (keyinfo.Key) {
                case ConsoleKey.W:
                {
                    this.MoveRobotUp();
                    break;
                }
                case ConsoleKey.A:
                {
                    this.MoveRobotLeft();
                    break;
                }
                case ConsoleKey.S:
                {
                    this.MoveRobotDown();
                    break;
                }
                case ConsoleKey.D:
                {
                    this.MoveRobotRight();
                    break;
                }
                case ConsoleKey.G:
                {
                    this.GrabJewels();
                    break;
                }
            }
            if (this.robot.IsDead()) {
                this.Print();
                Console.WriteLine("Game Over!");
                break;
            }
        }
        while (keyinfo.Key != ConsoleKey.Escape);
    }

    public void Print() {
        this.map.Print();

    }

    public void GrabJewels() {
        map.Interact(this.robot);
    }

    private void MoveRobot(Position deltaPosition) {

        Position nextPosition = this.robot.Position + deltaPosition;
        try {
            this.map.CheckCollision(nextPosition);
            this.map.Set(this.robot.Position, null);
            this.robot.Move(deltaPosition);
            this.map.Set(this.robot.Position, this.robot);
        } catch (OutOfBoundsException) {
        } catch (CollisionException) {
        }
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
}
