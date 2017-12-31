using System;
using System.Collections.Generic;

namespace Pøevod_souboru
{
    public class Statistiky
    {
        public string Soubor { get; set; }

        public long Vety { get; private set; }

        public long Slova { get; private set; }

        public long Znaky { get; private set; }

        public long Radky { get; private set; }

        /*
        public Dictionary<string, bool> Spocitej =
            new Dictionary<string, bool>
            {
                { "vety", 1 },
                { "slova", 1 },
                { "znaky", 1 },
                { "radky", 1 }
            };
         */

        public void spocitej()
        {
            Vety = 1;
            Slova = 1;
            Radky = 1;
            Znaky = 1;
        }


    }
}
