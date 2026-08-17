using AP.Data.Repositories;
using AP.Models.Entities;
using System;

namespace AP.MVC.Services
{
    //SOLID: SRP - logica de usuarios
    //DP: Service layer
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

        // Registro
        public bool RegisterUser(string name, string email, string password)
        {
            if (UserExists(email))
                return false;

            var user = new User
            {
                Name = name,
                Username = email,
                Password = password,
                Role = "Player"
            };

            _repo.CreateUser(user);

            return true;
        }
    }
}