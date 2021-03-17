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

        public VehicleBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public VehicleBusiness()
        {
            uberContext = new UberContext();
        }

        public List<Vehicle> GetAll()
        {
            return uberContext.Vehicles.ToList();
        }
        public Vehicle Get(int id)
        {
            return uberContext.Vehicles.FirstOrDefault(m => m.Id == id);
        }
        public void Add(Vehicle vehicle)
        {
            uberContext.Vehicles.Add(vehicle);
            uberContext.SaveChanges();
        }
        public void Update(Vehicle vehicle)
        {
            var item = uberContext.Vehicles.FirstOrDefault(m => m.Id == vehicle.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(vehicle);
                uberContext.SaveChanges();
            }
        }
        public void Delete(int id)
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
