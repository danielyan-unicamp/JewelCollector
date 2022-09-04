
public class Game
{
    private static int MAX_JEWEL = 100;
    private Map map;
    private Robot robot;
    private Jewel[] jewels;
    private int jewelIndex;

    public Game(int width, int height, int robotX, int robotY) {
        this.map = new Map(width, height);
        this.robot = new Robot(robotX, robotY);
        this.map.Insert(this.robot);
        this.jewels = new Jewel[MAX_JEWEL];
    }

    public void InsertJewel(Jewel j) {
        this.jewels[jewelIndex++] = j;
        this.map.Insert(j);
    }
    public bool ProcessInput(string? command) {

        if (command == null) {
            return true;
        } else if (command.Equals("quit")) {
            return false;
        } else if (command.Equals("w")) {
            if (this.robot.CanMoveUp(this.map)) {
                this.robot.MoveUp();
                this.map.Update(this.robot);
                // this.map.update(this.robot, this.jewels);
            }
        } else if (command.Equals("a")) {
            if (this.robot.CanMoveLeft(this.map)) {
                this.robot.MoveLeft();
                this.map.Update(this.robot);
            }
        } else if (command.Equals("s")) {
            if (this.robot.CanMoveDown(this.map)) {
                this.robot.MoveDown();
                this.map.Update(this.robot);
            }
        } else if (command.Equals("d")) {
            if (this.robot.CanMoveRight(this.map)) {
                this.robot.MoveRight();
                this.map.Update(this.robot);
            }
        } else if (command.Equals("g")) {
            
        }
        return true;
    }

    public void print() {
        this.map.Print(this.robot, this.jewels);
    }
}
