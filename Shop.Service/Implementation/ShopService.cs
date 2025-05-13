using Shop.Data.API;
using Shop.Service.API;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Shop.Service.Test")]
namespace Shop.Service.Implementation
{
    internal class ShopService : IShopService
    {
        private readonly IDataRepository _repository;

        public ShopService()
        {
            _repository = IDataRepository.CreateNewRepository();
        }

        public ShopService(IDataRepository repository)
        {
            _repository = repository;
        }

        // ---------- Catalog ----------

        private CatalogServiceData CatalogToService(ICatalog c) =>
            new CatalogServiceData(c.Id, c.Name, c.Price);

        public async override Task AddCatalog(int id, string name, double price) =>
            await Task.Run(() => _repository.AddCatalog(id, name, price));

        public async override Task RemoveCatalog(int id) =>
            await Task.Run(() => _repository.RemoveCatalog(id));

        public override List<ICatalogServiceData> GetAllCatalogs() =>
            _repository.GetAllCatalogs()
                      .Select(c => (ICatalogServiceData)CatalogToService(c))
                      .ToList();

        // ---------- User ----------

        private UserServiceData UserToService(IUser u) =>
            new UserServiceData(u.Id, u.FirstName, u.LastName, u.Address);

        public async override Task AddUser(int id, string firstName, string lastName, string address) =>
            await Task.Run(() => _repository.AddUser(id, firstName, lastName, address));

        public async override Task RemoveUser(int id) =>
            await Task.Run(() => _repository.RemoveUser(id));

        public override List<IUserServiceData> GetAllUsers() =>
            _repository.GetAllUsers()
                      .Select(u => (IUserServiceData)UserToService(u))
                      .ToList();

        // ---------- State ----------

        private StateServiceData StateToService(IState s) =>
            new StateServiceData(s.StateId, s.Quantity, s.CatalogId);

        public async override Task AddState(int id, int quantity, int catalogId) =>
            await Task.Run(() => _repository.AddState(id, quantity, catalogId));

        public async override Task RemoveState(int id) =>
            await Task.Run(() => _repository.RemoveState(id));

        public override List<IStateServiceData> GetAllStates() =>
            _repository.GetAllStates()
                      .Select(s => (IStateServiceData)StateToService(s))
                      .ToList();

        // ---------- Event ----------

        private EventServiceData EventToService(IEvent e) =>
            new EventServiceData(e.Id, e.StateId, e.UserId, e.QuantityChanged);

        public async override Task AddEvent(int id, int stateId, int userId, int quantityChanged) =>
            await Task.Run(() => _repository.AddEvent(id, stateId, userId, quantityChanged));

        public async override Task RemoveEvent(int id) =>
            await Task.Run(() => _repository.RemoveEvent(id));

        public override List<IEventServiceData> GetAllEvents() =>
            _repository.GetAllEvents()
                      .Select(e => (IEventServiceData)EventToService(e))
                      .ToList();

        // ----------------------------------------
        // ------------ Business Logic ------------

        public async override Task SellItem(int id, int stateId, int userId, int quantityChanged)
        {
            if (_repository.GetState(stateId)?.Quantity < quantityChanged)
            {
                throw new Exception("Not enough items on stock");
            }
            await AddEvent(id, stateId, userId, quantityChanged);
            _repository.ChangeQuantity(stateId, -quantityChanged);
        }

        public async override Task ReturnItem(int id, int stateId, int userId, int quantityChanged)
        {
            await AddEvent(id, stateId, userId, quantityChanged);
            _repository.ChangeQuantity(stateId, quantityChanged);
        }

        public async override Task SupplyItem(int id, int stateId, int userId, int quantityChanged)
        {
            await AddEvent(id, stateId, userId, quantityChanged);
            _repository.ChangeQuantity(stateId, quantityChanged);
        }
    }
}
