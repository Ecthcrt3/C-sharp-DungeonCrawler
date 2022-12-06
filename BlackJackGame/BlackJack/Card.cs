using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public string Name { get; set; }
        public int FaceValue { get; set; }
        public string Suit { get; set; }

        public Card(string name, int faceValue, string suit)
        {
            Name = name;
            FaceValue = faceValue;
            Suit = suit;
        }
    }
}
