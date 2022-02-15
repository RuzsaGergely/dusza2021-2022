using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop_it_GUI
{
    static class PalyaGenerator
    {
        //jelenleg lementetlen pályák
        private static List<Palya> cache = new List<Palya>();
        //pályával visszatérő eljárás
        public static Palya General(int pID, int meret, int kanyarSz)
        {
            //jelenleg használt karakter ID
            int mod = 1;
            //üres mátrix (későbbi pálya)
            int[,] raw;
            bool reset;
            do
            {
                raw = new int[meret, meret];
                //pályán elhelyezkedő, hajlított vonalak generálása
                KanyarGen(ref raw, kanyarSz, ref mod);
                //
                //a pálya egyenes vonalainak generálása
                Feltolt(ref raw, ref mod);
                //
                var chars = new Dictionary<int, int>();
                for (int i = 0; i < raw.GetLength(0); i++)
                {
                    for (int j = 0; j < raw.GetLength(1); j++)
                    {
                        if (chars.ContainsKey(raw[i, j]))
                        {
                            chars[raw[i, j]]++;
                        }
                        else
                        {
                            chars.Add(raw[i, j], 1);
                        }
                    }
                }
                reset = chars.ContainsValue(1);
            } while (reset);

            //a pályán elhelyezkedő számok lecsökkentése (karakterré alakításhoz)
            Minimalise(ref raw);
            //
            return new Palya(pID, "", toChar(raw));
        }

        private static void Minimalise(ref int[,] x)
        {
            //összes különböző karakter kigyűjtése
            var sample = new List<int>();
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(0); j++)
                {
                    if (!sample.Contains(x[i, j]))
                        sample.Add(x[i, j]);
                }
            }
            //

            //azonos karakterek keresése, kicserélése
            //szorzás -1-el -> nincs szerkesztés utáni azonosság
            for (int i = 0; i < sample.Count; i++)
            {
                for (int j = 0; j < x.GetLength(0); j++)
                {
                    for (int k = 0; k < x.GetLength(0); k++)
                    {
                        if (x[j,k] == sample[i])
                        {
                            x[j, k] = -1 * (i + 1);
                        }
                    }
                }
            }
            //

            //a -1-es szörzás visszaállítása
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(0); j++)
                {
                    x[i, j] = -1 * x[i, j] - 1;
                }
            }
        }

        private static void Feltolt(ref int[,] onlyLines, ref int mod)
        {
            //nem elfoglalt helyek feltöltése mod-al, elfoglalt helyek esetén a mod növelése
            for (int i = 0; i < onlyLines.GetLength(0); i++)
            {
                for (int j = 0; j < onlyLines.GetLength(0); j++)
                {
                    if (onlyLines[i,j] == 0)
                    {
                        onlyLines[i, j] = mod;
                    }
                    else
                    {
                        mod++;
                    }
                }
                mod++;
            }
        }

        //számokat karakterré alakító függvény
        private static char[,] toChar(int[,] tmp)
        {
            //char[] abc = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '@', '&', '$', 'ß', '#', '<', '>', 'Đ', '%', '!', '~', '=', '-', 'ö', 'ü', 'ó', 'ő' };
            char[,] output = new char[tmp.GetLength(0), tmp.GetLength(1)];
            for (int i = 0; i < tmp.GetLength(0); i++)
            {
                for (int j = 0; j < tmp.GetLength(1); j++)
                {
                    //output[i, j] = abc[tmp[i, j]];
                    output[i, j] = Convert.ToChar(65 + tmp[i, j]);
                }
            }
            return output;
        }
        private static void KanyarGen(ref int[,] ures, int kanyarSz, ref int mod)
        {
            var size = ures.GetLength(0);
            var rand = new Random();
            //kanyarszámok vonalankénti elosztása
            int[] kanyarok = new int[kanyarSz];
            for (int i = 0; kanyarSz != 0; i++)
            {
                //vonal kanyarszámának kisorsolása
                kanyarok[i] = new Random().Next(1, kanyarSz+1);
                //lehetséges kanyarok számának csökkentése
                kanyarSz -= kanyarok[i];
            }

            //lépés a mátrixban
            void step(int direction, ref Tuple<int, int> curPoz)
            {
                //irány alapján történő eldöntés
                switch (direction)
                {
                    //jobbra lépés
                    case 0:
                        curPoz = Tuple.Create(curPoz.Item1, curPoz.Item2 + 1);
                        break;
                    //lefelé lépés
                    case 1:
                        curPoz = Tuple.Create(curPoz.Item1 + 1, curPoz.Item2);
                        break;
                    //balra lépés
                    case 2:
                        curPoz = Tuple.Create(curPoz.Item1, curPoz.Item2 - 1);
                        break;
                    //felfelé lépés
                    case 3:
                        curPoz = Tuple.Create(curPoz.Item1 - 1, curPoz.Item2);
                        break;
                }
            }
            //vonalak generálása
            foreach (int item in kanyarok)
            {
                //véletlenszerű kezdőirány
                var direction = rand.Next(0, 4);
                //jelenlegi pozíció változóbeli eltárolása
                Tuple<int, int> curPoz;
                //véletlenszerű kezdőpozíció
                switch (direction)
                {
                    case 0:
                        curPoz = Tuple.Create(rand.Next(0, size), 0);
                        break;
                    case 1:
                        curPoz = Tuple.Create(0, rand.Next(0, size));
                        break;
                    case 2:
                        curPoz = Tuple.Create(rand.Next(0, size), size - 1);
                        break;
                    case 3:
                        curPoz = Tuple.Create(size - 1, rand.Next(0, size));
                        break;
                    default:
                        curPoz = Tuple.Create(0, 0);
                        break;
                }
                //véletlenszeű lépésszám
                var steps = rand.Next(1, size);

                //irány alapján meghatározott hátsó szomszéd hasonlóságának meghatározása
                bool isIdentical(int[,] map, int curMod)
                {
                    //irány alapján történő eldöntés
                    switch (direction)
                    {
                        //hasonlóság eldöntése iránytól függően
                        case 0:
                            return map[curPoz.Item1, curPoz.Item2 - 1] == curMod && map[curPoz.Item1, curPoz.Item2] == curMod;
                        case 1:
                            return map[curPoz.Item1 - 1, curPoz.Item2] == curMod && map[curPoz.Item1, curPoz.Item2] == curMod;
                        case 2:
                            return map[curPoz.Item1, curPoz.Item2 + 1] == curMod && map[curPoz.Item1, curPoz.Item2] == curMod;
                        case 3:
                            return map[curPoz.Item1 + 1, curPoz.Item2] == curMod && map[curPoz.Item1, curPoz.Item2] == curMod;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                }

                //kanyarok számával ekvivalensen ismétlődő ciklus - kanyargenerálás
                for (int k = 0; k < item; k++)
                {
                    //lépések megtétele
                    for (int i = 0; i < steps; i++)
                    {
                        //esetleges átlépés / kihagyás ellenőrzése
                        try
                        {
                            if (ures[curPoz.Item1, curPoz.Item2] == 0)
                            {
                                ures[curPoz.Item1, curPoz.Item2] = mod;
                                step(direction, ref curPoz);
                            }
                            else if (isIdentical(ures, mod) /*((direction == 0) ? ures[curPoz.Item1, curPoz.Item2 - 1] : ures[curPoz.Item1 - 1, curPoz.Item2]) == ures[curPoz.Item1, curPoz.Item2]*/)
                            {
                                step(direction, ref curPoz);
                            }
                            else
                            {
                                //step(direction, ref curPoz);
                                //mod++;
                                break;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        
                    }

                    //új véletlenszerű irány generálása
                    switch (direction)
                    {
                        case 0:
                        case 2:
                            if (curPoz.Item1 == 0)
                                direction = 1;
                            else if (curPoz.Item1 == size - 1)
                                direction = 3;
                            else
                                direction = (rand.Next(0, 2) == 0) ? 3 : 1;
                            break;
                        case 1:                        
                        case 3:
                            if (curPoz.Item2 == 0)
                                direction = 0;
                            else if (curPoz.Item2 == size - 1)
                                direction = 2;
                            else
                                direction = (rand.Next(0, 2) == 0) ? 0 : 2;
                            break;
                    }

                    //új véletlenszerű lépésszám generálása
                    switch (direction)
                    {
                        case 0:
                            steps = rand.Next(1, size - curPoz.Item2);
                            break;
                        case 1:
                            steps = rand.Next(1, size - curPoz.Item1);
                            break;
                        case 2:
                            steps = rand.Next(1, curPoz.Item2 + 1);
                            break;
                        case 3:
                            steps = rand.Next(1, curPoz.Item1 + 1);
                            break;
                    }

                    //step(direction, ref curPoz);
                }

                //utolsó kanyar után, a mátrix széléhez történő elnyújtás
                switch (direction)
                {
                    case 0:
                        //jobb
                        {
                            var remaining = size - curPoz.Item2;
                            for (int i = 0; i < remaining; i++)
                            {
                                try
                                {
                                    if (ures[curPoz.Item1, curPoz.Item2] == 0)
                                    {
                                        ures[curPoz.Item1, curPoz.Item2] = mod;
                                        step(direction, ref curPoz);
                                    }
                                    else if (isIdentical(ures, mod) /*((direction == 0) ? ures[curPoz.Item1, curPoz.Item2 - 1] : ures[curPoz.Item1 - 1, curPoz.Item2]) == ures[curPoz.Item1, curPoz.Item2]*/)
                                    {
                                        step(direction, ref curPoz);
                                    }
                                    else
                                    {
                                        step(direction, ref curPoz);
                                        mod++;
                                    }
                                }
                                catch (Exception)
                                {
                                    step(direction, ref curPoz);
                                }
                            }
                        }
                        break;
                    case 1:
                        //le
                        {
                            var remaining = size - curPoz.Item1;
                            for (int i = 0; i < remaining; i++)
                            {
                                try
                                {
                                    if (ures[curPoz.Item1, curPoz.Item2] == 0)
                                    {
                                        ures[curPoz.Item1, curPoz.Item2] = mod;
                                        step(direction, ref curPoz);
                                    }
                                    else if (isIdentical(ures, mod) /*((direction == 0) ? ures[curPoz.Item1, curPoz.Item2 - 1] : ures[curPoz.Item1 - 1, curPoz.Item2]) == ures[curPoz.Item1, curPoz.Item2]*/)
                                    {
                                        step(direction, ref curPoz);
                                    }
                                    else
                                    {
                                        step(direction, ref curPoz);
                                        mod++;
                                    }
                                }
                                catch (Exception)
                                {
                                    step(direction, ref curPoz);
                                }
                            }
                        }
                        break;
                    case 2:
                        //bal
                        {
                            var remaining = curPoz.Item2 + 1;
                            for (int i = 0; i < remaining; i++)
                            {
                                try
                                {
                                    if (ures[curPoz.Item1, curPoz.Item2] == 0)
                                    {
                                        ures[curPoz.Item1, curPoz.Item2] = mod;
                                        step(direction, ref curPoz);
                                    }
                                    else if (isIdentical(ures, mod) /*((direction == 0) ? ures[curPoz.Item1, curPoz.Item2 - 1] : ures[curPoz.Item1 - 1, curPoz.Item2]) == ures[curPoz.Item1, curPoz.Item2]*/)
                                    {
                                        step(direction, ref curPoz);
                                    }
                                    else
                                    {
                                        step(direction, ref curPoz);
                                        mod++;
                                    }
                                }
                                catch (Exception)
                                {
                                    step(direction, ref curPoz);
                                }
                            }
                        }
                        break;
                    case 3:
                        //fel
                        {
                            var remaining = curPoz.Item1 + 1;
                            for (int i = 0; i < remaining; i++)
                            {
                                try
                                {
                                    if (ures[curPoz.Item1, curPoz.Item2] == 0)
                                    {
                                        ures[curPoz.Item1, curPoz.Item2] = mod;
                                        step(direction, ref curPoz);
                                    }
                                    else if (isIdentical(ures, mod) /*((direction == 0) ? ures[curPoz.Item1, curPoz.Item2 - 1] : ures[curPoz.Item1 - 1, curPoz.Item2]) == ures[curPoz.Item1, curPoz.Item2]*/)
                                    {
                                        step(direction, ref curPoz);
                                    }
                                    else
                                    {
                                        step(direction, ref curPoz);
                                        mod++;
                                    }
                                }
                                catch (Exception)
                                {
                                    step(direction, ref curPoz);
                                }
                            }
                        }
                        break;
                }

                //vonal meghúzása után, az id növelése
                mod++;

            }
        }
    }
}
