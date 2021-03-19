using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DriverProfileBusiness
    {
        private UberContext uberContext;
        public DriverProfileBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public DriverProfileBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all driver profiles from the table DriverProfiles
        /// </summary>
        /// <returns></returns>
        public List<DriverProfile> GetAll()
        {

            return uberContext.DriverProfiles.ToList();

        }
        /// <summary>
        /// Gets a driver profile with a given id from the table DriverProfile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DriverProfile Get(int id)
        {

            return uberContext.DriverProfiles.FirstOrDefault(m => m.Id == id);


        }
        /// <summary>
        /// Adds a driver profile to the table DriverProfiles
        /// </summary>
        /// <param name="driverProfile"></param>
        public void Add(DriverProfile driverProfile)
        {

            uberContext.DriverProfiles.Add(driverProfile);
            uberContext.SaveChanges();

        }
        /// <summary>
        /// Updates the changes for a given driver profile from the table DriverProfile
        /// </summary>
        /// <param name="driverProfile"></param>
        public void Update(DriverProfile driverProfile)
        {

            var item = uberContext.DriverProfiles.FirstOrDefault(m => m.Id == driverProfile.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(driverProfile);
                uberContext.SaveChanges();
            }

        }
        /// <summary>
        /// Deletes a driver profile with a given id from the table DriverProfiles
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var item = uberContext.DriverProfiles.Find(id);
            if (item != null)
            {
                uberContext.DriverProfiles.Remove(item);
                uberContext.SaveChanges();
            }
        }
    }
}
