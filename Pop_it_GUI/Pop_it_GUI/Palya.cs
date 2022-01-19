using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop_it_GUI
{
    public class Palya
    {
        public int id { get; set; }
        public string palya_neve { get; set; }
        public char[,] palya { get; set; }
        public Palya(int ID, string PALYA_NEVE, char[,] PALYA)
        {
            id = ID;
            palya_neve = PALYA_NEVE;
            palya = PALYA;
        }
    }
}
