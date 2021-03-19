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
        /// <summary>
        /// Gets all vehicles from the table Vehicles
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetAll()
        {
            return uberContext.Vehicles.ToList();
        }
        /// <summary>
        /// Gets a vehicle with a given id from the table Vehicles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vehicle Get(int id)
        {
            return uberContext.Vehicles.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds a vehicle to the table Vehicles
        /// </summary>
        /// <param name="vehicle"></param>
        public void Add(Vehicle vehicle)
        {
            uberContext.Vehicles.Add(vehicle);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes to a given vehicle from the table Vehicles
        /// </summary>
        /// <param name="vehicle"></param>
        public void Update(Vehicle vehicle)
        {
            var item = uberContext.Vehicles.FirstOrDefault(m => m.Id == vehicle.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(vehicle);
                uberContext.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes a vehicle with a given id from the table Vehicles
        /// </summary>
        /// <param name="id"></param>
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
