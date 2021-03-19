using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private UberContext uberContext;
        public UserBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public UserBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all users from the table Users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return uberContext.Users.ToList();
        }
        /// <summary>
        /// Gets an user with a given id from the table Users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(int id)
        {
            return uberContext.Users.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds an user to the table Users
        /// </summary>
        /// <param name="user"></param>
        public void Add(User user)
        {
            uberContext.Users.Add(user);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes for a given user from the table Users
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            var item = uberContext.Users.FirstOrDefault(m => m.Id == user.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(user);
                uberContext.SaveChanges();
            }

        }
        /// <summary>
        /// Deletes an user with a given id from the table Users
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var item = uberContext.Users.Find(id);
            if (item != null)
            {
                uberContext.Users.Remove(item);
                uberContext.SaveChanges();
            }
        }
    }
}
