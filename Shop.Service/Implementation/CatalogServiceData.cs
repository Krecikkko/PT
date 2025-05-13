using Shop.Service.API;

namespace Shop.Service.Implementation
{
    internal class CatalogServiceData : ICatalogServiceData
    {
        public CatalogServiceData(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }
    }
}
