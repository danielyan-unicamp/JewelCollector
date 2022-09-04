
public class Game
{
    private Map map;

    public Game(int width, int height, int robotX, int robotY) {
        this.map = new Map(width, height);
    }

    public bool processInput(string? command) {

        if (command == null) {
            return true;
        } else if (command.Equals("quit")) {
            return false;
        } else if (command.Equals("w")) {
            
        } else if (command.Equals("a")) {
            
        } else if (command.Equals("s")) {
            
        } else if (command.Equals("d")) {
        
        } else if (command.Equals("g")) {
            
        }
        return true;
    }

    public void print() {
        this.map.print();
    }
}
