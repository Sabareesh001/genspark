using Oops.Models;

namespace Oops.Interfaces
{
    public interface IInteract
    {
        void AddUser(Dictionary<int, User> users, ref int nextId);
        void SendNotification(Dictionary<int, User> users);
    }
}
