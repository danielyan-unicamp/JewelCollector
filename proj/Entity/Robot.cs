public class Robot : Entity
{
    private List<Jewel> bag = new List<Jewel>();
    public Robot(int x, int y) : base(x, y) {}
    public Robot(Position position) : base(position) {}

    public void MoveTo(Position newPosition) {
        this.Position = newPosition;
    }
    public void Move(Position deltaPosition) {
        this.Position.Add(deltaPosition);
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

    public void GrabJewels(Map map) {
        List<Jewel> jewels = map.TakeJewels(this.Position);
        this.bag.AddRange(jewels);
    }

    public string BagInfo() {
        int total = 0;
        foreach(Jewel j in bag) {
            total += j.GetValue();
        }
        return $"Bag total items: {this.bag.Count} | Bag total value: {total}";
    }

    public override string ToString()
    {
        return "ME";
    }
}