using Shop.Data.API;

namespace Shop.Service.Test
{
    internal class MockState : IState
    {
        public MockState(int stateId, int quantity, int catalogId)
        {
            StateId = stateId;
            Quantity = quantity;
            CatalogId = catalogId;
        }

        public int StateId
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public int CatalogId
        {
            get;
            set;
        }
    }
}
