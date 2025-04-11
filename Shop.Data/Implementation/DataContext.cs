using Shop.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Implementation
{
    internal class DataContext : IDataContext
    {
        internal List<IUser> users = new();
        internal List<IState> states = new();
        internal List<IEvent> events = new();
        internal Dictionary<string, ICatalog> catalog = new();
    }
}
