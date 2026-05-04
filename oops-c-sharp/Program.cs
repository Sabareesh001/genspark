using Oops.Interfaces;
using Oops.Services;
using Oops.Models;
using Oops.Repositories;

namespace Oops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize repository (dependency)
            IUserRepository userRepository = new UserRepository();

            // Inject repository into service (dependency injection)
            IInteract interactService = new InteractService(userRepository);

            bool running = true;

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
                        interactService.AddUser();
                        break;
                    case "2":
                        interactService.SendNotification();
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