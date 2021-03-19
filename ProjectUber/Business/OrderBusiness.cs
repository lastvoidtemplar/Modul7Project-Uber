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
        /// <summary>
        /// Gets all orders from the table Orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAll()
        {
            return uberContext.Orders.ToList();
        }
        /// <summary>
        /// Gets an order with a given id from the table Orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order Get(int id)
        {
            return uberContext.Orders.FirstOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Adds an order to the table Orders
        /// </summary>
        /// <param name="order"></param>
        public void Add(Order order)
        {
            uberContext.Orders.Add(order);
            uberContext.SaveChanges();
        }
        /// <summary>
        /// Updates the changes for a given order from the table Orders
        /// </summary>
        /// <param name="order"></param>
        public void Update(Order order)
        {
            var item = uberContext.Orders.FirstOrDefault(m => m.Id == order.Id);
            if (item != null)
            {
                uberContext.Entry(item).CurrentValues.SetValues(order);
                uberContext.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes an order with a given id from the table Orders
        /// </summary>
        /// <param name="id"></param>
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
