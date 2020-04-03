using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Attributes;

namespace Restaurant.Types
{
    public enum SideType
    {
        [MenuPrice(1.50)]
        Fries,

        [MenuPriceAttribute(0.75)]
        Salad
    }
}
