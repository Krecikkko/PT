using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTest
{
    [TestClass]
    public sealed class ProductRepositoryTest
    {
        [TestMethod]
        public void add_Then_getById_ReturnsSameProduct()
        {
            var repo = new InMemoryProductRepository();
            var product = new Product { id = 1, name = "Apple", price = 2.5m };

            repo.add(product);
            var result = repo.getById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(product.id, result.id);
            Assert.AreEqual(product.name, result.name);
            Assert.AreEqual(product.price, result.price);
        }

        [TestMethod]
        public void getById_ReturnsNull_IfProductNotAdded()
        {
            var repo = new InMemoryProductRepository();

            var result = repo.getById(999);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void add_OverridesExistingProductWithSameId()
        {
            var repo = new InMemoryProductRepository();
            var original = new Product { id = 1, name = "Milk", price = 3m };
            var updated = new Product { id = 1, name = "Milk (updated)", price = 3.5m };

            repo.add(original);
            repo.add(updated);
            var result = repo.getById(1);

            Assert.AreEqual("Milk (updated)", result.name);
            Assert.AreEqual(3.5m, result.price);
        }
    }
}
