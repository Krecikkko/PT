using Shop.Presentation.Model.Implementation;

namespace Shop.Presentation.Model.API
{
    public abstract class IModel
    {
        public abstract List<ICatalogModelData> GetAllCatalogs();
        public abstract Task RemoveCatalog(int id);
        public abstract Task AddCatalog(int id, string name, double price);

        public abstract List<IUserModelData> GetAllUsers();
        public abstract Task RemoveUser(int id);
        public abstract Task AddUser(int id, string firstname, string lastname, string address);

        public abstract List<IStateModelData> GetAllStates();
        public abstract Task RemoveState(int id);
        public abstract Task AddState(int id, int quantity, int catalogId);

        public abstract Task RemoveEvent(int id);
        public abstract List<IEventModelData> GetAllEvents();

        public abstract Task SellItem(int id, int stateId, int userId, int QuantityChanged);
        public abstract Task ReturnItem(int id, int stateId, int userId, int QuantityChanged);
        public abstract Task SupplyItem(int id, int stateId, int userId, int QuantityChanged);

        public static IModel CreateNewModel()
        {
            return new ModelDefault();
        }
    }
}
