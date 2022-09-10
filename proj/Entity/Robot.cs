public class Robot : Entity
{
    private int HealthPoints = 5;
    private List<ICollectable> bag = new List<ICollectable>();
    public Robot(Position position) : base(position) {}

    public void MoveTo(Position newPosition) {
        this.Position = newPosition;
    }

    public void Move(Position deltaPosition) {
        this.Position += deltaPosition;
        this.HealthPoints--;
    }
    public void AddHealth(int value) {
        this.HealthPoints += value;
    }

    public bool IsDead() {
        return this.HealthPoints == 0;
    }

    public void AddToBag(ICollectable collectable) {
        this.bag.Add(collectable);
    }


    public string BagInfo() {
        int total = 0;
        foreach(Jewel j in bag) {
            total += j.GetValue();
        }
        return $"Bag total items: {this.bag.Count} | Bag total value: {total}";
    }
    public string HealthInfo() {
        return $"Health: {this.HealthPoints}";
    }

    public override string ToString() {
        return "ME";
    }
}