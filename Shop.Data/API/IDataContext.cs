namespace Shop.Data.API
{
    internal interface IDataContext
    {
        // ----------- Catalog -----------
        public IQueryable<ICatalog> Catalog { get; }
        Task AddCatalogAsync(ICatalog catalogEntry);
        Task RemoveCatalogAsync(int id);

        // ----------- User -----------
        public IQueryable<IUser> User { get; }
        Task AddUserAsync(IUser userEntry);
        Task RemoveUserAsync(int id);

        // ----------- Event -----------
        public IQueryable<IEvent> Event { get; }
        Task AddEventAsync(IEvent eventEntry);
        Task RemoveEventAsync(int id);

        // ----------- State -----------
        public IQueryable<IState> State { get; }
        Task AddStateAsync(IState stateEntry);
        Task RemoveStateAsync(int id);
    }
}
