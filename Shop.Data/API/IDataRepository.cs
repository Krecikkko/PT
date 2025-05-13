using Shop.Data.Implementation;

namespace Shop.Data.API
{
    public abstract class IDataRepository
    {
        // ----------- Catalog -----------
        public abstract void AddCatalog(int id, string name, double price);
        public abstract void RemoveCatalog(int id);
        public abstract ICatalog? GetCatalog(int id);
        public abstract IEnumerable<ICatalog> GetAllCatalogs();

        // ---------- User -----------
        public abstract void AddUser(int id, string firstName, string lastName, string address);
        public abstract void RemoveUser(int id);
        public abstract IUser? GetUser(int id);
        public abstract IEnumerable<IUser> GetAllUsers();

        // ---------- State -----------
        public abstract void AddState(int id, int quantity, int catalogId);
        public abstract void RemoveState(int id);
        public abstract IState? GetState(int id);
        public abstract IEnumerable<IState> GetAllStates();

        // ---------- Event -----------
        public abstract void AddEvent(int id, int stateId, int userId, int quantityChanged);
        public abstract void RemoveEvent(int id);
        public abstract IEnumerable<IEvent> GetAllEvents();

        //-------------------------------------
        public abstract void ChangeQuantity(int stateId, int change);
        public abstract void ClearAll();

        // Factory
        public static IDataRepository CreateNewRepository()
        {
            return new DataRepository();
        }

        public static IDataRepository CreateNewRepository(string connectionString)
        {
            return new DataRepository(connectionString);
        }
    }
}
