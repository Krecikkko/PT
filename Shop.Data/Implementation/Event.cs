using Shop.Data.API;

namespace Shop.Data.Implementation
{
    internal class Event : IEvent
    {
        public int Id { get; private set; }
        public int StateId { get; private set; }
        public int UserId { get; private set; }
        public int QuantityChanged { get; set; }
        
        public Event(int id, int stateId, int userId, int quantityChanged)
        {
            Id = id;
            StateId = stateId;
            UserId = userId;
            QuantityChanged = quantityChanged;
        }
    }
}
