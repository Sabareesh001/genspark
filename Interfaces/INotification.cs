using Oops.Models;
namespace Oops.Interfaces
{
    public interface INotification
    {
        string Message { get; set; }
        DateOnly SentDate { get; set; }
        public void SendNotification(User user);
    }
}