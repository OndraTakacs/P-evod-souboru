using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace Pøevod_souboru
{

    /// <summary>
    /// Tøída realizující pøevod souboru
    /// </summary>
    public class Prevod
    {
        private string vstupniSoubor;
        /// <summary>
        /// Soubor, která se má pøevádìt
        /// </summary>
        public string VstupniSoubor {
            get
            {
                return vstupniSoubor;
            }
            set
            {
                vstupniSoubor = value;
                Kodovani = new StreamReader(value).CurrentEncoding;
                FileInfo info = new FileInfo(value);
                DelkaSouboru = info.Length;
            }
        }

        
        /// <summary>
        /// Soubor, do kterého se mají uložit výsledky
        /// </summary>
        public string VystupniSoubor { private get; set; }

        /// <summary>
        /// Kódování vstupního a výstupního souboru. Automaticky rozpoznává jen UTF-8
        /// </summary>
        public Encoding Kodovani{ get; set; }



        private long stav = 0;
        /// <summary>
        /// Stav zpracování souboru v poètu pøeètených znakù
        /// </summary>
        public long Stav
        {
            get
            {
                return stav;
            }
            private set
            {
                stav = value;
                int promile = (int)(1000 * value / DelkaSouboru);
                if (promile > 1000)
                {
                    promile = 1000;
                }
                if (promile - starePromile > 0)
                {
                    starePromile = promile;
                    if (worker != null)
                    {
                        worker.ReportProgress(promile);
                    }
                }
            }
        }


        /// <summary>
        /// Pomocná promìnná pro výpoèet dostateèné zmìny stavu
        /// </summary>
        private int starePromile = 0;

        private BackgroundWorker worker;

        /// <summary>
        /// má se odstranit diakritika?
        /// </summary>
        public bool odstranitDiakritiku { get; set; } = false;

        /// <summary>
        /// mají se odstranit prázdné øádky?
        /// </summary>
        public bool odstranitRadky { get; set; } = false;

        /// <summary>
        /// mají se odstranit mezery a interpunkce a použít CamelCase?
        /// </summary>
        public bool odstranitInterpunkci { get; set; } = false;


        /// <summary>
        /// Délka souboru ve znacích
        /// </summary>
        public long DelkaSouboru { get; set; } = 0;

        
        /// <summary>
        /// Byl poslední naètený znak pøed aktuálním znakem bílý nebo interpunkce?
        /// </summary>
        private bool posledniBilyInterpunkce = false;

        /// <summary>
        /// Poèet znakù na øádku, po kterém se aktualizuje stav zpracování
        /// </summary>
        private static int krokZpracovani = 5000;


        /// <summary>
        /// Konstanta, která urèuje, kdy se nejedná o náhled
        /// </summary>
        private static int neniNahled = -1;


        /// <summary>
        /// Zpracuje soubor uložený ve vstupniSoubor a výstup vrátí ve formì náhledu nebo jej zapíše do souboru
        /// </summary>
        /// <param name="maxRadku"> maximální poèet øádkù pøi náhlade, -1 udává, že nejde o náhled</param>
        /// <param name="sender">BackgroundWorker, který volal tuto metodu</param>
        /// <param name="e">Událost od BackgroundWorkera</param>
        /// <returns>Náhled prvních nìkolika øádkù zpracovaného souboru</returns>
        public string preved(int maxRadku = -1, object sender = null, DoWorkEventArgs e = null)
        {
            string nahled = "";
            int radku = 0;
            reset();

            worker = sender as BackgroundWorker;
            StreamWriter sw = null;
            using (StreamReader sr = new StreamReader(VstupniSoubor))
            {
                // když se nejedná o náhled, tak se zapisuje na výstup
                if (maxRadku == neniNahled)
                {
                    sw = new StreamWriter(new FileStream(VystupniSoubor, FileMode.Create), Kodovani);
                }
                // øádek naètený ze vstupního souboru
                string radek;
                // øádek, který se má zapsat na výstup nebo do náhledu
                string novyRadekString = "";
                // pro každý øádek souboru
                while ((radek = sr.ReadLine()) != null)
                {
                    // udává o kolik byl zvýšen prùbìžný stav zpracování
                    long stavZvysen = 0;
                    // použití pole znakù pro nový øádek pro vìtší efektivitu
                    char[] novyRadek = new char[radek.Length];

                    // jestli se má odstranit diakritika nebo interpunkce, je tøeba projít všechny znaky øádku
                    if (odstranitDiakritiku || odstranitInterpunkci)
                    {
                        // index vstupního øádku
                        int i = 0;
                        // index výstupního øádku
                        int j = 0;
                        // aktuálnì naètený znak
                        char c;
                        // novì naètený znak
                        char novy;

                        // zpracování všech znakù øádku
                        while (i < radek.Length)
                        {
                            c = radek[i];

                            #region výpoèet CamelCase
                            novy = c;
                            if (odstranitInterpunkci)
                            {
                                if (char.IsWhiteSpace(c) || Interpunkce.interpunkce.Contains(c))
                                {
                                    posledniBilyInterpunkce = true;
                                }
                                // naètený znak
                                else
                                {
                                    // byl naèten znak a znak pøed ním byl bílý, takže se jedná o nové slovo
                                    if (posledniBilyInterpunkce == true)
                                    {
                                        novy = char.ToUpper(c);
                                    }
                                    posledniBilyInterpunkce = false;
                                }
                            }
                            #endregion

                            // když se nemá odstranit diakritika nebo se má odstranit a diakritiku neobsahuje
                            if ((!odstranitDiakritiku || (odstranitDiakritiku && !Diakritika.pismena.Contains(c)))
                                // a když se má nemá odstranit intrepunkce a mezery nebo má odstranit a interpunkci neobsahuje a neobsahuje bílý znak
                                && (!odstranitInterpunkci || (odstranitInterpunkci && !Interpunkce.interpunkce.Contains(c) && !char.IsWhiteSpace(c))))
                            // tak se zapíše nový znak
                            {
                                novyRadek[j] = novy;
                                j++;
                            }
                            i++;

                            #region poèítání prùbìžného stavu zpracování
                            if (i % krokZpracovani == 0)
                            {
                                Stav += krokZpracovani;
                                stavZvysen += krokZpracovani;

                                // ošetøení náhledu pøi velmi dlouhém øádku
                                if (maxRadku > neniNahled)
                                {
                                    return nahled + novyRadek;
                                }
                            }
                            #endregion

                            #region zpracování požadavku na pøerušení operace
                            if (worker != null && worker.CancellationPending)
                            {
                                e.Cancel = true;
                                if (!(maxRadku > neniNahled))
                                    sw.Close();
                                return nahled;
                            }
                            #endregion
                        }

                        #region ošetøení vkládání prázných znakù do øetìzce
                        if (j > 0)
                            novyRadekString = new string(novyRadek);
                        else
                            novyRadekString = "";
                        #endregion

                        #region navrácení stavu na pùvodní hodnotu, aby se vyrovnalo druhé zvýšení na konci øádku
                        if (stavZvysen > 0)
                        {
                            stav -= stavZvysen;
                        }
                        #endregion
                    }
                    // nebylo tøeba zpracovávat øádek
                    else
                        novyRadekString = radek;

                    // pokud se nemá pøeskoèit prázdný øádek
                    if (!odstranPrazdnyRadek(novyRadekString))
                    {
                        #region uložení náhledu
                        if (maxRadku > neniNahled)
                        {
                            nahled += novyRadekString.Trim('\0') + System.Environment.NewLine;
                            radku++;
                            if (maxRadku > neniNahled && radku >= maxRadku)
                            {
                                return nahled;
                            }
                        }
                        #endregion
                        #region uložení do výstupního souboru
                        else
                        {
                            if (sr.Peek() == -1)
                            {
                                sw.Write(novyRadekString);
                            }
                            else
                                sw.WriteLine(novyRadekString);
                        }
                        #endregion
                    }
                    // aktualizase stavu zpracování
                    Stav += radek.Length;
                }
            }
            sw.Close();
            return nahled;
        }

        /// <summary>
        /// Má se odstranit prázdný øádek?
        /// </summary>
        /// <param name="radek">Øádek dat</param>
        /// <returns>True pokud se má øádek odstranit</returns>
        private bool odstranPrazdnyRadek(string radek)
        {
            if (!odstranitRadky)
                return false;
            if (radek.Length > 0)
                return false;
            return true;
        }

        /// <summary>
        /// Má se odstranit znak?
        /// </summary>
        /// <param name="c">Znak, jehož odstranìní se posuzuje</param>
        /// <returns>Vrací true, když se má odstranit znak</returns>
        private bool odstranDiakritiku(char c)
        {
            if (!odstranitDiakritiku)
                return false;
            if (Diakritika.pismena.Contains(c))
                return true;
            return false;
        }

        // 

        /// <summary>
        /// Má se odstranit tento znak v pøípadì mezery nebo interpunkce?
        /// </summary>
        /// <param name="c">Posuzovaný znak</param>
        /// <returns>Vrací true, když se má odstranit zadaný znak</returns>
        private bool odstranMezeryInterpunkci(char c)
        {
            if (!odstranitInterpunkci)
                return false;
            if (Interpunkce.interpunkce.Contains(c) || char.IsWhiteSpace(c))
                return true;
            return false;
        }

        /// <summary>
        /// Vypoète CamelCase. Funkce se v kódu nevolá kvùli vìtši efektivitì výpoètu
        /// </summary>
        /// <param name="c">Znak, který se má pøevádìt</param>
        /// <returns>pùvodní znak nebo velký znak</returns>
        private char camelCase(char c)
        {
            if (!odstranitInterpunkci)
                return c;

            if (char.IsWhiteSpace(c) || Interpunkce.interpunkce.Contains(c))
            {
                posledniBilyInterpunkce = true;
            }
            // naètený znak
            else
            {
                // byl naèten znak a znak pøed ním byl bílý, takže se jedná o nové slovo
                if (posledniBilyInterpunkce == true)
                {
                    posledniBilyInterpunkce = false;
                    return char.ToUpper(c);
                }
                posledniBilyInterpunkce = false;
            }

            return c;
        }


        /// <summary>
        /// Znovunastavení promìnných tøídy
        /// </summary>
        private void reset()
        {
            stav = 0;
            starePromile = 0;
            posledniBilyInterpunkce = false;
        }
    }
}
