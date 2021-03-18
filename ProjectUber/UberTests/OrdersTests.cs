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
