using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserProfileBusiness
    {
        private UberContext uberContext;
        public UserProfileBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public UserProfileBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all user profiles from the table UserProfiles
        /// </summary>
        /// <returns></returns>
        public List<UserProfile> GetAll()
        {
            return uberContext.UserProfiles.ToList();
        }
        /// <summary>
        /// Gets an user profile with a given id from the table UserProfiles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserProfile Get(int id)
        {

            return uberContext.UserProfiles.FirstOrDefault(m => m.Id == id);

        }
        /// <summary>
        /// Adds an user profile to the table UserProfiles
        /// </summary>
        /// <param name="userProfile"></param>
        public void Add(UserProfile userProfile)
        {
            uberContext.UserProfiles.Add(userProfile);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes to a given user profile from UserProfiles
        /// </summary>
        /// <param name="userProfile"></param>
        public void Update(UserProfile userProfile)
        {
            var item = uberContext.UserProfiles.FirstOrDefault(m => m.Id == userProfile.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(userProfile);
                uberContext.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes an user profile with a given id from the table UserProfiles
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var item = uberContext.UserProfiles.Find(id);
            if (item != null)
            {
                uberContext.UserProfiles.Remove(item);
                uberContext.SaveChanges();
            }
        }
    }
}
