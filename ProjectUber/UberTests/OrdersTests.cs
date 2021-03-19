using Business;
using Data;
using Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberTests
{
    public class OrdersTests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if elements of the test list are equal to elements of the returned list from the business.
        /// </summary>
        [TestCase]
        public void GetAllTest()
        {
            var data = new List<Order>
            {
                new Order { Price=100 },
                new Order { Price=200 },
                new Order { Price=300 },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            var business = new OrderBusiness(mockContext.Object);
            var products = business.GetAll();
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual(100, products[0].Price);
            Assert.AreEqual(200, products[1].Price);
            Assert.AreEqual(300, products[2].Price);
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Verifies if methods "Add" and "SaveChanges" were performed.
        /// </summary>
        [TestCase]
        public void AddTest()
        {
            var data = new List<Order>
            {
                new Order { Price=100 },
                new Order { Price=200 },
                new Order { Price=300 },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            var product = new Order() { Price = 400 };
            var business = new OrderBusiness(mockContext.Object);
            business.Add(product);
            mockSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned order is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Order>
                {
                new Order {Id=1, Price=100 },
                new Order {Id=2, Price=200 },
                new Order {Id=3, Price=300 },
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            var business = new OrderBusiness(mockContext.Object);
            var product = business.Get(1);
            Assert.AreEqual(1, product.Id);
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if method "Get" will return null, if it is given non-existenting id.
        /// </summary>
        [TestCase]
        public void GetTestWithOutExistingId()
        {
            var data = new List<Order>
                {
                new Order {Id=1, Price=100 },
                new Order {Id=2, Price=200 },
                new Order {Id=3, Price=300 },
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            var business = new OrderBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if order with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Order>
                {
                new Order {Id=1, Price=100 },
                new Order {Id=2, Price=200 },
                new Order {Id=3, Price=300 },
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Orders).Returns(mockSet.Object);
            var business = new OrderBusiness(mockContext.Object);
            var products = business.GetAll();
            int deleteId = 1; business.Delete(products[0].Id);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.Id == deleteId));
        }
        [TestCase]
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if method "Delete" will throw exeption, if it is given non-existenting id.
        /// </summary>
        public void DeleteTestWithOutExistingId()
        {
            var data = new List<Order>
                {
                new Order {Id=1, Price=100 },
                new Order {Id=2, Price=200 },
                new Order {Id=3, Price=300 },
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Orders).Returns(mockSet.Object);
            var business = new OrderBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Order>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
