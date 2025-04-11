using Shop.Data.API;
using Shop.Logic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Implementation
{
    internal class ShopService : IShopService
    {
        private IDataRepository _repository;

        public ShopService(IDataRepository repository)
        {
            _repository = repository;
        }

        public override void SellItem(string userId, string stateId, int quantity)
        {
            if (_repository.GetState(stateId).Quantity < quantity)
            {
                throw new Exception("Not enough items on stock");
            }
            _repository.AddEvent(new Sell(userId, stateId, quantity));
        }
    }
}
