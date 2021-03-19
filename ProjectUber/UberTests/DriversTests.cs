using Business;
using Data;
using Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UberTests
{
    public class DriversTests
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
            var data = new List<Driver>
            {
                new Driver { FirstName="Item1" },
                new Driver { FirstName="Item2" },
                new Driver { FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Driver>>();
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Drivers).Returns(mockSet.Object);
            var business = new DriverBusiness(mockContext.Object);
            var Drivers = business.GetAll();
            Assert.AreEqual(3, Drivers.Count);
            Assert.AreEqual("Item1", Drivers[0].FirstName);
            Assert.AreEqual("Item2", Drivers[1].FirstName);
            Assert.AreEqual("Item3", Drivers[2].FirstName);
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
            var data = new List<Driver>
            {
                new Driver { FirstName="Item1" },
                new Driver { FirstName="Item2" },
                new Driver { FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Driver>>();
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Drivers).Returns(mockSet.Object);
            var Driver = new Driver() { FirstName = "Item4" };
            var business = new DriverBusiness(mockContext.Object);
            business.Add(Driver);
            mockSet.Verify(m => m.Add(It.IsAny<Driver>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned driver is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Driver>
            {
                new Driver {Id =1, FirstName="Item1" },
                new Driver {Id =2, FirstName="Item2" },
                new Driver {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Driver>>();
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Drivers).Returns(mockSet.Object);
            var business = new DriverBusiness(mockContext.Object);
            var driver = business.Get(1);
            Assert.AreEqual(1, driver.Id);
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
            var data = new List<Driver>
            {
                new Driver {Id =1, FirstName="Item1" },
                new Driver {Id =2, FirstName="Item2" },
                new Driver {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Driver>>();
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Drivers).Returns(mockSet.Object);
            var business = new DriverBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if driver with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Driver>
            {
                new Driver {Id =1, FirstName="Item1" },
                new Driver {Id =2, FirstName="Item2" },
                new Driver {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Driver>>();
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Drivers).Returns(mockSet.Object);
            var business = new DriverBusiness(mockContext.Object);
            var drivers = business.GetAll();
            int deleteId = 1; business.Delete(drivers[0].Id);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.Id == deleteId));
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if method "Delete" will throw exeption, if it is given non-existenting id.
        /// </summary>
        [TestCase]
        public void DeleteTestWithOutExistingId()
        {
            var data = new List<Driver>
            {
                new Driver {Id =1, FirstName="Item1" },
                new Driver {Id =2, FirstName="Item2" },
                new Driver {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Driver>>();
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Driver>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Drivers).Returns(mockSet.Object);
            var business = new DriverBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Driver>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
