public class Map
{
    private static string EMPTY_TILE = "--";
    private int width;
    private int height;
    public Map(int width, int height) {
        this.width = width;
        this.height = height;
    }

    public void print() {
        for (int i = 0; i < this.height; i++) {
            for (int j = 0; j < this.width; j++) {
                Console.Write(EMPTY_TILE);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
