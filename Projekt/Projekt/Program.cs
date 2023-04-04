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

        struct elk
        {
            public string nev, tett, ido;
        }

        struct rend
        {
            public string rendszam, tulaj;
        }

        struct ns
        {
            public int index;
            public string szoveg;
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

            //Parázs - Erdő
            //Nap;Verzió;Belép;Szöveg;Egyikdöntés;epont;Másikdöntés;mpont
            StreamReader per = new StreamReader("01.txt");
            List<pas> pe = new List<pas>();
            pas p1seged;
            while (!per.EndOfStream)
            {
                string[] d = per.ReadLine().Split(';');
                p1seged.nap = int.Parse(d[0]);
                p1seged.verzio = int.Parse(d[1]);
                p1seged.be = int.Parse(d[2]);
                p1seged.szoveg = d[3];
                p1seged.edontes = d[4];
                p1seged.epont = int.Parse(d[5]);
                p1seged.mdontes = d[6];
                p1seged.mpont = int.Parse(d[7]);
                pe.Add(p1seged);
            }
            per.Close();

            //Parázs - Hegység
            //Nap;Verzió;Belép;Szöveg;Egyikdöntés;epont;Másikdöntés;mpont
            StreamReader phe = new StreamReader("02.txt");
            List<pas> ph = new List<pas>();
            pas p2seged;
            while (!phe.EndOfStream)
            {
                string[] d = phe.ReadLine().Split(';');
                p2seged.nap = int.Parse(d[0]);
                p2seged.verzio = int.Parse(d[1]);
                p2seged.be = int.Parse(d[2]);
                p2seged.szoveg = d[3];
                p2seged.edontes = d[4];
                p2seged.epont = int.Parse(d[5]);
                p2seged.mdontes = d[6];
                p2seged.mpont = int.Parse(d[7]);
                ph.Add(p2seged);
            }
            phe.Close();

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

            //Sodashi - Erdő
            //Nap;Verzió;Belép;Szöveg;Egyikdöntés;epont;Másikdöntés;mpont
            StreamReader ser = new StreamReader("11.txt");
            List<pas> se = new List<pas>();
            pas s1seged;
            while (!ser.EndOfStream)
            {
                string[] d = ser.ReadLine().Split(';');
                s1seged.nap = int.Parse(d[0]);
                s1seged.verzio = int.Parse(d[1]);
                s1seged.be = int.Parse(d[2]);
                s1seged.szoveg = d[3];
                s1seged.edontes = d[4];
                s1seged.epont = int.Parse(d[5]);
                s1seged.mdontes = d[6];
                s1seged.mpont = int.Parse(d[7]);
                se.Add(s1seged);
            }
            ser.Close();

            //Sodashi - Hegység
            //Nap;Verzió;Belép;Szöveg;Egyikdöntés;epont;Másikdöntés;mpont
            StreamReader she = new StreamReader("12.txt");
            List<pas> sh = new List<pas>();
            pas s2seged;
            while (!she.EndOfStream)
            {
                string[] d = she.ReadLine().Split(';');
                s2seged.nap = int.Parse(d[0]);
                s2seged.verzio = int.Parse(d[1]);
                s2seged.be = int.Parse(d[2]);
                s2seged.szoveg = d[3];
                s2seged.edontes = d[4];
                s2seged.epont = int.Parse(d[5]);
                s2seged.mdontes = d[6];
                s2seged.mpont = int.Parse(d[7]);
                sh.Add(s2seged);
            }
            she.Close();

            //Elkövető nyilvántartás
            //Név;Bűncselekmény;Időpont(év/hónap/nap)
            StreamReader sr2 = new StreamReader("elknyilv.txt");
            List<elk> elkovetok = new List<elk>();
            elk eseged;
            while (!sr2.EndOfStream)
            {
                string[] d = sr2.ReadLine().Split(';');
                eseged.nev = d[0];
                eseged.tett = d[1];
                eseged.ido = d[2];
                elkovetok.Add(eseged);
            }
            sr2.Close();

            //Rendszám nyilvántartás
            //Rendszám, Tulaj
            //FileStream fsrsznyilv = new FileStream("rendnyilv.txt", FileMode.Append);
            StreamReader sr3 = new StreamReader("rendnyilv.txt");
            List<rend> rendszamok = new List<rend>();
            rend rseged;
            while (!sr3.EndOfStream)
            {
                string[] d = sr3.ReadLine().Split(';');
                rseged.rendszam = d[0];
                rseged.tulaj = d[1];
                rendszamok.Add(rseged);
            }
            sr3.Close();

            //Nyomozás story
            //Index,Szöveg
            StreamReader sr4 = new StreamReader("1eset.txt");
            List<ns> elsoeset = new List<ns>();
            ns nsseged;
            while (!sr4.EndOfStream)
            {
                string[] d = sr4.ReadLine().Split(';');
                nsseged.index = int.Parse(d[0]);
                nsseged.szoveg = d[1];
                elsoeset.Add(nsseged);
            }

            string akarsz = "i";
            string mi = "";
            int lo;
            int palya;
            int tav;
            int volt;
            List<string> nyomok = new List<string>();
            string egyeset = "Esetszám: 1\nTípus: Bejentés\nÜzenet: Már két napja nem láttuk a lányunkat, nem nyit ajtót, nem veszi fel a telefont. A háza zárva, és két napja nem volt ott mozgás. Segítségre lenne szükségünk!";
            string kettoeset = "Esetszám: 2\nTípus: Bejentés\nÜzenet: a szomszéd telken gyakran hallottunk furcsa hangokat, nyerítésre hasonlítottak. A múlt hét elején valami nagyon hangos zajra lettünk figyelmesek az éjjel. Az óta se tudunk semmit az esetről, de aggódunk hogy valakinek baja esett. Segítségre lenne szükségünk!";
            string haromeset = "Esetszám: 3\nTípus: Bejentés\nÜzenet: A múlt éjjel egy furcsa hangra lettünk figyelmesek a szomszéd lakásból. A folyosón dulakodás nyomait találtunk. A lakó azt mondta részeg volt, és elesett, de nem hiszünk neki, félünk hogy valakinek baja eshetett. Segítségre lenne szükségünk!";
            string negyeset = "Esetszám: 4\nTípus: Bejentés\nÜzenet: Ma reggel a 12 éves lányunk egyedül ment az iskolába. tanárai jelezték, hogy nem ért be óráira, a barátai nem tudnak róla semmit. A telfont sem veszi fel, kincsöng,de nincs reakció, de volt olyan is a közel 50 hívásból, hogy valaki kinyomta. Ez nem jellemző rá. Segítségre lenne szükségünk!";
            List<string> esetek = new List<string>();
            bool elsonap = true;
            esetek.Add(egyeset);
            esetek.Add(kettoeset);
            esetek.Add(haromeset);
            esetek.Add(negyeset);

            while (akarsz == "i")
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("Mivel szeretnél játszani?\n\t1: Távlovagló verseny szimulátor\n\t2: Rendőr szimulátor\n\t");
                    mi = Console.ReadLine();
                } while (mi != "1" && mi != "2");

                //Távlovaglás
                if (mi == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Távlovagló verseny szimulátor");
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

                    //Ló választ
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
                            //1. nap 1. verzió
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{pe[0].nap}. nap");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"A hátralévő távolság: {palyak[1].tav} km");
                            Console.WriteLine($"{pe[0].szoveg}");
                            Console.WriteLine($"{pe[0].edontes}");
                            Console.WriteLine($"{pe[0].mdontes}");
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");
                            if (mi == "1") tav = tav - pe[0].epont;
                            if (mi == "2") tav = tav - pe[0].mpont;

                            //2. nap 1. verzió
                            if (tav == 950)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[1].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[1].szoveg}");
                                Console.WriteLine($"{pe[1].edontes}");
                                Console.WriteLine($"{pe[1].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[1].epont;
                                if (mi == "2") tav = tav - pe[1].mpont;
                            }

                            //2. nap 2. verzió
                            if (tav == 945)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[2].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[2].szoveg}");
                                Console.WriteLine($"{pe[2].edontes}");
                                Console.WriteLine($"{pe[2].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[2].epont;
                                if (mi == "2") tav = tav - pe[2].mpont;
                            }

                            //3. nap 1. verzió
                            if (tav == 855)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[3].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[3].szoveg}");
                                Console.WriteLine($"{pe[3].edontes}");
                                Console.WriteLine($"{pe[3].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[3].epont;
                                if (mi == "2") tav = tav - pe[3].mpont;
                            }

                            //3. nap 2. verzió
                            if (tav == 905)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[4].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[4].szoveg}");
                                Console.WriteLine($"{pe[4].edontes}");
                                Console.WriteLine($"{pe[4].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[4].epont;
                                if (mi == "2") tav = tav - pe[4].mpont;
                            }

                            //3. nap 3. verzió
                            if (tav == 825)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[5].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[5].szoveg}");
                                Console.WriteLine($"{pe[5].edontes}");
                                Console.WriteLine($"{pe[5].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[5].epont;
                                if (mi == "2") tav = tav - pe[5].mpont;
                            }

                            //4. nap 1. verzió
                            if (tav == 810)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[6].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[6].szoveg}");
                                Console.WriteLine($"{pe[6].edontes}");
                                Console.WriteLine($"{pe[6].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[6].epont;
                                if (mi == "2") tav = tav - pe[6].mpont;
                            }

                            //4. nap 2. verzió - vég - b
                            if (tav == 824)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[7].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[7].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 3. verzió - vég - b
                            if (tav == 903)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[8].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 4. verzió
                            if (tav == 795)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[9].szoveg}");
                                Console.WriteLine($"{pe[9].edontes}");
                                Console.WriteLine($"{pe[9].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[9].epont;
                                if (mi == "2") tav = tav - pe[9].mpont;
                            }

                            //4. nap 5. verzió
                            if (tav == 780)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[10].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[10].szoveg}");
                                Console.WriteLine($"{pe[10].edontes}");
                                Console.WriteLine($"{pe[10].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[10].epont;
                                if (mi == "2") tav = tav - pe[10].mpont;
                            }

                            //5. nap 1. verzió - vég - b
                            if (tav == 809)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[11].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[11].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 2. verzió
                            if (tav == 700)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[12].szoveg}");
                                Console.WriteLine($"{pe[12].edontes}");
                                Console.WriteLine($"{pe[12].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[12].epont;
                                if (mi == "2") tav = tav - pe[12].mpont;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 778)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[13].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[13].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 1. verzió - vég - b
                            if (tav == 699)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[14].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 2. verzió
                            if (tav == 650)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[15].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[15].szoveg}");
                                Console.WriteLine($"{pe[15].edontes}");
                                Console.WriteLine($"{pe[15].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[15].epont;
                                if (mi == "2") tav = tav - pe[15].mpont;
                            }

                            //7. nap 1. verzió - vég - b
                            if (tav == 649)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[16].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió
                            if (tav == 500)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[17].szoveg}");
                                Console.WriteLine($"{pe[17].edontes}");
                                Console.WriteLine($"{pe[17].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[17].epont;
                                if (mi == "2") tav = tav - pe[17].mpont;
                            }

                            //8. nap 1. verzió - vég - b
                            if (tav == 499)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[18].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 2. verzió
                            if (tav == 400)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[19].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[19].szoveg}");
                                Console.WriteLine($"{pe[19].edontes}");
                                Console.WriteLine($"{pe[19].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[19].epont;
                                if (mi == "2") tav = tav - pe[19].mpont;
                            }

                            //9. nap 1. verzió - vég - b
                            if (tav == 399)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[20].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 2. verzió
                            if (tav == 250)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[21].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[21].szoveg}");
                                Console.WriteLine($"{pe[21].edontes}");
                                Console.WriteLine($"{pe[21].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[21].epont;
                                if (mi == "2") tav = tav - pe[21].mpont;
                            }

                            //10. nap 1. verzió - vég - b
                            if (tav == 249)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[22].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //10. nap 2. verzió
                            if (tav == 100)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[23].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{pe[23].szoveg}");
                                Console.WriteLine($"{pe[23].edontes}");
                                Console.WriteLine($"{pe[23].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - pe[23].epont;
                                if (mi == "2") tav = tav - pe[23].mpont;
                            }

                            //11. nap 1. verzió - vég - b
                            if (tav == 99)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[24].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[24].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //11. nap 2. verzió - vég - ny
                            if (tav == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{pe[25].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{pe[25].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //Hegység
                        if (palya == 2)
                        {
                            tav = palyak[palya].tav;
                            //1. nap 1. verzió
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{ph[0].nap}. nap");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"A hátralévő távolság: {palyak[1].tav} km");
                            Console.WriteLine($"{ph[0].szoveg}");
                            Console.WriteLine($"{ph[0].edontes}");
                            Console.WriteLine($"{ph[0].mdontes}");
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");
                            if (mi == "1") tav = tav - ph[0].epont;
                            if (mi == "2") tav = tav - ph[0].mpont;

                            //2. nap 1. verzió
                            if (tav == 760)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[1].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[1].szoveg}");
                                Console.WriteLine($"{ph[1].edontes}");
                                Console.WriteLine($"{ph[1].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[1].epont;
                                if (mi == "2") tav = tav - ph[1].mpont;
                            }

                            //2. nap 2. verzió
                            if (tav == 780)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[2].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[2].szoveg}");
                                Console.WriteLine($"{ph[2].edontes}");
                                Console.WriteLine($"{ph[2].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[2].epont;
                                if (mi == "2") tav = tav - ph[2].mpont;
                            }

                            //3. nap 1. verzió
                            if (tav == 655)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[3].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[3].szoveg}");
                                Console.WriteLine($"{ph[3].edontes}");
                                Console.WriteLine($"{ph[3].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[3].epont;
                                if (mi == "2") tav = tav - ph[3].mpont;
                            }

                            //3. nap 2. verzió
                            if (tav == 705)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[4].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[4].szoveg}");
                                Console.WriteLine($"{ph[4].edontes}");
                                Console.WriteLine($"{ph[4].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[4].epont;
                                if (mi == "2") tav = tav - ph[4].mpont;
                            }

                            //3. nap 3. verzió
                            if (tav == 685)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[5].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[5].szoveg}");
                                Console.WriteLine($"{ph[5].edontes}");
                                Console.WriteLine($"{ph[5].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[5].epont;
                                if (mi == "2") tav = tav - ph[5].mpont;
                            }

                            //3. nap 4. verzió
                            if (tav == 715)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[6].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[6].szoveg}");
                                Console.WriteLine($"{ph[6].edontes}");
                                Console.WriteLine($"{ph[6].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[6].epont;
                                if (mi == "2") tav = tav - ph[6].mpont;
                            }

                            //4. nap 1. verzió
                            if (tav == 560)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[7].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[7].szoveg}");
                                Console.WriteLine($"{ph[7].edontes}");
                                Console.WriteLine($"{ph[7].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[7].epont;
                                if (mi == "2") tav = tav - ph[7].mpont;
                            }

                            //4. nap 2. verzió - vég - b
                            if (tav == 654)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[8].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 3. verzió
                            if (tav == 605)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[9].szoveg}");
                                Console.WriteLine($"{ph[9].edontes}");
                                Console.WriteLine($"{ph[9].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[9].epont;
                                if (mi == "2") tav = tav - ph[9].mpont;
                            }

                            //4. nap 4. verzió - vég - b
                            if (tav == 704)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[10].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[10].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 1. verzió
                            if (tav == 440)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[11].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[11].szoveg}");
                                Console.WriteLine($"{ph[11].edontes}");
                                Console.WriteLine($"{ph[11].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[11].epont;
                                if (mi == "2") tav = tav - ph[11].mpont;
                            }

                            //5. nap 2. verzió - vég - b
                            if (tav == 559)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[12].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 604)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[13].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[13].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 4. verzió
                            if (tav == 490)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[14].szoveg}");
                                Console.WriteLine($"{ph[14].edontes}");
                                Console.WriteLine($"{ph[14].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[14].epont;
                                if (mi == "2") tav = tav - ph[14].mpont;
                            }

                            //6. nap 1. verzió - vég - b
                            if (tav == 439)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[15].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[15].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 2. verzió
                            if (tav == 320)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[16].szoveg}");
                                Console.WriteLine($"{ph[16].edontes}");
                                Console.WriteLine($"{ph[16].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[16].epont;
                                if (mi == "2") tav = tav - ph[16].mpont;
                            }

                            //6. nap 3. verzió
                            if (tav == 395)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[17].szoveg}");
                                Console.WriteLine($"{ph[17].edontes}");
                                Console.WriteLine($"{ph[17].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[17].epont;
                                if (mi == "2") tav = tav - ph[17].mpont;
                            }

                            //6. nap 4. verzió - vég - b
                            if (tav == 489)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[18].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 1. verzió - vég - b
                            if (tav == 319)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[19].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[19].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió
                            if (tav == 225)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[20].szoveg}");
                                Console.WriteLine($"{ph[20].edontes}");
                                Console.WriteLine($"{ph[20].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[20].epont;
                                if (mi == "2") tav = tav - ph[20].mpont;
                            }

                            //7. nap 3. verzió
                            if (tav == 300)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[21].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[21].szoveg}");
                                Console.WriteLine($"{ph[21].edontes}");
                                Console.WriteLine($"{ph[21].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[21].epont;
                                if (mi == "2") tav = tav - ph[21].mpont;
                            }

                            //7. nap 4. verzió - vég - b
                            if (tav == 319)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[22].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 1. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[23].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[23].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 2. verzió
                            if (tav == 75)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[24].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[24].szoveg}");
                                Console.WriteLine($"{ph[24].edontes}");
                                Console.WriteLine($"{ph[24].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[24].epont;
                                if (mi == "2") tav = tav - ph[24].mpont;
                            }

                            //8. nap 3. verzió
                            if (tav == 300)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[25].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{ph[25].szoveg}");
                                Console.WriteLine($"{ph[25].edontes}");
                                Console.WriteLine($"{ph[25].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - ph[25].epont;
                                if (mi == "2") tav = tav - ph[25].mpont;
                            }

                            //8. nap 4. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[26].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[26].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 1. verzió - vég - ny
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[27].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[27].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 2. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[28].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[28].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 3. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ph[29].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ph[29].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
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
                                Console.WriteLine($"{ss[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[8].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 3. verzió - vég - b
                            if (tav == 504)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[9].szoveg}");
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
                                Console.WriteLine($"{ss[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[12].szoveg}");
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
                                Console.WriteLine($"{ss[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[14].szoveg}");
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
                                Console.WriteLine($"{ss[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[16].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 429)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[17].szoveg}");
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
                                Console.WriteLine($"{ss[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[20].szoveg}");
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
                                Console.WriteLine($"{ss[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[22].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 1. verzió - vég - ny
                            if (tav == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[23].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[23].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió - vég - b
                            if (tav == 74)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ss[24].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{ss[24].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //Erdő
                        if (palya == 1)
                        {
                            tav = palyak[palya].tav;
                            //1. nap 1. verzió
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{se[0].nap}. nap");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"A hátralévő távolság: {palyak[1].tav} km");
                            Console.WriteLine($"{se[0].szoveg}");
                            Console.WriteLine($"{se[0].edontes}");
                            Console.WriteLine($"{se[0].mdontes}");
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");
                            if (mi == "1") tav = tav - se[0].epont;
                            if (mi == "2") tav = tav - se[0].mpont;

                            //2. nap 1. verzió
                            if (tav == 950)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[1].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[1].szoveg}");
                                Console.WriteLine($"{se[1].edontes}");
                                Console.WriteLine($"{se[1].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[1].epont;
                                if (mi == "2") tav = tav - se[1].mpont;
                            }

                            //2. nap 2. verzió
                            if (tav == 945)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[2].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[2].szoveg}");
                                Console.WriteLine($"{se[2].edontes}");
                                Console.WriteLine($"{se[2].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[2].epont;
                                if (mi == "2") tav = tav - se[2].mpont;
                            }

                            //3. nap 1. verzió
                            if (tav == 800)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[3].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[3].szoveg}");
                                Console.WriteLine($"{se[3].edontes}");
                                Console.WriteLine($"{se[3].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[3].epont;
                                if (mi == "2") tav = tav - se[3].mpont;
                            }

                            //3. nap 2. verzió
                            if (tav == 900)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[4].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[4].szoveg}");
                                Console.WriteLine($"{se[4].edontes}");
                                Console.WriteLine($"{se[4].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[4].epont;
                                if (mi == "2") tav = tav - se[4].mpont;
                            }

                            //4. nap 1. verzió - vég - b
                            if (tav == 799)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[5].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[5].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 2. verzió
                            if (tav == 740)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[6].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[6].szoveg}");
                                Console.WriteLine($"{se[6].edontes}");
                                Console.WriteLine($"{se[6].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[6].epont;
                                if (mi == "2") tav = tav - se[6].mpont;
                            }

                            //4. nap 3. verzió - vég - b
                            if (tav == 898)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[7].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[7].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 4. verzió
                            if (tav == 835)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[8].szoveg}");
                                Console.WriteLine($"{se[8].edontes}");
                                Console.WriteLine($"{se[8].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[8].epont;
                                if (mi == "2") tav = tav - se[8].mpont;
                            }

                            //5. nap 1. verzió - vég - b
                            if (tav == 739)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[9].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 2. verzió
                            if (tav == 690)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[10].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[10].szoveg}");
                                Console.WriteLine($"{se[10].edontes}");
                                Console.WriteLine($"{se[10].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[10].epont;
                                if (mi == "2") tav = tav - se[10].mpont;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 833)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[11].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[11].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 4. verzió
                            if (tav == 735)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[12].szoveg}");
                                Console.WriteLine($"{se[12].edontes}");
                                Console.WriteLine($"{se[12].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[12].epont;
                                if (mi == "2") tav = tav - se[12].mpont;
                            }

                            //6. nap 1. verzió - vég - b
                            if (tav == 689)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[13].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[13].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 2. verzió
                            if (tav == 590)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[14].szoveg}");
                                Console.WriteLine($"{se[14].edontes}");
                                Console.WriteLine($"{se[14].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[14].epont;
                                if (mi == "2") tav = tav - se[14].mpont;
                            }

                            //6. nap 3. verzió - vég - b
                            if (tav == 733)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[15].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[15].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 4. verzió
                            if (tav == 585)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[16].szoveg}");
                                Console.WriteLine($"{se[16].edontes}");
                                Console.WriteLine($"{se[16].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[16].epont;
                                if (mi == "2") tav = tav - se[16].mpont;
                            }

                            //7. nap 1. verzió - vég - b
                            if (tav == 589)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[17].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió
                            if (tav == 500)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[18].szoveg}");
                                Console.WriteLine($"{se[18].edontes}");
                                Console.WriteLine($"{se[18].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[18].epont;
                                if (mi == "2") tav = tav - se[18].mpont;
                            }

                            //7. nap 3. verzió - vég - b
                            if (tav == 583)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[19].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[19].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 4. verzió
                            if (tav == 455)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[20].szoveg}");
                                Console.WriteLine($"{se[20].edontes}");
                                Console.WriteLine($"{se[20].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[20].epont;
                                if (mi == "2") tav = tav - se[20].mpont;
                            }

                            //8. nap 1. verzió - vég - b
                            if (tav == 499)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[21].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[21].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 2. verzió
                            if (tav == 380)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[22].szoveg}");
                                Console.WriteLine($"{se[22].edontes}");
                                Console.WriteLine($"{se[22].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[22].epont;
                                if (mi == "2") tav = tav - se[22].mpont;
                            }

                            //8. nap 3. verzió - vég - b
                            if (tav == 443)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[23].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[23].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 4. verzió
                            if (tav == 295)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[24].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[24].szoveg}");
                                Console.WriteLine($"{se[24].edontes}");
                                Console.WriteLine($"{se[24].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[24].epont;
                                if (mi == "2") tav = tav - se[24].mpont;
                            }

                            //9. nap 1. verzió - vég - b
                            if (tav == 379)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[25].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[25].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 2. verzió
                            if (tav == 280)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[26].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[26].szoveg}");
                                Console.WriteLine($"{se[26].edontes}");
                                Console.WriteLine($"{se[26].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[26].epont;
                                if (mi == "2") tav = tav - se[26].mpont;
                            }

                            //9. nap 3. verzió - vég - b
                            if (tav == 293)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[27].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[27].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 4. verzió
                            if (tav == 195)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[28].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[28].szoveg}");
                                Console.WriteLine($"{se[28].edontes}");
                                Console.WriteLine($"{se[28].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[28].epont;
                                if (mi == "2") tav = tav - se[28].mpont;
                            }

                            //10. nap 1. verzió - vég - b
                            if (tav == 279)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[29].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[29].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //10. nap 2. verzió
                            if (tav == 130)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[30].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[30].szoveg}");
                                Console.WriteLine($"{se[30].edontes}");
                                Console.WriteLine($"{se[30].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[30].epont;
                                if (mi == "2") tav = tav - se[30].mpont;
                            }

                            //10. nap 3. verzió - vég - b
                            if (tav == 193)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[31].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[31].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //10. nap 4. verzió
                            if (tav == 135)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[32].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{se[32].szoveg}");
                                Console.WriteLine($"{se[32].edontes}");
                                Console.WriteLine($"{se[32].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - se[32].epont;
                                if (mi == "2") tav = tav - se[32].mpont;
                            }

                            //11. nap 1. verzió - vég - b
                            if (tav == 129)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[33].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[33].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //11. nap 2. verzió - vég - ny
                            if (tav == 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[34].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[34].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //11. nap 3. verzió - vég - b
                            if (tav == 133)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{se[35].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{se[35].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //Hegység
                        if (palya == 2)
                        {
                            tav = palyak[palya].tav;
                            //1. nap 1. verzió
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{sh[0].nap}. nap");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"A hátralévő távolság: {palyak[1].tav} km");
                            Console.WriteLine($"{sh[0].szoveg}");
                            Console.WriteLine($"{sh[0].edontes}");
                            Console.WriteLine($"{sh[0].mdontes}");
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");
                            if (mi == "1") tav = tav - sh[0].epont;
                            if (mi == "2") tav = tav - sh[0].mpont;

                            //2. nap 1. verzió
                            if (tav == 760)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[1].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[1].szoveg}");
                                Console.WriteLine($"{sh[1].edontes}");
                                Console.WriteLine($"{sh[1].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[1].epont;
                                if (mi == "2") tav = tav - sh[1].mpont;
                            }

                            //2. nap 2. verzió
                            if (tav == 780)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[2].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[2].szoveg}");
                                Console.WriteLine($"{sh[2].edontes}");
                                Console.WriteLine($"{sh[2].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[2].epont;
                                if (mi == "2") tav = tav - sh[2].mpont;
                            }

                            //3. nap 1. verzió
                            if (tav == 655)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[3].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[3].szoveg}");
                                Console.WriteLine($"{sh[3].edontes}");
                                Console.WriteLine($"{sh[3].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[3].epont;
                                if (mi == "2") tav = tav - sh[3].mpont;
                            }

                            //3. nap 2. verzió
                            if (tav == 705)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[4].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[4].szoveg}");
                                Console.WriteLine($"{sh[4].edontes}");
                                Console.WriteLine($"{sh[4].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[4].epont;
                                if (mi == "2") tav = tav - sh[4].mpont;
                            }

                            //3. nap 3. verzió
                            if (tav == 685)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[5].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[5].szoveg}");
                                Console.WriteLine($"{sh[5].edontes}");
                                Console.WriteLine($"{sh[5].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[5].epont;
                                if (mi == "2") tav = tav - sh[5].mpont;
                            }

                            //3. nap 4. verzió
                            if (tav == 715)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[6].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[6].szoveg}");
                                Console.WriteLine($"{sh[6].edontes}");
                                Console.WriteLine($"{sh[6].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[6].epont;
                                if (mi == "2") tav = tav - sh[6].mpont;
                            }

                            //4. nap 1. verzió
                            if (tav == 560)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[7].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[7].szoveg}");
                                Console.WriteLine($"{sh[7].edontes}");
                                Console.WriteLine($"{sh[7].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[7].epont;
                                if (mi == "2") tav = tav - sh[7].mpont;
                            }

                            //4. nap 2. verzió - vég - b
                            if (tav == 654)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[8].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[8].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //4. nap 3. verzió
                            if (tav == 605)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[9].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[9].szoveg}");
                                Console.WriteLine($"{sh[9].edontes}");
                                Console.WriteLine($"{sh[9].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[9].epont;
                                if (mi == "2") tav = tav - sh[9].mpont;
                            }

                            //4. nap 4. verzió - vég - b
                            if (tav == 704)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[10].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[10].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 1. verzió
                            if (tav == 440)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[11].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[11].szoveg}");
                                Console.WriteLine($"{sh[11].edontes}");
                                Console.WriteLine($"{sh[11].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[11].epont;
                                if (mi == "2") tav = tav - sh[11].mpont;
                            }

                            //5. nap 2. verzió - vég - b
                            if (tav == 559)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[12].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[12].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 3. verzió - vég - b
                            if (tav == 604)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[13].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[13].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //5. nap 4. verzió
                            if (tav == 490)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[14].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[14].szoveg}");
                                Console.WriteLine($"{sh[14].edontes}");
                                Console.WriteLine($"{sh[14].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[14].epont;
                                if (mi == "2") tav = tav - sh[14].mpont;
                            }

                            //6. nap 1. verzió - vég - b
                            if (tav == 439)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[15].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[15].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //6. nap 2. verzió
                            if (tav == 320)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[16].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[16].szoveg}");
                                Console.WriteLine($"{sh[16].edontes}");
                                Console.WriteLine($"{sh[16].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[16].epont;
                                if (mi == "2") tav = tav - sh[16].mpont;
                            }

                            //6. nap 3. verzió
                            if (tav == 395)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[17].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[17].szoveg}");
                                Console.WriteLine($"{sh[17].edontes}");
                                Console.WriteLine($"{sh[17].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[17].epont;
                                if (mi == "2") tav = tav - sh[17].mpont;
                            }

                            //6. nap 4. verzió - vég - b
                            if (tav == 489)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[18].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[18].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 1. verzió - vég - b
                            if (tav == 319)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[19].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[19].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //7. nap 2. verzió
                            if (tav == 225)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[20].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[20].szoveg}");
                                Console.WriteLine($"{sh[20].edontes}");
                                Console.WriteLine($"{sh[20].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[20].epont;
                                if (mi == "2") tav = tav - sh[20].mpont;
                            }

                            //7. nap 3. verzió
                            if (tav == 300)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[21].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[21].szoveg}");
                                Console.WriteLine($"{sh[21].edontes}");
                                Console.WriteLine($"{sh[21].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[21].epont;
                                if (mi == "2") tav = tav - sh[21].mpont;
                            }

                            //7. nap 4. verzió - vég - b
                            if (tav == 319)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[22].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[22].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 1. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[23].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[23].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //8. nap 2. verzió
                            if (tav == 75)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[24].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[24].szoveg}");
                                Console.WriteLine($"{sh[24].edontes}");
                                Console.WriteLine($"{sh[24].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[24].epont;
                                if (mi == "2") tav = tav - sh[24].mpont;
                            }

                            //8. nap 3. verzió
                            if (tav == 300)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[25].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"A hátralévő távolság: {tav} km");
                                Console.WriteLine($"{sh[25].szoveg}");
                                Console.WriteLine($"{sh[25].edontes}");
                                Console.WriteLine($"{sh[25].mdontes}");
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                if (mi == "1") tav = tav - sh[25].epont;
                                if (mi == "2") tav = tav - sh[25].mpont;
                            }

                            //8. nap 4. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[26].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[26].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 1. verzió - vég - ny
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[27].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[27].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Megnyerted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 2. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[28].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[28].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            //9. nap 3. verzió - vég - b
                            if (tav == 224)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{sh[29].nap}. nap");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{sh[29].szoveg}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Elvesztetted a versenyt.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                //Rendőrség
                if (mi == "2")
                {
                    while(akarsz=="i")
                    {
                        volt = 0;
                        nyomok.Clear();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rendőr szimulátor");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A játék során több különböző bűntény után tudsz nyomozni, illetve elkövetőket elfogni. A döntéseid befolyásolják ezek sikerességét. Ha döntési lehetőség elé kerülsz, és nincsen egyéb instrukció, a döntésed sorszámával tudod azt végrehajtani.\nAmennyiben elfogadtad a játék szamályzatot, nyomd meg az ENTER-t.");
                        do
                        {
                            mi = Console.ReadLine();
                        } while (mi != "");
                        Console.Clear();
                        if (elsonap)
                        {
                            Console.WriteLine("Mint egy átlag hétfő reggelen ma is szolgálatba állsz.\nMegnyitod az estek listáját.");
                            elsonap = false;
                        }
                        else
                        {
                            Console.WriteLine("Megnyitod az estek listáját.");
                        }

                        foreach (var igen in esetek)
                        {
                            if (igen != "")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("-------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(igen);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("-------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        do
                        {
                            Console.Write("Add meg az általad vélasztott eset esetszámát! ");
                            mi = Console.ReadLine();
                        } while (mi != "1" && mi != "2" && mi != "3" && mi != "4");

                        //1. eset - Gyilkosság
                        if (mi == "1")
                        {
                            volt++;
                            Console.Clear();
                            Console.WriteLine(elsoeset[0].szoveg);
                            Console.WriteLine(elsoeset[1].szoveg);
                            Console.WriteLine(elsoeset[2].szoveg);
                            do
                            {
                                Console.Write("Választásod sorszáma: ");
                                mi = Console.ReadLine();
                            } while (mi != "1" && mi != "2");

                            //Vallomások
                            if (mi == "1")
                            {
                                Console.Clear();
                                Console.WriteLine($"A szülők vallomása:\n\t{elsoeset[3].szoveg}");
                                nyomok.Add("Kovács Ádám");
                                nyomok.Add("Vágóhíd");
                                Console.WriteLine(elsoeset[4].szoveg);
                                Console.WriteLine(elsoeset[5].szoveg);
                                Console.WriteLine(elsoeset[6].szoveg);
                                Console.WriteLine(elsoeset[7].szoveg);

                                do
                                {
                                    Console.Write("Választásod sorszáma: ");
                                    mi = Console.ReadLine();
                                } while (mi != "1" && mi != "2");
                                Console.Clear();

                                //Lakás
                                if (mi == "1")
                                {
                                    Console.WriteLine(elsoeset[8].szoveg);
                                    Console.WriteLine("\n"+elsoeset[9].szoveg);
                                    FileStream fselknyilv = new FileStream("elknyilv.txt", FileMode.Append);
                                    StreamWriter sw = new StreamWriter(fselknyilv);
                                    Console.WriteLine("Vedd fel az elkövető nevét a nyilvántartásba!");
                                    do
                                    {
                                        Console.Write("Elkövető neve: ");
                                        mi = Console.ReadLine();
                                    } while (mi == "");
                                    eseged.nev = mi;

                                    do
                                    {
                                        Console.Write("Bűncselekmény: ");
                                        mi = Console.ReadLine();
                                    } while (mi == "");
                                    eseged.tett = mi;

                                    do
                                    {
                                        Console.Write("Bűncselekmény elküvetésének dátuma [év/hónap/nap]: ");
                                        mi = Console.ReadLine();
                                    } while (!mi.Contains("/"));
                                    eseged.ido = mi;

                                    sw.WriteLine($"{eseged.nev};{eseged.tett};{eseged.ido}");

                                    sw.Close();
                                    fselknyilv.Close();
                                }

                                //Munkahely
                                if (mi == "2")
                                {

                                }
                            }

                            //Behatolás
                            if (mi == "2")
                            {

                            }








                            esetek[0] = "";
                        }

                        //2. eset - Állatkínzás
                        if (mi == "2")
                        {
                            volt++;
                            Console.Clear();

                            esetek[1] = "";
                        }

                        //3. eset - Gyilkosság
                        if (mi == "3")
                        {
                            volt++;
                            Console.Clear();

                            esetek[2] = "";
                        }

                        //4. eset - Emberrablás
                        if (mi == "4")
                        {
                            volt++;
                            Console.Clear();

                            esetek[3] = "";
                        }

                        Console.Clear();
                        if (volt != 4)
                        {
                            do
                            {
                                Console.Write("Akarsz további rendőrségi munkákat végezni? [i/n] ");
                                akarsz = Console.ReadLine();
                            } while (akarsz != "i" && akarsz != "n");
                        }
                        if (volt == 4) akarsz = "n";
                        
                    }
                    
                }



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
