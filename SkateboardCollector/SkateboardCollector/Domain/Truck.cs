using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Domain
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string TruckBrand { get; set; }

        public float TruckSize { get; set; }

        public Truck(int id, string brand, float size)
        {
            TruckId = id;
            TruckBrand = brand;
            TruckSize = size;
        }
        public override string ToString()
        {
            if (TruckId == 0)
            {
                return "You haven't set a truck\nfor this board yet!";
            }
            else
            {
                return "Brand: " + TruckBrand + "\nSize: " + TruckSize;
            }
        }
    }
}
