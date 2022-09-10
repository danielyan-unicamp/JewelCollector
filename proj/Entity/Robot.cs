public class Robot : Entity
{
    private Jewel[] bag = new Jewel[100];
    private int bagSize = 0;
    public Robot(int x, int y) : base(x, y) {}
    public Robot(Position position) : base(position) {}


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
        Jewel[] jewels = map.TakeJewels(this.Position);
        foreach(Jewel jewel in jewels) {
            if (jewel is Jewel) {
                this.bag[bagSize++] = jewel;
            }
        }
    }

    public string BagInfo() {
        int total = 0;
        for(int i = 0; i < bagSize; i++) {
            total += bag[i].GetValue();
        }
        return $"Bag total items: {this.bagSize} | Bag total value: {total}";
    }

    public override string ToString()
    {
        return "ME";
    }
}