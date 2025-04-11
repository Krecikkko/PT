using Shop.Data.API;

namespace Shop.Logic.Implementation
{
    internal class Return : IReturn
    {
        public string StateId { get; }
        public string UserId { get; }
        public int QuantityChanged { get; set; }

        public Return(string stateId, string userId, int quantityChanged)
        {
            StateId = stateId;
            UserId = userId;
            QuantityChanged = quantityChanged;

        }
    }
}
