using Shop.Data.API;

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
