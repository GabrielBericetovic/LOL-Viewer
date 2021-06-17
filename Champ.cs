using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bericetovic_Step3
{
    class Champ
    {
        public Champ(int c_ID, int cR_ID, string c_Name)
        {
            C_ID = c_ID;
            CR_ID = cR_ID;
            C_Name = c_Name;
        }

        public int C_ID { get; set; }
        public int CR_ID { get; set; }
        public string C_Name { get; set; }

        public override string ToString()
        {
            return C_Name;
        }
    }
}
