public class Robot : Entity
{

    public Robot(int x, int y) : base(x, y) {

    }

    public void MoveUp() {
        this.Position.Add(0, -1);
    }
    public void MoveLeft() {
        this.Position.Add(-1, 0);
    }
    public void MoveDown() {
        this.Position.Add(0, 1);
    }
    public void MoveRight() {
        this.Position.Add(1, 0);
    }

    private bool IsOutOfMap(Map map, Position position) {
        return position.IsOutOfBounds(map.Width, map.Height);
    }
    public bool CanMoveUp(Map map) {
        return !this.IsOutOfMap(map, this.Position + new Position(0, -1));
    }
    public bool CanMoveLeft(Map map) {
        return !this.IsOutOfMap(map, this.Position + new Position(-1, 0));
    }
    public bool CanMoveDown(Map map) {
        return !this.IsOutOfMap(map, this.Position + new Position(0, 1));
    }
    public bool CanMoveRight(Map map) {
        return !this.IsOutOfMap(map, this.Position + new Position(1, 0));
    }
}