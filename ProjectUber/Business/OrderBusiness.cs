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
        public OrderBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        public OrderBusiness()
        {
            uberContext = new UberContext();
        }
        public List<Order> GetAll()
        {
            return uberContext.Orders.ToList();
        }
        public Order Get(int id)
        {
            return uberContext.Orders.FirstOrDefault(m => m.Id == id);
        }
        public void Add(Order order)
        {
            uberContext.Orders.Add(order);
            uberContext.SaveChanges();
        }
        public void Update(Order order)
        {
            var item = uberContext.Orders.FirstOrDefault(m => m.Id == order.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(order);
                uberContext.SaveChanges();
            }
        }
        public void Delete(int id)
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
