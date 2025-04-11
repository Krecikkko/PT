using Shop.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Implementation
{
    internal class State : IState
    {
        private ICatalog Catalog;
        public string StateId { get; set; }
        public string ItemId => Catalog.Id;
        public int Quantity { get; set; }

        public State(string stateId, int quantity, ICatalog catalog)
        {
            StateId = stateId;
            Quantity = quantity;
            Catalog = catalog;
        }

       
    }
}
