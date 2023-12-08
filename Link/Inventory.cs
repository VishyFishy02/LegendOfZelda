using LegendofZelda.Interfaces;
using System.Collections.Generic;

namespace LegendofZelda
{
    public class Inventory
    {
        private Dictionary<string, int> inventory = new();
        public Inventory()
        {
            this.inventory.Add("bomb", 0);
            this.inventory.Add("key", 0);
            this.inventory.Add("orange map", 0);
            this.inventory.Add("compass", 0);
            this.inventory.Add("fairy", 0); // may remove fairies from dungeon 1
            this.inventory.Add("orange gemstone", 0);
            this.inventory.Add("triforce", 0);
            this.inventory.Add("bow", 0);
            this.inventory.Add("boomerang", 0);
            this.inventory.Add("small red heart", 0);
            this.inventory.Add("small blue heart", 0);
            this.inventory.Add("master sword", 0);
        }
        public int getItemCount(string itemStr)
        {   
            return this.inventory[itemStr];
        }
        public int getThrowableCount(Link.Throwables throwable)
        {
            int returner = 0;
            switch (throwable) {
                case Link.Throwables.Boomerang:
                    returner = inventory["boomerang"];
                    break;
                case Link.Throwables.Bomb:
                    returner = inventory["bomb"];
                    break;
                case Link.Throwables.Fire:
                    returner =  1;
                    break;
                case Link.Throwables.Arrow:
                    returner = inventory["bow"];
                    break;
            }
            return returner;
        }
        public void addItem(IItem item)
        {
            int itemCount;
            if (this.inventory.ContainsKey(item.toString()))
            {
                itemCount = this.inventory[item.toString()];
                if (item.toString() == "bomb") // bomb items give link 4 throwable bombs
                {
                    inventory[item.toString()] = itemCount + 4;
                }
                else if (item.toString() == "orange gemstone")
                {
                    inventory[item.toString()] = itemCount + 3;
                }
                else
                {
                    inventory[item.toString()] = itemCount + 1;
                }
            }
        }
        public void removeItem(string itemStr)
        {
            int itemCount;
            if (this.inventory.ContainsKey(itemStr))
            {
                itemCount = this.inventory[itemStr];
                inventory[itemStr] = itemCount - 1;
            }
        }
    }
}

