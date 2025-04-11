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
        private ICatalog _catalog;
        public string StateId { get; set; }
        public string ItemId => _catalog.Id; // Getting ItemId we get id of the catalog
        public int Quantity { get; set; }

        public State(string stateId, int quantity, ICatalog catalog)
        {
            StateId = stateId;
            Quantity = quantity;
            _catalog = catalog;
        }
    }
}
