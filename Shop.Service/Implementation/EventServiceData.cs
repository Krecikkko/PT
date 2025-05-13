using Shop.Service.API;

namespace Shop.Service.Implementation
{
    internal class EventServiceData : IEventServiceData
    {
        public int Id
        {
            get;
        }

        public int StateId
        {
            get;
        }

        public int UserId
        {
            get;
        }

        public int QuantityChanged
        {
            get;
            set;
        }

        public EventServiceData(int id, int stateId, int userId, int quantityChanged)
        {
            Id = id;
            StateId = stateId;
            UserId = userId;
            QuantityChanged = quantityChanged;
        }
    }
}
