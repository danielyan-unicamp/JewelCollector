
public class Game
{
    private static int MAX_JEWEL = 100;
    private Map map;
    private Robot robot;
    private Jewel[] jewels;
    private int jewelIndex;

    public Game(int width, int height, int robotX, int robotY) {
        this.robot = new Robot(robotX, robotY);
        this.map = new Map(width, height, this.robot);
        this.jewels = new Jewel[MAX_JEWEL];
    }

    public void InsertJewel(Jewel j) {
        this.jewels[jewelIndex++] = j;
        this.map.Insert(j);
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
        } catch (OutOfBoundsException e){
            return true;
        }
    }

    public void print() {
        this.map.Print(this.robot, this.jewels);
    }
}
