using System.Text.Json;

public class EntityConfig
{
    public string? type { get; set; }
    public int x { get; set; }
    public int y { get; set; }
}
public class Config
{

    public int mapWidth { get; set; }
    public int mapHeight { get; set; }
    public int robotX { get; set; }
    public int robotY { get; set; }
    public IList<EntityConfig>? entities { get; set; }
}

public class JewelCollector
{

    public static void Main()
    {
        string jsonString = File.ReadAllText("config.json");
        Config gameConfig = JsonSerializer.Deserialize<Config>(jsonString)!;
        Game game = new Game(gameConfig.mapWidth, gameConfig.mapHeight, gameConfig.robotX, gameConfig.robotY);
        if (gameConfig.entities != null)
        {
            foreach (EntityConfig e in gameConfig.entities)
            {
                // this ugly, fix this
                if (e.type == "Red") game.Insert(new Red(e.x, e.y));
                if (e.type == "Blue") game.Insert(new Blue(e.x, e.y));
                if (e.type == "Green") game.Insert(new Green(e.x, e.y));
                if (e.type == "Tree") game.Insert(new Tree(e.x, e.y));
                if (e.type == "Water") game.Insert(new Water(e.x, e.y));
            }
        }
        // make it count the total of points
        game.StartLoop();
    }
}