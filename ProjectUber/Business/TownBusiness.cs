using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TownBusiness
    {
        private UberContext uberContext;
        public TownBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public TownBusiness()
        {
            uberContext = new UberContext();
        }
        /// <summary>
        /// Gets all towns from the table Towns
        /// </summary>
        /// <returns></returns>
        public List<Town> GetAll()
        {
            return uberContext.Towns.ToList();
        }
        /// <summary>
        /// Gets a town with a given id from the table Towns
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Town Get(int id)
        {
            return uberContext.Towns.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds a town to the table Towns
        /// </summary>
        /// <param name="town"></param>
        public void Add(Town town)
        {
            uberContext.Towns.Add(town);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes to a given town from the table Towns
        /// </summary>
        /// <param name="town"></param>
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
        /// <param name="id"></param>
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
