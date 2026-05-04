namespace Oops.Models
{
    public class User(string name, string email, string phoneNumber)
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string PhoneNumber { get; set; } = phoneNumber;
    }
}