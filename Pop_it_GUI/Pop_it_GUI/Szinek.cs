﻿using System;
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
            szinkodok.Add('b', Color.FromArgb(255, 180, 211, 178));
            szinkodok.Add('c', Color.Beige);
            szinkodok.Add('d', Color.FromArgb(255, 248, 234, 252));
            szinkodok.Add('e', Color.FromArgb(255, 170, 148, 153));
            szinkodok.Add('f', Color.FromArgb(255, 184, 159, 163));
            szinkodok.Add('g', Color.PaleTurquoise);
            szinkodok.Add('h', Color.FromArgb(255, 255, 255, 149));
            szinkodok.Add('i', Color.Khaki);
            szinkodok.Add('j', Color.LemonChiffon);
            szinkodok.Add('k', Color.LightSalmon);
            szinkodok.Add('l', Color.FromArgb(255, 201, 239, 230));
            szinkodok.Add('m', Color.Olive);
            szinkodok.Add('n', Color.FromArgb(255, 234, 238, 224));
            szinkodok.Add('o', Color.SlateGray);
            szinkodok.Add('p', Color.FromArgb(255, 236, 238, 164));
            szinkodok.Add('q', Color.FromArgb(255, 222, 200, 189));
            szinkodok.Add('r', Color.FromArgb(255, 233, 189, 190));
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
            szinkodok.Add('=', Color.SeaGreen);
            szinkodok.Add('-', Color.Firebrick);
            szinkodok.Add('ö', Color.Moccasin);
            szinkodok.Add('ü', Color.MistyRose);
            szinkodok.Add('ó', Color.Snow);
            szinkodok.Add('ő', Color.SteelBlue);
            szinkodok.Add('A', Color.White);
            szinkodok.Add('B', Color.FromArgb(255, 171, 222, 234));
            szinkodok.Add('C', Color.FromArgb(255, 255, 202, 175));
            szinkodok.Add('D', Color.FromArgb(255, 202, 200, 244));
            szinkodok.Add('E', Color.FromArgb(255, 191, 213, 232));
            szinkodok.Add('F', Color.FromArgb(255, 181, 227, 216));
            szinkodok.Add('G', Color.FromArgb(255, 246, 236, 245));
            szinkodok.Add('H', Color.FromArgb(255, 253, 222, 238));
            szinkodok.Add('I', Color.FromArgb(255, 240, 232, 205));
            szinkodok.Add('J', Color.FromArgb(255, 255, 255, 176));
            szinkodok.Add('K', Color.FromArgb(255, 253, 202, 162));
            szinkodok.Add('L', Color.FromArgb(255, 253, 202, 162));
            szinkodok.Add('M', Color.FromArgb(255, 219, 213, 185));
            szinkodok.Add('N', Color.FromArgb(255, 224, 243, 176));
            szinkodok.Add('O', Color.FromArgb(255, 221, 212, 232));
            szinkodok.Add('P', Color.FromArgb(255, 254, 236, 200));
            szinkodok.Add('Q', Color.FromArgb(255, 240, 182, 213));
            szinkodok.Add('R', Color.FromArgb(255, 251, 170, 153));
            szinkodok.Add('S', Color.FromArgb(255, 236, 189, 144));
            szinkodok.Add('T', Color.FromArgb(255, 174, 218, 207));
            szinkodok.Add('U', Color.FromArgb(255, 217, 175, 202));
            szinkodok.Add('V', Color.FromArgb(255, 230, 230, 250));
            szinkodok.Add('W', Color.FromArgb(255, 225, 215, 232));
            szinkodok.Add('X', Color.FromArgb(255, 208, 234, 231));
            szinkodok.Add('Y', Color.FromArgb(255, 209, 240, 226));
            szinkodok.Add('Z', Color.FromArgb(255, 255, 234, 216));
            szinkodok.Add('[', Color.FromArgb(255, 207, 220, 138));
            szinkodok.Add('\\', Color.FromArgb(255, 248, 228, 183));
            szinkodok.Add(']', Color.FromArgb(255, 180, 201, 201));
            szinkodok.Add('^', Color.FromArgb(255, 216, 236, 143));
            szinkodok.Add('_', Color.FromArgb(255, 245, 242, 208));
            szinkodok.Add((char)96, Color.FromArgb(255, 224, 236, 248));
            szinkodok.Add('{', Color.FromArgb(255, 255, 253, 229));
            szinkodok.Add('|', Color.FromArgb(255, 211, 212, 213));
            szinkodok.Add('}', Color.FromArgb(255, 176, 194, 74));
            szinkodok.Add('~', Color.FromArgb(255, 206, 118, 102));
            szinkodok.Add((char) 127, Color.FromArgb(255, 255, 222, 164));
            szinkodok.Add((char)128, Color.FromArgb(255, 246, 239, 212));
            szinkodok.Add((char)129, Color.FromArgb(255, 219, 133, 136));
            szinkodok.Add((char)130, Color.FromArgb(255, 150, 255, 60));
            szinkodok.Add((char)131, Color.FromArgb(255, 244, 238, 250));
            szinkodok.Add((char)132, Color.FromArgb(255, 157, 150, 147));
            szinkodok.Add((char)133, Color.FromArgb(255, 252, 169, 133));
            szinkodok.Add((char)134, Color.FromArgb(255, 180, 211, 178));
            szinkodok.Add((char)135, Color.FromArgb(255, 255, 255, 170));
            szinkodok.Add((char)136, Color.FromArgb(255, 164, 167, 128));
            szinkodok.Add((char)137, Color.FromArgb(255, 249, 140, 182));
            szinkodok.Add((char)138, Color.FromArgb(255, 193, 179, 215));
            szinkodok.Add((char)139, Color.FromArgb(255, 156, 156, 156));
            szinkodok.Add((char)140, Color.FromArgb(255, 204, 217, 247));
            szinkodok.Add((char)141, Color.FromArgb(255, 148, 223, 184));
            szinkodok.Add((char)142, Color.FromArgb(255, 108, 138, 130));
            szinkodok.Add((char)143, Color.FromArgb(255, 72, 181, 163));
            szinkodok.Add('?', Color.FromArgb(255, 72, 181, 100));
        }
    }
}
