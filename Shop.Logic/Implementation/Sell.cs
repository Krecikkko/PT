using Shop.Data.API;

namespace Shop.Logic.Implementation
{
    internal class Sell : ISell
    {
        public string StateId { get; }
        public string UserId { get; }
        public int QuantityChanged { get; set; }

        public Sell(string stateId, string userId, int quantityChanged)
        {
            StateId = stateId;
            UserId = userId;
            QuantityChanged = quantityChanged;
        }
    }
}
