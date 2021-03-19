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
    /// Business logic of the table Drivers
    /// </summary>
    public class DriverBusiness
    {
        private UberContext uberContext;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        /// <param name="uberContext"></param>
        public DriverBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }
        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public DriverBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all drivers from the table Drivers
        /// </summary>
        /// <returns>List of all drivers</returns>
        public List<Driver> GetAll()
        {
            return uberContext.Drivers.ToList();
        }
        /// <summary>
        /// Gets a driver whith a given id from the table Drivers
        /// </summary>
        /// <param name="id">Id used to find the driver</param>
        /// <returns>Driver with the given id</returns>
        public Driver Get(int id)
        {
            return uberContext.Drivers.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds a driver to the table Drivers
        /// </summary>
        /// <param name="driver">Driver that will be added to the table</param>
        public void Add(Driver driver)
        {
            uberContext.Drivers.Add(driver);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes for a given driver from thw table Drivers
        /// </summary>
        /// <param name="driver">Driver that will be updated</param>
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
        /// <param name="id">Id of the given driver</param>
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
