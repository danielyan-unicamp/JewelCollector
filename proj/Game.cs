
public delegate void KeyPressedHandler(ConsoleKey key);
public class Game
{
    private Map Map { get; set; }
    private Robot Robot { get; set; }

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
        Print();

        do
        {
            keyinfo = Console.ReadKey(true);
            Print();
            KeyPressed(keyinfo.Key);
            if (Robot.IsDead())
            {
                GameEnd();
                break;
            }
            if (Map.IsCleared())
            {
                NewGame();
                break;
            }
        }
        while (keyinfo.Key != ConsoleKey.Escape);
    }

    public void GameEnd()
    {
        Console.WriteLine("Game Over!");
    }
    public void NewGame()
    {
        Console.WriteLine("Stage Completed!");

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
