using Shop.Presentation.Model.API;

namespace Shop.Presentation.Model.Implementation
{
    internal class CatalogModelData : ICatalogModelData
    {
        public CatalogModelData(int id, string name, double price)
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
