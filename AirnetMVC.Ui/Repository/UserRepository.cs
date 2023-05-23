using AirnetMVC.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirnetMVC.Ui.Repository
{
    public class UserRepository
    {
        public AirnetContext context;
        public UserRepository()
        {
            context = new AirnetContext();
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

        }
        public void EditUser(User user)
        {
            context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteUser(string userId)
        {
            context.Users.Remove(context.Users.Find(userId));
            context.SaveChanges();
        }
        public User GetUserById(string userId)
        {
            User user = context.Users.Find(userId);
            return user;
        }

        public Plan GetPlanById(Guid id)
        {
            return context.Plans.Find(id);
        }

        public IEnumerable<User> GetAllUser()
        {
            var users = context.Users.ToList();
            return users;
        }


    }
}