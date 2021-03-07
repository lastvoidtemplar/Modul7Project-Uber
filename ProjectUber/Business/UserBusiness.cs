using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public  class UserBusiness
    {
        private UberContext uberContext;
        public List<User> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Users.ToList();
            }
        }
        public User Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Users.Find(id);
            }

        }
        public void Add(User user)
        {
            using (uberContext = new UberContext())
            {
                uberContext.Users.Add(user);
                uberContext.SaveChanges();
            }
        }
        public void Update(User user)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.Users.Find(user.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(user);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
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
}
