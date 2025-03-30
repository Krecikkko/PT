namespace Shop.Data
{
    public interface IProductRepository
    {
        Product getById(int id);
        void add(Product product);
    }

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly Dictionary<int, Product> _products = new();

        public Product getById(int id) => _products.TryGetValue(id, out var product) ? product : null;

        public void add(Product product) => _products[product.id] = product;
    }
}
