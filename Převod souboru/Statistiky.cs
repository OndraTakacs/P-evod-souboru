using System;
using System.IO;

namespace Pøevod_souboru
{
    public class Statistiky
    {
        public string Soubor { get; set; }

        // poèet posloupností znakù, vèetnì bílých, oddìlených teèkou
        // nìkolik teèek za sebou se poèítá jako jedno ukonèení vìty, ne nìkolik vìt
        public long Vety { get; private set; }

        // jakýkoliv znak oddìlený bílým znakem
        public long Slova { get; private set; }

        // poèet jakýchkoliv znakù, vèetnì bílých
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

        // byl poslední naètený znak bílý?
        private bool posledniBily = true;
        
        // byl poslední znak teèka?
        private bool posledniTecka = true;

        public void spocitej()
        {
            using (StreamReader sr = new StreamReader(Soubor))
            {
                string radek;
                while ((radek = sr.ReadLine()) != null)
                {
                    Radky++;

                    int delka = radek.Length;
                    Znaky += delka;

                    int i = 0;
                    char c;

                    // konec øádku se bere jako bílý znak
                    posledniBily = true;

                    while (i < delka)
                    {
                        c = radek[i];

                        pripoctiSlovo(c);
                        pripoctiVetu(c);

                        i++;
                    }
                }
            }
        }

        private void pripoctiSlovo(char c)
        {
            if (char.IsWhiteSpace(c))
            {
                posledniBily = true;
            }
            // naètený znak
            else
            {
                // byl naèten znak a znak pøed ním byl bílý, takže se jedná o nové slovo
                if (posledniBily == true)
                    Slova++;

                posledniBily = false;
            }
        }

        private void pripoctiVetu(char c)
        {
            if (c == '.')
            {
                if (!posledniTecka)
                    Vety++;
                posledniTecka = true;
            }
            else
                posledniTecka = false;
        }

    }
}
