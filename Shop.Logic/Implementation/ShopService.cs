using Shop.Data.API;
using Shop.Logic.API;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Shop.Test")]
namespace Shop.Logic.Implementation
{
    internal class ShopService : IShopService
    {
        private IDataRepository _repository;

        public ShopService(IDataRepository repository)
        {
            _repository = repository;
        }

        public override void SupplyItem(string userId, string stateId, int quantity)
        {
            _repository.AddEvent(new Supply(stateId, userId, quantity));
            _repository.ChangeQuantity(stateId, quantity);
        }

        public override void SellItem(string userId, string stateId, int quantity)
        {
            if (_repository.GetState(stateId).Quantity < quantity)
            {
                throw new Exception("Not enough items on stock");
            }
            _repository.AddEvent(new Sell(stateId, userId, quantity));
            _repository.ChangeQuantity(stateId, -quantity);
        }

        public override void ReturnItem(string userId,string stateId, int quantity)
        {
            List<IEvent> events = _repository.GetAllEvents().ToList();
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].UserId == userId && events[i].StateId == stateId)
                {
                    _repository.AddEvent(new Return(stateId, userId, quantity));
                    _repository.ChangeQuantity(stateId, quantity);
                    break;
                }
                else
                {
                    throw new Exception("Transaction not found");
                }
            }
        }
    }
}
