using System;
using System.Linq;
using System.IO;
using System.ComponentModel;

namespace Pøevod_souboru
{
    public class Statistiky
    {
        public string Soubor { get; set; }

        public long DelkaSouboru { get; set; }

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
                    // konec øádku se bere jako bílý znak
                    posledniBily = true;

                    while (i < delka)
                    {
                        c = radek[i];

                        #region pøipoèti slovo
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
                        #endregion

                        #region pøipoèti vìtu
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
