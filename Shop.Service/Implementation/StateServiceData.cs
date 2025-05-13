using Shop.Service.API;
using Shop.Data.API;

namespace Shop.Service.Implementation
{
    internal class StateServiceData : IStateServiceData
    {
        public StateServiceData(int stateId, int quantity, int catalogId)
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
