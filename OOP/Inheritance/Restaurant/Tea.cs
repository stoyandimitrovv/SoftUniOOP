using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Tea : HotBeverage
    {
        public Tea(string name, double price, double milliliters) : base(name, price, milliliters)
        {
        }
    }
}
