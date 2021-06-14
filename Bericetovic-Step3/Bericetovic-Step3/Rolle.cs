using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bericetovic_Step3
{
    class Rolle
    {
        public Rolle(int r_ID, string r_Name, string lane)
        {
            R_ID = r_ID;
            R_Name = r_Name;
            Lane = lane;
        }

        public int R_ID { get; set; }
        public string R_Name { get; set; }
        public string Lane { get; set; }
    }
}
