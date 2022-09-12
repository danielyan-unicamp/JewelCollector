
public delegate void KeyPressedHandler(ConsoleKey key);
public class Game
{
    private Map Map { get; }
    private Robot Robot { get; }

    private event KeyPressedHandler KeyPressed;

    public Game(int width, int height, int robotX, int robotY)
    {
        Robot = new Robot(new Position(robotX, robotY), this);
        Map = new Map(width, height);
        Map.Insert(Robot);
        Robot.PositionChanged += Map.UpdatePosition;
        KeyPressed += Robot.OnKeyPress;
    }
    /// <summary>
    /// Insere uma Entity no jogo
    /// </summary>
    /// <param name="entity">A entidade a ser inserida</param>
    public void Insert(Entity entity)
    {
        Map.Insert(entity);
    }

    public void StartLoop()
    {

        ConsoleKeyInfo keyinfo;
        do
        {
            Print();
            keyinfo = Console.ReadKey(true);
            KeyPressed(keyinfo.Key);
            if (Robot.IsDead())
            {
                Print();
                Console.WriteLine("Game Over!");
                break;
            }
        }
        while (keyinfo.Key != ConsoleKey.Escape);
    }

    public void Print()
    {
        Map.Print();
        Console.WriteLine(Robot.BagInfo());
        Console.WriteLine(Robot.HealthInfo());

    }

    public void GrabJewels()
    {
        // Kinda weird
        Map.Interact(Robot);
    }

    public void CheckCollision(Position nextPosition)
    {
        Map.CheckCollision(nextPosition);
    }

}
