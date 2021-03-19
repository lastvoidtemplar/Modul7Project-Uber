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
    public class UsersTests
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
            var data = new List<User>
            {
                new User { FirstName="Item1" },
                new User { FirstName="Item2" },
                new User { FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var business = new UserBusiness(mockContext.Object);
            var users = business.GetAll();
            Assert.AreEqual(3, users.Count);
            Assert.AreEqual("Item1", users[0].FirstName);
            Assert.AreEqual("Item2", users[1].FirstName);
            Assert.AreEqual("Item3", users[2].FirstName);

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
            var data = new List<User>
            {
                new User { FirstName="Item1" },
                new User { FirstName="Item2" },
                new User { FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var user = new User() { FirstName = "Item4" };
            var business = new UserBusiness(mockContext.Object);
            business.Add(user);
            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned user is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<User>
            {
                 new User {Id =1, FirstName="Item1" },
                new User {Id =2, FirstName="Item2" },
                new User {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var business = new UserBusiness(mockContext.Object);
            var user = business.Get(1);
            Assert.AreEqual(1, user.Id);
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
            var data = new List<User>
            {
                 new User {Id =1, FirstName="Item1" },
                new User {Id =2, FirstName="Item2" },
                new User {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var business = new UserBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if user with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<User>
            {
                new User {Id =1, FirstName="Item1" },
                new User {Id =2, FirstName="Item2" },
                new User {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var business = new UserBusiness(mockContext.Object);
            var users = business.GetAll();
            int deleteId = 1; business.Delete(users[0].Id);
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
             var data = new List<User>
            {
                new User {Id =1, FirstName="Item1" },
                new User {Id =2, FirstName="Item2" },
                new User {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
            var business = new UserBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
