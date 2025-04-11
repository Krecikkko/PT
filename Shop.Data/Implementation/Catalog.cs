using Shop.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Implementation
{
    internal class Catalog : ICatalog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Catalog(string id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
