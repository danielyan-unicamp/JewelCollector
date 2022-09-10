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
        game.Insert(new Water(5, 0));
        game.Insert(new Water(5, 1));
        game.Insert(new Water(5, 2));
        game.Insert(new Water(5, 3));
        game.Insert(new Water(5, 4));
        game.Insert(new Water(5, 5));
        game.Insert(new Water(5, 6));
        game.Insert(new Tree(5, 9));
        game.Insert(new Tree(3, 9));
        game.Insert(new Tree(8, 3));
        game.Insert(new Tree(2, 5));
        game.Insert(new Tree(1, 4));
        do {
            game.Print();
            Console.Write("Enter the command: ");
            string? command = Console.ReadLine();
            running = game.ProcessInput(command);
        } while (running);
    }
}