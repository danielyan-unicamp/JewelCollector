public class Robot : Entity
{
    private List<Jewel> bag = new List<Jewel>();
    public Robot(Position position) : base(position) {}

    public void MoveTo(Position newPosition) {
        this.Position = newPosition;
    }

    public void Move(Position deltaPosition) {
        this.Position += deltaPosition;
    }

    public void AddJewels(List<Jewel> jewels) {
        this.bag.AddRange(jewels);
    }


    public string BagInfo() {
        int total = 0;
        foreach(Jewel j in bag) {
            total += j.GetValue();
        }
        return $"Bag total items: {this.bag.Count} | Bag total value: {total}";
    }

    public override string ToString() {
        return "ME";
    }
}