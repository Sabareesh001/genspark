using Oops.Interfaces;
using Oops.Models;

namespace Oops.Services
{
    public class InteractService : IInteract
    {
        public void AddUser(Dictionary<int, User> users, ref int nextId)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            users.Add(nextId, new User(name, email, phone));
            Console.WriteLine($"User added successfully with ID {nextId}");
            nextId++;
        }

        public void SendNotification(Dictionary<int, User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No users available. Please add users first.");
                return;
            }

            Console.WriteLine("\n=== Users ===");
            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value.Name} ({kvp.Value.Email})");
            }

            Console.Write("Select user ID: ");
            if (int.TryParse(Console.ReadLine(), out int userId) && users.ContainsKey(userId))
            {
                User selectedUser = users[userId];

                Console.Write("Enter message: ");
                string message = Console.ReadLine();

                Console.WriteLine("\nChoose notification type:");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. SMS");
                Console.Write("Choose: ");

                string notificationType = Console.ReadLine();

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
