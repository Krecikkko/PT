﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Model.API
{
    public interface IStateModelData
    {
        int StateId
        {
            get;
            set;
        }

        int Quantity
        {
            get;
            set;
        }

        int CatalogId
        {
            get;
            set;
        }
    }
}
