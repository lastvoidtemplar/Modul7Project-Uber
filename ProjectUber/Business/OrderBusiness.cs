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
    /// Business logic of the table Orders
    /// </summary>
    public class OrderBusiness
    {
        private UberContext uberContext;

        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public OrderBusiness(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public OrderBusiness()
        {
            uberContext = new UberContext();
        }

        /// <summary>
        /// Gets all orders from the table Orders
        /// </summary>
        /// <returns>List of all orders</returns>
        public List<Order> GetAll()
        {
            return uberContext.Orders.ToList();
        }

        /// <summary>
        /// Gets an order with a given id from the table Orders
        /// </summary>
        /// <param name="id">Id used to find the order</param>
        /// <returns>Order with the given id</returns>
        public Order Get(int id)
        {
            return uberContext.Orders.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Adds an order to the table Orders
        /// </summary>
        /// <param name="order">Order that will be added to the table</param>
        public void Add(Order order)
        {
            uberContext.Orders.Add(order);
            uberContext.SaveChanges();
        }

        /// <summary>
        /// Updates the changes for a given order from the table Orders
        /// </summary>
        /// <param name="order">Order that will be updated</param>
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
        /// <param name="id">The id of the given order</param>
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
