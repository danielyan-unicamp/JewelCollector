public class Map
{
    private int Width { get => this.grid.Width; }
    private int Height { get => this.grid.Height; }
    private Grid<Entity> grid;
    private Robot robot;
    public Map(int width, int height, Robot robot) {
        this.grid = new Grid<Entity>(width, height);
        this.robot = robot;
        this.grid.Set(this.robot.Position, this.robot);
    }

    public void Interact(Robot robot) {

        List<Entity> entities = this.grid.GetNearby(this.robot.Position);
        foreach (Entity entity in entities) {
            if (entity is ICollectable ic) {
                this.grid.Set(entity.Position, null);
                ic.Interact(robot);
            }
            if (entity is IRechargeable ir) {
                ir.Interact(robot);
            }
        }
    }

    public void Set(Position position, Entity? entity) {
        this.grid.Set(position, entity);
    }

    public void CheckCollision(Position nextPosition) {
        if (nextPosition.IsOutOfBounds(this.Width, this.Height)) throw new OutOfBoundsException();
        if (this.grid.Get(nextPosition) != null) throw new CollisionException();
    }

    public void Insert(Entity e) {
        this.grid.Set(e.Position, e);
    }

    public void Print() {
        foreach ((Position, String) t in Position.LoopAll(this.Width, this.Height)) {
            Entity? e = this.grid.Get(t.Item1);
            if (e == null) {
                Console.Write("--");
            } else {
                Console.Write(e);
            } 
            Console.Write(t.Item2);
        }

        // Print UI
        Console.WriteLine(this.robot.BagInfo());
        Console.WriteLine(this.robot.HealthInfo());
    }

    public List<Jewel> TakeJewels(Position position) {
        List<Entity> entities = this.grid.GetNearby(position);
        List<Jewel> jewels = entities.OfType<Jewel>().ToList();
        foreach(Jewel j in jewels) {
            this.grid.Set(j.Position, null);
        }
        return entities.OfType<Jewel>().ToList();
    }
}
