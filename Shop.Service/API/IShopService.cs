using Shop.Data.API;
using Shop.Service.Implementation;

namespace Shop.Service.API
{
    public abstract class IShopService
    {
        // ------------ Catalog ------------
        public abstract Task AddCatalog(int id, string name, double price);
        public abstract Task RemoveCatalog(int id);
        public abstract List<ICatalogServiceData> GetAllCatalogs();

        // ----------- User ------------
        public abstract Task AddUser(int id, string firstName, string lastName, string address);
        public abstract Task RemoveUser(int id);
        public abstract List<IUserServiceData> GetAllUsers();

        // ---------- State ------------
        public abstract Task AddState(int id, int quantity, int catalogId);
        public abstract Task RemoveState(int id);
        public abstract List<IStateServiceData> GetAllStates();

        // ---------- Event ------------
        public abstract Task AddEvent(int id, int stateId, int userId, int quantityChanged);
        public abstract Task RemoveEvent(int id);
        public abstract List<IEventServiceData> GetAllEvents();

        // ----------------------------------------
        // ------------ Business Logic ------------

        public abstract Task SellItem(int id, int stateId, int userId, int quantity);
        public abstract Task SupplyItem(int id, int stateId, int userId, int quantity);
        public abstract Task ReturnItem(int id, int stateId, int userId, int quantity);

        public static IShopService CreateNewService(IDataRepository data)
        {
            return new ShopService(data);
        }
        public static IShopService CreateNewService()
        {
            return new ShopService();
        }
    }
}
