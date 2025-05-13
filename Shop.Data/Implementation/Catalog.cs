using Shop.Data.API;

namespace Shop.Data.Implementation
{
    internal class Catalog : ICatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Catalog(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
