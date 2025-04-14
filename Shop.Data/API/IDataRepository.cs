namespace Shop.Data.API
{
    public interface IDataRepository
    {
        void AddCatalog(ICatalog catalog);
        void RemoveCatalog(string id);
        ICatalog GetCatalog(string id);
        IEnumerable<ICatalog> GetAllCatalogs();

        //-------------------------------------
        void AddUser(IUser user);
        void RemoveUser(string id);
        IUser GetUser(string id);
        IEnumerable<IUser> GetAllUsers();

        //-------------------------------------
        void AddState(IState state);
        void RemoveState(string id);
        IState GetState(string id);
        IEnumerable<IState> GetAllStates();

        //-------------------------------------
        void AddEvent(IEvent eventItem);
        void RemoveEvent(IEvent eventItem);
        IEnumerable<IEvent> GetAllEvents();

        //-------------------------------------
        void ChangeQuantity(string stateId, int change);
    }
}
