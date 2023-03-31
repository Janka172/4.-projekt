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
            while (!psi.EndOfStream)
            {
                string[] d = psi.ReadLine().Split(';');
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

            //Sodashi - Sivatag
            //Nap;Verzió;Belép;Szöveg;Egyikdöntés;epont;Másikdöntés;mpont
            StreamReader ssi = new StreamReader("10.txt");
            List<pas> ss = new List<pas>();
            pas s0seged;
            while (!ssi.EndOfStream)
            {
                string[] d = ssi.ReadLine().Split(';');
                s0seged.nap = int.Parse(d[0]);
                s0seged.verzio = int.Parse(d[1]);
                s0seged.be = int.Parse(d[2]);
                s0seged.szoveg = d[3];
                s0seged.edontes = d[4];
                s0seged.epont = int.Parse(d[5]);
                s0seged.mdontes = d[6];
                s0seged.mpont = int.Parse(d[7]);
                ss.Add(s0seged);
            }
            ssi.Close();
            

            string akarsz = "i";
            string mi = "";
            int lo;
            int palya;
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
                    Console.Clear();
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
                    Console.Clear();

                    //Ló választó
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Melyik lóval akarsz indulni?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\tSorszám: 1\n\tNév: Parázs\n\tKitartás: 10\n\tGyorsaság: 5\n\tTerepképesség: 7\n\tEngedelmesség: 8\n\t\n\tSorszám: 2\n\tNév: Sodashi\n\tKitartás: 8\n\tGyorsaság: 10\n\tTerepképesség: 6\n\tEngedelmesség: 7\n\t");
                    do
                    {
                        Console.Write("Add meg a választott ló sorszámát! ");
                        mi=Console.ReadLine();
                    } while (mi!="1" && mi != "2" && mi != "3");
                    lo = int.Parse(mi) - 1;
                    Console.Clear();

                    //Parázs
                    if (lo == 0)
                    {
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                if (mi == "1") tav = tav - ps[14].epont;//314
                                if (mi == "2") tav = tav - ps[14].mpont;//313
                                
                            }

                            //6. nap 1. verzió - vég - ny
                            if (tav == 120)
                            {
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[18].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 5. verzió - vég - b
                            if (tav == 314)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[19].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[19].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 5. verzió - vég - b
                            if (tav == 313)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[20].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 1. verzió - vég - ny
                            if (tav == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[21].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[21].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió - vég - ny
                            if (tav == 50)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[22].szoveg}");
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
                        //Sivatag
                        if (palya == 0)
                        {
                            tav = palyak[palya].tav;
                            //1. nap 1. verzió
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{ss[0].nap}. nap");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"A hátralévő távolság: {palyak[0].tav} km");
                            Console.WriteLine($"{ss[0].szoveg}");
                            Console.WriteLine($"{ss[0].edontes}");
                            Console.WriteLine($"{ss[0].mdontes}");
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");
                            if (mi == "1") tav = tav - ss[0].epont;
                            if (mi == "2") tav = tav - ss[0].mpont;


                            //2. nap 1. verzió
                            if (tav == 565)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[1].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[1].szoveg}");
                                Console.WriteLine($"{ss[1].edontes}");
                                Console.WriteLine($"{ss[1].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[1].epont;
                                if (mi == "2") tav = tav - ss[1].mpont;
                            }

                            //2. nap 2. verzió
                            if (tav == 585)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[2].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[2].szoveg}");
                                Console.WriteLine($"{ss[2].edontes}");
                                Console.WriteLine($"{ss[2].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[2].epont;
                                if (mi == "2") tav = tav - ss[2].mpont;
                            }

                            //3. nap 1. verzió
                            if (tav == 445)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[3].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[3].szoveg}");
                                Console.WriteLine($"{ss[3].edontes}");
                                Console.WriteLine($"{ss[3].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[3].epont;
                                if (mi == "2") tav = tav - ss[3].mpont;
                            }

                            //3. nap 2. verzió
                            if (tav == 505)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[4].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[4].szoveg}");
                                Console.WriteLine($"{ss[4].edontes}");
                                Console.WriteLine($"{ss[4].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[4].epont;
                                if (mi == "2") tav = tav - ss[4].mpont;
                            }

                            //3. nap 3. verzió
                            if (tav == 490)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[5].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[5].szoveg}");
                                Console.WriteLine($"{ss[5].edontes}");
                                Console.WriteLine($"{ss[5].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[5].epont;
                                if (mi == "2") tav = tav - ss[5].mpont;
                            }

                            //3. nap 4. verzió
                            if (tav == 435)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[6].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[6].szoveg}");
                                Console.WriteLine($"{ss[6].edontes}");
                                Console.WriteLine($"{ss[6].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[6].epont;
                                if (mi == "2") tav = tav - ss[6].mpont;
                            }

                            //4. nap 1. verzió
                            if (tav == 315)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[7].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[7].szoveg}");
                                Console.WriteLine($"{ss[7].edontes}");
                                Console.WriteLine($"{ss[7].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[7].epont;
                                if (mi == "2") tav = tav - ss[7].mpont;
                            }

                            //4. nap 2. verzió - vég - b
                            if (tav == 444)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[8].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 3. verzió - vég - b
                            if (tav == 504)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[9].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 4. verzió
                            if (tav == 430)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[10].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[10].szoveg}");
                                Console.WriteLine($"{ss[10].edontes}");
                                Console.WriteLine($"{ss[10].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[10].epont;
                                if (mi == "2") tav = tav - ss[10].mpont;
                            }

                            //4. nap 5. verzió
                            if (tav == 370)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[11].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[11].szoveg}");
                                Console.WriteLine($"{ss[11].edontes}");
                                Console.WriteLine($"{ss[11].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[1].epont;
                                if (mi == "2") tav = tav - ss[1].mpont;
                            }

                            //4. nap 6. verzió - vég - b
                            if (tav == 489)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[12].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 7. verzió
                            if (tav == 415)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[13].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[13].szoveg}");
                                Console.WriteLine($"{ss[13].edontes}");
                                Console.WriteLine($"{ss[13].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[13].epont;
                                if (mi == "2") tav = tav - ss[13].mpont;
                            }

                            //4. nap 8. verzió - vég - b
                            if (tav == 434)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[14].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 1. verzió
                            if (tav == 225)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[15].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[15].szoveg}");
                                Console.WriteLine($"{ss[15].edontes}");
                                Console.WriteLine($"{ss[15].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[15].epont;
                                if (mi == "2") tav = tav - ss[15].mpont;
                            }

                            //5. nap 2. verzió - vég - b
                            if (tav == 314)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[16].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 429)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[17].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 4. verzió
                            if (tav == 335)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[18].szoveg}");
                                Console.WriteLine($"{ss[18].edontes}");
                                Console.WriteLine($"{ss[18].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[18].epont;
                                if (mi == "2") tav = tav - ss[18].mpont;
                            }

                            //5. nap 5. verzió
                            if (tav == 280)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[19].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[19].szoveg}");
                                Console.WriteLine($"{ss[19].edontes}");
                                Console.WriteLine($"{ss[19].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[19].epont;
                                if (mi == "2") tav = tav - ss[19].mpont;
                            }

                            //5. nap 6. verzió - vég - b
                            if (tav == 413)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[20].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                            //6. nap 1. verzió
                            if (tav == 75)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[21].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ss[21].szoveg}");
                                Console.WriteLine($"{ss[21].edontes}");
                                Console.WriteLine($"{ss[21].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ss[21].epont;
                                if (mi == "2") tav = tav - ss[21].mpont;
                            }

                            //6. nap 2. verzió - vég - b
                            if (tav == 413)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[22].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 1. verzió - vég - ny
                            if (tav == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[23].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[23].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió - vég - b
                            if (tav == 74)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ps[24].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ps[24].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
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
