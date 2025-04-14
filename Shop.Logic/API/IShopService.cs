using Shop.Data.API;

namespace Shop.Logic.API
{
    public interface IShopService
    {
        void SellItem(string userId, string stateId, int quantity);
        void SupplyItem(string userId, string stateId, int quantity);
        void ReturnItem(string userId, string stateId, int quantity);
    }
}
