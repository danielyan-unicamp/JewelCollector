public class JewelCollector {

     public static void Main() {
  
        bool running = true;
        Game game = new Game(10, 10, 0, 0);
        game.InsertJewel(new Red(1, 9));
        game.InsertJewel(new Red(8, 8));
        game.InsertJewel(new Green(9, 1));
        game.InsertJewel(new Green(7, 6));
        game.InsertJewel(new Blue(3, 4));
        game.InsertJewel(new Blue(2, 1));
        do {
            game.print();
            Console.Write("Enter the command: ");
            string? command = Console.ReadLine();
            running = game.ProcessInput(command);
        } while (running);
    }
}