public class JewelCollector {

     public static void Main() {
  
        bool running = true;
        Game game = new Game(10, 10, 0, 0);
        game.Insert(new Red(1, 9));
        game.Insert(new Red(8, 8));
        game.Insert(new Green(9, 1));
        game.Insert(new Green(7, 6));
        game.Insert(new Blue(3, 4));
        game.Insert(new Blue(2, 1));
        do {
            game.Print();
            Console.Write("Enter the command: ");
            string? command = Console.ReadLine();
            running = game.ProcessInput(command);
        } while (running);
    }
}