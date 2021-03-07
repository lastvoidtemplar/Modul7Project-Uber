using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DriverBusiness
    {
        private UberContext uberContext;
        public List<Driver> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Drivers.ToList();
            }
        }
        public Driver Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Drivers.Find(id);
            }

        }
        public void Add(Driver driver)
        {
            using (uberContext = new UberContext())
            {
                uberContext.Drivers.Add(driver);
                uberContext.SaveChanges();
            }
        }
        public void Update(Driver driver)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.Drivers.Find(driver.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(driver);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
            {
                var item = uberContext.Drivers.Find(id);
                if (item != null)
                {
                    uberContext.Drivers.Remove(item);
                    uberContext.SaveChanges();
                }
            }
        }
    }
}
