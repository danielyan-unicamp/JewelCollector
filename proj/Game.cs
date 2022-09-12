
public delegate void KeyPressedHandler(ConsoleKey key);
public class Game
{
    const double RED_MULTIPLIER = 0.02;
    const double BLUE_MULTIPLIER = 0.02;
    const double GREEN_MULTIPLIER = 0.02;
    const double WATER_MULTIPLIER = 0.05;
    const double TREE_MULTIPLIER = 0.07;
    private Map Map { get; set; }
    private Robot Robot { get; set; }

    private event KeyPressedHandler KeyPressed;

    public Game(int width, int height, int robotX, int robotY)
    {
        Robot = new Robot(robotX, robotY, this);
        Map = new Map(width, height);
        Map.Insert(Robot);
        Robot.PositionChanged += Map.UpdatePosition;
        KeyPressed += Robot.OnKeyPress;
    }

    private void Restart()
    {
        Robot.PositionChanged -= Map.UpdatePosition;
        KeyPressed -= Robot.OnKeyPress;
        int width = Map.Width + 1;
        int height = Map.Height + 1;
        if (width > 30) width = 30;
        if (height > 30) height = 30;
        int numberOfCells = width * height;
        Random rnd = new Random();
        Robot = new Robot(rnd.Next(0, width), rnd.Next(0, height), this);
        Map = new Map(width, height);
        Map.Insert(Robot);
        InsertBlue(numberOfCells);
        InsertGreen(numberOfCells);
        InsertRed(numberOfCells);
        InsertTree(numberOfCells);
        InsertWater(numberOfCells);
        Robot.PositionChanged += Map.UpdatePosition;
        KeyPressed += Robot.OnKeyPress;

    }

    private void InsertBlue(int numberOfCells)
    {
        int numberOfBlue = (int)Math.Floor(numberOfCells * BLUE_MULTIPLIER);
        for (int i = 0; i < numberOfBlue; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Blue(position));
        }
    }
    private void InsertGreen(int numberOfCells)
    {
        int numberOfGreen = (int)Math.Floor(numberOfCells * GREEN_MULTIPLIER);
        for (int i = 0; i < numberOfGreen; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Green(position));
        }
    }
    private void InsertRed(int numberOfCells)
    {
        int numberOfRed = (int)Math.Floor(numberOfCells * RED_MULTIPLIER);
        for (int i = 0; i < numberOfRed; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Red(position));
        }
    }
    private void InsertTree(int numberOfCells)
    {
        int numberOfTree = (int)Math.Floor(numberOfCells * TREE_MULTIPLIER);
        for (int i = 0; i < numberOfTree; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Tree(position));
        }
    }
    private void InsertWater(int numberOfCells)
    {
        int numberOfWater = (int)Math.Floor(numberOfCells * WATER_MULTIPLIER);
        for (int i = 0; i < numberOfWater; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Water(position));
        }
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
            KeyPressed(keyinfo.Key);
            Print();
            if (Robot.IsDead())
            {
                GameEnd();
                break;
            }
            if (Map.IsCleared())
            {
                NewGame();
                Print();

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
        Restart();
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
