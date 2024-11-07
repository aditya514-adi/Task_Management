using System.Collections.Generic;
using System.Linq;
using BCrypt.Net; // Ensure this is included
using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public class InMemoryUserStore
    {
        private readonly List<UserModel> users = new List<UserModel>();

        public void AddUser(UserModel user)
        {
            if (users.Any(u => u.Username == user.Username))
            {
                throw new System.Exception("User already exists.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); // Hash the password before storing
            users.Add(user);
        }

        public UserModel GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public List<UserModel> GetAllUsers()
        {
            return users.ToList();
        }

        public bool ValidateUser(string username, string password)
        {
            var user = GetUser(username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password); // Verify hashed password
        }
    }
}
