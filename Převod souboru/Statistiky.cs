using System;
using System.Linq;
using System.IO;
using System.ComponentModel;

namespace P�evod_souboru
{
    public class Statistiky
    {
        public string Soubor { get; set; }

        public long DelkaSouboru { get; set; }

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

        public void spocitej(object sender, DoWorkEventArgs e)
        {
            FileInfo info = new FileInfo(Soubor);
            DelkaSouboru = info.Length;

            BackgroundWorker worker = sender as BackgroundWorker;
            reset();
            long stav = 0;
            int starePromile = 0;

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

                        #region p�ipo�ti slovo
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
                        #endregion

                        #region p�ipo�ti v�tu
                        if (Interpunkce.konecVety.Contains(c))
                        {
                            if (!posledniTecka)
                                Vety++;
                            posledniTecka = true;
                        }
                        else
                            posledniTecka = false;
                        #endregion

                        i++;
                    }

                    stav += radek.Length + 4;
                    int promile = (int)(1000 * stav / DelkaSouboru);
                    if (promile > 1000)
                    {
                        promile = 1000;
                    }
                    if (promile - starePromile > 0)
                    {
                        starePromile = promile;
                        worker.ReportProgress(promile);
                    }

                    if (worker.CancellationPending)
                    {
                        Znaky = DelkaSouboru;
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }

        private void reset()
        {
            Vety = 0;
            Radky = 0;
            Slova = 0;
            Znaky = 0;
        }

    }
}
