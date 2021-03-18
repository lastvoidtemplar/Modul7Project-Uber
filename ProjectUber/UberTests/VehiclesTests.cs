using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberTests
{
    public class VehiclesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void GetAllTest()
        {
            var data = new List<Vehicle>
            {
                new Product { Name="Item1" },
                new Product { Name="Item2" },
                new Product { Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);
            var business = new ProductBusiness(mockContext.Object);
            var products = business.GetAll();
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual("Item1", products[0].Name);
            Assert.AreEqual("Item2", products[1].Name);
            Assert.AreEqual("Item3", products[2].Name);



        }
        [TestCase]
        public void AddTest()
        {
            var data = new List<Product>
            {
                new Product { Name="Item1" },
                new Product { Name="Item2" },
                new Product { Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);
            var product = new Product() { Name = "Item4" };
            var business = new ProductBusiness(mockContext.Object);
            business.Add(product);
            mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Product>
            {
                 new Product {Id =1, Name="Item1" },
                new Product {Id =2, Name="Item2" },
                new Product {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);
            var business = new ProductBusiness(mockContext.Object);
            var product = business.Get(1);
            Assert.AreEqual(1, product.Id);
        }
        [TestCase]
        public void GetTestWithOutExistingId()
        {
            var data = new List<Product>
            {
                new Product {Id =1, Name="Item1" },
                new Product {Id =2, Name="Item2" },
                new Product {Id =3, Name="Item3" },
            }.AsQueryable();



            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);
            var business = new ProductBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }



        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Product>
            {
                new Product {Id =1, Name="Item1" },
                new Product {Id =2, Name="Item2" },
                new Product {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Products).Returns(mockSet.Object);
            var business = new ProductBusiness(mockContext.Object);
            var products = business.GetAll();
            int deleteId = 1; business.Delete(products[0].Id);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.Id == deleteId));
        }
        [TestCase]
        public void DeleteTestWithOutExistingId()
        {
            var data = new List<Product>()
            {
               new Product {Id =1, Name="Item1" },
                new Product {Id =2, Name="Item2" },
                new Product {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<UberContext>();
            mockContext.Setup(x => x.Products).Returns(mockSet.Object);
            var business = new ProductBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Product>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
