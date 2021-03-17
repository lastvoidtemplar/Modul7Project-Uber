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
        public List<UserProfile> GetAll()
        {
            return uberContext.UserProfiles.ToList();
        }
        public UserProfile Get(int id)
        {

            return uberContext.UserProfiles.FirstOrDefault(m => m.Id == id);

        }
        public void Add(UserProfile userProfile)
        {
            uberContext.UserProfiles.Add(userProfile);
            uberContext.SaveChanges();
        }
        public void Update(UserProfile userProfile)
        {
            var item = uberContext.UserProfiles.FirstOrDefault(m => m.Id == userProfile.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(userProfile);
                uberContext.SaveChanges();
            }
        }
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
