using Shop.Presentation.Model.API;

namespace Shop.Presentation.Model.Implementation
{
    internal class StateModelData : IStateModelData
    {
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

        public StateModelData(int stateId, int quantity, int catalogId)
        {
            StateId = stateId;
            Quantity = quantity;
            CatalogId = catalogId;
        }
    }
}
