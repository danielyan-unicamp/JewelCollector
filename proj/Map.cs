public class Map
{
    private static string EMPTY_TILE = "--";
    public int Width { get; }
    public int Height { get; }
    public Map(int width, int height) {
        this.Width = width;
        this.Height = height;
    }

    public void print() {
        for (int i = 0; i < this.Height; i++) {
            for (int j = 0; j < this.Width; j++) {
                Console.Write(EMPTY_TILE);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
