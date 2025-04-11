using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Implementation
{
    internal class Catalog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Catalog(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
