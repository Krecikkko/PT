using Shop.Data.API;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Shop.Test")]
namespace Shop.Data.Implementation
{
    internal class DataRepository : IDataRepository
    {
        private DataContext _data;

        public DataRepository(IDataGenerator? generator)
        {
            _data = new DataContext();
            generator?.Generate(this);
        }

        public void AddCatalog(ICatalog catalog)
        {
            _data.catalog.Add(catalog.Id, catalog);
        }

        public void RemoveCatalog(string id)
        {
            _data.catalog.Remove(id);
        }

        public ICatalog GetCatalog(string id)
        {
            return _data.catalog[id];
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            return _data.catalog.Values;
        }

        //-------------------------------------

        public void AddUser(IUser user)
        {
            _data.users.Add(user);
        }

        public void RemoveUser(string id)
        {
            for (int i = 0; i < _data.users.Count; i++)
            {
                if (_data.users[i].Id == id)
                {
                    _data.users.RemoveAt(i);
                    break;
                }
            }
        }

        public IUser GetUser(string id)
        {
            for (int i = 0; i < _data.users.Count; i++)
            {
                if (_data.users[i].Id == id)
                {
                    return _data.users[i];
                }
            }
            throw new Exception("User not found");
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _data.users;
        }

        //-------------------------------------

        public void AddState(IState state)
        {
            _data.states.Add(state);
        }

        public void RemoveState(string id)
        {
            for (int i = 0; i < _data.states.Count; i++)
            {
                if (_data.states[i].StateId == id)
                {
                    _data.states.RemoveAt(i);
                    break;
                }
            }
        }

        public IState GetState(string id)
        {
            for (int i = 0; i < _data.states.Count; i++)
            {
                if (_data.states[i].StateId == id)
                {
                    return _data.states[i];
                }
            }
            throw new Exception("State not found");
        }

        public IEnumerable<IState> GetAllStates()
        {
            return _data.states;
        }

        //-------------------------------------

        public void AddEvent(IEvent eventItem) {
            _data.events.Add(eventItem);
        }

        public void RemoveEvent(IEvent eventItem)
        {
            foreach (var target in _data.events)
            {
                if (eventItem.Equals(target))
                {
                    _data.events.Remove(eventItem);
                    break;
                }
            }
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return _data.events;
        }

        //-------------------------------------

        public void ChangeQuantity(string stateId, int change)
        {
            GetState(stateId).Quantity += change;
        }
    }
}
