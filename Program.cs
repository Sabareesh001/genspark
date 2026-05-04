using Oops.Interfaces;
using Oops.Services;
using Oops.Models;
namespace Oops
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, User> users = new Dictionary<int, User>
            {
                { 1, new User("John Doe", "john@example.com", "555-1234") },
                { 2, new User("Jane Smith", "jane@example.com", "555-5678") },
                { 3, new User("Bob Johnson", "bob@example.com", "555-9012") },
                { 4, new User("Alice Williams", "alice@example.com", "555-3456") },
                { 5, new User("Charlie Brown", "charlie@example.com", "555-7890") }
            };

            int nextId = 6;
            bool running = true;
            IInteract interactService = new InteractService();

            while (running)
            {
                Console.WriteLine("\n=== Notification System ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Send Notification");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        interactService.AddUser(users, ref nextId);
                        break;
                    case "2":
                        interactService.SendNotification(users);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}