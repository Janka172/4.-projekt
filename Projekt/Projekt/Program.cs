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
                    Console.WriteLine("A játék során a döntéseid befolyásolják a végkimenetelt. Megadott idő alatt kell teljesíteni a távot. Minden a játékban lezajló nap egy-egy döntési lehetőséget foglal magába. Ezek közül annak sorszámának beírásával lehet választani.");

                    //Pálya választó
                    Console.WriteLine("Melyik pályán akarsz indulni?\n\tSorszám: 1\n\tHelyszín: Sivatag\n\tHossz(nap): 7\n\tTávolság(km): 665\n\n\tSorszám: 2\n\tHelyszín: Erdő\n\tHossz(nap): 11\n\tTávolság(km): 1045\n\n\tSorszám: 3\n\tHelyszín: Hegység\n\tHossz(nap): 9\n\tTávolság(km): 855\n\t");
                    do
                    {
                        Console.Write("Add meg a választott pálya sorszámát! ");
                        mi = Console.ReadLine();
                    } while (mi != "1" && mi != "2" && mi != "3");
                    palya = int.Parse(mi) - 1;

                    //Ló választó
                    Console.WriteLine("Melyik lóval akarsz indulni?\n\tSorsazám: 1\n\tNév: Parázs\n\tKitartás: 10\n\tGyorsaság: 5\n\tTerepképesség: 7\n\tEngedelmesség: 8\n\t\n\tSorsazám: 2\n\tNév: Sodashi\n\tKitartás: 8\n\tGyorsaság: 10\n\tTerepképesség: 6\n\tEngedelmesség: 7\n\t\n\tSorsazám: 3\n\tNév: Szélvihar\n\tKitartás: 10\n\tGyorsaság: 9\n\tTerepképesség: 10\n\tEngedelmesség: 1\n\t");
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
                            napok = palyak[palya].hossz;
                            tav = palyak[palya].tav;

                        }

                        //Erdő
                        if (palya == 1)
                        {
                            napok = palyak[palya].hossz;
                            tav = palyak[palya].tav;

                        }

                        //Hegység
                        if (palya == 2)
                        {
                            napok = palyak[palya].hossz;
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
                            napok = palyak[palya].hossz;
                            tav = palyak[palya].tav;

                        }

                        //Erdő
                        if (palya == 1)
                        {
                            napok = palyak[palya].hossz;
                            tav = palyak[palya].tav;

                        }

                        //Hegység
                        if (palya == 2)
                        {
                            napok = palyak[palya].hossz;
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
                            napok = palyak[palya].hossz;
                            tav = palyak[palya].tav;

                        }

                        //Erdő
                        if (palya == 1)
                        {
                            napok = palyak[palya].hossz;
                            tav = palyak[palya].tav;

                        }

                        //Hegység
                        if (palya == 2)
                        {
                            napok = palyak[palya].hossz;
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
