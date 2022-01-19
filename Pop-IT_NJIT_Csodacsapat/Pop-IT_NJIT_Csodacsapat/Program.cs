/* C# console (.NET core 3.1 LTS)
 * Dusza Árpád programozói verseny 2021 - Csodacsapat: Petrányi Bence, Ruzsa Gergely, Sztrigán Vivien - BMSZC NJIT
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pop_IT_NJIT_Csodacsapat
{
    class Palya
    {
        public Int16 palya_merete { get; set; }
        public Int16 palya_id { get; set; }
        public char[,] palya_elemek { get; set; }
        public bool[,] palya_statusz { get; set; }
        public Palya(Int16 pi, string file)
        {
            string[] fajl_Beolvasva = File.ReadAllLines(Path.Combine("../../../palyak/", file), Encoding.UTF8);
            Int16 pm = (Int16)fajl_Beolvasva[0].Length;
            palya_merete = pm;
            palya_id = pi;
            palya_elemek = new char[pm, pm];
            palya_statusz = new bool[pm, pm];
            int indexer = 0;
            foreach (var item in fajl_Beolvasva)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    palya_elemek[indexer, i] = item[i];
                    palya_statusz[indexer, i] = false;
                }
                indexer++;
            }
        }
        public void palyaKiir()
        {
            int indexer = 0;
            Console.Write("   ");
            for (int i = 0; i < palya_merete; i++)
            {
                Console.Write($"{i} ");
            }
            Console.Write("\n");
            for (int i = 0; i < palya_elemek.GetLength(0); i++)
            {
                Console.Write($"{indexer}  ");
                for (int j = 0; j < palya_elemek.GetLength(1); j++)
                {
                    if (palya_statusz[i, j])
                    {
                        Console.Write("* ");
                    } else
                    {
                        Console.Write($"{palya_elemek[i, j]} ");
                    }
                }
                Console.Write("\n");
                indexer++;
            }
        }
        public bool vegePalya()
        {
            bool statusz = true;
            for (int i = 0; i < palya_statusz.GetLength(0); i++)
            {
                for (int j = 0; j < palya_statusz.GetLength(1); j++)
                {
                    if(palya_statusz[i,j] == false)
                    {
                        statusz = false;
                    }
                }
            }
            return statusz;
        }
        public bool ervenyesLepes(short x, short y)
        {
            bool visszateresi_Ertek = true;
            if (palya_statusz[x, y])
            {
                return false;
            }
            return visszateresi_Ertek;
        }
    }
    class Program
    {
        static List<Palya> palyak = new List<Palya>();
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            menu();
            Console.ReadKey();
        }

        static void menu()
        {
            Console.Clear();
            Console.WriteLine($"Üdvözöljük a Pop-It! játékban! Az alábbi parancsok állnak rendelkezésésre: játék, generálás, kilépés");
            Console.Write("Pop-It!> ");
            string jatek_Valaszt = Console.ReadLine();
            if (jatek_Valaszt.ToLower() == "játék")
            {
                Console.Clear();
                Console.Write("Adja meg a pálya sorszámát: ");
                string sor_Szam_string = Console.ReadLine();
                int sor_Szam = 0;
                while (!int.TryParse(sor_Szam_string, out sor_Szam) && (sor_Szam < 0 || sor_Szam > 1000))
                {
                    Console.Write("Érvénytelen szám. Kérem adjon meg újat: ");
                    sor_Szam_string = Console.ReadLine();
                }
                if (sor_Szam > 0 && sor_Szam < 1000)
                {
                    //érvényes szám esetén továbbfut
                    Console.WriteLine("Kérem várjon! A térkép készülődik!");
                    palyaBeolv("palya" + sor_Szam.ToString() + ".txt");
                    jatek((short)sor_Szam);
                }
            }
            else if (jatek_Valaszt.ToLower() == "generálás") //Bekéri az új pálya argumentumait
            {
                Console.Clear();
                Console.WriteLine("Térképgenerálás: adja meg az X, n és k bemeneteket!");
                Int16[] param = new Int16[3];
                Console.Write("X (pálya sorszám) paraméter> ");
                try
                {
                    param[0] = Int16.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    param[0] = 1;
                }

                Console.Write("N (pálya mérete) paraméter> ");
                try
                {
                    param[1] = Int16.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    param[1] = 4;
                }

                Console.WriteLine("Figyelem! Csak a 0 és az 1-es fordulás van implementálva!");
                Console.Write("K (fordulások száma) paraméter> ");
                try
                {
                    param[2] = Int16.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    param[2] = 1;
                }

                Generator gn = new Generator(param);
                Generator.generalas(gn);
                Console.WriteLine("A pálya elkészült! Nyomd meg az entert a visszatéréshez!");
                Console.ReadKey();
                menu();

            }
            else if (jatek_Valaszt.ToLower() == "kilépés") //kilép a consoleból
            {
                Environment.Exit(0);
            } else
            {
                menu();
            }
        }

        static void palyaBeolv(string utvonal)
        {
            palyak.Add(new Palya(1, utvonal));
        }

        static void jatek(Int16 palya_Id)
        {
            Palya jelenlegi_Palya = palyak.First();
            bool vege = false;
            Int16 jatekos = 1;
            while (!vege)
            {
                Console.Clear();
                if (jelenlegi_Palya.vegePalya())
                {
                    Console.WriteLine($"Gratulálok! Játékos {jatekos} győzött! Nyomd meg az entert a folytatáshoz...");
                    Console.ReadKey();
                    menu();
                }
                Console.WriteLine("Formátum: egy kordináta = \"x,y\", több kordináta = \"x,y x,y x,y\" (szóközzel elválasztva)");
                jelenlegi_Palya.palyaKiir();
                Console.Write($"[Játékos {jatekos}] Következő gömb(ök): ");
                string bemenet = Console.ReadLine();
                try
                {
                    string[] bemenet_Szeletelt = bemenet.Split(' ');
                    bool egy_Vonal = true;
                    // Ellenőriz, hogy egy vonalban vannak-e
                    char utolso_Karakter = ';';
                    for (int i = 0; i < bemenet_Szeletelt.Length; i++)
                    {
                        foreach (var item in bemenet_Szeletelt)
                        {
                            string[] bemenet_Szeletelt_Al = item.Split(',');
                            if (jelenlegi_Palya.palya_elemek[int.Parse(bemenet_Szeletelt_Al[0]), int.Parse(bemenet_Szeletelt_Al[1])] != utolso_Karakter && utolso_Karakter != ';')
                            {
                                egy_Vonal = false;
                            } else
                            {
                                utolso_Karakter = jelenlegi_Palya.palya_elemek[int.Parse(bemenet_Szeletelt_Al[0]), int.Parse(bemenet_Szeletelt_Al[1])];
                            }
                        }
                    }

                    if (egy_Vonal)
                    {
                        // Ellenőriz, hogy maga a lépés érvényes-e (avagy ki van-e már pukkasztva a mező)
                        foreach (var item in bemenet_Szeletelt)
                        {
                            string[] bemenet_Szeletelt_Al = item.Split(',');
                            if (!jelenlegi_Palya.ervenyesLepes(short.Parse(bemenet_Szeletelt_Al[0]), short.Parse(bemenet_Szeletelt_Al[1])))
                            {
                                Console.WriteLine("Érvénytelen lépés!");
                                continue;
                            }
                            jelenlegi_Palya.palya_statusz[int.Parse(bemenet_Szeletelt_Al[0]), int.Parse(bemenet_Szeletelt_Al[1])] = true;
                        }
                        if (jatekos == 1)
                            jatekos = 2;
                        else
                            jatekos = 1;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                }
            }
        }
    }
}
