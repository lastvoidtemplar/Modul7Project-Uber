using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class VehicleBusiness
    {
        private UberContext uberContext;
        public List<Vehicle> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Vehicles.ToList();
            }
        }
        public Vehicle Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Vehicles.Find(id);
            }

        }
        public void Add(Vehicle vehicle)
        {
            using (uberContext = new UberContext())
            {
                uberContext.Vehicles.Add(vehicle);
                uberContext.SaveChanges();
            }
        }
        public void Update(Vehicle vehicle)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.Vehicles.Find(vehicle.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(vehicle);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
            {
                var item = uberContext.Vehicles.Find(id);
                if (item != null)
                {
                    uberContext.Vehicles.Remove(item);
                    uberContext.SaveChanges();
                }
            }
        }
    }
}
