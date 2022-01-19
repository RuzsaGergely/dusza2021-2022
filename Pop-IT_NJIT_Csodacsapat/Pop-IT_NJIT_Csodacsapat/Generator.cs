using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Pop_IT_NJIT_Csodacsapat
{
    class Generator
    {
        private Random r { get; set; }
        private Int16 index { get; set; }
        private Int16 meret { get; set; }
        private Int16 hajlit { get; set; }

        public Generator(Int16[] adatok)
        {
            index = adatok[0];
            meret = adatok[1];
            hajlit = adatok[2];
            r = new Random();
        }

        public static void generalas(Generator forma)
        {
            Int16[,] nyers = new Int16[forma.meret, forma.meret];
            Tuple<Int16, Int16, bool>[] kanyarok = new Tuple<Int16, Int16, bool>[forma.hajlit];
            
            for (Int16 i = 0; i < kanyarok.Length; i++)
            {
                kanyarok[i] = Tuple.Create(Convert.ToInt16(forma.r.Next(0, forma.meret)), Convert.ToInt16(forma.r.Next(0, forma.meret)), Convert.ToBoolean(forma.r.Next(0,2)));
            }

            for (Int16 i = 0; i < nyers.GetLength(0); i++)
            {
                for (Int16 j = 0; j < nyers.GetLength(1); j++)
                {
                    nyers[i, j] = i;
                }
            }

            Int16 max = forma.meret;
            switch (forma.hajlit)
            {
                case 0:
                    break;
                case 1:
                    for (int i = 0; i < nyers.GetLength(0); i++)
                    {
                        for (int j = 0; j < nyers.GetLength(1); j++)
                        {
                            if (kanyarok[0].Item3 && kanyarok[0].Item1 < i && kanyarok[0].Item2 == j)
                            {
                                nyers[i, j] = kanyarok[0].Item1;
                            }
                            else if (!kanyarok[0].Item3 && kanyarok[0].Item1 > i && kanyarok[0].Item2 == j)
                            {
                                nyers[i, j] = kanyarok[0].Item1;
                            }
                            else if (kanyarok[0].Item3 && kanyarok[0].Item1 <= i && kanyarok[0].Item2 < j)
                            {
                                nyers[i, j] = Int16.Parse($"1{nyers[i, j].ToString()}");
                            }
                            else if (!kanyarok[0].Item3 && kanyarok[0].Item1 >= i && kanyarok[0].Item2 < j)
                            {
                                nyers[i, j] = Int16.Parse($"1{nyers[i, j].ToString()}");
                            }
                        }
                    }
                    break;
                case 2:
                case 3:

                    break;
                case 4:

                    break;
            }

            mentes(nyers, forma.index);

            /*
            bool[] multi_Kanyar = new bool[10];
                foreach (var item in kanyarok)
                {
                    if (!multi_Kanyar[item.Item1])
                    {
                        for (Int16 i = 0; i < nyers.GetLength(0); i++)
                        {
                            for (Int16 j = 0; j < nyers.GetLength(1); j++)
                            {
                                if (i == item.Item1 && item.Item2 > j)
                                {
                                    nyers[i, j] = 99;
                                }
                                else if (item.Item3 && j == item.Item2 && i < item.Item1)
                                {
                                    nyers[i, j] = nyers[i + 1, j];
                                }
                                else if (!item.Item3 && j == item.Item2 && i > item.Item1)
                                {
                                    nyers[i, j] = nyers[i - 1, j];
                                }
                            }
                        }
                        multi_Kanyar[item.Item1] = true;
                    }
                    else
                    {
                        for (Int16 i = 0; i < nyers.GetLength(0); i++)
                        {
                            for (Int16 j = 0; j < nyers.GetLength(1); j++)
                            {
                                if (j == item.Item1 && item.Item2 > i)
                                {
                                    nyers[i, j] = 99;
                                }
                                else if (item.Item3 && i == item.Item2 && j < item.Item1)
                                {
                                    nyers[i, j] = nyers[i, j + 1];
                                }
                                else if (!item.Item3 && i == item.Item2 && j > item.Item1)
                                {
                                    nyers[i, j] = nyers[i, j - 1];
                                }
                            }
                        }
                    }
                }*/



            //ellenőrzés
            /*for (Int16 i = 0; i < nyers.GetLength(0); i++)
            {
                for (Int16 j = 0; j < nyers.GetLength(1); j++)
                {
                    Console.Write("\t" + nyers[i,j]);
                }
                Console.WriteLine();
            }*/

        }

        private static void mentes(Int16[,] terkep, Int16 index)
        {
            char[] abc = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            using (StreamWriter fajlkezelo = new StreamWriter(File.Create(Path.Combine("..", "..", "..", "palyak", $"palya{index}.txt")), Encoding.UTF8))
            {
                string temp = "";
                for (int i = 0; i < terkep.GetLength(0); i++)
                {
                    for (int j = 0; j < terkep.GetLength(1); j++)
                    {
                        temp += abc[terkep[i, j]];
                    }
                    temp += "\n";
                }
                fajlkezelo.WriteLine(temp);
            }
        }
    }
}
