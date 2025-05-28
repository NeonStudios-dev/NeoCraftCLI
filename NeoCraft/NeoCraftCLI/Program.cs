using System;
using NeoCraftCLI;

namespace NeoCraftCLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string projectName = "NeoCraft";
            string versionCodeName = "Modline";
            string version = "0.0.1";
            string state = "alpha";
            Console.Title = $"{projectName} - {versionCodeName} {state} {version}";

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "--help":
                        Console.WriteLine("Usage: NeoCraftCLI [options]");
                        Console.WriteLine("Options:");
                        Console.WriteLine("  --help       Show this help message");
                        Console.WriteLine("  --version    Show the version of the application");
                        break;

                    case "--version":
                        Console.WriteLine($"NeoCraftCLI\n - {state} preview {version}\n - Code Name: {versionCodeName}");
                        break;

                    default:
                        Console.WriteLine("done");
                        break;
                }
            }
            else
            {
                MainMenu();
            }
        }

        public static void MainMenu()
        {
            string projectName = "NeoCraft";
            string versionCodeName = "Modline";
            string version = "0.0.1";
            string state = "alpha";
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine($"---==== TestMenu - {projectName} {versionCodeName} {state} {version} ====---");
                Console.WriteLine(@"1 -> Instances
2 -> Accounts
3 -> Settings
4 -> Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Instances selected.");
                        Imgr.Run();
                        break;
                    case "2":
                        Console.WriteLine("Accounts selected.");
                        // TODO: Add Accounts logic here
                        break;
                    case "3":
                        Console.WriteLine("Settings selected.");
                        // TODO: Add Settings logic here
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}