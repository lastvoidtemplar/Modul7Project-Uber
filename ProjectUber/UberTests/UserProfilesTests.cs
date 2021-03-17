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
    public class UserProfilesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void GetAllTest()
        {
            var data = new List<UserProfile>
            {
                new UserProfile { Username="Item1" },
                new UserProfile { Username="Item2" },
                new UserProfile { Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<UserProfile>>();
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.UserProfiles).Returns(mockSet.Object);
            var business = new UserProfileBusiness(mockContext.Object);
            var userProfiles = business.GetAll();
            Assert.AreEqual(3, userProfiles.Count);
            Assert.AreEqual("Item1", userProfiles[0].Username);
            Assert.AreEqual("Item2", userProfiles[1].Username);
            Assert.AreEqual("Item3", userProfiles[2].Username);

        }
        [TestCase]
        public void AddTest()
        {
            var data = new List<UserProfile>
            {
                new UserProfile { Username="Item1" },
                new UserProfile { Username="Item2" },
                new UserProfile { Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<UserProfile>>();
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.UserProfiles).Returns(mockSet.Object);
            var userProfile = new UserProfile() { Username = "Item4" };
            var business = new UserProfileBusiness(mockContext.Object);
            business.Add(userProfile);
            mockSet.Verify(m => m.Add(It.IsAny<UserProfile>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<UserProfile>
            {
                 new UserProfile {Id =1, Username="Item1" },
                new UserProfile {Id =2, Username="Item2" },
                new UserProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<UserProfile>>();
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.UserProfiles).Returns(mockSet.Object);
            var business = new UserProfileBusiness(mockContext.Object);
            var userProfile = business.Get(1);
            Assert.AreEqual(1, userProfile.Id);
        }
        [TestCase]
        public void GetTestWithOutExistingId()
        {
            var data = new List<UserProfile>
            {
                new UserProfile {Id =1, Username="Item1" },
                new UserProfile {Id =2, Username="Item2" },
                new UserProfile {Id =3, Username="Item3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserProfile>>();
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.UserProfiles).Returns(mockSet.Object);
            var business = new UserProfileBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }

        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<UserProfile>
            {
                new UserProfile {Id =1, Username="Item1" },
                new UserProfile {Id =2, Username="Item2" },
                new UserProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<UserProfile>>();
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.UserProfiles).Returns(mockSet.Object);
            var business = new UserProfileBusiness(mockContext.Object);
            var userProfiles = business.GetAll();
            int deleteId = 1; business.Delete(userProfiles[0].Id);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.Id == deleteId));
        }
        [TestCase]
        public void DeleteTestWithOutExistingId()
        {
            var data = new List<UserProfile>()
            {
               new UserProfile {Id =1, Username="Item1" },
                new UserProfile {Id =2, Username="Item2" },
                new UserProfile {Id =3, Username="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<UserProfile>>();
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserProfile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.UserProfiles).Returns(mockSet.Object);
            var business = new UserProfileBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<UserProfile>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
