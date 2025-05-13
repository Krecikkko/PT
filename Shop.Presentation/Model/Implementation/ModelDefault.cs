using Shop.Presentation.Model.API;
using Shop.Service.API;

namespace Shop.Presentation.Model.Implementation
{
    internal class ModelDefault : IModel
    {
        private IShopService _service;

        internal ModelDefault(IShopService? service = null)
        {
            _service = service ?? IShopService.CreateNewService();
        }

        // ----------------- Catalog -----------------

        private CatalogModelData? CatalogToModel(ICatalogServiceData c)
        {
            return c == null ? null : new CatalogModelData(c.Id, c.Name, c.Price);
        }

        public override List<ICatalogModelData> GetAllCatalogs()
        {
            var listData = _service.GetAllCatalogs();
            List<ICatalogModelData> result = new List<ICatalogModelData>();

            foreach (var entry in listData)
            {
                result.Add(CatalogToModel(entry));
            }
            return result;
        }

        public async override Task RemoveCatalog(int id)
        {
            await Task.Run(() => { _service.RemoveCatalog(id); });
        }

        public async override Task AddCatalog(int id, string name, double price)
        {
            await Task.Run(() => { _service.AddCatalog(id, name, price); });
        }

        // ----------------- User -----------------

        private UserModelData? UserToModel(IUserServiceData e)
        {
            return e == null ? null : new UserModelData(e.Id, e.FirstName, e.LastName, e.Address);
        }

        public override List<IUserModelData> GetAllUsers()
        {
            var listData = _service.GetAllUsers();
            List<IUserModelData> result = new List<IUserModelData>();

            foreach (var entry in listData)
            {
                result.Add(UserToModel(entry));
            }
            return result;
        }

        public async override Task RemoveUser(int id)
        {
            await Task.Run(() => { _service.RemoveUser(id); });
        }

        public async override Task AddUser(int id, string firstname, string lastname, string address)
        {
            await Task.Run(() => { _service.AddUser(id, firstname, lastname, address); });
        }

        // ----------------- State -----------------

        private StateModelData? StateToModel(IStateServiceData s)
        {
            return s == null ? null : new StateModelData(s.StateId, s.CatalogId, s.Quantity);
        }

        public override List<IStateModelData> GetAllStates()
        {
            var listData = _service.GetAllStates();
            List<IStateModelData> result = new List<IStateModelData>();

            foreach (var entry in listData)
            {
                result.Add(StateToModel(entry));
            }
            return result;
        }

        public async override Task RemoveState(int id)
        {
            await Task.Run(() => { _service.RemoveState(id); });
        }

        public async override Task AddState(int id, int quantity, int catalogId)
        {
            await Task.Run(() => { _service.AddState(id, quantity, catalogId); });
        }

        // ----------------- Event -----------------

        private EventModelData? EventToModel(IEventServiceData e)
        {
            return e == null ? null : new EventModelData(e.Id, e.StateId, e.UserId, e.QuantityChanged);
        }

        public async override Task RemoveEvent(int id)
        {
            await Task.Run(() => { _service.RemoveEvent(id); });
        }

        public override List<IEventModelData> GetAllEvents()
        {
            var listData = _service.GetAllEvents();
            List<IEventModelData> result = new List<IEventModelData>();

            foreach (var entry in listData)
            {
                result.Add(EventToModel(entry));
            }
            return result;
        }

        // ----------------- Actions -----------------

        public async override Task SellItem(int id, int stateId, int userId, int QuantityChanged)
        {
            await Task.Run(() => { _service.SellItem(id, stateId, userId, QuantityChanged); });
        }

        public async override Task ReturnItem(int id, int stateId, int userId, int QuantityChanged)
        {
            await Task.Run(() => { _service.ReturnItem(id, stateId, userId, QuantityChanged); });
        }

        public async override Task SupplyItem(int id, int stateId, int userId, int QuantityChanged)
        {
            await Task.Run(() => { _service.SupplyItem(id, stateId, userId, QuantityChanged); });
        }
    }
}
