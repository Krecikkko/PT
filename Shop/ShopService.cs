using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic
{
    class ShopService
    {
        private readonly IProductRepository _repository;

        public ShopService(IProductRepository repository)
        {
            _repository = repository;
        }

        public decimal getPriceWithTax(int productId)
        {
            var product = _repository.getById(productId);
            if (product == null) throw new ArgumentException("Product not found");
            return product.price * 1.23m; // 23% tax
        }
    }
}
