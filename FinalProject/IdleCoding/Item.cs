using System;
using System.Collections.Generic;
using System.Text;

namespace IdleCoding
{
    class Item
    {
        public int itemID;
        public String itemName;
        public double price;
        public double earning;

        public Item(int itemID, string itemName, double price, double earning)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.price = price;
            this.earning = earning;
        }
    }
}
