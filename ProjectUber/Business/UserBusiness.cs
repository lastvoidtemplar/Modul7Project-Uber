using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Business logic of the table Users
    /// </summary>
    public class UserBusiness
    {
        private UberContext uberContext;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public UserBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }
        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public UserBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all users from the table Users
        /// </summary>
        /// <returns>List of all users</returns>
        public List<User> GetAll()
        {
            return uberContext.Users.ToList();
        }
        /// <summary>
        /// Gets an user with a given id from the table Users
        /// </summary>
        /// <param name="id">Id used to find the user</param>
        /// <returns>User with the given id</returns>
        public User Get(int id)
        {
            return uberContext.Users.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds an user to the table Users
        /// </summary>
        /// <param name="user">User that will be added to the table</param>
        public void Add(User user)
        {
            uberContext.Users.Add(user);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes for a given user from the table Users
        /// </summary>
        /// <param name="user">User that will be updated</param>
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
        /// <param name="id">The id of given user</param>
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
