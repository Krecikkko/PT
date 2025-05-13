using Shop.Data.API;
using System.Data.Linq;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Shop.Test")]
namespace Shop.Data.Implementation
{
    internal class DataRepository : IDataRepository
    {
        private GroceryShopDataContext _context;

        public DataRepository(string? customConnectionString = null)
        {
            if (customConnectionString != null)
            {
                _context = new GroceryShopDataContext(customConnectionString);
            }
            else
            {
                _context = new GroceryShopDataContext();
            }
        }

        // ------------------ Catalog ------------------

        private ICatalog? EntryToObj(catalog catalog)
        {
            if (catalog != null)
            {
                return new Catalog(catalog.id, catalog.name, catalog.price);
            }
            return null;
        }

        public override void AddCatalog(int id, string name, double price)
        {
            catalog c = new catalog
            {
                id = id,
                name = name,
                price = price
            };
            _context.catalog.InsertOnSubmit(c);
            _context.SubmitChanges();
        }

        public override void RemoveCatalog(int id)
        {
            catalog cat = _context.catalog.Single(catalog => catalog.id == id);
            _context.catalog.DeleteOnSubmit(cat);
            _context.SubmitChanges();
        }

        public override ICatalog? GetCatalog(int id)
        {
            catalog c = new catalog();
            var cat = (from catalog
                       in _context.catalog
                       where catalog.id == id
                       select catalog).FirstOrDefault();
            if (cat == null)
            {
                return null;
            }
            else
            {
                c.id = cat.id;
                c.price = cat.price;
                c.name = cat.name;
                return EntryToObj(c);
            }
        }

        public override IEnumerable<ICatalog> GetAllCatalogs()
        {
            var cat = (from catalog
                       in _context.catalog
                        select EntryToObj(catalog)
                       );
            return cat;
        }

        // ------------------ User ------------------

        private IUser? EntryToObj(user user)
        {
            if (user != null)
            {
                return new User(user.id, user.firstName, user.lastName, user.address);
            }
            return null;
        }

        public override void AddUser(int id, string firstName, string lastName, string address)
        {
            user u = new user
            {
                id = id,
                firstName = firstName,
                lastName = lastName,
                address = address,
            };
            _context.user.InsertOnSubmit(u);
            _context.SubmitChanges();
        }

        public override void RemoveUser(int id)
        {
            user usr = _context.user.Single(user => user.id == id);
            _context.user.DeleteOnSubmit(usr);
            _context.SubmitChanges();
        }

        public override IUser? GetUser(int id)
        {
            var usr = (from user
                       in _context.user
                       where user.id == id
                       select user).FirstOrDefault();
            if (usr == null)
            {
                return null;
            }
            else
            {
                return EntryToObj(usr);
            }
        }

        public override IEnumerable<IUser> GetAllUsers()
        {
            var usr = (from user
                       in _context.user
                       select EntryToObj(user)
                       );
            return usr;
        }

        // ------------------ State ------------------

        private IState? EntryToObj(state state)
        {
            if (state != null)
            {
                return new State(state.id, state.quantity, state.catalogId);
            }
            return null;
        }

        public override void AddState(int id, int quantity, int catalogId)
        {
            state stt = new state
            {
                id = id,
                quantity = quantity,
                catalogId = catalogId,
            };
            _context.state.InsertOnSubmit(stt);
            _context.SubmitChanges();
        }

        public override void RemoveState(int id)
        {
            state stt = _context.state.Single(state => state.id == id);
            _context.state.DeleteOnSubmit(stt);
            _context.SubmitChanges();
        }

        public override IState? GetState(int id)
        {
            state stt = _context.state.SingleOrDefault(state => state.id == id);
            if (stt == null)
            {
                return null;
            }
            else
            {
                return EntryToObj(stt);
            }
        }

        public override IEnumerable<IState> GetAllStates()
        {
            var stt = from state
                        in _context.state
                      select EntryToObj(state);
            return stt;
        }

        // ------------------ Event ------------------

        private IEvent? EntryToObj(@event @event)
        {
            if (@event != null)
            {
                return new Event(@event.id, @event.stateId, @event.userId, @event.quantityChanged);
            }
            return null;
        }

        public override void AddEvent(int id, int stateId, int userId, int QuantityChanged)
        {
            @event evt = new @event
            {
                id = id,
                stateId = stateId,
                userId = userId,
                quantityChanged = QuantityChanged
            };
            ChangeQuantity(stateId, QuantityChanged);
            _context.@event.InsertOnSubmit(evt);
            _context.SubmitChanges();
        }

        public override void RemoveEvent(int id)
        {
            @event evt = _context.@event.SingleOrDefault(@event => @event.id == id);
            _context.@event.DeleteOnSubmit(evt);
            _context.SubmitChanges();
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            var ev = from @event
                         in _context.@event
                         select EntryToObj(@event);
            return ev;
        }

        //----------------------------------------------

        public override void ChangeQuantity(int stateId, int change)
        {
            state stt = _context.state.Single(state => state.id == stateId);
            stt.quantity += change;
            _context.SubmitChanges();
        }

        public override void ClearAll()
        {
            _context.ExecuteCommand("DELETE FROM events");
            _context.ExecuteCommand("DELETE FROM states");
            _context.ExecuteCommand("DELETE FROM users");
            _context.ExecuteCommand("DELETE FROM catalogs");
        }
    }
}
