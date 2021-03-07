using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public  class UserProfileBusiness
    {
        private UberContext uberContext;
        public List<UserProfile> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.UserProfiles.ToList();
            }
        }
        public UserProfile Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.UserProfiles.Find(id);
            }

        }
        public void Add(UserProfile userProfile)
        {
            using (uberContext = new UberContext())
            {
                uberContext.UserProfiles.Add(userProfile);
                uberContext.SaveChanges();
            }
        }
        public void Update(UserProfile userProfile)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.UserProfiles.Find(userProfile.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(userProfile);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
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
}
