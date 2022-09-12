public class Map
{
    private int Width { get => EntityGrid.Width; }
    private int Height { get => EntityGrid.Height; }
    private Grid<Entity> EntityGrid;
    public Map(int width, int height)
    {
        EntityGrid = new Grid<Entity>(width, height);
    }

    public void Set(Position position, Entity? entity)
    {
        EntityGrid.Set(position, entity);
    }
    public void Insert(Entity e)
    {
        Set(e.Position, e);
    }

    public void UpdatePosition(Position oldPosition, Position newPosition, Entity entity)
    {
        Set(oldPosition, null);
        Set(newPosition, entity);
    }

    public void Interact(Robot robot)
    {
        List<Entity> entities = EntityGrid.GetNearby(robot.Position);
        foreach (Entity entity in entities)
        {
            if (entity is ICollectable ic)
            {
                Set(entity.Position, null);
                ic.Collect(robot);
            }
            if (entity is IRechargeable ir)
            {
                ir.Recharge(robot);
            }
        }
    }


    public void CheckCollision(Position nextPosition)
    {
        if (nextPosition.IsOutOfBounds(Width, Height)) throw new OutOfBoundsException();
        if (EntityGrid.Get(nextPosition) != null) throw new CollisionException();
    }

    public void Print()
    {
        foreach ((Position position, String lineEnd) tuple in Position.LoopAll(Width, Height))
        {
            Entity? e = EntityGrid.Get(tuple.position);
            Console.Write(e == null ? "--" : e);
            Console.Write(tuple.lineEnd);
        }

    }

}
