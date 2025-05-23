﻿using Shop.Data.API;

namespace Shop.Service.Test
{
    internal class MockCatalog : ICatalog
    {
        public MockCatalog(int id, string name, double price)
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
