using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Implementation
{
    internal class Supply : ISupply
    {
        public string StateId { get; }
        public string UserId { get; }
        public int QuantityChanged { get; set; }

        public Supply(string stateId, string userId, int quantityChanged)
        {
            StateId = stateId;
            UserId = userId;
            QuantityChanged = quantityChanged;

        }
    }
}
