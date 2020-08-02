using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public UserModel LogIn(string email, string password)
        {
            var users = DatabaseAccessor.Instance.Users.FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                                      && t.UserPassword == password));

            if (users == null)
            {
                return null;
            }

            return new UserModel { Id = users.UserId, Name = users.UserEmail };
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Register(email, password, false);

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user , Name = email };
        }
    }
}