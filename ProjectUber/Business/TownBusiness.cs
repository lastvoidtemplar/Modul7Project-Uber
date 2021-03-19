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
    /// Business logic of the table Towns
    /// </summary>
    public class TownBusiness
    {
        private UberContext uberContext;

        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public TownBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public TownBusiness()
        {
            uberContext = new UberContext();
        }

        /// <summary>
        /// Gets all towns from the table Towns
        /// </summary>
        /// <returns>List of all towns</returns>
        public List<Town> GetAll()
        {
            return uberContext.Towns.ToList();
        }

        /// <summary>
        /// Gets a town with a given id from the table Towns
        /// </summary>
        /// <param name="id">Id used to find the town</param>
        /// <returns>Town with the given id</returns>
        public Town Get(int id)
        {
            return uberContext.Towns.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Adds a town to the table Towns
        /// </summary>
        /// <param name="town">Town that will be added to the table</param>
        public void Add(Town town)
        {
            uberContext.Towns.Add(town);
            uberContext.SaveChanges();
        }

        /// <summary>
        /// Updates the changes to a given town from the table Towns
        /// </summary>
        /// <param name="town">Town that will be updated</param>
        public void Update(Town town)
        {
            var item = uberContext.Towns.FirstOrDefault(m => m.Id == town.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(town);
                uberContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a town with a given id from the table Towns
        /// </summary>
        /// <param name="id">The id of the given town</param>
        public void Delete(int id)
        {
            var item = uberContext.Towns.Find(id);
            if (item != null)
            {
                uberContext.Towns.Remove(item);
                uberContext.SaveChanges();
            }
        }
    }
}
