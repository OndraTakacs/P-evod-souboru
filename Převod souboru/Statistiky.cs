using System;
using System.Linq;
using System.IO;
using System.ComponentModel;

namespace P�evod_souboru
{

    /// <summary>
    /// T��da, kter� po��t� statistiky souboru: po�et v�t, slov, znak� a ��dk�
    /// </summary>
    public class Statistiky
    {

        /// <summary>
        /// Soubor, jeho� statistiky se maj� spo��tat
        /// </summary>
        public string Soubor { get; set; }


        /// <summary>
        /// D�lka souboru ve znac�ch
        /// </summary>
        public long DelkaSouboru { get; set; }

        /// <summary>
        /// Po�et posloupnost� znak�, v�etn� b�l�ch, odd�len�ch te�kou.
        /// N�kolik te�ek za sebou se po��t� jako jedno ukon�en� v�ty, ne n�kolik v�t
        /// </summary>
        public long Vety { get; private set; }

        /// <summary>
        /// jak�koliv znak odd�len� b�l�m znakem
        /// </summary>
        public long Slova { get; private set; }

        /// <summary>
        /// po�et jak�chkoliv znak�, v�etn� b�l�ch
        /// </summary>
        public long Znaky { get; private set; }


        /// <summary>
        /// Po�et ��dk� v souboru
        /// </summary>
        public long Radky { get; private set; }

        /// <summary>
        /// byl posledn� na�ten� znak b�l�?
        /// </summary>
        private bool posledniBily = true;

        /// <summary>
        /// byl posledn� znak te�ka?
        /// </summary>
        private bool posledniTecka = true;

        /// <summary>
        /// Po�et znak� na ��dku, po kter�m se aktualizuje stav zpracov�n�
        /// </summary>
        private static int krokZpracovani = 5000;


        /// <summary>
        /// Spo��t� statistiky souboru
        /// </summary>
        /// <param name="sender">BackgroundWorker, kter� volal tuto metodu</param>
        /// <param name="e">Ud�lost BackgroudnWorkera</param>
        public void spocitej(object sender, DoWorkEventArgs e)
        {
            #region na�ten� odhadu d�lky souboru
            FileInfo info = new FileInfo(Soubor);
            DelkaSouboru = info.Length;
            #endregion

            BackgroundWorker worker = sender as BackgroundWorker;
            reset();
            // stav zpracov�n� statistik
            long stav = 0;
            // stav zpracov�n� v promile
            int promile = 0;
            // Pomocn� prom�nn� pro v�po�et dostate�n� zm�ny stavu
            int starePromile = 0;


            using (StreamReader sr = new StreamReader(Soubor))
            {
                // ��dek vstupn�ho souboru
                string radek;
                // pro ka�d� ��dek
                while ((radek = sr.ReadLine()) != null)
                {
                    // p�i�ten� ��dk�
                    Radky++;

                    #region p�i�ten� d�lky
                    int delka = radek.Length;
                    Znaky += delka;
                    #endregion

                    // index pozice na ��dku
                    int i = 0;
                    // aktu�ln� na�ten� znak
                    char c;
                    // ud�v� o kolik byl zv��en pr�b�n� stav zpracov�n�
                    long stavZvysen = 0;
                    // konec ��dku se bere jako b�l� znak
                    posledniBily = true;

                    // zpracov�n� ka�d�ho znaku ��dku pro spo��t�n� slov a v�t
                    while (i < delka)
                    {
                        c = radek[i];

                        #region p�ipo�te slovo
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

                        #region p�ipo�te v�tu
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

                        #region po��t�n� pr�b�n�ho stavu zpracov�n�
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
                    #region navr�cen� stavu na p�vodn� hodnotu, aby se vyrovnalo druh� zv��en� na konci ��dku
                    if (stavZvysen > 0)
                    {
                        stav -= stavZvysen;
                    }
                    #endregion

                    #region aktualizace stavu zpracov�n�
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

                    #region o�et�en� zru�en� po��t�n� statistik
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
        /// Vynuluje prom�nn� p�ed nov�m po��t�n�m statistik
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
