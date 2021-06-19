using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bericetovic_Step3
{
    class Deck
    {
        public Deck(int iD, string bild, decimal price, string marke, decimal groesse)
        {
            ID = iD;
            Bild = bild;
            Price = price;
            Marke = marke;
            Groesse = groesse;
        }

        public int ID { get; set; }

        public decimal Price { get; set; }
        public string Marke { get; set; }
        public decimal Groesse { get; set; }
        public string Bild { get; set; }

        public override string ToString()
        {
            return Marke;
        }
    }
}
