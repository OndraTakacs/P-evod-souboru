using System;
using System.IO;

namespace P�evod_souboru
{
    public class Statistiky
    {
        public string Soubor { get; set; }

        // po�et posloupnost� znak�, v�etn� b�l�ch, odd�len�ch te�kou
        // n�kolik te�ek za sebou se po��t� jako jedno ukon�en� v�ty, ne n�kolik v�t
        public long Vety { get; private set; }

        // jak�koliv znak odd�len� b�l�m znakem
        public long Slova { get; private set; }

        // po�et jak�chkoliv znak�, v�etn� b�l�ch
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

        // byl posledn� na�ten� znak b�l�?
        private bool posledniBily = true;
        
        // byl posledn� znak te�ka?
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

                    // konec ��dku se bere jako b�l� znak
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
            // na�ten� znak
            else
            {
                // byl na�ten znak a znak p�ed n�m byl b�l�, tak�e se jedn� o nov� slovo
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
