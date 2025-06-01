using System;
using System.Collections.Generic;

namespace NeoCraftCLI
{
    public class ImgrServ
    {
        // Store instance names in memory for this demo
        private static List<string> instances = new List<string>();

        public static void ListInst()
        {
            Console.WriteLine("Listing Instances...");
            if (instances.Count == 0)
            {
                Console.WriteLine("No instances found.");
                return;
            }
            for (int i = 0; i < instances.Count; i++)
            {
                Console.WriteLine($"Instance {i + 1}: {instances[i]}");
            }
        }

        public static void CreateInst(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Instance name cannot be empty.");
                return;
            }
            if (instances.Contains(name))
            {
                Console.WriteLine($"Instance '{name}' already exists.");
                return;
            }
            instances.Add(name);
            Console.WriteLine($"Instance '{name}' created successfully.");
        }

        public static void DeleteInst(string name)
        {
            if (!instances.Remove(name))
            {
                Console.WriteLine($"Instance '{name}' not found.");
            }
            else
            {
                Console.WriteLine($"Instance '{name}' deleted successfully.");
            }
        }

        public static void StartInst(string name)
        {
            if (!instances.Contains(name))
            {
                Console.WriteLine($"Instance '{name}' not found.");
                return;
            }
            Console.WriteLine($"Instance '{name}' started successfully.");
        }

        public static void StopInst(string name)
        {
            if (!instances.Contains(name))
            {
                Console.WriteLine($"Instance '{name}' not found.");
                return;
            }
            Console.WriteLine($"Instance '{name}' stopped successfully.");
        }

        public static void RestartInst(string name)
        {
            if (!instances.Contains(name))
            {
                Console.WriteLine($"Instance '{name}' not found.");
                return;
            }
            Console.WriteLine($"Instance '{name}' restarted successfully.");
        }

        public static void UpdateInst(string name)
        {
            if (!instances.Contains(name))
            {
                Console.WriteLine($"Instance '{name}' not found.");
                return;
            }
            Console.WriteLine($"Instance '{name}' updated successfully.");
        }

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Instance Manager!");
            Console.WriteLine("Available commands:");
            Console.WriteLine("1. List Instances");
            Console.WriteLine("2. Create Instance");
            Console.WriteLine("3. Delete Instance");
            Console.WriteLine("4. Start Instance");
            Console.WriteLine("5. Stop Instance");
            Console.WriteLine("6. Restart Instance");
            Console.WriteLine("7. Update Instance");
            Console.WriteLine("8. Exit");

            while (true)
            {
                Console.Write("\nEnter command number: ");
                string input = Console.ReadLine()?.Trim();
                switch (input)
                {
                    case "1":
                        ListInst();
                        break;
                    case "2":
                        Console.Write("Enter instance name: ");
                        CreateInst(Console.ReadLine()?.Trim());
                        break;
                    case "3":
                        Console.Write("Enter instance name to delete: ");
                        DeleteInst(Console.ReadLine()?.Trim());
                        break;
                    case "4":
                        Console.Write("Enter instance name to start: ");
                        StartInst(Console.ReadLine()?.Trim());
                        break;
                    case "5":
                        Console.Write("Enter instance name to stop: ");
                        StopInst(Console.ReadLine()?.Trim());
                        break;
                    case "6":
                        Console.Write("Enter instance name to restart: ");
                        RestartInst(Console.ReadLine()?.Trim());
                        break;
                    case "7":
                        Console.Write("Enter instance name to update: ");
                        UpdateInst(Console.ReadLine()?.Trim());
                        break;
                    case "8":
                        Console.WriteLine("Exiting Instance Manager. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
    }
}
