using System.Collections.Generic;
using System.Linq;
using AP.Models.Entities;

namespace AP.MVC.Repositories
{
    public class UserRepository
    {
        private static List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "1234",
                MustChangePassword = false
            }
        };

        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }

        public User GetByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public void UpdatePassword(User user, string newPassword)
        {
            user.Password = newPassword;
            user.MustChangePassword = false;
        }
    }
}