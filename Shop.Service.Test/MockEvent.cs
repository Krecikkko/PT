using Shop.Data.API;

namespace Shop.Service.Test
{
    internal class MockEvent : IEvent
    {
        public int Id { get; }
        public int StateId { get; }
        public int UserId { get; }
        public int QuantityChanged { get; set; }

        public MockEvent(int id, int stateId, int userId, int quantityChanged)
        {
            Id = id;
            StateId = stateId;
            UserId = userId;
            QuantityChanged = quantityChanged;
        }
    }
}
