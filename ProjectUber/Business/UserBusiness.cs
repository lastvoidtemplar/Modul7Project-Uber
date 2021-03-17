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
        public List<User> GetAll()
        {
            return uberContext.Users.ToList();
        }
        public User Get(int id)
        {
            return uberContext.Users.FirstOrDefault(m => m.Id == id);
        }
        public void Add(User user)
        {
            uberContext.Users.Add(user);
            uberContext.SaveChanges();
        }
        public void Update(User user)
        {
            var item = uberContext.Users.FirstOrDefault(m => m.Id == user.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(user);
                uberContext.SaveChanges();
            }

        }
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
