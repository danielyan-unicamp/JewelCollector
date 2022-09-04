public class JewelCollector {

     public static void Main() {
  
        bool running = true;
        Game game = new Game(10, 10, 0, 0);
        do {
            game.print();
            Console.Write("Enter the command: ");
            string? command = Console.ReadLine();
            running = game.processInput(command);
        } while (running);
    }
}