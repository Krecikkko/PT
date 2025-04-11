using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.API
{
    public interface IState
    {
        string ItemId { get; set; }
        string StateId { get; set; }
        int Quantity { get; set; }
    }
}
