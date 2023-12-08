using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonReferences
{
    public class Common
    {
        private static Common instance = new();

        public readonly int rushRoomsIndex = 19;
        public readonly int numOfRushRooms = 5;
        public readonly int caveRoomsIndex = 17;
        public readonly int heightOfInventory = 150;

        public static Common Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
