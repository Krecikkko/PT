using Shop.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public override void AddCatalog(ICatalog catalog)
        {
            _data.catalog.Add(catalog.Id, catalog);
        }

        public override void RemoveCatalog(string id)
        {
            _data.catalog.Remove(id);
        }

        public override ICatalog GetCatalog(string id)
        {
            return _data.catalog[id];
        }

        public override IEnumerable<ICatalog> GetAllCatalogs()
        {
            return _data.catalog.Values;
        }

        //-------------------------------------

        public override void AddUser(IUser user)
        {
            _data.users.Add(user);
        }

        public override void RemoveUser(string id)
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

        public override IUser GetUser(string id)
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

        public override IEnumerable<IUser> GetAllUsers()
        {
            return _data.users;
        }

        //-------------------------------------

        public override void AddState(IState state)
        {
            _data.states.Add(state);
        }

        public override void RemoveState(string id)
        {
            // data.states.Remove(id);
        }

        public override IState GetState(string id)
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

        public override IEnumerable<IState> GetAllStates()
        {
            return _data.states;
        }

        //-------------------------------------

        public override void AddEvent(IEvent eventItem) {
            _data.events.Add(eventItem);
        }

        public override void RemoveEvent(IEvent eventItem)
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

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return _data.events;
        }

        //-------------------------------------

        public override void ChangeQuantity(string stateId, int change)
        {
            GetState(stateId).Quantity += change;
        }
    }
}
