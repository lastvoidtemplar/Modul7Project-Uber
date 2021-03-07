using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderBusiness
    {
        private UberContext uberContext;
        public List<Order> GetAll()
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Orders.ToList();
            }
        }
        public Order Get(int id)
        {
            using (uberContext = new UberContext())
            {
                return uberContext.Orders.Find(id);
            }

        }
        public void Add(Order order)
        {
            using (uberContext = new UberContext())
            {
                uberContext.Orders.Add(order);
                uberContext.SaveChanges();
            }
        }
        public void Update(Order order)
        {
            using (uberContext = new UberContext())
            {
                var item = uberContext.Orders.Find(order.Id);
                if (item != null)
                {
                    uberContext.Entry(item).CurrentValues.SetValues(order);
                    uberContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {

            using (uberContext = new UberContext())
            {
                var item = uberContext.Orders.Find(id);
                if (item != null)
                {
                    uberContext.Orders.Remove(item);
                    uberContext.SaveChanges();
                }
            }
        }
    }
}
