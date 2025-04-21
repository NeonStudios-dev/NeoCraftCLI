using System;

namespace NeoCraftCLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Check if the user provided a command-line argument
if (args.Length > 0)
{
    // Print the first argument to the console
    Console.WriteLine($"Argument: {args[0]}");
    
    switch (args[0])
    {
        case "--help":
            // Print help information
            Console.WriteLine("Usage: NeoCraftCLI [options]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --help       Show this help message");
            Console.WriteLine("  --version    Show the version of the application");
            break;
            
        case "--version":
            // Print the version of the application
            Console.WriteLine("NeoCraftCLI Version alpha preview 0.0.1");
            break;
            
        default:
            MainMenu();
            break;
    }
}
        }

 public static void MainMenu(){
        Console.WriteLine("TestMenu");
    }
    }

}

