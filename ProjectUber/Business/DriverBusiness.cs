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
        /// <summary>
        /// Gets all drivers from the table Drivers
        /// </summary>
        /// <returns></returns>
        public List<Driver> GetAll()
        {
            return uberContext.Drivers.ToList();
        }
        /// <summary>
        /// Gets a driver whith a given id from the table Drivers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Driver Get(int id)
        {
            return uberContext.Drivers.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds a driver to the table Drivers
        /// </summary>
        /// <param name="driver"></param>
        public void Add(Driver driver)
        {
            uberContext.Drivers.Add(driver);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes for a given driver from thw table Drivers
        /// </summary>
        /// <param name="driver"></param>
        public void Update(Driver driver)
        {
            var item = uberContext.Drivers.FirstOrDefault(m => m.Id == driver.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(driver);
                uberContext.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes a driver with a given id from the table Drivers 
        /// </summary>
        /// <param name="id"></param>
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
