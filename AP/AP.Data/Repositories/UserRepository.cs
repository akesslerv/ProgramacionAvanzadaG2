using AP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AP.Data.Repositories
{
    public class UserRepository
    {
        private readonly MathPuzzleEntities db = new MathPuzzleEntities();

        public User ValidateUser(string username, string password)
        {
            var entity = db.Users.FirstOrDefault(u => u.Email == username);

            if (entity == null)
                return null;

            if (entity.Password != password)
                return null;

            return MapUser(entity);
        }

        public User GetByUsername(string username)
        {
            var entity = db.Users.FirstOrDefault(u =>
                u.Email == username);

            if (entity == null)
                return null;

            return MapUser(entity);
        }

        public void UpdatePassword(User user, string newPassword)
        {
            var entity = db.Users.FirstOrDefault(u =>
                u.UserId == user.Id);

            if (entity != null)
            {
                entity.Password = newPassword;
                db.SaveChanges();

                user.Password = newPassword;
                user.MustChangePassword = false;
            }
        }

        private User MapUser(Users entity)
        {
            return new User
            {
                Id = entity.UserId,
                Username = entity.Email,
                Name = entity.Name,
                Password = entity.Password,
                Role = entity.Role,
                MustChangePassword = false
            };
        }
        public bool CreateUser(User user)
        {
            var entity = new Users
            {
                Name = user.Name,
                Email = user.Username,
                Password = user.Password,
                Role = "Player"
            };

            db.Users.Add(entity);
            db.SaveChanges();

            return true;
        }
    }
}