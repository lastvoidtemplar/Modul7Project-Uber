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
        public List<DriverProfile> GetAll()
        {

            return uberContext.DriverProfiles.ToList();

        }
        public DriverProfile Get(int id)
        {

            return uberContext.DriverProfiles.FirstOrDefault(m => m.Id == id);


        }
        public void Add(DriverProfile driverProfile)
        {

            uberContext.DriverProfiles.Add(driverProfile);
            uberContext.SaveChanges();

        }
        public void Update(DriverProfile driverProfile)
        {

            var item = uberContext.DriverProfiles.FirstOrDefault(m => m.Id == driverProfile.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(driverProfile);
                uberContext.SaveChanges();
            }

        }
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
