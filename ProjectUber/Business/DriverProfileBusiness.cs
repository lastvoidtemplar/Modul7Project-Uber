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
        public List<DriverProfile> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.DriverProfiles.ToList();
            }
        }
        public DriverProfile Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.DriverProfiles.Find(id);
            }

        }
        public void Add(DriverProfile driverProfile)
        {
            using (uberContext = new UberContext())
            {
                uberContext.DriverProfiles.Add(driverProfile);
                uberContext.SaveChanges();
            }
        }
        public void Update(DriverProfile driverProfile)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.DriverProfiles.Find(driverProfile.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(driverProfile);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
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
}
