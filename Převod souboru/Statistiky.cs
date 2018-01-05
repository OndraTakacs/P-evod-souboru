using System;
using System.Linq;
using System.IO;
using System.ComponentModel;

namespace Pøevod_souboru
{

    /// <summary>
    /// Tøída, která poèítá statistiky souboru: poèet vìt, slov, znakù a øádkù
    /// </summary>
    public class Statistiky
    {

        /// <summary>
        /// Soubor, jehož statistiky se mají spoèítat
        /// </summary>
        public string Soubor { get; set; }


        /// <summary>
        /// Délka souboru ve znacích
        /// </summary>
        public long DelkaSouboru { get; set; }

        /// <summary>
        /// Poèet posloupností znakù, vèetnì bílých, oddìlených teèkou.
        /// Nìkolik teèek za sebou se poèítá jako jedno ukonèení vìty, ne nìkolik vìt
        /// </summary>
        public long Vety { get; private set; }

        /// <summary>
        /// jakýkoliv znak oddìlený bílým znakem
        /// </summary>
        public long Slova { get; private set; }

        /// <summary>
        /// poèet jakýchkoliv znakù, vèetnì bílých
        /// </summary>
        public long Znaky { get; private set; }


        /// <summary>
        /// Poèet øádkù v souboru
        /// </summary>
        public long Radky { get; private set; }

        /// <summary>
        /// byl poslední naètený znak bílý?
        /// </summary>
        private bool posledniBily = true;

        /// <summary>
        /// byl poslední znak teèka?
        /// </summary>
        private bool posledniTecka = true;

        /// <summary>
        /// Poèet znakù na øádku, po kterém se aktualizuje stav zpracování
        /// </summary>
        private static int krokZpracovani = 5000;


        /// <summary>
        /// Spoèítá statistiky souboru
        /// </summary>
        /// <param name="sender">BackgroundWorker, který volal tuto metodu</param>
        /// <param name="e">Událost BackgroudnWorkera</param>
        public void spocitej(object sender, DoWorkEventArgs e)
        {
            #region naètení odhadu délky souboru
            FileInfo info = new FileInfo(Soubor);
            DelkaSouboru = info.Length;
            #endregion

            BackgroundWorker worker = sender as BackgroundWorker;
            reset();
            // stav zpracování statistik
            long stav = 0;
            // stav zpracování v promile
            int promile = 0;
            // Pomocná promìnná pro výpoèet dostateèné zmìny stavu
            int starePromile = 0;


            using (StreamReader sr = new StreamReader(Soubor))
            {
                // øádek vstupního souboru
                string radek;
                // pro každý øádek
                while ((radek = sr.ReadLine()) != null)
                {
                    // pøiètení øádkù
                    Radky++;

                    #region pøiètení délky
                    int delka = radek.Length;
                    Znaky += delka;
                    #endregion

                    // index pozice na øádku
                    int i = 0;
                    // aktuálnì naètený znak
                    char c;
                    // udává o kolik byl zvýšen prùbìžný stav zpracování
                    long stavZvysen = 0;
                    // konec øádku se bere jako bílý znak
                    posledniBily = true;

                    // zpracování každého znaku øádku pro spoèítání slov a vìt
                    while (i < delka)
                    {
                        c = radek[i];

                        #region pøipoète slovo
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

                        #region pøipoète vìtu
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

                        #region poèítání prùbìžného stavu zpracování
                        if (i % krokZpracovani == 0)
                        {
                            stav += krokZpracovani;
                            stavZvysen += krokZpracovani;

                            promile = (int)(1000 * stav / DelkaSouboru);
                            if (promile > 1000)
                            {
                                promile = 1000;
                            }
                            if (promile - starePromile > 0)
                            {
                                starePromile = promile;
                                worker.ReportProgress(promile);
                            }
                        }
                        #endregion
                    }
                    #region navrácení stavu na pùvodní hodnotu, aby se vyrovnalo druhé zvýšení na konci øádku
                    if (stavZvysen > 0)
                    {
                        stav -= stavZvysen;
                    }
                    #endregion

                    #region aktualizace stavu zpracování
                    stav += radek.Length + 4;
                    promile = (int)(1000 * stav / DelkaSouboru);
                    if (promile > 1000)
                    {
                        promile = 1000;
                    }
                    if (promile - starePromile > 0)
                    {
                        starePromile = promile;
                        worker.ReportProgress(promile);
                    }
                    #endregion

                    #region ošetøení zrušení poèítání statistik
                    if (worker.CancellationPending)
                    {
                        Znaky = DelkaSouboru;
                        e.Cancel = true;
                        break;
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// Vynuluje promìnné pøed novým poèítáním statistik
        /// </summary>
        private void reset()
        {
            Vety = 0;
            Radky = 0;
            Slova = 0;
            Znaky = 0;
            posledniBily = true;
            posledniTecka = true;
        }

    }
}
