using AP.Models.Entities;
using AP.MVC.Repositories;

namespace AP.MVC.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;

        public UserService()
        {
            _repo = new UserRepository();
        }

        // login
        public User ValidateLogin(string username, string password)
        {
            return _repo.ValidateUser(username, password);
        }

        // existe user
        public bool UserExists(string username)
        {
            return _repo.GetByUsername(username) != null;
        }

        // cambiar pwd
        public bool ChangePassword(string username, string newPassword)
        {
            var user = _repo.GetByUsername(username);

            if (user == null)
                return false;

            _repo.UpdatePassword(user, newPassword);
            return true;
        }
    }
}