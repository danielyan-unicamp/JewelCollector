
public class Game
{
    private Map map;
    private Robot robot;

    public Game(int width, int height, int robotX, int robotY) {
        this.map = new Map(width, height);
        this.robot = new Robot(robotX, robotY);
    }

    public bool processInput(string? command) {

        if (command == null) {
            return true;
        } else if (command.Equals("quit")) {
            return false;
        } else if (command.Equals("w")) {
            if (this.robot.CanMoveUp(this.map)) {
                this.robot.MoveUp();
            }
        } else if (command.Equals("a")) {
            if (this.robot.CanMoveLeft(this.map)) {
                this.robot.MoveLeft();
            }
        } else if (command.Equals("s")) {
            if (this.robot.CanMoveDown(this.map)) {
                this.robot.MoveDown();
            }
        } else if (command.Equals("d")) {
            if (this.robot.CanMoveRight(this.map)) {
                this.robot.MoveRight();
            }
        } else if (command.Equals("g")) {
            
        }
        return true;
    }

    public void print() {
        this.map.print(this.robot);
    }
}
