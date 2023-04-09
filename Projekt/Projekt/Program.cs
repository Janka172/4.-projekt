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
        static bool szame(string szo)
        {
            bool valasz = true;
            for (int i = 0; i < szo.Length - 1; i++)
            {
                if (szo[i] < '0' || szo[i] > '9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }

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

        struct dino
        {
            public string faj, szoveg;
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
            sr4.Close();

            //Jurassic Park 4
            StreamReader sr5 = new StreamReader("jp1.txt");
            List<string> jphatter = new List<string>();
            string jphseged;
            while (!sr5.EndOfStream)
            {
                jphatter.Add(sr5.ReadLine());
            }
            sr5.Close();

            StreamReader sr6 = new StreamReader("jp2.txt");
            List<string> jpkar = new List<string>();
            string jpkseged;
            while (!sr6.EndOfStream)
            {
                jpkar.Add(sr6.ReadLine());
            }
            sr6.Close();

            StreamReader sr7 = new StreamReader("jp4.txt");
            List<ns> jptulaj = new List<ns>();
            ns jptseged;
            while (!sr7.EndOfStream)
            {
                string[] d = sr7.ReadLine().Split(';');
                jptseged.index = int.Parse(d[0]);
                jptseged.szoveg = d[1];
                jptulaj.Add(jptseged);
            }
            sr7.Close();

            StreamReader sr8 = new StreamReader("jp3.txt");
            List<dino> dinok = new List<dino>();
            dino dinoseged;
            while (!sr8.EndOfStream)
            {
                string[] d = sr8.ReadLine().Split(';');
                dinoseged.faj = d[0];
                dinoseged.szoveg = d[1];
                dinok.Add(dinoseged);
            }
            sr8.Close();

            StreamReader sr9 = new StreamReader("jp5.txt");
            List<ns> jpdolgozo = new List<ns>();
            ns jpdseged;
            while (!sr9.EndOfStream)
            {
                string[] d = sr9.ReadLine().Split(';');
                jpdseged.index = int.Parse(d[0]);
                jpdseged.szoveg = d[1];
                jpdolgozo.Add(jpdseged);
            }
            sr9.Close();

            //Képek
            string jplogo = "                  ,\n               ,  ;:._.-`''.\n             ;.;'.;`      _ `.\n              ',;`       ( \\ ,`-.  \n           `:.`,         (_/ ;\\  `-.\n            ';:              / `.   `-._\n          `;.;'              `-,/ .     `-.\n          ';;'              _    `^`       `.\n         ';;            ,'-' `--._          ;\n':      `;;        ,;     `.    ':`,,.__,,_ /\n `;`:;`;:`       ,;  '.    ;,      ';';':';;`\n              .,; '    '-._ `':.;    \n            .:; `          '._ `';;,\n          ;:` `    :'`'       ',__.)\n        `;:;:.,...;'`'\n      ';. '`'::'`''  .'`'\n    ,'   `';;:,..::;`'`'\n, .;`      `'::''`\n,`;`.\n";
            
            
            string indoraptor = "           ....:::::::::::::...                             \n       ..::......::^^^^::^:^:^::...                         \n    ..               :^^^^::^^^^^::::..      ...            \n  .                   ^^^^..^^^^:::::^^::.....:::.::...     \n                      .^^^.:^:^^:^^^.:^::::::::::::::::^.   \n                      .^^^  ..:^^^::..:^^^::::::^^^^:^^^^^. \n                    :::^^:   .^:. .....      ..::^^^::::^~^.\n                   ::   ^:   ::::::  ...        .....::::::.\n                   ^.             ^^. .:                ..  \n                  .:...            ::.  .                   \n                   .                :.  ..                  \n                                          ...               \n                                            ...             \n";
            
            string indominusrex = "                                                                                \n                                                                                \n                                                                    .... #(/    \n                                                             /***,(#(/,,/#%&*  \n                                                         ...*#%/#...,.*#%/%#(   \n                         ,**,**/**** .                .. ,,*(,*(*,/#(%/%%%      \n  @&&&#####((///*/*****/(/***/***/**,*,,,             ./,/**,,#&&&&&&//.        \n &&*   ,&&%#######%%%%%#((*,*(//*,**(,*/****.        /***,*/(&((##&&&           \n &%         /&&%%%%&&%%(#(////(/((//****/,,*,*/*. ,*,**,/**,/(#%((#(//*  ,/     \n *%              %%&%&%#((((/###(####(/(///**,/,/,/*,*//*/#*%###((((&&%# .      \n  &                   ##%(((((%%%#((##%#((///**,*(/((//(#///%(#%%%#(/((/#.(/    \n   *                   #%#####%%%%%%%%##(((#((((#%((/#&#(/((#%#        ,%#(&%%# \n                       &%%%%#%&&%&%%%%#/((#(###%#%%((&%##(###                   \n     ,                 (%%%#%%%###%%%/%%%%%#%%%#%###(%%                         \n                      /&%#%%&%   .%(#%&@&%&&&%##%%%#.                           \n                       %%%&&%  ,*//%%#&%%/%%%%##(.                              \n                       %&&&*  (%%#(%&%/       ,%&                               \n                      /%&&&   %%%% *#%#       *&%%,                             \n                      /#%/&   /%&/  ,##(   ., #%%#                              \n                      ##**    #&&*%*  (#/   #(%.                                \n                     (#*#%*  ./&&&&#%%#(#//((#((/,.                             \n                 ##%%##/@%%%%////////**(/##(((,.                                \n                .,,********///**,,...,,%/////(,..                               \n                                                                                \n";

            string indoraptor2 = "                         ..::........                       \n                     :~~!!!!!!7????777!~~~^^:...            \n                  .^!77~7???!~7!~^^::::^^^^~~~~~^^::::..... \n   ..:^~^^:...::^~!7?7!^~777~:.                             \n.~!!!!~!!!7777!!7777??!~:!7!^.                              \n.:::::.....:^^!7?777!^.. :77~:                              \n              .:~!^.      ::^~^^:                           \n                .!~            .~:                          \n              .:~:.             ~~                         \n           .::^:.            .^~^~:                     \n     ";

            string indominusrex2 = "  .^^^:.                                                    \n ^7??77!~~~^.                                               \n .:~~??J?!!!~^.                                    ...:.    \n    .::~7777!~~^:.                                    .~^   \n         :~!7!!~~:.       ..:^~~~^^^:..               !~   \n       ..^?7!!~^^:::...:^~~7?777777!!77!~~::.....  ..^!~.   \n    .^~~~!!!!~~~^^~!7??J?777?7!!~~!7?7!!!7~^^~~^^^^~^:.     \n :^~~^^^^^^^~~~~~~~~!!77!!!!!~~^^:~7!!!!777!:.::....        \n   .       .^^~~~^~!77!~~~~~~^:::~7!!!777??!:...           \n        ....   ..^^~!7?7!!~^^^^^^^^~^^!77777?:.             \n      :^^!^^::^~!^::^^^^!7!^^::.:::::.^~!!!77?7:           \n       : .:    .:^:. :^^^~^^::.         .:~~~~!!~^^:.       \n                  :^!!^:.   ^^:.          ....::::~!~       \n                 .:.:^    :~~^.                  :!7~.     \n                    ..::^~~^:                      ^7!!^.   \n                     ...:...                     :^~~^^^~.  \n                                                  ..   .   \n";

            string allo = "                                     7:           \n                 ..             ::::!J7??!!??:    \n          .:^^^^^~77^:         .^^:::::^!~~7YG!   \n       .^^:..   .^!7??J?~:.   ~^:::~~~^:~~~~7?5~  \n    ..:.        ^?777????J5?~^^~!77?7~~^^:::^~.   \n  ...          ^!!7?77??7!~~!~^~!~~~^::^^^.       \n              !~~!77777!~~~!!~:^^^^~~~~~~!!~:     \n             ~~^^^!~!!!~^^~!~^::::^^~~!777JJ?JY?7 \n             7^!~:!7~~^~~~~~^^:::::::::...:^^^~^: \n            .~^!~::~~^!!!~:^^::::::               \n             ^^^~^..:^!J?!^^:^^^7~7:              \n             .^:^^. .!^^~^^^::^~?^^7!^^~.         \n              ^:^?J J5!......:^^~~     ~.         \n              ::~P^ .5?      .~!!:                \n               .^J~  ~^      .~~?.                \n               .^!!          .~~?.                \n               .~!?           ^~7!                \n               :??7:          .^7J7.              \n            .^^!P~:!           .!?7J?~..          \n                                :^~^!7^..         \n";

            string apato = "   :!?J777!~:          :!7!^.                  .:.\n ~J?!~^^:^^^~~~~:.  .!YYYYJJ?~.              :. . \n.5~::.  .:^^^^^~~!!7JYJJ????!!!^           ::     \n77^:        .:^^^^^^^^^^~77~^^~~^       .^^.      \n .:            .:~~^^::::^^^^^^^~~^^^^~~^.        \n                 ^7~^:::.:::^^^:^^:...            \n                 .!~~^::...::::.:^                \n                  :~:..^::.::^.:::                \n                  .!^: :^: .:^ .:.                \n                   ~~:  ^^~^:. .::                \n                   :~: .^7?~  .:::                \n                   ^~^. .~~:                      \n";

            string atroci = "                                                  .....:.:. \n                   ........:.:...........       :^:~7!!777! \n             ...::.^:.:::.^~~~~^^~^^~~~^!^~^~^^^:^!!Y5^     \n         ... .               .^~!!~!!!!!~:!!~!!~!!~. :^^:   \n     ...                        .^~!!~!!^~!~7~~..           \n                                  .^!~~!^:.:!!:             \n                                 .?Y7^::    .7.             \n                                :!: .^      ..              \n                                :.   .^^                    \n                               ::.                          \n..                          \n";

            string bary = "  .      .                                                  \n:!7777?7!7~~~:.                                             \n  .^::^~77!~~~::                                            \n       :::7!!~^::             .....                        \n  .:~!!!~!~~~^^^^~^::~~~!!~~^~~~~^^~~^::.                   \n:~~^..       .:^^^~!!~^^~~!~!!~!~^^~!!!~^^::.               \n                .^^^^^:^!!7!!!777~~~7!^!?!~!!~^^^:..    .:  \n                   ^!!~^^^~~~~!~~~~~~~^~7~^~~~~~!!~~^^:..~?:\n              .^:..^:.^~~^!~~^^^^^^~^.:^~::::::::::::^^:::. \n              ..    .^:..::::.. .::.:::^~:                  \n                     .       ::.     .^^^!7~::              \n                             ^^:            .^:             \n                           .^^:              :^^            \n                          :::.             .:^.^            \n";

            string brachi = " !7~^.                                                      \n:^~~77!.                                                    \n    :~!!.                                                   \n     ^!^!                                                   \n     .7^7                                                   \n     .J^7.                                                  \n     .Y~7:                                                  \n     ^J~?:                                                  \n     ^J^7^                                                  \n     ~Y~!!                                                  \n     ~Y~~7                                                  \n     :5!^!^                                                 \n      Y7:^?.                                                \n      ^5~:!?                                                \n       Y?^^!?.                                              \n       .57^^!J~                                             \n        ~Y7^^~?7.                                           \n         ^J!^:^!!!:.                                        \n          :7!^::~~~!7??7!^.                                 \n           .7!!^:~~~~!7!777??~.                             \n            .777!~7?!7?!!^^!?YY?^.                          \n              ??!?YY~~7!~:^7?JJJJ777:                       \n               J77557~~7?^:!7777?~^JYJ~.                    \n               :J7J5J~^~7!:^~~~7!:.~!7J?~                   \n                .YJ5Y7^^!!:^~!!!^:::!!?!7?~:.. ....:..      \n                 ~~?5777Y!::^~~^::::~!??^~!77??7!~::....:.  \n                 .7^??JJP7:^^^^^^:::^!J7.......             \n                 !?^~Y77J:  ::^^....~~!J                    \n                 ?!:JY^!~   :^!:    :~^!.                   \n                 !~:Y7~7   .:^^      ~~?.                   \n                 :!7?!7!   ::::     .~7?:                   \n                  .7!!7~                                    \n";

            string carno = "                 ..                                         \n                .^^^~^:                                     \n               ^~~!7?!^                                     \n             .!~~:::::.                                     \n             !~~~.:^:...                                    \n             ~~~!^~^^^^^^:.                                 \n             7!::!!^~^:!^^::.                               \n             7?~^:^^:::~~::::^^^:...                        \n            .^^^^::^:.:~^.::::^^^~~~~~^^^..                 \n             .:.:.....:^         .      ...::.              \n               :::   !^:                      .:            \n             .:^.   .!.                         ..          \n            .^^.    ::.                                     \n            ::.     ~~.                                     \n                   .:^:.                                    \n                                                            \n";

            string cera = " .?..:!!7:.                                                 \n^7777?J~!^J~::.:.^~^::..                                    \n.^^~7?7::77!?~7G5G5!7PP?!Y5!^^:...                          \n        .:^?JYJ7PJ!~Y5!Y5PJ!?PJ7?5?J5J5J??7?!7!~!^^^^:...   \n            .?Y?7?J~7J75J7?JJ~.^77~!~~!~^^^^:::.....        \n              5J  ..^~~??~!^                                \n            .!:        :!?7:                                \n            :            :~^                                \n                          .J7                               \n                          ^J.                               \n                       :^^~.                                \n";

            string compy = "      ....                                                  \n       ......                                               \n           ..                                               \n           :.                                               \n           :.                                               \n           ... ......                                       \n             .::......:::..           .......               \n              ...::...................                      \n             . .  ..  ...                                   \n                   .  ...                                   \n                    .   ..                                  \n                   ..     .                                 \n                  .       ..                                \n                 .        .                                 \n                         .                                  \n                                                            \n";

            string dakota = "                                                            \n                                             .              \n                                            .:^:::::::.     \n                                             ::^^^^^^~^.    \n                               ..::::::::. .^:::^^^:        \n                    ...::^:^^^^^^!J7^~^^^^^^:.......::      \n            .:::::.....:::::::.:^~!^:::::^:::::.            \n        .^^~~~^.              .^^^.....^^:....              \n     .:^....                  .::.   ..::...::....          \n                              ..    ..  .::^^::.::..:       \n                             .:     :.    ..:::. ..         \n                             :!     .:.                     \n                             :^:      ....                  \n";

            string deino = "                                               ^^::         \n                                              :7~^~!^.      \n                                            .::...:^^~:     \n                                          .^^^::^^:^:^~^.   \n                                        .~~~7JY55Y55YJY55Y~ \n                                      .^!^~~77JY5J???!!~~^. \n             ........::^^~!!~^^^::^~~~!!~!J7~^~^~!!~~~~~~:  \n        :^~!!!~~^^^^~!~!?!7~~~!~!!77~~^~^7.                 \n    :^~~~~~^:^^~^^^^J?~7YJ~:~!~^^!77^^:^!                   \n  :^:.           .7.?5^?J7..::^!J?~^...^.                   \n                 ^?GPJ^!!: ..7PJ^.  .:.                     \n                .: ?B?^!^  :!7?7~:  :^                      \n                :.  ^~^:  :~^:. .:^ ..                      \n                ^         !.    ..:                         \n                          ::.                               \n                           ^^:....                          \n                             ..                             \n";

            string diplo = "                                                    :^:.    \n                                                  :!!77!!~: \n                                                 ^~~~^:..   \n                                                :!~:.       \n                                               .!~:!.       \n                                               !!^!:        \n                                              ~!!!~         \n                                             ^77!!          \n                                            ^777~.          \n                                          .~!77~.           \n                                         :!77!^.            \n                                       :!77!^:              \n                                    .^!!!7~.                \n                             .::..:~!777!:                  \n                          .^~!777!!!!!~:.                   \n                        :7?777!?7~:^^:.                     \n                       .???7???JJ??~...                     \n                    .:7???77?7?JY5J~:^:                     \n                .:^~~^.~?JJ7~^::^^^:^^                      \n         ........      .!~^^7~     ^7:                      \n                        !: .7.  . .7!.                      \n                        ^^  !:  !: 7~                       \n                        ~!..7~ .!^.7^                       \n                           .~:.   .::                       \n";

            string dimo = "       :.                                                   \n      .~~^:                                                 \n       .~777^.                                              \n         ~77!!^                                             \n          :!!??7:                                           \n           :!7?J?~                                          \n            .!!!7?7.                                        \n             .7777?7                                        \n              .?777?!                                       \n          .!!!!!!!77?^    :^^::::::::::::::::::....         \n        .~???77!!!!777:  .~^^~~~~^:..          ........     \n        ^~!!7777!~!~!!!~~~^^~~^.                            \n       .!!~^^~!77!~~!!!~~~^~~~^^^^^^:::::::...:^~~~:        \n              ..:^~~~~~^^~^^~~^^.         ....:....         \n                  .::..  ...^^::^^:                         \n                                                            \n";

            string dilo = "                         :~:.                               \n                        .~~!~~:.                            \n          .     ..     .77???77!~:                          \n         .^~^^^~!!~    ~JJJJJJJ?7!^.                        \n        .^!~~~~~~~~.  .!7?JJJJJ???7~.                       \n        :~7!^!?JJ7!~..^~!777??J??J?!^                       \n       .^!?7~^~!!!7?!^^~!77?????7??!^                       \n       :~!7??!~:^::~7!^^~!7????7777~:                       \n      .^~!!7777~~~!!7~~^~!???????7!~^        ...:::....     \n      .~!77777!!!7!~^^!!!7???????!~~.    .^~^::...          \n       ^~!!!!7!!7^.::^!77????7!7!~^:  .^!~:.                \n       .^~!!!77!!~~^^^^!7???77!^:.  :!7~.                   \n        .^~!777!77~~7~:^^~!7!~~: .^77^                      \n         .:^!7!77!~~:^::^~^~!777777^                        \n           ..::^^^^^:^^^~?7!!!7!7!.                         \n               .:.~::^^^~!~~~~!!~!                          \n               .~~!~^:^^^^~~~^~!~!~                         \n               :~^^~~.   .::.  .^~7.                        \n                 :~!^           .^~!.                       \n                 .~!:            .^~.                       \n                  ~:               ^^                       \n                 :~                .^:                      \n                :~:                 .~:                     \n             .:^^~.                 :~~~:.                  \n            ......                  ......                  \n";

            string galli = "                   .:^:.                                    \n                  :?7!~^.                                   \n                  Y?  :                                     \n                 :P^                                        \n                 .Y7                                        \n                  !Y7~!77~~::..                             \n                  .!??JY?5PYJYY??7?77!!~^:                  \n                .. :7!!7??YJ7?J?JJ???~~~^~^                 \n              .~::::..^!!7??!!7?J?^:.    .^                 \n               .    ^7: .~!!^.~7?~       :.                 \n                   .^:    .:~:.~7J?^.   :.                  \n                           .~7^ ..:^!!^.                    \n                        ^~~^:.       ^?.                    \n                        .~.           ~!                    \n                                      ^?!                   \n                                      ^~^                   \n";

            string giga = "        .^!~:.                                              \n      .^!!~~!!7?:                                           \n     :7????????J!                                           \n     !7~~^^~~~~~:                                           \n     !7!!^^:~^ .:                                           \n     ~!77!~??!^!7~.                                         \n     ^^^~?777~!77!~:                                        \n    ^!~^:~7777!7777!^.                                      \n   .777!!!!!7??7777!!!^                                     \n:~::!!7!!!~~!?7!7!~!777~.                                   \n..:~^::!!7!!7?77!^~77?7J?^                                  \n    .  .^~~~~~~~^^^77J?JJ7~.                                \n         !^^^^:.:^~!!7?YJ~!7:                               \n        ^~^::~~^^^~!777J?^^~7!:.             ......         \n       .7!^::.:^^^:~!7!77~^:^!77!~~!~~~!7!77??!!7?!!~^~^.   \n       .7~^^:    ...:~!!!7~^^^^!!!7J?!!7?7~^^^........:::^^.\n        ^~^^.         ^!!!~.:^^^^^^^^::...                  \n         ~^^            ^!!!.                               \n        ^!~:             ~77^                               \n      :!!~^:             .!7!.                              \n  .:^~!77:               :!77~.                             \n  :^^::^:              :!~~7!:~:                            \n";

            string mosa = "                                                                                ....::...           \n                                                                   ..:::^^^^~~~~~^~~~~!!!!!!!!~^^^. \n                                                            ...:^~~~!!!!777777?7777777???7777!!!7~: \n                                                      .::^^~~~!!!7777777????7?JJ?7!~~::::...        \n         .^^^^^::::                               .:^~~!!!!!!77!77?JYJJJJYYY?7?YYY?~.               \n       :^!777777!~~^                          .:^^~~~~!!!!!777777?J555YY555YYY??555Y?!^.            \n  .:^~!777!~^:...~!~                     ..:^~~~~~!!!!!!!!!77????7?YJJYYYYYYYY!~!?JJJJJJ?7~^:..     \n .^^:::.       .~!!.                ..:^^~~~!~~~!!!!!??7?J?JJJYJJ!7???YJ??7!~^:..   ...:^~~!!7?~    \n               ~!~:. .    ....::::^^~~~~~~!!!!!!!7???JYYYYYYYYY5J7777??!~^                    ..    \n               ^~!~~~~~~~!!!~~~~~~~~~~~~!~!!7JJJJYYYYYYYYYYYYYJ?77!~::::::.                         \n                .:^~~!!!!!!!!!!~~~!!!!!!77??JJYYYYYYYJJYJJ?7!~!!~^:  ::::.                          \n                    ..::^~~!!!!~^~!?777?JJJJJJJJJJ???7!~^:.  ^~:.    ::.                            \n                               :~7~^~~~~!!77!!~^^::..       ..                                      \n                              ^7!:       .::                                                        \n                            .~7^         .::                                                        \n                           .^^.                                                                     \n";

            string para = "   :^~!!!!~~~:.                                                       \n  ^!~^^~!?77??J?~:                                                    \n         .!777!??J7:                                                  \n         :!7JJ7777??!.                                                \n         77JJJ7777777~                                                \n         ??777777~~!~^^:.                                             \n         !J?7!!7J?JJJJYYJ?!:.                                         \n         :J?!~~!!?JJ?JJJJYYJJ??!~:                                    \n          !?7!~~!!777??77??J???JJJ?!:                                 \n          :J?7!~~~!7??7???JJ?!!7???JJ7:                               \n          ^YJ?7!!!!!!77!!7777~~!7???JJJ~                              \n          .7J?77!!77!7?!^~~~^~!!!7??JJ?Y?:                            \n            7?777!~~!777!^^:^!!!!77???!7JJ!:                          \n          .:~!77!~!!77!!~^^:~!!!!!!!7!~!!7??~                         \n          !7~~7~::^^^~~~^^^^!!!!~!!~~^^~~~!7??:                       \n         .77~ .         !!~!!~~!!^^^^^~~~~~~!?J7:                     \n          ..            ~!~?!!!!.     .:^~~~~~!??7^.                  \n                        .~!?!7!!^.       .:^~~~~!77?7!~^::::::::::.   \n                          .7!!!~!!:          .:^^~~!!!777777!~~^:.    \n                          ^?!~.:^~!!.            .....:.....          \n                         .?7!^   !!~.                                 \n                        .7!~.   .7!^                                  \n                      .^!!7^  .:~~!:                                  \n                     .::::^.  .....                                   \n";

            string pthera = "                                   .^^::.                             \n                                    :~~~!~^..                         \n                                   .~~~!!!!!~!!~~~^^^^^^^^::::.:....  \n                                   ^^~!~!!!!!77??7777!!~!!~^^^::...   \n.                                 ^!!^~!!!7?7777??77!~~^::.           \n^.                               ^7??^.^^^^^^::...                    \n:~^^.         ...           ...:~7JJ^                                 \n ^~~^           :^^:      .^!!!7?JY7                                  \n :~~~~^^^^.       :~~~^~^^~!777!7?7!.                                 \n  ^~77~~~~~^        :~!!~^!!7!!7??7!^                                 \n  :~!7!!~~~~~:.       ^~^~77!!????!!^                                 \n   .^~!!~~~~!!!!~^:. .^~^~!!~!77!~~!!~^:.                             \n     .^!!~~77!777J?!~~~~~^^^~~~~^^^^^~~~~~^^^^.                       \n       :!7!77!!!!???7!!!!!~~~~~~~~~~~!!!!!!~~~^                       \n        .^!777!!7777777777777777!~^~!~~~~!!~~~:                       \n          .^!!!!7777?777777777777!^~7^^~!!!~~~.                       \n            .:^~!!!777??777777!77~^7~   :^~~~~                        \n               .:^~!!!!77?7777!!!^!!       .:^:::                     \n                  .:^~!!!!77777!^~!.          ..:                     \n                      .:~~~!!!!~~!:                                   \n                         .^~!!!~~~                                    \n                            .^~~^^::.                                 \n                               .:....                                 \n";

            string plesio = "         :^^~!^^:                                                 .~7?J??7777!^                                         \n     ~????77!!!!7!7!:                            ~:         \n   .!???Y?7!!~?YYJ?77:            .:           .~!.         \n   !JJ?JY?77^ .!YYYJ!!.            ^~.       .~77.          \n  ~??JJJYJ7!.   !YYYJ7~             ~7?7777777?!.           \n ^?!!J7JYY57.   .JYJJ?!          ^7Y55PP55YYJ!:       ....  \n^J!^~~!?J5Y?7^   75YJJ!.      :7YP55Y555YYJ?7~:^^~~^^^::..  \n^7!~~^7YYYJ?!.   7P5JJ7.    :JPP555P5555JJ7!^.....          \n^~^!7?Y55YYY7    !55JJ7~..:!Y5555YYYYYY?7~^:                \n ^~!77JJYYY5~    :JYYY7?J555YYYJJYJ??77~:..                 \n  .^!?77?J?J^     ^JYY?7!?JJ?77!!!~~^^^.                    \n    :!7?777J^      .^!!!~~~~~^:.....:::.                    \n     :~!?7~~            .::.         ::^:.                  \n      .^~~^.           ^~:.          .^^~~:                 \n                      ~^.             .:~77^.               \n                      .                 .^7?!:              \n                                           :^^.             \n";


            string sino = "    .^^: ^^::!J~.^~  ::                                     \n   :~!??~~!7~~~!!~!^77:                                     \n  :7!~~^~~~~~~~!!!!777!                                     \n  ^~~~~~~~~~!7!!~~77777!:  .                                \n  :~~~~^^~~~!!!7~ .^!7??77!.                                \n  .~~~^. :~~!7??J7^:7?JJ??:.                                \n  .~~~~  ~!~!7?YJY555JJJ?J?J!~^:                            \n.^^~^~!!!JY7~!??5PP5Y?J?JY?JYYY5J7!:                        \n..:^~~!7!7??!~7?J5P5YJJ5Y5JJYYYYY5YY?~.                     \n  .:^~!7??JJ!!!7?????7J55J?JYJJJJY5YYYJ!.                   \n   .^~7777??7!777777!7??7!?JJJJJJYY5JJJJ?:                  \n    :~!!!~777~7J7!!~???7!!7???JYYYYYJJJ?JJ^                 \n     ~^^:^^~~^^?5?~75YJJJ?77???JYJ?J??JJ?JY7:               \n         :~77!^75J7J5PJ7!~!7????J?77?7?J????J?~:            \n       .~~!JY!^^!!?YYP7!~^~7????J!!77^!?J??777?J?~:.     .:^\n       .::~~7?~^~!7PGP?!^:^~!7??J7?7^^^~!!!7!!!77???77777!~.\n         :~^^7J~^!7J5J7~^^^:^~!7?!~^::^^!!7777???77777!^:   \n         ~!!~~7~~?YJ!~~~~~^~~^~7?~ .  :^^~~!:.:^^^^:..      \n         ~!~~~^..~7!~~~^::^^~~!77~     :^^~!.               \n        ~!^:^^:     ..:.   ^~~7???.     ^~!7.               \n       ~!^^^:.            :~^^!?JJ7     ^~7?~               \n      ^7!~^^            .^~~^~7???J:    ^~77?~.             \n     .~^^^:^.           .:..^~?!?7?:    .^^:~^^             \n";

            string spino = "                                :7JJYJJ!^                   \n                              :!?YYYYYYYYJ~                 \n                            .~JYJ?JJYYY5YYY7    .~7!^.      \n                       ..:^!?JJJJJYY55PGPGGGY?77JYYJJJ!~:   \n           ..::^~~!77??????????JJYYYJYYY5YYYYYYJ7!~^!??7?7~:\n...::^^^~~!77????77777!~^^~^~7777?YJ^~!!!!!77!^...   .::^~^.\n ........     .............::^~!!7JJ..:..^?!..              \n                              .^!!!~      :!~               \n                             :~!~~.         !^              \n                            ^!~.            ..:             \n                             ^J~                            \n                              ~7!^.                         \n";

            string such = "                                                     ....             \n                                                 ^~7JJJ??~^^::...     \n                               :^~~~!!!!!!~^^::~??777!^~77!~!7!7?7!:  \n                          .:^~!!!!!!!!7?7?7777!!~^~^^^^:~!!!:  .....  \n                      .:~!!7!!~!!!777!~!?7!^^~^^^^:       .^~~~::.    \n  ..             .:~!77!!!~~^:^!~^~~!!^:~!!::^~.              :~!^    \n   .^^::....:^!?7??7!~~^::^:^:^!~^:~7!~:!?7!~?^                       \n     .:^:^~^~^~^::.. .        .^!!^:^~^^77: :7.                       \n                               :7?^^.   .~~^:^^^.                     \n                               :!7^:      :::..                       \n                              :~?!                                    \n                            .!?^7J7.                                  \n                            :!7  !!!:                                 \n                             ^^::. .:                                 \n";

            string teri = "                   ^~^^:^^:.                                          \n                  .7?77!!7!~^^:.                                      \n                    .::^~^!7!!^^^                                     \n                      ..^!7?7~^^~^                                    \n                       ~?7~:^^~~!!^                                   \n                       !~.   .~!~!!~~~~^::                            \n                               ~?!!7!77!~!7~.                         \n                              :?YJ7!!77~^^!77^.                       \n                             .7?~!77!!^:^^^!777^:.                    \n                           :~7!~~!!!!~^^^!~~~7?!77~.                  \n                 ..:^:::^^!!~:^?!~7!^^^^:~7~:^!7^~!!~:             .. \n               .:~!!7~~~~~:.  ?Y~:^^^^~^^^^^~~7~ ..:^~~^:.    ..::^^. \n              .:::^^.  .      7?^^^^. .:^^^:!~~~.    .::^^^^^^~~:.    \n             ::. .:            ~^^~7~ ..  ~.!!^^.                     \n             .   ^.               ^^:    .: :7^.                      \n                 .              .~~^.       :?^                       \n                               .7~:~.       .?!.                      \n                               ^~^.:         ~7!:                     \n                                 .           .~!^~^:.                 \n                                              :^.~~^:                 \n";

            string trike = "      .^. ^Y!::^7.                                                    \n   .^.7J!!J7!!!!7!:..                                                 \n   ~5JYJ???!??!!!7!!!..      .:^.                                     \n .JY5YYJJJ??~77!!!!!!?J?JJJJ?7~.                                      \n^JPP55P5YJJY!^!!!!!7Y5YJ7~^:.                                         \n^55555PP5Y557^~!!7?J7^~7:                                             \n755YYJJJ??J5J7?77!~~!!JJ~                                             \n75YYYY?JJJY5JJ5PGPYY7!7?7:::~~^:                                      \n^Y5P5YJ??555Y5PPPYYJ~!77?55YP555YJ?!^.                                \n .!7~:. ^5Y77YPP5Y55?!!7??YYJJPP5YYJJ?7~:                             \n        ~Y?!JPPJ75Y?!~~!777???7?PJ7?????7!^:.                         \n       .??JJJYY!~~!7~~!!7?7!!7!~~777?77777777~^.                      \n        JY7!!???Y?~~^^~~!?J?7!!!:^~~!!!!77!~!7??!~:.                  \n       .PYJ?77!!!!~^^^^^~!7??77~^^~~~~~!7?7!!77?????7!^.              \n       ^P5?7!7!!!!^^~~^:^^^~77?!^^^~!~~!77!~!7!77!!777???7~:.         \n       !PJ7~~!77!!~~!~~^:^^~!7?7~^^~~~~!!~~~~~^^^^^^^^^~!7?JYJ7~:     \n      .YY7~~!7777!!~~~^^~!!!77!~^^^^~!!!7~:..             ..:^!7??!^. \n      !Y7!~!!~!!!!!~^^^!7777!~^^^^^^^!7777:                      .:~~:\n      :J7~~^    .:^~~?J?7!!!!~~:.. .^^~!!7?7.                         \n      .?7~~:       :5YY?!~~7~^:      ..:^^!7^                         \n       J7~~:        ::7!777?!^:        :^^!?~                         \n      ^J7~~^            :^::..        :^~~!?!                         \n     ~YJ57^~:                         .....:.                         \n";

            string tyra = "          ..:^^~^.                                                    \n     ^77777?77!~77~:                                                  \n    ^7JJJ7!!~~~~!J?7^.                                                \n  :7?7JY???J7!~~!JJ?!!.                                               \n :Y7!???JYYYJ??77J5J7!7.                                              \n !?!~!!7??JJY?!~!7JY?7??:                                             \n ^!7!~^!!!7!~^:^7??JJ7!??!^:.:.                                       \n  ::^. ^!~!^^^^~!?7!J?~!??YJ?JYYJ7~.                                  \n       .??!!77!~!!!7?7~~!77JJJJJ5P5Y?~~^::..                          \n        ~J7?7~~!7777!~!!~!!!7?77JYJJY5555Y??!.                        \n        !J?!!~7???7~~~~~~~~!!!!!7??JJYYJ???7??~                .:.    \n       :??!7!?J?^:~~~~~~~~~!7!!!??7??JYJ??77?JY?^.             .!J?~  \n      .?7!!7??!. :?77!~~~~~~!~!!7??????J??777?YJJ?7!~:.           7BY:\n       :~~!!^.   ?Y?77!!!~~~~~!~!7!77?????7!!!?JJ???JJJ?7!~^:::::^JP5?\n                .777!!!7!~~~~~~!!7777!?J??77~~~7JJ?7??JYY5YY555YYYYYJ^\n                 .~~~7!7!!~~~^^^~!?????JJ777~~^!?JJ7777???JJJJYJJJJ7: \n                  : ~~:^!!!!!~^^^~77!??JJ?!!^^^^!?J??J???77!7!!!!~:   \n                 .7!.   7?!~!!~!777!!!!!7~~~^^^^~~7!~~~~~~^^::.       \n                 ~~7.  .?7~^~^~!!~!!77!!~~~~^^^^^~!~.                 \n                 :^:.   :~^^^~~!!: ..::^^:.. ^^^~!!7!^                \n                         ^~^^^~~!~           .~~^~~!!~                \n                          :~^^^~!^            .:^^^~!~                \n                           .:^^^~!.              :^^~!^               \n                             .~^^!!.              .~^^!:              \n                             ^7~^~^                ^~^~~              \n                            ~77~~~                 .!!!!:             \n                     .:..:~7?J7~^.                 .~~!~!.            \n                   .!777!!!?77!:                .^~~~^!?~!~::         \n                    ....  .:...                 :^::..^!^:^^^:        \n";

            string veloci = "      :^!!^^~~~~~^                                                    \n    :777??7??JJ???:                                                   \n  .7???JJJ??7?7!!!.                                                   \n  ?J7?JJJYJJ??7!~^                                .:^^^^^:..          \n .Y!!7!!!~^:::.                                :~77!^:::::^^^:..      \n ^?~7~~~.                                    .7?~.           .....    \n :?~7!!!.                                   ~Y7.                      \n  ?!7777!:.                               :?5!                        \n  ~?!777!!77!777!~^:                   .^75Y~                         \n   !77777!?YJJJJYJJ?7!~::.      .:^~!7JYJY?~                          \n   .!7??7!?YYYJ??JJJJ?JJJ??77?7?JJY5Y5J?7~:                           \n     7??7~!JY555J??J?7?Y5JYY5YJ???777!~^:                             \n     .7?7!~^^~~7JYJJY!!YYJJ55YJ7!!~^:.                                \n      ^~~!!!77?JJ?7JJ~~7YJJPG?^:..                                    \n     :7^.~?J~~~~!!!7!^~~!JYPP:                                        \n     .!~^~7J!:?!^^~~~^^!!!J5G!.                                       \n      .:..~!???7~~^^:  .^!7?Y55Y?.                                    \n           .:.:~~~~^~    .!7777?Y?:                                   \n                :^~~~^      :^!!!7?!                                  \n                   ~~7~         ..^7!.                                \n                 .^7!^.            :!!                                \n              .:!~77:             .:^!!.                              \n         .::^~^^~7~.             .^^~~^~:.                            \n            ......                 :~: :^^.                           \n";


            //Egyéb változók
            string akarsz = "i";
            string k = "i";
            string mi = "";
            string e = "";
            int lo;
            int palya;
            int tav;
            int volt;
            string beallat;
            int beind=172;
            bool nemm = false;
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
            HashSet<int> sorszamok = new HashSet<int>();

            //Játék
            while (akarsz == "i")
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("Mivel szeretnél játszani?\n\t1: Távlovagló verseny szimulátor\n\t2: Rendőr szimulátor\n\t3: Jurassic park IV.\n\t");
                    mi = Console.ReadLine();
                } while (mi != "1" && mi != "2" && mi != "3");
                
                //Távlovaglás
                if (mi == "1" && !nemm)
                {
                    nemm = true;
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
                if (mi == "2" && !nemm)
                {
                    nemm = true;
                    while(akarsz=="i")
                    {
                        volt = 0;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rendőr szimulátor");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A játék során több különböző bűntény után tudsz nyomozni, illetve elkövetőket elfogni. A döntéseid befolyásolják ezek sikerességét. Ha döntési lehetőség elé kerülsz, és nincsen egyéb instrukció, a döntésed sorszámával tudod azt végrehajtani.\nAmennyiben elfogadtad a játék szamályzatot, nyomd meg az ENTER-t.");
                        do
                        {
                            mi = Console.ReadLine();
                            if (mi != "") Console.WriteLine("Nem ez az ENTER!");
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

                        //1. eset - Gyilkosság - vég
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
                                    Console.WriteLine(elsoeset[11].szoveg);
                                    Console.WriteLine("\n"+elsoeset[12].szoveg);
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
                            }

                            //Behatolás
                            if (mi == "2")
                            {
                                Console.WriteLine(elsoeset[4].szoveg);
                                Console.WriteLine(elsoeset[10].szoveg);
                                Console.WriteLine($"A szülők vallomása:\n\t{elsoeset[3].szoveg}");
                                Console.Clear();

                                //Lakás
                                if (mi == "1")
                                {
                                    Console.WriteLine(elsoeset[8].szoveg);
                                    Console.WriteLine("\n" + elsoeset[9].szoveg);
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
                                    Console.WriteLine(elsoeset[11].szoveg);
                                    Console.WriteLine("\n" + elsoeset[12].szoveg);
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
                
                //Jurassic park IV.
                if (mi == "3" && !nemm)
                {
                    nemm = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Jurassic park IV.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("A játék során több különböző szemszögből élheted át a történet bonyodalmait. Minden a játékban lezajló nap egy-egy döntési lehetőséget foglal magába. Ezek közül annak sorszámának beírásával lehet választani. A cél a Park biztonságossá tétele, végső esetben annak elhagyása.");
                    Console.WriteLine(jplogo);

                    Console.Write("A leírás elolvasását az ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("ENTER");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" lenyomássával jelezd!\n");

                    Console.Write("Mennyiben kíváncsi vagy arra, hogy milyen dinoszauruszok jelnnek meg a történet során a ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("'help'");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" kulcsszó beírásásval jelezd!\n");
                    do
                    {
                        mi = Console.ReadLine();
                        mi = mi.ToLower();
                        if (mi != "") Console.WriteLine("Nem ez az ENTER!");
                    } while (mi != "" && mi != "help");
                    Console.Clear();

                    //Dinoszaurusz bemutató
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dinoszaurusz bemutató");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("A programban mergtalálható dinoszauruszok: ");
                    if (mi == "help")
                    {
                        do
                        {
                            Console.Clear();
                            for (int igen = 0; igen < dinok.Count; igen++)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("-------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{igen + 1}: {dinok[igen].faj}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                if (igen == dinok.Count-1)
                                {
                                    Console.WriteLine("-------------------------");
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                sorszamok.Add(igen);
                            }

                            do
                            {
                                Console.Write("Az állat sorszámának megadásával olvashatsz, láthatsz róla információkat! ");
                                beallat = Console.ReadLine();
                                if (szame(beallat)) beind = int.Parse(beallat) - 1;
                                else beind = 172;
                            } while (!sorszamok.Contains(beind));

                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(dinok[beind].faj);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(dinok[beind].szoveg);
                            if (beind == 0) Console.WriteLine(allo);
                            if (beind == 1) Console.WriteLine(apato);
                            if (beind == 2) Console.WriteLine(atroci);
                            if (beind == 3) Console.WriteLine(bary);
                            if (beind == 4) Console.WriteLine(brachi);
                            if (beind == 5) Console.WriteLine(carno);
                            if (beind == 6) Console.WriteLine(cera);
                            if (beind == 7) Console.WriteLine(compy);
                            if (beind == 8) Console.WriteLine(dakota);
                            if (beind == 9) Console.WriteLine(deino);
                            if (beind == 10) Console.WriteLine(diplo);
                            if (beind == 11) Console.WriteLine(dimo);
                            if (beind == 12) Console.WriteLine(dilo);
                            if (beind == 13) Console.WriteLine(galli);
                            if (beind == 14) Console.WriteLine(giga);
                            if (beind == 15) Console.WriteLine(mosa);
                            if (beind == 16) Console.WriteLine(para);
                            if (beind == 17) Console.WriteLine(pthera);
                            if (beind == 18) Console.WriteLine(plesio);
                            if (beind == 19) Console.WriteLine(sino);
                            if (beind == 20) Console.WriteLine(spino);
                            if (beind == 21) Console.WriteLine(such);
                            if (beind == 22) Console.WriteLine(teri);
                            if (beind == 23) Console.WriteLine(trike);
                            if (beind == 24) Console.WriteLine(tyra);
                            if (beind == 25) Console.WriteLine(veloci);
                            if (beind == 26) Console.WriteLine(indominusrex);
                            if (beind == 27) Console.WriteLine(indoraptor);

                            do
                            {
                                Console.Write("Akarsz további dinoszauruszokról olvasni? [i/n] ");
                                k = Console.ReadLine();
                            } while (k != "i" && k != "n");
                        } while (k == "i");
                        



                    }


                    Console.Clear();
                    Console.WriteLine("Előszőr válaszd ki, melyik karakterrel szeretnél játszani!");
                    for (int igen = 0; igen < 2; igen++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{igen+1}: {jpkar[igen]}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (igen == 1)
                        {
                            Console.WriteLine("-------------------------");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    do
                    {
                        Console.Write("Add meg az általad választott karakter sorszámát! ");
                        mi = Console.ReadLine();
                    } while (mi != "1" && mi != "2");
                    Console.Clear();
                    Console.WriteLine($"A háttértörténet:\n\t{jphatter[0]}");
                    Console.Write("Amennyiben elolvastad a történetet, és készen állsz a játékra, azt az ENTER lenyomássával jelezd!");

                    do
                    {
                        e = Console.ReadLine();
                        if (e != "") Console.WriteLine("Nem ez az ENTER!");
                    } while (e != "");
                    Console.Clear();

                    //Tulaj
                    if (mi == "1")
                    {
                        Console.WriteLine(jptulaj[0].szoveg);
                        Console.WriteLine(jptulaj[1].szoveg);
                        Console.WriteLine(jptulaj[2].szoveg);
                        string igen1;
                        do
                        {
                            Console.Write("Add meg a döntésted sorszámát! ");
                            igen1 = Console.ReadLine();
                        } while (igen1 != "1" && igen1 != "2");

                        //Sietsz - Indominus rex
                        if (igen1 == "1")
                        {
                            Console.Clear();
                            Console.WriteLine(jptulaj[3].szoveg);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kutató: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[4].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[5].szoveg);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kutató: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[6].szoveg);

                            Console.WriteLine(jptulaj[7].szoveg);
                            Console.WriteLine(jptulaj[8].szoveg);
                            string igen2;
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                igen2 = Console.ReadLine();
                            } while (igen2 != "1" && igen2 != "2");

                            //Megnézed
                            if (igen2 == "1")
                            {
                                Console.Clear();
                                Console.WriteLine(jptulaj[9].szoveg);

                                Console.WriteLine(indominusrex);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[10].szoveg);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Kutató: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[11].szoveg);

                                Console.WriteLine(jptulaj[12].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[13].szoveg);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Kutató: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[14].szoveg);

                                Console.WriteLine(jptulaj[15].szoveg);
                                Console.WriteLine(jptulaj[16].szoveg);
                                string igen3;
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    igen3 = Console.ReadLine();
                                } while (igen3 != "1" && igen3 != "2");

                                //Aggódni
                                if (igen3 == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine(jptulaj[17].szoveg);
                                    Console.WriteLine(jptulaj[18].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("1. látogató: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[19].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("2. látogató: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[20].szoveg);

                                    Console.WriteLine(jptulaj[21].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[22].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("Gondozó: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[23].szoveg);

                                    Console.WriteLine(jptulaj[24].szoveg);
                                    Console.WriteLine(jptulaj[25].szoveg);
                                    string igen4;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen4 = Console.ReadLine();
                                    } while (igen4 != "1" && igen4 != "2");

                                    //Aludni
                                    if (igen4 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[26].szoveg);

                                        Console.WriteLine(jptulaj[27].szoveg);
                                        Console.WriteLine(jptulaj[28].szoveg);
                                        string igen5;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen5 = Console.ReadLine();
                                        } while (igen5 != "1" && igen5 != "2");

                                        //Eligazító
                                        if (igen5 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[29].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[30].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[31].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[32].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[33].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[34].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[35].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[36].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[37].szoveg);

                                            Console.WriteLine(jptulaj[38].szoveg);
                                            Console.WriteLine(jptulaj[39].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Úthálózat
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[40].szoveg);

                                                Console.WriteLine(jptulaj[41].szoveg);
                                                Console.WriteLine(jptulaj[42].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Iroda - vég - b
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                //Kikötő - vég - ny
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[44].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Kikötő - vég - b
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[45].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }

                                        //Utca
                                        if (igen5 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[46].szoveg);
                                            Console.WriteLine(jptulaj[47].szoveg);
                                            Console.WriteLine(jptulaj[48].szoveg);
                                            string igen8;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen8 = Console.ReadLine();
                                            } while (igen8 != "1" && igen8 != "2");

                                            //Ball - vég - b
                                            if (igen8 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[49].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Jobb
                                            if (igen8 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[50].szoveg);
                                                Console.WriteLine(jptulaj[51].szoveg);
                                                Console.WriteLine(jptulaj[52].szoveg);
                                                string igen9;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen9 = Console.ReadLine();
                                                } while (igen9 != "1" && igen9 != "2");

                                                //Épület - vég - b
                                                if (igen9 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[53].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                //Aluljáró
                                                if (igen9 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[54].szoveg);
                                                    Console.WriteLine(jptulaj[55].szoveg);
                                                    Console.WriteLine(jptulaj[56].szoveg);
                                                    string igen10;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen10 = Console.ReadLine();
                                                    } while (igen10 != "1" && igen10 != "2");

                                                    //Vetítő
                                                    if (igen10 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[58].szoveg);
                                                        Console.WriteLine(jptulaj[59].szoveg);
                                                        Console.WriteLine(jptulaj[60].szoveg);
                                                        string igen11;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen11 = Console.ReadLine();
                                                        } while (igen11 != "1" && igen11 != "2");

                                                        //Szellőző
                                                        if (igen11 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[62].szoveg);
                                                            Console.WriteLine(jptulaj[63].szoveg);
                                                            Console.WriteLine(jptulaj[64].szoveg);
                                                            string igen12;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen12 = Console.ReadLine();
                                                            } while (igen12 != "1" && igen12 != "2");

                                                            //Irodáig - vég - b
                                                            if (igen12 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[65].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kijössz - vég - ny
                                                            if (igen12 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[66].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Elhagyni - vég - b
                                                        if (igen11 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[61].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Folyosó - vég - b
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[57].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //Fel a falra
                                    if (igen4 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[67].szoveg);
                                        Console.WriteLine(jptulaj[68].szoveg);
                                        Console.WriteLine(jptulaj[69].szoveg);
                                        string igen13;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen13 = Console.ReadLine();
                                        } while (igen13 != "1" && igen13 != "2");

                                        //Odébb
                                        if (igen13 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[71].szoveg);
                                            Console.WriteLine(jptulaj[72].szoveg);
                                            Console.WriteLine(jptulaj[73].szoveg);
                                            string igen14;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen14 = Console.ReadLine();
                                            } while (igen14 != "1" && igen14 != "2");

                                            //Zárt kör
                                            if (igen14 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[74].szoveg);
                                                Console.WriteLine(jptulaj[75].szoveg);
                                                Console.WriteLine(jptulaj[76].szoveg);
                                                string igen15;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen15 = Console.ReadLine();
                                                } while (igen15 != "1" && igen15 != "2");

                                                //Ölni
                                                if (igen15 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[77].szoveg);
                                                    Console.WriteLine(jptulaj[78].szoveg);
                                                    Console.WriteLine(jptulaj[79].szoveg);
                                                    string igen16;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen16 = Console.ReadLine();
                                                    } while (igen16 != "1" && igen16 != "2");

                                                    //Menkülni - vég - b
                                                    if (igen16 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[80].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Evakuáció
                                                    if (igen16 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[81].szoveg);
                                                        Console.WriteLine(jptulaj[82].szoveg);
                                                        Console.WriteLine(jptulaj[83].szoveg);
                                                        string igen17;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen17 = Console.ReadLine();
                                                        } while (igen17 != "1" && igen17 != "2");

                                                        //Hajó - vég - ny
                                                        if (igen17 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[84].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Utca
                                                        if (igen17 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[46].szoveg);
                                                            Console.WriteLine(jptulaj[47].szoveg);
                                                            Console.WriteLine(jptulaj[48].szoveg);
                                                            string igen18;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen18 = Console.ReadLine();
                                                            } while (igen18 != "1" && igen18 != "2");

                                                            //Ball - vég - b
                                                            if (igen18 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[49].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Jobb
                                                            if (igen18 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[50].szoveg);
                                                                Console.WriteLine(jptulaj[51].szoveg);
                                                                Console.WriteLine(jptulaj[52].szoveg);
                                                                string igen19;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen19 = Console.ReadLine();
                                                                } while (igen19 != "1" && igen19 != "2");

                                                                //Épület - vég - b
                                                                if (igen19 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[53].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Aluljáró
                                                                if (igen19 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[54].szoveg);
                                                                    Console.WriteLine(jptulaj[55].szoveg);
                                                                    Console.WriteLine(jptulaj[56].szoveg);
                                                                    string igen20;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen20 = Console.ReadLine();
                                                                    } while (igen20 != "1" && igen20 != "2");

                                                                    //Vetítő
                                                                    if (igen20 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[58].szoveg);
                                                                        Console.WriteLine(jptulaj[59].szoveg);
                                                                        Console.WriteLine(jptulaj[60].szoveg);
                                                                        string igen21;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen21 = Console.ReadLine();
                                                                        } while (igen21 != "1" && igen21 != "2");

                                                                        //Szellőző
                                                                        if (igen21 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[62].szoveg);
                                                                            Console.WriteLine(jptulaj[63].szoveg);
                                                                            Console.WriteLine(jptulaj[64].szoveg);
                                                                            string igen22;
                                                                            do
                                                                            {
                                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                                igen22 = Console.ReadLine();
                                                                            } while (igen22 != "1" && igen22 != "2");

                                                                            //Irodáig - vég - b
                                                                            if (igen22 == "1")
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine(jptulaj[65].szoveg);
                                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                            }

                                                                            //Kijössz - vég - ny
                                                                            if (igen22 == "2")
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine(jptulaj[66].szoveg);
                                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                            }
                                                                        }

                                                                        //Elhagyni - vég - b
                                                                        if (igen21 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[61].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Folyosó - vég - b
                                                                    if (igen20 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[57].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }
                                                }

                                                //Altatni - vég - ny
                                                if (igen15 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[85].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Evakuáció
                                            if (igen14 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[81].szoveg);
                                                Console.WriteLine(jptulaj[82].szoveg);
                                                Console.WriteLine(jptulaj[83].szoveg);
                                                string igen17;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen17 = Console.ReadLine();
                                                } while (igen17 != "1" && igen17 != "2");

                                                //Hajó - vég - ny
                                                if (igen17 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[84].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                //Utca
                                                if (igen17 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[46].szoveg);
                                                    Console.WriteLine(jptulaj[47].szoveg);
                                                    Console.WriteLine(jptulaj[48].szoveg);
                                                    string igen18;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen18 = Console.ReadLine();
                                                    } while (igen18 != "1" && igen18 != "2");

                                                    //Ball - vég - b
                                                    if (igen18 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[49].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Jobb
                                                    if (igen18 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[50].szoveg);
                                                        Console.WriteLine(jptulaj[51].szoveg);
                                                        Console.WriteLine(jptulaj[52].szoveg);
                                                        string igen19;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen19 = Console.ReadLine();
                                                        } while (igen19 != "1" && igen19 != "2");

                                                        //Épület - vég - b
                                                        if (igen19 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[53].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Aluljáró
                                                        if (igen19 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[54].szoveg);
                                                            Console.WriteLine(jptulaj[55].szoveg);
                                                            Console.WriteLine(jptulaj[56].szoveg);
                                                            string igen20;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen20 = Console.ReadLine();
                                                            } while (igen20 != "1" && igen20 != "2");

                                                            //Vetítő
                                                            if (igen20 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[58].szoveg);
                                                                Console.WriteLine(jptulaj[59].szoveg);
                                                                Console.WriteLine(jptulaj[60].szoveg);
                                                                string igen21;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen21 = Console.ReadLine();
                                                                } while (igen21 != "1" && igen21 != "2");

                                                                //Szellőző
                                                                if (igen21 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[62].szoveg);
                                                                    Console.WriteLine(jptulaj[63].szoveg);
                                                                    Console.WriteLine(jptulaj[64].szoveg);
                                                                    string igen22;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen22 = Console.ReadLine();
                                                                    } while (igen22 != "1" && igen22 != "2");

                                                                    //Irodáig - vég - b
                                                                    if (igen22 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[65].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }

                                                                    //Kijössz - vég - ny
                                                                    if (igen22 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[66].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Elhagyni - vég - b
                                                                if (igen21 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[61].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Folyosó - vég - b
                                                            if (igen20 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[57].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //Maradsz - vég - b
                                        if (igen13 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[70].szoveg);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }

                                }

                                //Figyelmen kívül hagyni
                                if (igen3 == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine(jptulaj[86].szoveg);
                                    Console.WriteLine(jptulaj[87].szoveg);

                                    //Aludni
                                    Console.Clear();
                                    Console.WriteLine(jptulaj[26].szoveg);

                                    Console.WriteLine(jptulaj[27].szoveg);
                                    Console.WriteLine(jptulaj[28].szoveg);
                                    string igen5;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen5 = Console.ReadLine();
                                    } while (igen5 != "1" && igen5 != "2");

                                    //Eligazító
                                    if (igen5 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[29].szoveg);

                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("Tulaj: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[30].szoveg);

                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("Dolgozó: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[31].szoveg);

                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("Tulaj: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[32].szoveg);

                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("Dolgozó: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[33].szoveg);

                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("Tulaj: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[34].szoveg);

                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("Dolgozó: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[35].szoveg);

                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("Tulaj: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[36].szoveg);

                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("Dolgozó: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(jptulaj[37].szoveg);

                                        Console.WriteLine(jptulaj[38].szoveg);
                                        Console.WriteLine(jptulaj[39].szoveg);
                                        string igen6;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen6 = Console.ReadLine();
                                        } while (igen6 != "1" && igen6 != "2");

                                        //Úthálózat
                                        if (igen6 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[40].szoveg);

                                            Console.WriteLine(jptulaj[41].szoveg);
                                            Console.WriteLine(jptulaj[42].szoveg);
                                            string igen7;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen7 = Console.ReadLine();
                                            } while (igen7 != "1" && igen7 != "2");

                                            //Iroda - vég - b
                                            if (igen7 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[43].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Kikötő - vég - ny
                                            if (igen7 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[44].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }

                                        //Kikötő - vég - b
                                        if (igen6 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[45].szoveg);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }

                                    //Utca
                                    if (igen5 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[46].szoveg);
                                        Console.WriteLine(jptulaj[47].szoveg);
                                        Console.WriteLine(jptulaj[48].szoveg);
                                        string igen8;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen8 = Console.ReadLine();
                                        } while (igen8 != "1" && igen8 != "2");

                                        //Ball - vég - b
                                        if (igen8 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[49].szoveg);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        //Jobb
                                        if (igen8 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[50].szoveg);
                                            Console.WriteLine(jptulaj[51].szoveg);
                                            Console.WriteLine(jptulaj[52].szoveg);
                                            string igen9;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen9 = Console.ReadLine();
                                            } while (igen9 != "1" && igen9 != "2");

                                            //Épület - vég - b
                                            if (igen9 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[53].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Aluljáró
                                            if (igen9 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[54].szoveg);
                                                Console.WriteLine(jptulaj[55].szoveg);
                                                Console.WriteLine(jptulaj[56].szoveg);
                                                string igen10;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen10 = Console.ReadLine();
                                                } while (igen10 != "1" && igen10 != "2");

                                                //Vetítő
                                                if (igen10 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[58].szoveg);
                                                    Console.WriteLine(jptulaj[59].szoveg);
                                                    Console.WriteLine(jptulaj[60].szoveg);
                                                    string igen11;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen11 = Console.ReadLine();
                                                    } while (igen11 != "1" && igen11 != "2");

                                                    //Szellőző
                                                    if (igen11 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[62].szoveg);
                                                        Console.WriteLine(jptulaj[63].szoveg);
                                                        Console.WriteLine(jptulaj[64].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Irodáig - vég - b
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[65].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Kijössz - vég - ny
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[66].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Elhagyni - vég - b
                                                    if (igen11 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[61].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Folyosó - vég - b
                                                if (igen10 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[57].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                            //Állatorvos
                            if (igen2 == "2")
                            {
                                Console.Clear();
                                Console.WriteLine(jptulaj[88].szoveg);

                                Console.WriteLine(indominusrex2);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[89].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write("Állatorvos: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[90].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[91].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write("Állatorvos: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[92].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[93].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write("Állatorvos: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[94].szoveg);

                                Console.WriteLine(jptulaj[95].szoveg);
                                Console.WriteLine(jptulaj[96].szoveg);

                                string igen12;
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    igen12 = Console.ReadLine();
                                } while (igen12 != "1" && igen12 != "2");

                                //Hallgatsz rá -  vég -ny
                                if (igen12 == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine(jptulaj[97].szoveg);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Sikerült megelőznöd egy katasztrófát.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                //Ignorálni
                                if (igen12 == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine(jptulaj[17].szoveg);
                                    Console.WriteLine(jptulaj[18].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("1. látogató: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[19].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("2. látogató: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[20].szoveg);

                                    Console.WriteLine(jptulaj[21].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[22].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("Gondozó: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[23].szoveg);

                                    Console.WriteLine(jptulaj[24].szoveg);
                                    Console.WriteLine(jptulaj[25].szoveg);
                                    string igen4;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen4 = Console.ReadLine();
                                    } while (igen4 != "1" && igen4 != "2");

                                    //Aludni
                                    if (igen4 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[26].szoveg);

                                        Console.WriteLine(jptulaj[27].szoveg);
                                        Console.WriteLine(jptulaj[28].szoveg);
                                        string igen5;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen5 = Console.ReadLine();
                                        } while (igen5 != "1" && igen5 != "2");

                                        //Eligazító
                                        if (igen5 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[29].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[30].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[31].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[32].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[33].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[34].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[35].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[36].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[37].szoveg);

                                            Console.WriteLine(jptulaj[38].szoveg);
                                            Console.WriteLine(jptulaj[39].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Úthálózat
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[40].szoveg);

                                                Console.WriteLine(jptulaj[41].szoveg);
                                                Console.WriteLine(jptulaj[42].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Iroda - vég - b
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                //Kikötő - vég - ny
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[44].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Kikötő - vég - b
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[45].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }

                                        //Utca
                                        if (igen5 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[46].szoveg);
                                            Console.WriteLine(jptulaj[47].szoveg);
                                            Console.WriteLine(jptulaj[48].szoveg);
                                            string igen8;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen8 = Console.ReadLine();
                                            } while (igen8 != "1" && igen8 != "2");

                                            //Ball - vég - b
                                            if (igen8 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[49].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Jobb
                                            if (igen8 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[50].szoveg);
                                                Console.WriteLine(jptulaj[51].szoveg);
                                                Console.WriteLine(jptulaj[52].szoveg);
                                                string igen9;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen9 = Console.ReadLine();
                                                } while (igen9 != "1" && igen9 != "2");

                                                //Épület - vég - b
                                                if (igen9 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[53].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                //Aluljáró
                                                if (igen9 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[54].szoveg);
                                                    Console.WriteLine(jptulaj[55].szoveg);
                                                    Console.WriteLine(jptulaj[56].szoveg);
                                                    string igen10;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen10 = Console.ReadLine();
                                                    } while (igen10 != "1" && igen10 != "2");

                                                    //Vetítő
                                                    if (igen10 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[58].szoveg);
                                                        Console.WriteLine(jptulaj[59].szoveg);
                                                        Console.WriteLine(jptulaj[60].szoveg);
                                                        string igen11;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen11 = Console.ReadLine();
                                                        } while (igen11 != "1" && igen11 != "2");

                                                        //Szellőző
                                                        if (igen11 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[62].szoveg);
                                                            Console.WriteLine(jptulaj[63].szoveg);
                                                            Console.WriteLine(jptulaj[64].szoveg);
                                                            string igen24;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen24 = Console.ReadLine();
                                                            } while (igen24 != "1" && igen24 != "2");

                                                            //Irodáig - vég - b
                                                            if (igen24 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[65].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kijössz - vég - ny
                                                            if (igen24 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[66].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Elhagyni - vég - b
                                                        if (igen11 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[61].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Folyosó - vég - b
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[57].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //Fel a falra
                                    if (igen4 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[67].szoveg);
                                        Console.WriteLine(jptulaj[68].szoveg);
                                        Console.WriteLine(jptulaj[69].szoveg);
                                        string igen13;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen13 = Console.ReadLine();
                                        } while (igen13 != "1" && igen13 != "2");

                                        //Odébb
                                        if (igen13 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[71].szoveg);
                                            Console.WriteLine(jptulaj[72].szoveg);
                                            Console.WriteLine(jptulaj[73].szoveg);
                                            string igen14;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen14 = Console.ReadLine();
                                            } while (igen14 != "1" && igen14 != "2");

                                            //Zárt kör
                                            if (igen14 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[74].szoveg);
                                                Console.WriteLine(jptulaj[75].szoveg);
                                                Console.WriteLine(jptulaj[76].szoveg);
                                                string igen15;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen15 = Console.ReadLine();
                                                } while (igen15 != "1" && igen15 != "2");

                                                //Ölni
                                                if (igen15 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[77].szoveg);
                                                    Console.WriteLine(jptulaj[78].szoveg);
                                                    Console.WriteLine(jptulaj[79].szoveg);
                                                    string igen16;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen16 = Console.ReadLine();
                                                    } while (igen16 != "1" && igen16 != "2");

                                                    //Menkülni - vég - b
                                                    if (igen16 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[80].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Evakuáció
                                                    if (igen16 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[81].szoveg);
                                                        Console.WriteLine(jptulaj[82].szoveg);
                                                        Console.WriteLine(jptulaj[83].szoveg);
                                                        string igen17;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen17 = Console.ReadLine();
                                                        } while (igen17 != "1" && igen17 != "2");

                                                        //Hajó - vég - ny
                                                        if (igen17 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[84].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Utca
                                                        if (igen17 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[46].szoveg);
                                                            Console.WriteLine(jptulaj[47].szoveg);
                                                            Console.WriteLine(jptulaj[48].szoveg);
                                                            string igen18;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen18 = Console.ReadLine();
                                                            } while (igen18 != "1" && igen18 != "2");

                                                            //Ball - vég - b
                                                            if (igen18 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[49].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Jobb
                                                            if (igen18 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[50].szoveg);
                                                                Console.WriteLine(jptulaj[51].szoveg);
                                                                Console.WriteLine(jptulaj[52].szoveg);
                                                                string igen19;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen19 = Console.ReadLine();
                                                                } while (igen19 != "1" && igen19 != "2");

                                                                //Épület - vég - b
                                                                if (igen19 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[53].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Aluljáró
                                                                if (igen19 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[54].szoveg);
                                                                    Console.WriteLine(jptulaj[55].szoveg);
                                                                    Console.WriteLine(jptulaj[56].szoveg);
                                                                    string igen20;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen20 = Console.ReadLine();
                                                                    } while (igen20 != "1" && igen20 != "2");

                                                                    //Vetítő
                                                                    if (igen20 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[58].szoveg);
                                                                        Console.WriteLine(jptulaj[59].szoveg);
                                                                        Console.WriteLine(jptulaj[60].szoveg);
                                                                        string igen21;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen21 = Console.ReadLine();
                                                                        } while (igen21 != "1" && igen21 != "2");

                                                                        //Szellőző
                                                                        if (igen21 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[62].szoveg);
                                                                            Console.WriteLine(jptulaj[63].szoveg);
                                                                            Console.WriteLine(jptulaj[64].szoveg);
                                                                            string igen22;
                                                                            do
                                                                            {
                                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                                igen22 = Console.ReadLine();
                                                                            } while (igen22 != "1" && igen22 != "2");

                                                                            //Irodáig - vég - b
                                                                            if (igen22 == "1")
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine(jptulaj[65].szoveg);
                                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                            }

                                                                            //Kijössz - vég - ny
                                                                            if (igen22 == "2")
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine(jptulaj[66].szoveg);
                                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                            }
                                                                        }

                                                                        //Elhagyni - vég - b
                                                                        if (igen21 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[61].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Folyosó - vég - b
                                                                    if (igen20 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[57].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }
                                                }

                                                //Altatni - vég - ny
                                                if (igen15 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[85].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Evakuáció
                                            if (igen14 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[81].szoveg);
                                                Console.WriteLine(jptulaj[82].szoveg);
                                                Console.WriteLine(jptulaj[83].szoveg);
                                                string igen17;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen17 = Console.ReadLine();
                                                } while (igen17 != "1" && igen17 != "2");

                                                //Hajó - vég - ny
                                                if (igen17 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[84].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                //Utca
                                                if (igen17 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[46].szoveg);
                                                    Console.WriteLine(jptulaj[47].szoveg);
                                                    Console.WriteLine(jptulaj[48].szoveg);
                                                    string igen18;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen18 = Console.ReadLine();
                                                    } while (igen18 != "1" && igen18 != "2");

                                                    //Ball - vég - b
                                                    if (igen18 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[49].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Jobb
                                                    if (igen18 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[50].szoveg);
                                                        Console.WriteLine(jptulaj[51].szoveg);
                                                        Console.WriteLine(jptulaj[52].szoveg);
                                                        string igen19;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen19 = Console.ReadLine();
                                                        } while (igen19 != "1" && igen19 != "2");

                                                        //Épület - vég - b
                                                        if (igen19 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[53].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Aluljáró
                                                        if (igen19 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[54].szoveg);
                                                            Console.WriteLine(jptulaj[55].szoveg);
                                                            Console.WriteLine(jptulaj[56].szoveg);
                                                            string igen20;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen20 = Console.ReadLine();
                                                            } while (igen20 != "1" && igen20 != "2");

                                                            //Vetítő
                                                            if (igen20 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[58].szoveg);
                                                                Console.WriteLine(jptulaj[59].szoveg);
                                                                Console.WriteLine(jptulaj[60].szoveg);
                                                                string igen21;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen21 = Console.ReadLine();
                                                                } while (igen21 != "1" && igen21 != "2");

                                                                //Szellőző
                                                                if (igen21 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[62].szoveg);
                                                                    Console.WriteLine(jptulaj[63].szoveg);
                                                                    Console.WriteLine(jptulaj[64].szoveg);
                                                                    string igen22;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen22 = Console.ReadLine();
                                                                    } while (igen22 != "1" && igen22 != "2");

                                                                    //Irodáig - vég - b
                                                                    if (igen22 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[65].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }

                                                                    //Kijössz - vég - ny
                                                                    if (igen22 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[66].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Elhagyni - vég - b
                                                                if (igen21 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[61].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Folyosó - vég - b
                                                            if (igen20 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[57].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //Maradsz - vég - b
                                        if (igen13 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[70].szoveg);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }

                                }
                            }


                        }

                        //Késel - Indoraptor
                        if (igen1 == "2")
                        {
                            Console.Clear();
                            Console.WriteLine(jptulaj[3].szoveg);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kutató: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[97].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[98].szoveg);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kutató: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[99].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[100].szoveg);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kutató: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jptulaj[101].szoveg);

                            Console.WriteLine(jptulaj[102].szoveg);
                            Console.WriteLine(jptulaj[103].szoveg);
                            string igen2;
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                igen2 = Console.ReadLine();
                            } while (igen2 != "1" && igen2 != "2");

                            //Ma
                            if (igen2 == "1")
                            {
                                Console.Clear();
                                Console.WriteLine(jptulaj[104].szoveg);

                                Console.WriteLine(indoraptor2);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie(Indoraptorok gondozója): ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[105].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[106].szoveg);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[107].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[108].szoveg);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[109].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[110].szoveg);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[111].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[112].szoveg);

                                Console.WriteLine(jptulaj[114].szoveg);
                                Console.WriteLine(jptulaj[115].szoveg);
                                string igen3;
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    igen3 = Console.ReadLine();
                                } while (igen3 != "1" && igen3 != "2");

                                //Tanítás
                                if (igen3 == "1")
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[116].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[117].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[118].szoveg);

                                    Console.WriteLine(jptulaj[119].szoveg);

                                    Console.WriteLine(jptulaj[120].szoveg);
                                    Console.WriteLine(jptulaj[121].szoveg);
                                    string igen4;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen4 = Console.ReadLine();
                                    } while (igen4 != "1" && igen4 != "2");

                                    //Korlátlan
                                    if (igen4 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[122].szoveg);
                                        Console.WriteLine(jptulaj[123].szoveg);
                                        Console.WriteLine(jptulaj[124].szoveg);
                                        string igen5;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen5 = Console.ReadLine();
                                        } while (igen5 != "1" && igen5 != "2");

                                        //Végig hallgatod
                                        if (igen5 == "1")
                                        {
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //Számonkérés
                                        if (igen5 == "2")
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[256].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[257].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[258].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //Korlát
                                    if (igen4 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[259].szoveg);

                                        Console.WriteLine(jptulaj[134].szoveg);
                                        Console.WriteLine(jptulaj[135].szoveg);
                                        string igen7;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen7 = Console.ReadLine();
                                        } while (igen7 != "1" && igen7 != "2");

                                        //Alszol
                                        if (igen7 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[136].szoveg);
                                            Console.WriteLine(jptulaj[137].szoveg);
                                            Console.WriteLine(jptulaj[138].szoveg);
                                            string igen8;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen8 = Console.ReadLine();
                                            } while (igen8 != "1" && igen8 != "2");

                                            //Indoraptor
                                            if (igen8 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[139].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[140].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[141].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[142].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[143].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[144].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[145].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[146].szoveg);

                                                Console.WriteLine(jptulaj[147].szoveg);
                                                Console.WriteLine(jptulaj[148].szoveg);
                                                string igen9;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen9 = Console.ReadLine();
                                                } while (igen9 != "1" && igen9 != "2");

                                                //Titokban
                                                if (igen9 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[149].szoveg);
                                                    Console.WriteLine(jptulaj[150].szoveg);
                                                    Console.WriteLine(jptulaj[151].szoveg);
                                                    string igen10;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen10 = Console.ReadLine();
                                                    } while (igen10 != "1" && igen10 != "2");

                                                    //Felveszed
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[152].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[153].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[154].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[155].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[156].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[157].szoveg);

                                                        Console.WriteLine(jptulaj[158].szoveg);
                                                        Console.WriteLine(jptulaj[159].szoveg);
                                                        string igen11;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen11 = Console.ReadLine();
                                                        } while (igen11 != "1" && igen11 != "2");

                                                        //Evakuáció - vég - ny
                                                        if (igen11 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[161].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen11 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Ignorálod - vég - ny
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[162].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[163].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[164].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[165].szoveg);

                                                        Console.WriteLine(jptulaj[166].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiüríted - vég -ny
                                                if (igen9 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[167].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Vezérlő
                                            if (igen8 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[168].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[169].szoveg);

                                                Console.WriteLine(jptulaj[170].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.Write("Dolgozó: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[171].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[172].szoveg);

                                                Console.WriteLine(jptulaj[173].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[174].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[175].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[176].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[177].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[178].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[179].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[180].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[181].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[182].szoveg);

                                                Console.WriteLine(jptulaj[183].szoveg);
                                                Console.WriteLine(jptulaj[184].szoveg);
                                                string igen12;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen12 = Console.ReadLine();
                                                } while (igen12 != "1" && igen12 != "2");

                                                //Vársz
                                                if (igen12 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[185].szoveg);
                                                    Console.WriteLine(jptulaj[186].szoveg);
                                                    Console.WriteLine(jptulaj[187].szoveg);
                                                    string igen13;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen13 = Console.ReadLine();
                                                    } while (igen13 != "1" && igen13 != "2");

                                                    //Kifutó
                                                    if (igen13 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[188].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[189].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[190].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[191].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[192].szoveg);

                                                        Console.WriteLine(jptulaj[193].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[194].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[195].szoveg);

                                                        Console.WriteLine(jptulaj[196].szoveg);
                                                        Console.WriteLine(jptulaj[197].szoveg);
                                                        string igen14;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen14 = Console.ReadLine();
                                                        } while (igen14 != "1" && igen14 != "2");

                                                        //Menkülsz - vég - b
                                                        if (igen14 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Iroda - vég - b
                                                        if (igen14 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[43].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Menkülsz - vég - b
                                                    if (igen13 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[160].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiküldöd
                                                if (igen12 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[198].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }
                                        }

                                        //Visszahívod
                                        if (igen7 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[199].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[132].szoveg);

                                            Console.WriteLine(jptulaj[201].szoveg);
                                            Console.WriteLine(jptulaj[202].szoveg);
                                            string igen15;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen15 = Console.ReadLine();
                                            } while (igen15 != "1" && igen15 != "2");

                                            //Mindent - vég - ny
                                            if (igen15 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[203].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Csak - vég - ny
                                            if (igen15 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[204].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                }

                                //Biztonság
                                if (igen3 == "2")
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[260].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[261].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[262].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[263].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[264].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[265].szoveg);

                                    Console.WriteLine(jptulaj[119].szoveg);

                                    Console.WriteLine(jptulaj[120].szoveg);
                                    Console.WriteLine(jptulaj[121].szoveg);
                                    string igen4;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen4 = Console.ReadLine();
                                    } while (igen4 != "1" && igen4 != "2");

                                    //Korlátlan
                                    if (igen4 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[122].szoveg);
                                        Console.WriteLine(jptulaj[123].szoveg);
                                        Console.WriteLine(jptulaj[124].szoveg);
                                        string igen5;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen5 = Console.ReadLine();
                                        } while (igen5 != "1" && igen5 != "2");

                                        //Végig hallgatod
                                        if (igen5 == "1")
                                        {
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //Számonkérés
                                        if (igen5 == "2")
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[256].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[257].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[258].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //Korlát
                                    if (igen4 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[259].szoveg);

                                        Console.WriteLine(jptulaj[134].szoveg);
                                        Console.WriteLine(jptulaj[135].szoveg);
                                        string igen7;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen7 = Console.ReadLine();
                                        } while (igen7 != "1" && igen7 != "2");

                                        //Alszol
                                        if (igen7 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[136].szoveg);
                                            Console.WriteLine(jptulaj[137].szoveg);
                                            Console.WriteLine(jptulaj[138].szoveg);
                                            string igen8;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen8 = Console.ReadLine();
                                            } while (igen8 != "1" && igen8 != "2");

                                            //Indoraptor
                                            if (igen8 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[139].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[140].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[141].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[142].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[143].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[144].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[145].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[146].szoveg);

                                                Console.WriteLine(jptulaj[147].szoveg);
                                                Console.WriteLine(jptulaj[148].szoveg);
                                                string igen9;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen9 = Console.ReadLine();
                                                } while (igen9 != "1" && igen9 != "2");

                                                //Titokban
                                                if (igen9 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[149].szoveg);
                                                    Console.WriteLine(jptulaj[150].szoveg);
                                                    Console.WriteLine(jptulaj[151].szoveg);
                                                    string igen10;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen10 = Console.ReadLine();
                                                    } while (igen10 != "1" && igen10 != "2");

                                                    //Felveszed
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[152].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[153].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[154].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[155].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[156].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[157].szoveg);

                                                        Console.WriteLine(jptulaj[158].szoveg);
                                                        Console.WriteLine(jptulaj[159].szoveg);
                                                        string igen11;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen11 = Console.ReadLine();
                                                        } while (igen11 != "1" && igen11 != "2");

                                                        //Evakuáció - vég - ny
                                                        if (igen11 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[161].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen11 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Ignorálod - vég - ny
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[162].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[163].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[164].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[165].szoveg);

                                                        Console.WriteLine(jptulaj[166].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiüríted - vég -ny
                                                if (igen9 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[167].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Vezérlő
                                            if (igen8 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[168].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[169].szoveg);

                                                Console.WriteLine(jptulaj[170].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.Write("Dolgozó: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[171].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[172].szoveg);

                                                Console.WriteLine(jptulaj[173].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[174].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[175].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[176].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[177].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[178].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[179].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[180].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[181].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[182].szoveg);

                                                Console.WriteLine(jptulaj[183].szoveg);
                                                Console.WriteLine(jptulaj[184].szoveg);
                                                string igen12;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen12 = Console.ReadLine();
                                                } while (igen12 != "1" && igen12 != "2");

                                                //Vársz
                                                if (igen12 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[185].szoveg);
                                                    Console.WriteLine(jptulaj[186].szoveg);
                                                    Console.WriteLine(jptulaj[187].szoveg);
                                                    string igen13;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen13 = Console.ReadLine();
                                                    } while (igen13 != "1" && igen13 != "2");

                                                    //Kifutó
                                                    if (igen13 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[188].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[189].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[190].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[191].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[192].szoveg);

                                                        Console.WriteLine(jptulaj[193].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[194].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[195].szoveg);

                                                        Console.WriteLine(jptulaj[196].szoveg);
                                                        Console.WriteLine(jptulaj[197].szoveg);
                                                        string igen14;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen14 = Console.ReadLine();
                                                        } while (igen14 != "1" && igen14 != "2");

                                                        //Menkülsz - vég - b
                                                        if (igen14 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Iroda - vég - b
                                                        if (igen14 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[43].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Menkülsz - vég - b
                                                    if (igen13 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[160].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiküldöd
                                                if (igen12 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[198].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }
                                        }

                                        //Visszahívod
                                        if (igen7 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[199].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[132].szoveg);

                                            Console.WriteLine(jptulaj[201].szoveg);
                                            Console.WriteLine(jptulaj[202].szoveg);
                                            string igen15;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen15 = Console.ReadLine();
                                            } while (igen15 != "1" && igen15 != "2");

                                            //Mindent - vég - ny
                                            if (igen15 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[203].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Csak - vég - ny
                                            if (igen15 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[204].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                }
                            }

                            //Holnap
                            if (igen2 == "2")
                            {
                                Console.Clear();
                                Console.WriteLine(jptulaj[113].szoveg);

                                Console.WriteLine(indoraptor2);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie(Indoraptorok gondozója): ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[105].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[106].szoveg);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[107].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[108].szoveg);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[109].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[110].szoveg);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Jessie: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[111].szoveg);

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jptulaj[112].szoveg);

                                Console.WriteLine(jptulaj[114].szoveg);
                                Console.WriteLine(jptulaj[115].szoveg);
                                string igen3;
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    igen3 = Console.ReadLine();
                                } while (igen3 != "1" && igen3 != "2");

                                //Tanítás
                                if (igen3 == "1")
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[116].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[117].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[118].szoveg);

                                    Console.WriteLine(jptulaj[119].szoveg);

                                    Console.WriteLine(jptulaj[120].szoveg);
                                    Console.WriteLine(jptulaj[121].szoveg);
                                    string igen4;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen4 = Console.ReadLine();
                                    } while (igen4 != "1" && igen4 != "2");

                                    //Korlátlan
                                    if (igen4 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[122].szoveg);
                                        Console.WriteLine(jptulaj[123].szoveg);
                                        Console.WriteLine(jptulaj[124].szoveg);
                                        string igen5;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen5 = Console.ReadLine();
                                        } while (igen5 != "1" && igen5 != "2");

                                        //Végig hallgatod
                                        if (igen5 == "1")
                                        {
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //Számonkérés
                                        if (igen5 == "2")
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[256].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[257].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[258].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //Korlát
                                    if (igen4 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[259].szoveg);

                                        Console.WriteLine(jptulaj[134].szoveg);
                                        Console.WriteLine(jptulaj[135].szoveg);
                                        string igen7;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen7 = Console.ReadLine();
                                        } while (igen7 != "1" && igen7 != "2");

                                        //Alszol
                                        if (igen7 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[136].szoveg);
                                            Console.WriteLine(jptulaj[137].szoveg);
                                            Console.WriteLine(jptulaj[138].szoveg);
                                            string igen8;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen8 = Console.ReadLine();
                                            } while (igen8 != "1" && igen8 != "2");

                                            //Indoraptor
                                            if (igen8 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[139].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[140].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[141].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[142].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[143].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[144].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[145].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[146].szoveg);

                                                Console.WriteLine(jptulaj[147].szoveg);
                                                Console.WriteLine(jptulaj[148].szoveg);
                                                string igen9;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen9 = Console.ReadLine();
                                                } while (igen9 != "1" && igen9 != "2");

                                                //Titokban
                                                if (igen9 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[149].szoveg);
                                                    Console.WriteLine(jptulaj[150].szoveg);
                                                    Console.WriteLine(jptulaj[151].szoveg);
                                                    string igen10;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen10 = Console.ReadLine();
                                                    } while (igen10 != "1" && igen10 != "2");

                                                    //Felveszed
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[152].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[153].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[154].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[155].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[156].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[157].szoveg);

                                                        Console.WriteLine(jptulaj[158].szoveg);
                                                        Console.WriteLine(jptulaj[159].szoveg);
                                                        string igen11;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen11 = Console.ReadLine();
                                                        } while (igen11 != "1" && igen11 != "2");

                                                        //Evakuáció - vég - ny
                                                        if (igen11 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[161].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen11 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Ignorálod - vég - ny
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[162].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[163].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[164].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[165].szoveg);

                                                        Console.WriteLine(jptulaj[166].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiüríted - vég -ny
                                                if (igen9 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[167].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Vezérlő
                                            if (igen8 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[168].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[169].szoveg);

                                                Console.WriteLine(jptulaj[170].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.Write("Dolgozó: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[171].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[172].szoveg);

                                                Console.WriteLine(jptulaj[173].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[174].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[175].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[176].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[177].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[178].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[179].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[180].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[181].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[182].szoveg);

                                                Console.WriteLine(jptulaj[183].szoveg);
                                                Console.WriteLine(jptulaj[184].szoveg);
                                                string igen12;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen12 = Console.ReadLine();
                                                } while (igen12 != "1" && igen12 != "2");

                                                //Vársz
                                                if (igen12 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[185].szoveg);
                                                    Console.WriteLine(jptulaj[186].szoveg);
                                                    Console.WriteLine(jptulaj[187].szoveg);
                                                    string igen13;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen13 = Console.ReadLine();
                                                    } while (igen13 != "1" && igen13 != "2");

                                                    //Kifutó
                                                    if (igen13 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[188].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[189].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[190].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[191].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[192].szoveg);

                                                        Console.WriteLine(jptulaj[193].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[194].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[195].szoveg);

                                                        Console.WriteLine(jptulaj[196].szoveg);
                                                        Console.WriteLine(jptulaj[197].szoveg);
                                                        string igen14;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen14 = Console.ReadLine();
                                                        } while (igen14 != "1" && igen14 != "2");

                                                        //Menkülsz - vég - b
                                                        if (igen14 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Iroda - vég - b
                                                        if (igen14 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[43].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Menkülsz - vég - b
                                                    if (igen13 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[160].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiküldöd
                                                if (igen12 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[198].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }
                                        }

                                        //Visszahívod
                                        if (igen7 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[199].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[132].szoveg);

                                            Console.WriteLine(jptulaj[201].szoveg);
                                            Console.WriteLine(jptulaj[202].szoveg);
                                            string igen15;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen15 = Console.ReadLine();
                                            } while (igen15 != "1" && igen15 != "2");

                                            //Mindent - vég - ny
                                            if (igen15 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[203].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Csak - vég - ny
                                            if (igen15 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[204].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                }

                                //Biztonság
                                if (igen3 == "2")
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[260].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[261].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[262].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[263].szoveg);

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("Tulaj: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[264].szoveg);

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("Jessie: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(jptulaj[265].szoveg);

                                    Console.WriteLine(jptulaj[119].szoveg);

                                    Console.WriteLine(jptulaj[120].szoveg);
                                    Console.WriteLine(jptulaj[121].szoveg);
                                    string igen4;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen4 = Console.ReadLine();
                                    } while (igen4 != "1" && igen4 != "2");

                                    //Korlátlan
                                    if (igen4 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[122].szoveg);
                                        Console.WriteLine(jptulaj[123].szoveg);
                                        Console.WriteLine(jptulaj[124].szoveg);
                                        string igen5;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen5 = Console.ReadLine();
                                        } while (igen5 != "1" && igen5 != "2");

                                        //Végig hallgatod
                                        if (igen5 == "1")
                                        {
                                            Console.Clear();

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //Számonkérés
                                        if (igen5 == "2")
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[256].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[257].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[258].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[125].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[126].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Jessie: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[127].szoveg);

                                            Console.WriteLine(jptulaj[128].szoveg);
                                            Console.WriteLine(jptulaj[129].szoveg);
                                            string igen6;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen6 = Console.ReadLine();
                                            } while (igen6 != "1" && igen6 != "2");

                                            //Engedsz
                                            if (igen6 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[130].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[131].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[132].szoveg);

                                                Console.WriteLine(jptulaj[133].szoveg);

                                                Console.WriteLine(jptulaj[134].szoveg);
                                                Console.WriteLine(jptulaj[135].szoveg);
                                                string igen7;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen7 = Console.ReadLine();
                                                } while (igen7 != "1" && igen7 != "2");

                                                //Alszol
                                                if (igen7 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[136].szoveg);
                                                    Console.WriteLine(jptulaj[137].szoveg);
                                                    Console.WriteLine(jptulaj[138].szoveg);
                                                    string igen8;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen8 = Console.ReadLine();
                                                    } while (igen8 != "1" && igen8 != "2");

                                                    //Indoraptor
                                                    if (igen8 == "1")
                                                    {
                                                        Console.Clear();

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[139].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[140].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[141].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[142].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[143].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[144].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[145].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[146].szoveg);

                                                        Console.WriteLine(jptulaj[147].szoveg);
                                                        Console.WriteLine(jptulaj[148].szoveg);
                                                        string igen9;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen9 = Console.ReadLine();
                                                        } while (igen9 != "1" && igen9 != "2");

                                                        //Titokban
                                                        if (igen9 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[149].szoveg);
                                                            Console.WriteLine(jptulaj[150].szoveg);
                                                            Console.WriteLine(jptulaj[151].szoveg);
                                                            string igen10;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen10 = Console.ReadLine();
                                                            } while (igen10 != "1" && igen10 != "2");

                                                            //Felveszed
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[152].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[153].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[154].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[155].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[156].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[157].szoveg);

                                                                Console.WriteLine(jptulaj[158].szoveg);
                                                                Console.WriteLine(jptulaj[159].szoveg);
                                                                string igen11;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen11 = Console.ReadLine();
                                                                } while (igen11 != "1" && igen11 != "2");

                                                                //Evakuáció - vég - ny
                                                                if (igen11 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[161].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Kikötő - vég - b
                                                                if (igen11 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Ignorálod - vég - ny
                                                            if (igen10 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[162].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[163].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[164].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[165].szoveg);

                                                                Console.WriteLine(jptulaj[166].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiüríted - vég -ny
                                                        if (igen9 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[167].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Vezérlő
                                                    if (igen8 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[168].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[169].szoveg);

                                                        Console.WriteLine(jptulaj[170].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[171].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[172].szoveg);

                                                        Console.WriteLine(jptulaj[173].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[174].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[175].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[176].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[177].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[178].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[179].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[180].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[181].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[182].szoveg);

                                                        Console.WriteLine(jptulaj[183].szoveg);
                                                        Console.WriteLine(jptulaj[184].szoveg);
                                                        string igen12;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen12 = Console.ReadLine();
                                                        } while (igen12 != "1" && igen12 != "2");

                                                        //Vársz
                                                        if (igen12 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[185].szoveg);
                                                            Console.WriteLine(jptulaj[186].szoveg);
                                                            Console.WriteLine(jptulaj[187].szoveg);
                                                            string igen13;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen13 = Console.ReadLine();
                                                            } while (igen13 != "1" && igen13 != "2");

                                                            //Kifutó
                                                            if (igen13 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[188].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[189].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[190].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[191].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[192].szoveg);

                                                                Console.WriteLine(jptulaj[193].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                                Console.Write("Tulaj: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[194].szoveg);

                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write("Jessie: ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(jptulaj[195].szoveg);

                                                                Console.WriteLine(jptulaj[196].szoveg);
                                                                Console.WriteLine(jptulaj[197].szoveg);
                                                                string igen14;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen14 = Console.ReadLine();
                                                                } while (igen14 != "1" && igen14 != "2");

                                                                //Menkülsz - vég - b
                                                                if (igen14 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[160].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }

                                                                //Iroda - vég - b
                                                                if (igen14 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[43].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }

                                                            //Menkülsz - vég - b
                                                            if (igen13 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[160].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kiküldöd
                                                        if (igen12 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[198].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }
                                                }

                                                //Visszahívod
                                                if (igen7 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[199].szoveg);

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("Dolgozó: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(jptulaj[132].szoveg);

                                                    Console.WriteLine(jptulaj[201].szoveg);
                                                    Console.WriteLine(jptulaj[202].szoveg);
                                                    string igen15;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen15 = Console.ReadLine();
                                                    } while (igen15 != "1" && igen15 != "2");

                                                    //Mindent - vég - ny
                                                    if (igen15 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[203].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Csak - vég - ny
                                                    if (igen15 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[204].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }
                                            }

                                            //Ragasztkodsz
                                            if (igen6 == "2")
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[205].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[206].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[207].szoveg);

                                                Console.WriteLine(jptulaj[208].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[209].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[210].szoveg);

                                                Console.WriteLine(jptulaj[211].szoveg);
                                                Console.WriteLine(jptulaj[212].szoveg);
                                                string igen16;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen16 = Console.ReadLine();
                                                } while (igen16 != "1" && igen16 != "2");

                                                //Aludni
                                                if (igen16 == "1" || igen16 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[213].szoveg);

                                                    Console.WriteLine(jptulaj[214].szoveg);
                                                    Console.WriteLine(jptulaj[215].szoveg);
                                                    string igen17;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen17 = Console.ReadLine();
                                                    } while (igen17 != "1" && igen17 != "2");

                                                    //Eligazító
                                                    if (igen17 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[216].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[217].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[218].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[219].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[220].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[221].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[222].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[223].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[224].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[225].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write("Dolgozó: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[226].szoveg);

                                                        Console.WriteLine(jptulaj[227].szoveg);
                                                        Console.WriteLine(jptulaj[228].szoveg);
                                                        string igen18;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen18 = Console.ReadLine();
                                                        } while (igen18 != "1" && igen18 != "2");

                                                        //Úthálózat
                                                        if (igen18 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[229].szoveg);

                                                            Console.WriteLine(jptulaj[230].szoveg);
                                                            Console.WriteLine(jptulaj[231].szoveg);
                                                            string igen19;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen19 = Console.ReadLine();
                                                            } while (igen19 != "1" && igen19 != "2");

                                                            //Iroda - vég - b
                                                            if (igen19 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[232].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Kikötő - vég - ny
                                                            if (igen19 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[233].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen18 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[234].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Utca
                                                    if (igen17 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[235].szoveg);
                                                        Console.WriteLine(jptulaj[237].szoveg);
                                                        string igen20;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen20 = Console.ReadLine();
                                                        } while (igen20 != "1" && igen20 != "2");

                                                        //Ball - vég - b
                                                        if (igen20 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[238].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Jobb
                                                        if (igen20 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[239].szoveg);
                                                            Console.WriteLine(jptulaj[240].szoveg);
                                                            Console.WriteLine(jptulaj[241].szoveg);
                                                            string igen21;
                                                            do
                                                            {
                                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                                igen21 = Console.ReadLine();
                                                            } while (igen21 != "1" && igen21 != "2");

                                                            //Épület - vég - b
                                                            if (igen21 == "1")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[242].szoveg);
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                            }

                                                            //Aluljáró
                                                            if (igen21 == "2")
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(jptulaj[243].szoveg);
                                                                Console.WriteLine(jptulaj[244].szoveg);
                                                                Console.WriteLine(jptulaj[245].szoveg);
                                                                string igen22;
                                                                do
                                                                {
                                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                                    igen22 = Console.ReadLine();
                                                                } while (igen22 != "1" && igen22 != "2");

                                                                //Vetítő
                                                                if (igen22 == "1")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[246].szoveg);
                                                                    Console.WriteLine(jptulaj[247].szoveg);
                                                                    Console.WriteLine(jptulaj[248].szoveg);
                                                                    string igen23;
                                                                    do
                                                                    {
                                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                                        igen23 = Console.ReadLine();
                                                                    } while (igen23 != "1" && igen23 != "2");

                                                                    //Szellőző
                                                                    if (igen23 == "1")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[249].szoveg);
                                                                        Console.WriteLine(jptulaj[250].szoveg);
                                                                        Console.WriteLine(jptulaj[251].szoveg);
                                                                        string igen24;
                                                                        do
                                                                        {
                                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                                            igen24 = Console.ReadLine();
                                                                        } while (igen24 != "1" && igen24 != "2");

                                                                        //Irodáig - vég - b
                                                                        if (igen24 == "1")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[252].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }

                                                                        //Kijössz - vég - ny
                                                                        if (igen24 == "2")
                                                                        {
                                                                            Console.Clear();
                                                                            Console.WriteLine(jptulaj[253].szoveg);
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                        }
                                                                    }

                                                                    //Elhagyni - vég - b
                                                                    if (igen23 == "2")
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine(jptulaj[254].szoveg);
                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                        Console.ForegroundColor = ConsoleColor.White;
                                                                    }
                                                                }

                                                                //Folyosó - vég - b
                                                                if (igen22 == "2")
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine(jptulaj[255].szoveg);
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //Korlát
                                    if (igen4 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jptulaj[259].szoveg);

                                        Console.WriteLine(jptulaj[134].szoveg);
                                        Console.WriteLine(jptulaj[135].szoveg);
                                        string igen7;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen7 = Console.ReadLine();
                                        } while (igen7 != "1" && igen7 != "2");

                                        //Alszol
                                        if (igen7 == "1")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[136].szoveg);
                                            Console.WriteLine(jptulaj[137].szoveg);
                                            Console.WriteLine(jptulaj[138].szoveg);
                                            string igen8;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen8 = Console.ReadLine();
                                            } while (igen8 != "1" && igen8 != "2");

                                            //Indoraptor
                                            if (igen8 == "1")
                                            {
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[139].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[140].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[141].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[142].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[143].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[144].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[145].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[146].szoveg);

                                                Console.WriteLine(jptulaj[147].szoveg);
                                                Console.WriteLine(jptulaj[148].szoveg);
                                                string igen9;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen9 = Console.ReadLine();
                                                } while (igen9 != "1" && igen9 != "2");

                                                //Titokban
                                                if (igen9 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[149].szoveg);
                                                    Console.WriteLine(jptulaj[150].szoveg);
                                                    Console.WriteLine(jptulaj[151].szoveg);
                                                    string igen10;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen10 = Console.ReadLine();
                                                    } while (igen10 != "1" && igen10 != "2");

                                                    //Felveszed
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[152].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[153].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[154].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[155].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[156].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[157].szoveg);

                                                        Console.WriteLine(jptulaj[158].szoveg);
                                                        Console.WriteLine(jptulaj[159].szoveg);
                                                        string igen11;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen11 = Console.ReadLine();
                                                        } while (igen11 != "1" && igen11 != "2");

                                                        //Evakuáció - vég - ny
                                                        if (igen11 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[161].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Kikötő - vég - b
                                                        if (igen11 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Ignorálod - vég - ny
                                                    if (igen10 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[162].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[163].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[164].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[165].szoveg);

                                                        Console.WriteLine(jptulaj[166].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiüríted - vég -ny
                                                if (igen9 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[167].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Vezérlő
                                            if (igen8 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[168].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[169].szoveg);

                                                Console.WriteLine(jptulaj[170].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.Write("Dolgozó: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[171].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[172].szoveg);

                                                Console.WriteLine(jptulaj[173].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[174].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[175].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[176].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[177].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[178].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[179].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[180].szoveg);

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Tulaj: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[181].szoveg);

                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write("Jessie: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(jptulaj[182].szoveg);

                                                Console.WriteLine(jptulaj[183].szoveg);
                                                Console.WriteLine(jptulaj[184].szoveg);
                                                string igen12;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen12 = Console.ReadLine();
                                                } while (igen12 != "1" && igen12 != "2");

                                                //Vársz
                                                if (igen12 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[185].szoveg);
                                                    Console.WriteLine(jptulaj[186].szoveg);
                                                    Console.WriteLine(jptulaj[187].szoveg);
                                                    string igen13;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen13 = Console.ReadLine();
                                                    } while (igen13 != "1" && igen13 != "2");

                                                    //Kifutó
                                                    if (igen13 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[188].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[189].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[190].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[191].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[192].szoveg);

                                                        Console.WriteLine(jptulaj[193].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Write("Tulaj: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[194].szoveg);

                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write("Jessie: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(jptulaj[195].szoveg);

                                                        Console.WriteLine(jptulaj[196].szoveg);
                                                        Console.WriteLine(jptulaj[197].szoveg);
                                                        string igen14;
                                                        do
                                                        {
                                                            Console.Write("Add meg a döntésted sorszámát! ");
                                                            igen14 = Console.ReadLine();
                                                        } while (igen14 != "1" && igen14 != "2");

                                                        //Menkülsz - vég - b
                                                        if (igen14 == "1")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[160].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }

                                                        //Iroda - vég - b
                                                        if (igen14 == "2")
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine(jptulaj[43].szoveg);
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                    }

                                                    //Menkülsz - vég - b
                                                    if (igen13 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[160].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Kiküldöd
                                                if (igen12 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[198].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszt.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }
                                        }

                                        //Visszahívod
                                        if (igen7 == "2")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(jptulaj[199].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jptulaj[132].szoveg);

                                            Console.WriteLine(jptulaj[201].szoveg);
                                            Console.WriteLine(jptulaj[202].szoveg);
                                            string igen15;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen15 = Console.ReadLine();
                                            } while (igen15 != "1" && igen15 != "2");

                                            //Mindent - vég - ny
                                            if (igen15 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[203].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            //Csak - vég - ny
                                            if (igen15 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[204].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Sikerült megfékezned a tomboló dinoszauruszokat.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }

                    //Dolgozó
                    if (mi == "2")
                    {
                        Console.Clear();
                        Console.WriteLine(jpdolgozo[0].szoveg);
                        Console.WriteLine(jpdolgozo[1].szoveg);
                        Console.WriteLine(jpdolgozo[2].szoveg);
                        string igen1;
                        do
                        {
                            Console.Write("Add meg a döntésted sorszámát! ");
                            igen1 = Console.ReadLine();
                        } while (igen1 != "1" && igen1 != "2");

                        //Sietsz (indoraptor)
                        if (igen1 == "1")
                        {
                            Console.Clear();

                            Console.WriteLine(jpdolgozo[3].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[4].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[5].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[6].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[7].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[8].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[9].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[10].szoveg);

                            Console.WriteLine(jpdolgozo[11].szoveg);
                            Console.WriteLine(jpdolgozo[12].szoveg);
                            string igen2;
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                igen2 = Console.ReadLine();
                            } while (igen2 != "1" && igen2 != "2");

                            //Miértén?
                            if (igen2 == "1")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Tulaj: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(jpdolgozo[13].szoveg);
                            }

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[14].szoveg);

                            Console.WriteLine(indoraptor);

                            Console.WriteLine(jpdolgozo[15].szoveg);
                            Console.WriteLine(jpdolgozo[16].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[17].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[18].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[19].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[20].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[21].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[22].szoveg);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Tulaj: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[23].szoveg);

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Dolgozó: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(jpdolgozo[24].szoveg);

                            Console.WriteLine(jpdolgozo[25].szoveg);
                            Console.WriteLine(jpdolgozo[26].szoveg);
                            string igen3;
                            do
                            {
                                Console.Write("Add meg a döntésted sorszámát! ");
                                igen3 = Console.ReadLine();
                            } while (igen3 != "1" && igen3 != "2");

                            //Hirdetés
                            if (igen3 == "1")
                            {
                                Console.Clear();
                                Console.WriteLine(jpdolgozo[27].szoveg);
                                Console.WriteLine(jpdolgozo[28].szoveg);
                                Console.WriteLine(jpdolgozo[29].szoveg);
                                string igen4;
                                do
                                {
                                    Console.Write("Add meg a döntésted sorszámát! ");
                                    igen4 = Console.ReadLine();
                                } while (igen4 != "1" && igen4 != "2");

                                //Vinni
                                if (igen4 == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine(jpdolgozo[30].szoveg);
                                    Console.WriteLine(jpdolgozo[31].szoveg);
                                    Console.WriteLine(jpdolgozo[32].szoveg);
                                    string igen5;
                                    do
                                    {
                                        Console.Write("Add meg a döntésted sorszámát! ");
                                        igen5 = Console.ReadLine();
                                    } while (igen5 != "1" && igen5 != "2");

                                    //Otthon
                                    if (igen5 == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jpdolgozo[33].szoveg);
                                        Console.WriteLine(jpdolgozo[34].szoveg);
                                        Console.WriteLine(jpdolgozo[35].szoveg);
                                        string igen6;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen6 = Console.ReadLine();
                                        } while (igen6 != "1" && igen6 != "2");

                                        //Felevesz
                                        if (igen6 == "1")
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[38].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[39].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[40].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[41].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[42].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[43].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[44].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[43].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[44].szoveg);

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("Dolgozó: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[45].szoveg);

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Tulaj: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(jpdolgozo[46].szoveg);

                                            Console.WriteLine(jpdolgozo[47].szoveg);
                                            Console.WriteLine(jpdolgozo[48].szoveg);
                                            string igen7;
                                            do
                                            {
                                                Console.Write("Add meg a döntésted sorszámát! ");
                                                igen7 = Console.ReadLine();
                                            } while (igen7 != "1" && igen7 != "2");

                                            //Megkeresed
                                            if (igen7 == "1")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jpdolgozo[50].szoveg);
                                                Console.WriteLine(jpdolgozo[51].szoveg);
                                                string igen8;
                                                do
                                                {
                                                    Console.Write("Add meg a döntésted sorszámát! ");
                                                    igen8 = Console.ReadLine();
                                                } while (igen8 != "1" && igen8 != "2");

                                                //Jobb
                                                if (igen8 == "1")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jpdolgozo[53].szoveg);
                                                    Console.WriteLine(jpdolgozo[54].szoveg);
                                                    Console.WriteLine(jpdolgozo[55].szoveg);
                                                    string igen9;
                                                    do
                                                    {
                                                        Console.Write("Add meg a döntésted sorszámát! ");
                                                        igen9 = Console.ReadLine();
                                                    } while (igen9 != "1" && igen9 != "2");

                                                    //Segíteni - vég -ny
                                                    if (igen9 == "1")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[57].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Sikerült megakadályoznod egy katasztrófát.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }

                                                    //Menkülni - vég - b
                                                    if (igen9 == "2")
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine(jptulaj[56].szoveg);
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                    }
                                                }

                                                //Ball - vég -ny
                                                if (igen8 == "2")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(jptulaj[58].szoveg);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Sikerült megakadályoznod egy katasztrófát.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            }

                                            //Menekülsz - vég - b
                                            if (igen7 == "2")
                                            {
                                                Console.Clear();
                                                Console.WriteLine(jptulaj[49].szoveg);
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Nem sikerült kijutnod a szigetről.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                        //Letesz
                                        if (igen6 == "2")
                                        {
                                            Console.Clear();

                                        }
                                    }

                                    //Vezérlőben
                                    if (igen5 == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(jpdolgozo[33].szoveg);
                                        Console.WriteLine(jpdolgozo[34].szoveg);
                                        Console.WriteLine(jpdolgozo[35].szoveg);
                                        string igen6;
                                        do
                                        {
                                            Console.Write("Add meg a döntésted sorszámát! ");
                                            igen6 = Console.ReadLine();
                                        } while (igen6 != "1" && igen6 != "2");

                                        //Felévesz
                                        if (igen6 == "1")
                                        {
                                            Console.Clear();

                                        }
                                        //Letesz
                                        if (igen6 == "2")
                                        {
                                            Console.Clear();

                                        }
                                    }
                                }

                                //Dobni
                                if (igen4 == "2")
                                {
                                    Console.Clear();

                                }
                            }

                            //Korlát
                            if (igen3 == "2")
                            {
                                Console.Clear();

                            }
                        }

                        //Pontos vagy (indominusz rex)
                        if (igen1 == "2")
                        {
                            Console.Clear();
                            Console.WriteLine(indominusrex2);
                        }
                    }
                }


                do
                {
                    Console.Write("Visszamész a menübe? [i/n] ");
                    akarsz = Console.ReadLine();
                } while (akarsz!="i" && akarsz != "n");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Készítette:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\tH");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("egedűs ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("J");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("anka");

            Console.ReadKey();
        }
    }
}
