using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Domain
{
    public class Deck
    {
        public int DeckId { get; set; }
        public string DeckBrand { get; set; }
        public float DeckWidth { get; set; }
        public float DeckLength { get; set; }

        public Deck(int id, string brand, float width, float length)
        {
            DeckId = id;
            DeckBrand = brand;
            DeckWidth = width;
            DeckLength = length;
        }
        public override string ToString()
        {
            if (DeckId == 0)
            {
                return "You haven't set a deck\nfor this board yet!";
            }
            else
            {
                return "Brand: " + DeckBrand + "\nWidth: " + DeckWidth + "\nLength: " + DeckLength;
            }
        }
    }
}
