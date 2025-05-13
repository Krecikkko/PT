using Shop.Data.API;

namespace Shop.Data.Implementation
{
    internal class State : IState
    {
        public int StateId { get; set; }
        public int CatalogId { get; set; }
        public int Quantity { get; set; }

        public State(int stateId, int quantity, int catalogId)
        {
            StateId = stateId;
            Quantity = quantity;
            CatalogId = catalogId;
        }
    }
}
