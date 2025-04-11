using Shop.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Implementation
{
    internal class DataRepository : IDataRepository
    {
        private DataContext data;

        public DataRepository(IDataGenerator? generator)
        {
            data = new DataContext();
            generator?.Generate(this);
        }

        public override void AddCatalog(ICatalog catalog)
        {
            data.catalog.Add(catalog.Id, catalog);
        }

        public override void RemoveCatalog(string id)
        {
            data.catalog.Remove(id);
        }

        public override ICatalog GetCatalog(string id)
        {
            return data.catalog[id];
        }

        public override IEnumerable<ICatalog> GetAllCatalogs()
        {
            return data.catalog.Values;
        }

        //-------------------------------------

        public override void AddUser(IUser user)
        {
            data.users.Add(user);
        }

        public override void RemoveUser(string id)
        {
            for (int i = 0; i < data.users.Count; i++)
            {
                if (data.users[i].Id == id)
                {
                    data.users.RemoveAt(i);
                    break;
                }
            }
        }

        public override IUser GetUser(string id)
        {
            for (int i = 0; i < data.users.Count; i++)
            {
                if (data.users[i].Id == id)
                {
                    return data.users[i];
                }
            }
            throw new Exception("User not found");
        }

        public override IEnumerable<IUser> GetAllUsers()
        {
            return data.users;
        }

        //-------------------------------------

        public override void AddState(IState state)
        {
            data.states.Add(state);
        }

        public override void RemoveState(string id)
        {
            // data.states.Remove(id);
        }

        public override IState GetState(string id)
        {
            for (int i = 0; i < data.states.Count; i++)
            {
                if (data.states[i].StateId == id)
                {
                    return data.states[i];
                }
            }
            throw new Exception("State not found");
        }

        public override IEnumerable<IState> GetAllStates()
        {
            return data.states;
        }

        //-------------------------------------

        public override void AddEvent(IEvent eventItem) {
            data.events.Add(eventItem);
        }

        public override void RemoveEvent(IEvent eventItem)
        {
            foreach (var target in data.events)
            {
                if (eventItem.Equals(target))
                {
                    data.events.Remove(eventItem);
                    break;
                }
            }
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return data.events;
        }

        //-------------------------------------

        public override void ChangeQuantity(string stateId, int change)
        {
            GetState(stateId).Quantity += change;
        }
    }
}
