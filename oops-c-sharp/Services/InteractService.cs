using Oops.Interfaces;
using Oops.Models;
using Oops.Repositories;

namespace Oops.Services
{
    public class InteractService : IInteract
    {
        private readonly IUserRepository _userRepository;

        public InteractService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine() ?? "";

            var newUser = new User(name, email, phone);
            _userRepository.AddUser(newUser);
            Console.WriteLine("User added successfully");
        }

        public void SendNotification()
        {
            var allUsers = _userRepository.GetAllUsers();

            if (allUsers.Count == 0)
            {
                Console.WriteLine("No users available. Please add users first.");
                return;
            }

            Console.WriteLine("\n=== Users ===");
            foreach (var kvp in allUsers)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value.Name} ({kvp.Value.Email})");
            }

            Console.Write("Select user ID: ");
            if (int.TryParse(Console.ReadLine(), out int userId) && _userRepository.UserExists(userId))
            {
                User? selectedUser = _userRepository.GetUser(userId);
                if (selectedUser == null)
                {
                    Console.WriteLine("Error retrieving user.");
                    return;
                }

                Console.Write("Enter message: ");
                string message = Console.ReadLine() ?? "";

                Console.WriteLine("\nChoose notification type:");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. SMS");
                Console.Write("Choose: ");

                string notificationType = Console.ReadLine() ?? "";

                if (notificationType == "1")
                {
                    INotification emailNotification = new EmailNotification(message);
                    emailNotification.SendNotification(selectedUser);
                }
                else if (notificationType == "2")
                {
                    INotification smsNotification = new SmsNotification(message);
                    smsNotification.SendNotification(selectedUser);
                }
                else
                {
                    Console.WriteLine("Invalid notification type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid user ID.");
            }
        }
    }
}
