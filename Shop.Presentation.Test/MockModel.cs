using Shop.Presentation.Model.API;
using Shop.Service.API;

namespace Shop.Presentation.Test
{
    public class MockModel : IModel
    {
        private IShopService service;

        internal MockModel(IShopService? _service = null)
        {
            service = _service ?? IShopService.CreateNewService();
        }
        public class CatalogMockModelData
        {
            public CatalogMockModelData(int id, string name, decimal price)
            {
                Id = id;
                Name = name;
                Price = price;
            }

            public int Id
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public decimal Price
            {
                get;
                set;
            }
        }

        internal class UserMockModelData
        {
            public int Id
            {
                get;
                set;
            }
            public string FirstName
            {
                get;
                set;
            }
            public string LastName
            {
                get;
                set;
            }
            public string Address
            {
                get;
                set;
            }
            public UserMockModelData(int id, string firstname, string lastname, string address)
            {
                Id = id;
                FirstName = firstname;
                LastName = lastname;
                Address = address;
            }
        }
        internal class StateMockModelData
        {
            public int StateId
            {
                get;
                set;
            }
            public int Quantity
            {
                get;
                set;
            }
            public int Catalog
            {
                get;
                set;
            }
            public StateMockModelData(int stateid, int quantity, int catalog)
            {
                StateId = stateid;
                Quantity = quantity;
                Catalog = catalog;
            }
        }
        internal class EventMockModelData
        {
            public int Id
            {
                get;
            }
            public int StateId
            {
                get;
            }
            public int UserId
            {
                get;
            }
            public int QuantityChanged
            {
                get;
                set;
            }
            public EventMockModelData(int id, int stateid, int userid, int quantitychanged)
            {
                Id = id;
                StateId = stateid;
                UserId = userid;
                QuantityChanged = quantitychanged;
            }
        }

        public override List<ICatalogModelData> GetAllCatalogs()
        {
            return service.GetAllCatalogs().ConvertAll(x => (ICatalogModelData)x);
        }

        public override Task RemoveCatalog(int id)
        {
            return service.RemoveCatalog(id);
        }

        public override Task AddCatalog(int id, string name, double price)
        {
            return service.AddCatalog(id, name, price);
        }

        public override List<IUserModelData> GetAllUsers()
        {
            return service.GetAllUsers().ConvertAll(x => (IUserModelData)x);
        }

        public override Task RemoveUser(int id)
        {
            return service.RemoveUser(id);
        }

        public override Task AddUser(int id, string firstname, string lastname, string address)
        {
            return service.AddUser(id, firstname, lastname, address);
        }

        public override List<IStateModelData> GetAllStates()
        {
            return service.GetAllStates().ConvertAll(x => (IStateModelData)x);
        }

        public override Task RemoveState(int id)
        {
            return service.RemoveState(id);
        }

        public override Task AddState(int id, int quantity, int catalogId)
        {
            return service.AddState(id, quantity, catalogId);
        }

        public override Task RemoveEvent(int id)
        {
            return service.RemoveEvent(id);
        }

        public override List<IEventModelData> GetAllEvents()
        {
            return service.GetAllEvents().ConvertAll(x => (IEventModelData)x);
        }

        public override Task SellItem(int id, int stateId, int userId, int QuantityChanged)
        {
            return service.SellItem(id, stateId, userId, -QuantityChanged);
        }

        public override Task ReturnItem(int id, int stateId, int userId, int QuantityChanged)
        {
            return service.ReturnItem(id, stateId, userId, QuantityChanged);
        }

        public override Task SupplyItem(int id, int stateId, int userId, int QuantityChanged)
        {
            return service.SupplyItem(id, stateId, userId, QuantityChanged);
        }
    }
}
