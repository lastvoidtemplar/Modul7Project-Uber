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
    public class DriverProfilesTests
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
            var data = new List<DriverProfile>
            {
                new DriverProfile { Username="Item1" },
                new DriverProfile { Username="Item2" },
                new DriverProfile { Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<DriverProfile>>();
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.DriverProfiles).Returns(mockSet.Object);
            var business = new DriverProfileBusiness(mockContext.Object);
            var DriverProfiles = business.GetAll();
            Assert.AreEqual(3, DriverProfiles.Count);
            Assert.AreEqual("Item1", DriverProfiles[0].Username);
            Assert.AreEqual("Item2", DriverProfiles[1].Username);
            Assert.AreEqual("Item3", DriverProfiles[2].Username);
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
            var data = new List<DriverProfile>
            {
                new DriverProfile { Username="Item1" },
                new DriverProfile { Username="Item2" },
                new DriverProfile { Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<DriverProfile>>();
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.DriverProfiles).Returns(mockSet.Object);
            var driverProfile = new DriverProfile() { Username = "Item4" };
            var business = new DriverProfileBusiness(mockContext.Object);
            business.Add(driverProfile);
            mockSet.Verify(m => m.Add(It.IsAny<DriverProfile>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned driverProfile is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<DriverProfile>
            {
                new DriverProfile {Id =1, Username="Item1" },
                new DriverProfile {Id =2, Username="Item2" },
                new DriverProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<DriverProfile>>();
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.DriverProfiles).Returns(mockSet.Object);
            var business = new DriverProfileBusiness(mockContext.Object);
            var driverProfile = business.Get(1);
            Assert.AreEqual(1, driverProfile.Id);
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
            var data = new List<DriverProfile>
            {
                new DriverProfile {Id =1, Username="Item1" },
                new DriverProfile {Id =2, Username="Item2" },
                new DriverProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<DriverProfile>>();
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.DriverProfiles).Returns(mockSet.Object);
            var business = new DriverProfileBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if driverProfile with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<DriverProfile>
            {
                new DriverProfile {Id =1, Username="Item1" },
                new DriverProfile {Id =2, Username="Item2" },
                new DriverProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<DriverProfile>>();
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.DriverProfiles).Returns(mockSet.Object);
            var business = new DriverProfileBusiness(mockContext.Object);
            var driverProfiles = business.GetAll();
            int deleteId = 1; business.Delete(driverProfiles[0].Id);
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
            var data = new List<DriverProfile>
            {
                new DriverProfile {Id =1, Username="Item1" },
                new DriverProfile {Id =2, Username="Item2" },
                new DriverProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<DriverProfile>>();
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DriverProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.DriverProfiles).Returns(mockSet.Object);
            var business = new DriverProfileBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<DriverProfile>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
