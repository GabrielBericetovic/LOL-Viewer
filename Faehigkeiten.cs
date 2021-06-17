using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bericetovic_Step3
{
    class Faehigkeiten
    {
        public Faehigkeiten(int f_ID, string q, string w, string e, string r)
        {
            F_ID = f_ID;
            Q = q;
            W = w;
            E = e;
            R = r;
        }

        public int F_ID { get; set; }
        public string Q { get; set; }
        public string W { get; set; }
        public string E { get; set; }
        public string R { get; set; }

        public override string ToString()
        {
            return $"{Q}  {W}  {E}  {R}";
        }

    }
}
