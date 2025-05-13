using Shop.Data.API;

namespace Shop.Service.API
{
    public interface IStateServiceData
    {
        int StateId
        {
            get;
            set;
        }

        int Quantity
        {
            get;
            set;
        }

        int CatalogId
        {
            get;
            set;
        }
    }
}
