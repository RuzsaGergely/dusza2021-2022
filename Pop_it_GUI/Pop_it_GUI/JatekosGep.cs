using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pop_it_GUI
{
    static class JatekosGep
    {
        static private char[,] map { get; set; }

        static public void makeMove(DataGridView map)
        {
            //lehetséges karakterek kigyűjtése
            var chars = new Dictionary<char, int>();
            for (int i = 0; i < map.Rows.Count; i++)
            {
                for (int j = 0; j < map.Columns.Count; j++)
                {
                    if (!(map[i,j].Style.BackColor == Color.Gray))
                    {
                        if (!chars.ContainsKey(map[i, j].Value.ToString()[0]))
                        {
                            chars.Add(map[i, j].Value.ToString()[0], 1);
                        }
                        else
                        {
                            chars[map[i, j].Value.ToString()[0]]++;
                        }
                    }
                }
            }

            var rand = new Random();
            //
            var character = chars.Keys.ElementAt(rand.Next(0, chars.Count));
            var amount = rand.Next(1, chars[character]);
            var skip = rand.Next(0, chars[character] - amount);
            for (int i = 0; i < map.Rows.Count; i++)
            {
                for (int j = 0; j < map.Columns.Count; j++)
                {
                    if (map[i, j].Value.ToString()[0] == character && map[i, j].Style.BackColor != Color.Gray)
                    {
                        if (skip != 0)
                        {
                            skip--;
                            break;
                        }
                        if (amount != 0)
                        {
                            map[i, j].Selected = true;
                            amount--;
                        }
                    }
                }
            }
        }

    }
}
