using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pop_it_GUI
{
    internal class Szinek
    {
        public Dictionary<char, Color> szinkodok = new Dictionary<char, Color>();
        public Szinek()
        {
            szinkodok.Add('a', Color.AliceBlue);
            szinkodok.Add('b', Color.Aqua);
            szinkodok.Add('c', Color.Beige);
            szinkodok.Add('d', Color.Chartreuse);
            szinkodok.Add('e', Color.CornflowerBlue);
            szinkodok.Add('f', Color.FloralWhite);
            szinkodok.Add('g', Color.PaleTurquoise);
            szinkodok.Add('h', Color.HotPink);
            szinkodok.Add('i', Color.Khaki);
            szinkodok.Add('j', Color.LemonChiffon);
            szinkodok.Add('k', Color.LightSalmon);
            szinkodok.Add('l', Color.Lime);
            szinkodok.Add('m', Color.Olive);
            szinkodok.Add('n', Color.SeaGreen);
            szinkodok.Add('o', Color.SlateGray);
            szinkodok.Add('p', Color.Tan);
        }
    }
}
