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
        public List<Town> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Towns.ToList();
            }
        }
        public Town Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Towns.Find(id);
            }

        }
        public void Add(Town town)
        {
            using(uberContext = new UberContext())
            {
                uberContext.Towns.Add(town);
                uberContext.SaveChanges();
            }
        }
        public void Update(Town town)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.Towns.Find(town.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(town);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
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
}
