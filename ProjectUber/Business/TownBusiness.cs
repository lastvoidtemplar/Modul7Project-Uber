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
        public List<Town> GetAll()
        {
            return uberContext.Towns.ToList();
        }
        public Town Get(int id)
        {
            return uberContext.Towns.FirstOrDefault(m => m.Id == id);
        }
        public void Add(Town town)
        {
            uberContext.Towns.Add(town);
            uberContext.SaveChanges();
        }
        public void Update(Town town)
        {
            var item = uberContext.Towns.FirstOrDefault(m => m.Id == town.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(town);
                uberContext.SaveChanges();
            }
        }
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
