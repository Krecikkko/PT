using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.API
{
    public interface IEvent
    {
        string StateId { get; set; }
        string UserId { get; set; }
        int QuantityChanged { get; set; }
    }
}
