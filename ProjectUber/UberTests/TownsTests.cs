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

    public class TownsTests
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
            var data = new List<Town>
            {
                new Town { Name="Item1" },
                new Town { Name="Item2" },
                new Town { Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            var business = new TownBusiness(mockContext.Object);
            var towns = business.GetAll();
            Assert.AreEqual(3, towns.Count);
            Assert.AreEqual("Item1", towns[0].Name);
            Assert.AreEqual("Item2", towns[1].Name);
            Assert.AreEqual("Item3", towns[2].Name);

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
            var data = new List<Town>
            {
                new Town { Name="Item1" },
                new Town { Name="Item2" },
                new Town { Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            var town = new Town() { Name = "Item4" };
            var business = new TownBusiness(mockContext.Object);
            business.Add(town);
            mockSet.Verify(m => m.Add(It.IsAny<Town>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned town is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Town>
            {
                 new Town {Id =1, Name="Item1" },
                new Town {Id =2, Name="Item2" },
                new Town {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            var business = new TownBusiness(mockContext.Object);
            var town = business.Get(1);
            Assert.AreEqual(1, town.Id);
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
            var data = new List<Town>
            {
                new Town {Id =1, Name="Item1" },
                new Town {Id =2, Name="Item2" },
                new Town {Id =3, Name="Item3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            var business = new TownBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if town with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Town>
            {
                new Town {Id =1, Name="Item1" },
                new Town {Id =2, Name="Item2" },
                new Town {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Towns).Returns(mockSet.Object);
            var business = new TownBusiness(mockContext.Object);
            var towns = business.GetAll();
            int deleteId = 1; business.Delete(towns[0].Id);
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
            var data = new List<Town>()
            {
               new Town {Id =1, Name="Item1" },
                new Town {Id =2, Name="Item2" },
                new Town {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Towns).Returns(mockSet.Object);
            var business = new TownBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Town>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
