using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Domain
{
    public class Skateboard
    {
        public int SkateboardId { get; set; }
        public int SbUserId { get; set; }
        public Deck SbDeck { get; set; }
        public Wheels SbWheels { get; set; }
        public Truck SbTrucks { get; set; }

        public Skateboard(int id , int userId, Deck sbDeck, Wheels sbWheels, Truck sbTrucks)
        {
            SkateboardId = id;
            SbUserId = userId;
            SbDeck = sbDeck;
            SbWheels = sbWheels;
            SbTrucks = sbTrucks;
        }
    }
}
