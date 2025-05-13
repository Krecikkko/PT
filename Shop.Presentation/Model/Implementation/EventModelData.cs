using Shop.Presentation.Model.API;

namespace Shop.Presentation.Model.Implementation
{
    internal class EventModelData : IEventModelData
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

        public EventModelData(int id, int stateid, int userid, int quantitychanged)
        {
            Id = id;
            StateId = stateid;
            UserId = userid;
            QuantityChanged = quantitychanged;
        }
    }
}
