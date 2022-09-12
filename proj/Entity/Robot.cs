public delegate void PositionChangedHandler(Position oldPosition, Position newPosition, Entity entity);

public class Robot : Entity
{
    private Game Game { get; }
    private int HealthPoints = 5;
    private List<ICollectable> Bag = new List<ICollectable>();
    public Robot(Position position, Game game) : base(position)
    {
        Game = game;
    }
    // 
    public event PositionChangedHandler? PositionChanged;
    public void OnKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W:
                {
                    Move(new Position(0, -1));
                    break;
                }
            case ConsoleKey.A:
                {
                    Move(new Position(-1, 0));
                    break;
                }
            case ConsoleKey.S:
                {
                    Move(new Position(0, 1));
                    break;
                }
            case ConsoleKey.D:
                {
                    Move(new Position(1, 0));
                    break;
                }
            case ConsoleKey.G:
                {
                    Game.GrabJewels();
                    break;
                }
        }
    }


    public void MoveTo(Position newPosition)
    {
        Position = newPosition;
    }

    public void Move(Position deltaPosition)
    {
        Position oldPosition = Position;
        Position newPosition = Position + deltaPosition;
        Game.CheckCollision(newPosition); // this can trigger errors
        Position = newPosition;
        HealthPoints--;
        if (PositionChanged != null)
        {
            PositionChanged(oldPosition, newPosition, this);
        }
    }
    public void AddHealth(int value)
    {
        HealthPoints += value;
    }

    public bool IsDead()
    {
        return HealthPoints == 0;
    }

    public void AddToBag(ICollectable collectable)
    {
        Bag.Add(collectable);
    }


    public string BagInfo()
    {
        int total = 0;
        foreach (Jewel jewel in Bag)
        {
            total += jewel.GetValue();
        }
        return $"Bag total items: {Bag.Count} | Bag total value: {total}";
    }
    public string HealthInfo()
    {
        return $"Health: {HealthPoints}";
    }

    public override string ToString()
    {
        return "ME";
    }
}