using Shop.Logic;
using Shop.Data;

namespace ShopTest
{
    [TestClass]
    public sealed class ShopServiceTest
    {
        [TestMethod]
        public void getPriceWithTax_ReturnsCorrectValue_WhenProductExists()
        {
            // Arrange
            var repo = new InMemoryProductRepository();
            var product = new Product { id = 1, name = "Bread", price = 10m };
            repo.add(product);
            var service = new ShopService(repo);

            // Act
            var result = service.getPriceWithTax(1);

            // Assert
            Assert.AreEqual(12.3m, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void getPriceWithTax_ThrowsException_WhenProductNotFound()
        {
            // Arrange
            var repo = new InMemoryProductRepository(); // Empty repo
            var service = new ShopService(repo);

            // Act
            service.getPriceWithTax(999); // This should throw
        }
    }
}
