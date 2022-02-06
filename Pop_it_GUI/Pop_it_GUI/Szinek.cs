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
            szinkodok.Add('f', Color.FromArgb(255, 146, 98, 127));
            szinkodok.Add('g', Color.PaleTurquoise);
            szinkodok.Add('h', Color.HotPink);
            szinkodok.Add('i', Color.Khaki);
            szinkodok.Add('j', Color.LemonChiffon);
            szinkodok.Add('k', Color.LightSalmon);
            szinkodok.Add('l', Color.Lime);
            szinkodok.Add('m', Color.Olive);
            szinkodok.Add('n', Color.SeaGreen);
            szinkodok.Add('o', Color.SlateGray);
            szinkodok.Add('p', Color.BlueViolet);
            szinkodok.Add('q', Color.GreenYellow);
            szinkodok.Add('r', Color.Purple);
            szinkodok.Add('s', Color.DimGray);
            szinkodok.Add('t', Color.Blue);
            szinkodok.Add('u', Color.Green);
            szinkodok.Add('v', Color.Red);
            szinkodok.Add('w', Color.Orange);
            szinkodok.Add('x', Color.SkyBlue);
            szinkodok.Add('y', Color.Fuchsia);
            szinkodok.Add('z', Color.Honeydew);
            szinkodok.Add('0', Color.Pink);
            szinkodok.Add('1', Color.Brown);
            szinkodok.Add('2', Color.Azure);
            szinkodok.Add('3', Color.Indigo);
            szinkodok.Add('4', Color.Lavender);
            szinkodok.Add('5', Color.Navy);
            szinkodok.Add('6', Color.RoyalBlue);
            szinkodok.Add('7', Color.Snow);
            szinkodok.Add('8', Color.Silver);
            szinkodok.Add('9', Color.Gold);
            szinkodok.Add('@', Color.Maroon);
            szinkodok.Add('&', Color.Gainsboro);
            szinkodok.Add('$', Color.PowderBlue);
            szinkodok.Add('ß', Color.Peru);
            szinkodok.Add('#', Color.DodgerBlue);
            szinkodok.Add('<', Color.Tomato);
            szinkodok.Add('>', Color.CadetBlue);
            szinkodok.Add('Đ', Color.MintCream);
            szinkodok.Add('%', Color.MidnightBlue);
            szinkodok.Add('!', Color.Sienna);
            szinkodok.Add('~', Color.RosyBrown);
            szinkodok.Add('=', Color.SeaGreen);
            szinkodok.Add('-', Color.Firebrick);
            szinkodok.Add('ö', Color.Moccasin);
            szinkodok.Add('ü', Color.MistyRose);
            szinkodok.Add('ó', Color.Snow);
            szinkodok.Add('ő', Color.SteelBlue);
        }
    }
}
