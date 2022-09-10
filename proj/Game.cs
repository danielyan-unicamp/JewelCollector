
public class Game
{
    private Map map;
    private Robot robot;

    public Game(int width, int height, int robotX, int robotY) {
        this.robot = new Robot(robotX, robotY);
        this.map = new Map(width, height, this.robot);
    }

    public void Insert(Entity e) {
        this.map.Insert(e);
    }

    public bool ProcessInput(string? command) {
        try {
            if (command == null) {
                return true;
            } else if (command.Equals("quit")) {
                return false;
            } else if (command.Equals("w")) {
                this.map.MoveRobotUp();
            } else if (command.Equals("a")) {
                this.map.MoveRobotLeft();
            } else if (command.Equals("s")) {
                this.map.MoveRobotDown();
            } else if (command.Equals("d")) {
                this.map.MoveRobotRight();
            } else if (command.Equals("g")) {
                this.robot.GrabJewels(this.map);
            }
            return true;
        } catch (OutOfBoundsException) {
        } catch (CollisionException) {
        }
        return true;
    }

    public void Print() {
        this.map.Print();
    }
}
