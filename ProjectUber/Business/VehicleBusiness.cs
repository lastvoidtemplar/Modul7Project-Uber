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
    /// Business logic of the table Vehicles
    /// </summary>
    public class VehicleBusiness
    {
        private UberContext uberContext;
        /// <summary>
        /// Constructor used in tests
        /// </summary>
        public VehicleBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }
        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public VehicleBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all vehicles from the table Vehicles
        /// </summary>
        /// <returns>List of all vehicles</returns>
        public List<Vehicle> GetAll()
        {
            return uberContext.Vehicles.ToList();
        }
        /// <summary>
        /// Gets a vehicle with a given id from the table Vehicles
        /// </summary>
        /// <param name="id">Id used to find the vehicle</param>
        /// <returns>Vehicle with the given id</returns>
        public Vehicle Get(int id)
        {
            return uberContext.Vehicles.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds a vehicle to the table Vehicles
        /// </summary>
        /// <param name="vehicle">Vehicle that will be added to the table</param>
        public void Add(Vehicle vehicle)
        {
            uberContext.Vehicles.Add(vehicle);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes to a given vehicle from the table Vehicles
        /// </summary>
        /// <param name="vehicle">Vehicle wich will be updated</param>
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
        /// <param name="id">The id of the given vehicle</param>
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
