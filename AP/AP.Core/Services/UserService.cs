using AP.Data.Repositories;
using AP.Models.Entities;
using System;

namespace AP.MVC.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;

        public UserService()
        {
            _repo = new UserRepository();
        }

        // Login
        public User ValidateLogin(string username, string password)
        {
            return _repo.ValidateUser(username, password);
        }

        // Existe usuario
        public bool UserExists(string username)
        {
            return _repo.GetByUsername(username) != null;
        }

        // Cambiar contraseña
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