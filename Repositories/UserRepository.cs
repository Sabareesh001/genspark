using Oops.Models;
using Oops.Interfaces;

namespace Oops.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<int, User> _users;
        private int _nextId;

        public UserRepository()
        {
            _users = new Dictionary<int, User>();
            _nextId = 1;
            InitializeDefaultUsers();
        }

        private void InitializeDefaultUsers()
        {
            _users.Add(_nextId++, new User("John Doe", "john@example.com", "555-1234"));
            _users.Add(_nextId++, new User("Jane Smith", "jane@example.com", "555-5678"));
            _users.Add(_nextId++, new User("Bob Johnson", "bob@example.com", "555-9012"));
            _users.Add(_nextId++, new User("Alice Williams", "alice@example.com", "555-3456"));
            _users.Add(_nextId++, new User("Charlie Brown", "charlie@example.com", "555-7890"));
        }

        public void AddUser(User user)
        {
            _users.Add(_nextId++, user);
        }

        public User? GetUser(int id)
        {
            return _users.ContainsKey(id) ? _users[id] : null;
        }

        public Dictionary<int, User> GetAllUsers()
        {
            return new Dictionary<int, User>(_users);
        }

        public bool UserExists(int id)
        {
            return _users.ContainsKey(id);
        }
    }
}
