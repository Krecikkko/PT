using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.API
{
    public abstract class IDataRepository
    {
        public abstract void AddCatalog(ICatalog catalog);
        public abstract void RemoveCatalog(string id);
        public abstract ICatalog GetCatalog(string id);
        public abstract IEnumerable<ICatalog> GetAllCatalogs();

        //-------------------------------------
        public abstract void AddUser(IUser user);
        public abstract void RemoveUser(string id);
        public abstract IUser GetUser(string id);
        public abstract IEnumerable<IUser> GetAllUsers();

        //-------------------------------------
        public abstract void AddState(IState state);
        public abstract void RemoveState(string id);
        public abstract IState GetState(string id);
        public abstract IEnumerable<IState> GetAllStates();

        //-------------------------------------
        public abstract void AddEvent(IEvent eventItem);
        public abstract void RemoveEvent(IEvent eventItem);
        public abstract IEnumerable<IEvent> GetAllEvents();

        //-------------------------------------
        public abstract void ChangeQuantity(string stateId, int change);

        //public static IDataRepository CreateNewRepository(IDataGenerator? generator)
        //{
        //    return new DataRepository(generator);
        //}
    }
}
