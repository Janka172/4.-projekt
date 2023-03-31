using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt
{
    class Program
    {
        struct ls
        {
            public string nev, engedelmesseg;
            public int kitartas, gyorsasag, terepkepesseg;
        }
        
        struct palya
        {
            public string hely;
            public int hossz, tav;
        }
        
        struct pas
        {
            public int nap, verzio, be, epont, mpont;
            public string szoveg, edontes, mdontes;
        }

        static void Main(string[] args)
        {
            //Lovak
            StreamReader sr = new StreamReader("lovak.txt");
            List<ls> lovak = new List<ls>();
            ls seged;
            while (!sr.EndOfStream)
            {
                string[] d = sr.ReadLine().Split(';');
                seged.nev = d[0];
                seged.kitartas = int.Parse(d[1]);
                seged.gyorsasag = int.Parse(d[2]);
                seged.terepkepesseg = int.Parse(d[3]);
                seged.engedelmesseg = d[4];
                lovak.Add(seged);
            }
            sr.Close();

            //Pályák
            StreamReader pr = new StreamReader("palya.txt");
            List<palya> palyak = new List<palya>();
            palya pseged;
            while (!pr.EndOfStream)
            {
                string[] d = pr.ReadLine().Split(';');
                pseged.hely = d[0];
                pseged.hossz = int.Parse(d[1]);
                pseged.tav = int.Parse(d[2]);
                palyak.Add(pseged);
            }
            pr.Close();

            //Parázs - Sivatag
            //Nap;Verzió;Belép;Szöveg;Egyikdöntés;epont;Másikdöntés;mpont
            StreamReader psi = new StreamReader("00.txt");
            List<pas> ps = new List<pas>();
            pas p0seged;
            while (!pr.EndOfStream)
            {
                string[] d = pr.ReadLine().Split(';');
                p0seged.nap = int.Parse(d[0]);
                p0seged.verzio = int.Parse(d[1]);
                p0seged.be = int.Parse(d[2]);
                p0seged.szoveg = d[3];
                p0seged.edontes = d[4];
                p0seged.epont = int.Parse(d[5]);
                p0seged.mdontes = d[6];
                p0seged.mpont = int.Parse(d[7]);
                ps.Add(p0seged);
            }
            psi.Close();

            



            string akarsz = "i";
            string mi = "";
            int lo;
            int palya;
            int energia;
            int napok;
            int tav;
            while (akarsz == "i")
            {
                do
                {
                    Console.WriteLine("Mivel szeretnél játszani?\n\t1: Távlovagló verseny\n\t");
                    mi = Console.ReadLine();
                } while (mi != "1");

                //Távlovaglás
                if (mi == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Távlovagló verseny");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("A játék során a döntéseid befolyásolják a végkimenetelt. Megadott idő alatt kell teljesíteni a távot. Minden a játékban lezajló nap egy-egy döntési lehetőséget foglal magába. Ezek közül annak sorszámának beírásával lehet választani.");

                    //Pálya választó
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Melyik pályán akarsz indulni?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\tSorszám: 1\n\tHelyszín: Sivatag\n\tHossz(nap): 7\n\tTávolság(km): 665\n\n\tSorszám: 2\n\tHelyszín: Erdő\n\tHossz(nap): 11\n\tTávolság(km): 1045\n\n\tSorszám: 3\n\tHelyszín: Hegység\n\tHossz(nap): 9\n\tTávolság(km): 855\n\t");
                    do
                    {
                        Console.Write("Add meg a választott pálya sorszámát! ");
                        mi = Console.ReadLine();
                    } while (mi != "1" && mi != "2" && mi != "3");
                    palya = int.Parse(mi) - 1;

                    //Ló választó
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Melyik lóval akarsz indulni?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\tSorsazám: 1\n\tNév: Parázs\n\tKitartás: 10\n\tGyorsaság: 5\n\tTerepképesség: 7\n\tEngedelmesség: 8\n\t\n\tSorsazám: 2\n\tNév: Sodashi\n\tKitartás: 8\n\tGyorsaság: 10\n\tTerepképesség: 6\n\tEngedelmesség: 7\n\t\n\tSorsazám: 3\n\tNév: Szélvihar\n\tKitartás: 10\n\tGyorsaság: 9\n\tTerepképesség: 10\n\tEngedelmesség: 1\n\t");
                    do
                    {
                        Console.Write("Add meg a választott ló sorszámát! ");
                        mi=Console.ReadLine();
                    } while (mi!="1" && mi != "2" && mi != "3");
                    lo = int.Parse(mi) - 1;
                    
                    //Parázs
                    if (lo == 0)
                    {
                        energia = lovak[lo].kitartas;
                        //Sivatag
                        if (palya == 0)
                        {
                            tav = palyak[palya].tav;

                            //1. nap 1. verzió
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{ps[0].nap}. nap");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"A hátralévő távolság: {palyak[0].tav} km");
                            Console.WriteLine($"{ps[0].szoveg}");
                            Console.WriteLine($"{ps[0].edontes}");
                            Console.WriteLine($"{ps[0].mdontes}");
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");
                            if (mi == "1") tav = tav - ps[0].epont; //575
                            if (mi == "2") tav = tav - ps[0].mpont; //605
                            
                            //2. nap 1. verzió
                            if (tav == 575)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[1].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[1].szoveg}");
                                Console.WriteLine($"{ps[1].edontes}");
                                Console.WriteLine($"{ps[1].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[1].epont; //510
                                if (mi == "2") tav = tav - ps[1].mpont; //545
                            }

                            //2. nap 2. verzió
                            if (tav == 605)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[2].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[2].szoveg}");
                                Console.WriteLine($"{ps[2].edontes}");
                                Console.WriteLine($"{ps[2].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[2].epont;//510
                                if (mi == "2") tav = tav - ps[2].mpont;//455
                            }

                            //3. nap 1. verzió
                            if (tav == 510)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[3].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[3].szoveg}");
                                Console.WriteLine($"{ps[3].edontes}");
                                Console.WriteLine($"{ps[3].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[3].epont;//450
                                if (mi == "2") tav = tav - ps[3].mpont;//360
                            }

                            //3. nap 2. verzió
                            if (tav == 545)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[4].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[4].szoveg}");
                                Console.WriteLine($"{ps[4].edontes}");
                                Console.WriteLine($"{ps[4].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[4].epont;//415
                                if (mi == "2") tav = tav - ps[4].mpont;//360
                            }

                            //3. nap 3. verzió
                            if (tav == 455)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[5].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[5].szoveg}");
                                Console.WriteLine($"{ps[5].edontes}");
                                Console.WriteLine($"{ps[5].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[5].epont;//415
                                if (mi == "2") tav = tav - ps[5].mpont;//335
                            }

                            //4. nap 1. verzió
                            if (tav == 450)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[6].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[6].szoveg}");
                                Console.WriteLine($"{ps[6].edontes}");
                                Console.WriteLine($"{ps[6].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[6].epont;//449
                                if (mi == "2") tav = tav - ps[6].mpont;//448
                            }

                            //4. nap 2. verzió
                            if (tav == 415)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[7].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[7].szoveg}");
                                Console.WriteLine($"{ps[7].edontes}");
                                Console.WriteLine($"{ps[7].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[7].epont;//315
                                if (mi == "2") tav = tav - ps[7].mpont;//295
                            }

                            //4. nap 3. verzió
                            if (tav == 335)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[8].szoveg}");
                                Console.WriteLine($"{ps[8].edontes}");
                                Console.WriteLine($"{ps[8].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[8].epont;//334
                                if (mi == "2") tav = tav - ps[8].mpont;//270
                            }

                            //5. nap 1. verzió - vég - b
                            if (tav == 449)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[9].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 2. verzió - vég - b
                            if (tav == 448)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[10].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[10].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 334)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[11].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[11].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 4. verzió
                            if (tav == 270)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[12].szoveg}");
                                Console.WriteLine($"{ps[12].edontes}");
                                Console.WriteLine($"{ps[12].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[12].epont;//200
                                if (mi == "2") tav = tav - ps[12].mpont;//120
                            }

                            //5. nap 5. verzió
                            if (tav == 295)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[13].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[13].szoveg}");
                                Console.WriteLine($"{ps[13].edontes}");
                                Console.WriteLine($"{ps[13].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[13].epont;//294
                                if (mi == "2") tav = tav - ps[13].mpont;//293
                            }

                            //5. nap 6. verzió
                            if (tav == 315)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[14].szoveg}");
                                Console.WriteLine($"{ps[14].edontes}");
                                Console.WriteLine($"{ps[14].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[14].epont;//
                                if (mi == "2") tav = tav - ps[14].mpont;//
                            }

                            //6. nap 1. verzió - vég - ny
                            if (tav == 120)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[15].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[15].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 2. verzió
                            if (tav == 200)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ps[16].szoveg}");
                                Console.WriteLine($"{ps[16].edontes}");
                                Console.WriteLine($"{ps[16].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ps[16].epont;//0
                                if (mi == "2") tav = tav - ps[16].mpont;//50
                            }

                            //6. nap 3. verzió - vég - b
                            if (tav == 294)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[17].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 4. verzió - vég - b
                            if (tav == 293)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[18].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                            //Győzelem SZÁMOOOK
                            if (tav == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //Erdő
                        if (palya == 1)
                        {
                            tav = palyak[palya].tav;

                        }

                        //Hegység
                        if (palya == 2)
                        {
                            tav = palyak[palya].tav;

                        }
                    }

                    //Sodashi
                    if (lo == 1)
                    {
                        energia = lovak[lo].kitartas;
                        //Sivatag
                        if (palya == 0)
                        {
                            tav = palyak[palya].tav;

                        }

                        //Erdő
                        if (palya == 1)
                        {
                            tav = palyak[palya].tav;

                        }

                        //Hegység
                        if (palya == 2)
                        {
                            tav = palyak[palya].tav;

                        }
                    }

                    //Szélvihar
                    if (lo == 2)
                    {
                        energia = lovak[lo].kitartas;
                        //Sivatag
                        if (palya == 0)
                        {
                            tav = palyak[palya].tav;

                        }

                        //Erdő
                        if (palya == 1)
                        {
                            tav = palyak[palya].tav;

                        }

                        //Hegység
                        if (palya == 2)
                        {
                            tav = palyak[palya].tav;

                        }
                    }





                }
                //Következő helye






                do
                {
                    Console.Write("Visszamész a menübe? [i/n] ");
                    akarsz = Console.ReadLine();
                } while (akarsz!="i" && akarsz != "n");
            }
            Console.ReadKey();
        }
    }
}
