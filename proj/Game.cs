
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

    public bool ProcessInput(string? command) {
        if (command == null) {
            return true;
        } else if (command.Equals("quit")) {
            return false;
        } else if (command.Equals("w")) {
            this.MoveRobotUp();
        } else if (command.Equals("a")) {
            this.MoveRobotLeft();
        } else if (command.Equals("s")) {
            this.MoveRobotDown();
        } else if (command.Equals("d")) {
            this.MoveRobotRight();
        } else if (command.Equals("g")) {
            this.GrabJewels();
        }
        return true;
    }

    public void Print() {
        this.map.Print();
    }

    public void GrabJewels() {
        List<Jewel> jewels = map.TakeJewels(this.robot.Position);
        this.robot.AddJewels(jewels);
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
        this.MoveRobot(new Position(-1, 0));
    }
    public void MoveRobotLeft() {
        this.MoveRobot(new Position(0, -1));
    }
    public void MoveRobotDown() {
        this.MoveRobot(new Position(1, 0));
    }
    public void MoveRobotRight() {
        this.MoveRobot(new Position(0, 1));
    }
}
