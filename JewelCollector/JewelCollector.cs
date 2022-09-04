public class JewelCollector {

     public static void Main() {
  
        bool running = true;
  
        do {
  
            Console.Write("Enter the command: ");
            string? command = Console.ReadLine();
            if (command == null) {
                continue;
            } else if (command.Equals("quit")) {
                running = false;
            } else if (command.Equals("w")) {
                
            } else if (command.Equals("a")) {
                
            } else if (command.Equals("s")) {
                
            } else if (command.Equals("d")) {
            
            } else if (command.Equals("g")) {
                
            }
        } while (running);
    }
}