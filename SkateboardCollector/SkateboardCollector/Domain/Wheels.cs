using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Domain
{
    public class Wheels
    {
        public int WheelsId { get; set; }
        public string WheelsBrand { get; set; }
        public int WheelsSize { get; set; }
        public string WheelsHardness { get; set; }

        public Wheels(int id , string brand, int size,string hardness)
        {
            WheelsId = id;
            WheelsBrand = brand;
            WheelsSize = size;
            WheelsHardness = hardness;
        }
        public override string ToString()
        {
            if (WheelsId == 0)
            {
                return "You haven't set wheels\nfor this board yet!";
            }
            else
            {
                return "Brand: " + WheelsBrand + "\nSize: " + WheelsSize + "\nHardness: " + WheelsHardness;
            }
        }
    }
}
