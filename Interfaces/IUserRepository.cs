using Oops.Models;

namespace Oops.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUser(int id);
        Dictionary<int, User> GetAllUsers();
        bool UserExists(int id);
    }
}
