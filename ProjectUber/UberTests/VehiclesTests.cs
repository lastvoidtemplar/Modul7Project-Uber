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
    public class VehiclesTests
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
            var data = new List<Vehicle>
            {
                new Vehicle { Model="Item1" },
                new Vehicle { Model="Item2" },
                new Vehicle { Model="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Vehicles).Returns(mockSet.Object);
            var business = new VehicleBusiness(mockContext.Object);
            var vehicles = business.GetAll();
            Assert.AreEqual(3, vehicles.Count);
            Assert.AreEqual("Item1", vehicles[0].Model);
            Assert.AreEqual("Item2", vehicles[1].Model);
            Assert.AreEqual("Item3", vehicles[2].Model);
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
            var data = new List<Vehicle>
            {
                new Vehicle { Model="Item1" },
                new Vehicle { Model="Item2" },
                new Vehicle { Model="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Vehicles).Returns(mockSet.Object);
            var vehicle = new Vehicle() { Model = "Item4" };
            var business = new VehicleBusiness(mockContext.Object);
            business.Add(vehicle);
            mockSet.Verify(m => m.Add(It.IsAny<Vehicle>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned vehicle is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Vehicle>
            {
                new Vehicle {Id =1, Model="Item1" },
                new Vehicle {Id =2, Model="Item2" },
                new Vehicle {Id =3, Model="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Vehicles).Returns(mockSet.Object);
            var business = new VehicleBusiness(mockContext.Object);
            var vehicle = business.Get(1);
            Assert.AreEqual(1, vehicle.Id);
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
            var data = new List<Vehicle>
            {
                new Vehicle {Id =1, Model="Item1" },
                new Vehicle {Id =2, Model="Item2" },
                new Vehicle {Id =3, Model="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Vehicles).Returns(mockSet.Object);
            var business = new VehicleBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if vehicle with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Vehicle>
            {
                new Vehicle {Id =1, Model="Item1" },
                new Vehicle {Id =2, Model="Item2" },
                new Vehicle {Id =3, Model="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Vehicles).Returns(mockSet.Object);
            var business = new VehicleBusiness(mockContext.Object);
            var vehicles = business.GetAll();
            int deleteId = 1; business.Delete(vehicles[0].Id);
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
            var data = new List<Vehicle>
            {
                new Vehicle {Id =1, Model="Item1" },
                new Vehicle {Id =2, Model="Item2" },
                new Vehicle {Id =3, Model="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Vehicles).Returns(mockSet.Object);
            var business = new VehicleBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Vehicle>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
