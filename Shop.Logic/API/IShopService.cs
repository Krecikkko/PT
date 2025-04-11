using Shop.Data.API;

namespace Shop.Logic.API
{
    public abstract class IShopService
    {
        public abstract void SellItem(string userId, string stateId, int quantity);
        public abstract void SupplyItem(string userId, string stateId, int quantity);
        public abstract void ReturnItem(string userId, string stateId, int quantity);

        public static IShopService CreateNewLogic(IDataRepository? repository)
        {
            return new ShopService(repository);
        }
    }
}
