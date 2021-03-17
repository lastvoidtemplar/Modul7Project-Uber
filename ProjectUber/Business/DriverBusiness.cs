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
        public DriverBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public DriverBusiness()
        {
            uberContext = new UberContext();
        }
        public List<Driver> GetAll()
        {
            return uberContext.Drivers.ToList();
        }
        public Driver Get(int id)
        {
            return uberContext.Drivers.FirstOrDefault(m => m.Id == id);
        }
        public void Add(Driver driver)
        {
            uberContext.Drivers.Add(driver);
            uberContext.SaveChanges();
        }
        public void Update(Driver driver)
        {
            var item = uberContext.Drivers.FirstOrDefault(m => m.Id == driver.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(driver);
                uberContext.SaveChanges();
            }
        }
        public void Delete(int id)
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
