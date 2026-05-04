using Oops.Interfaces;
using Oops.Models;
namespace Oops.Services
{
    public class EmailNotification(string Message) : INotification
    {
        public string Message { get; set; } = Message;
        public DateOnly SentDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public void SendNotification(User user)
        {
            Console.WriteLine(Message);
            Console.WriteLine($"This message sent to {user.Email} on {SentDate}");
        }
    }
    public class SmsNotification(string Message) : INotification
    {
        public string Message { get; set; } = Message;
        public DateOnly SentDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public void SendNotification(User user)
        {
            Console.WriteLine(Message);
            Console.WriteLine($"This message sent to {user.PhoneNumber} on {SentDate}");
        }
    }

}