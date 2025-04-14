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

        public void SupplyItem(string userId, string stateId, int quantity)
        {
            IState state = _repository.GetState(stateId);
            IUser user = _repository.GetUser(userId);
            _repository.AddEvent(new Supply(state, user, quantity));
            _repository.ChangeQuantity(stateId, quantity);
        }

        public void SellItem(string userId, string stateId, int quantity)
        {
            if (_repository.GetState(stateId).Quantity < quantity)
            {
                throw new Exception("Not enough items on stock");
            }
            IState state = _repository.GetState(stateId);
            IUser user = _repository.GetUser(userId);
            _repository.AddEvent(new Sell(state, user, quantity));
            _repository.ChangeQuantity(stateId, -quantity);
        }

        public void ReturnItem(string userId,string stateId, int quantity)
        {
            List<IEvent> events = _repository.GetAllEvents().ToList();
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].UserId == userId && events[i].StateId == stateId)
                {
                    IState state = _repository.GetState(stateId);
                    IUser user = _repository.GetUser(userId);
                    _repository.AddEvent(new Return(state, user, quantity));
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
