using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace Pøevod_souboru
{
    public class Prevod
    {
        private string vstupniSoubor;
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
        public string VystupniSoubor { private get; set; }
        public Encoding Kodovani{ get; set; }

        private long stav = 0;
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

        private int starePromile = 0;
        private BackgroundWorker worker;

        public event EventHandler<StavEventArgs> zmenaStavu;
        protected virtual void onZmenaStavu(StavEventArgs e)
        {
            zmenaStavu?.Invoke(this, e);
        }

        // má se odstranit diakritika?
        public bool odstranitDiakritiku { get; set; } = false;
        // mají se odstranit prázdné øádky?
        public bool odstranitRadky { get; set; } = false;
        // mají se odstranit mezery a interpunkce a použít CamelCase?
        public bool odstranitInterpunkci { get; set; } = false;

        public long DelkaSouboru { get; set; } = 0;

        private bool posledniBilyInterpunkce = false;

        // poèet znakù po kterém se aktualizuje stav zpracování
        private static int krokZpracovani = 5000;

        private static int jeNahled = -1;


        public string preved(int maxRadku = -1, object sender = null, DoWorkEventArgs e = null)
        {
            string nahled = "";
            int radku = 0;
            reset();

            worker = sender as BackgroundWorker;
            StreamWriter sw = null;
            using (StreamReader sr = new StreamReader(VstupniSoubor))
            {
                if (!(maxRadku > jeNahled))
                {
                    sw = new StreamWriter(new FileStream(VystupniSoubor, FileMode.Create), Kodovani);
                }
                string radek;
                string novyRadekString = "";
                while ((radek = sr.ReadLine()) != null)
                {
                    // udává o kolik byl zvýšen prùbìžný stav zpracování
                    long stavZvysen = 0;
                    // použití pole znakù pro vìtší efektivitu
                    char[] novyRadek = new char[radek.Length];
                    if (odstranitDiakritiku || odstranitInterpunkci)
                    {
                        int i = 0;
                        int j = 0;
                        char c;
                        char novy;

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

                            // poèítání prùbìžného stavu zpracování
                            if (i % krokZpracovani == 0)
                            {
                                Stav += krokZpracovani;
                                stavZvysen += krokZpracovani;

                                // ošetøení náhledu pøi velmi dlouhém øádku
                                if (maxRadku > jeNahled)
                                {
                                    return nahled + novyRadek;
                                }
                            } 

                            if (worker != null && worker.CancellationPending)
                            {
                                e.Cancel = true;
                                if (!(maxRadku > jeNahled))
                                    sw.Close();
                                return nahled;
                            }  
                        }
                        if (j > 0)
                            novyRadekString = new string(novyRadek);
                        else
                            novyRadekString = "";

                        // navrácení stavu na pùvodní hodnotu, aby se vyrovnalo druhé zvýšení na konci øádku
                        if (stavZvysen > 0)
                        {
                            stav -= stavZvysen;
                        }
                    }
                    else
                        novyRadekString = radek;

                    if (!odstranPrazdnyRadek(novyRadekString))
                    {
                        if (maxRadku > jeNahled)
                        {
                            nahled += novyRadekString.Trim('\0') + System.Environment.NewLine;
                            radku++;
                            if (maxRadku > jeNahled && radku >= maxRadku)
                            {
                                return nahled;
                            }
                        }
                        else
                        {
                            if (sr.Peek() == -1)
                            {
                                sw.Write(novyRadekString);
                            }
                            else
                                sw.WriteLine(novyRadekString);
                        }
                    }

                    Stav += radek.Length;
                }
            }
            sw.Close();
            return nahled;
        }

        // vrací true, když se má odstranit øádek
        private bool odstranPrazdnyRadek(string radek)
        {
            if (!odstranitRadky)
                return false;
            if (radek.Length > 0)
                return false;
            return true;
        }

        // vrací true, když se má odstranit znak
        private bool odstranDiakritiku(char c)
        {
            if (!odstranitDiakritiku)
                return false;
            if (Diakritika.pismena.Contains(c))
                return true;
            return false;
        }

        // vrací true, když se má odstranit znak
        private bool odstranMezeryInterpunkci(char c)
        {
            if (!odstranitInterpunkci)
                return false;
            if (Interpunkce.interpunkce.Contains(c) || char.IsWhiteSpace(c))
                return true;
            return false;
        }

        // vypoète camelCase. Funkce se v kódu nevolá kvùli vìtši efektivitì výpoètu
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

        private void reset()
        {
            stav = 0;
            starePromile = 0;
        }
    }

    public class StavEventArgs : EventArgs
    {
        public int stav;
        public StavEventArgs(int s)
        {
            stav = s;
        }
    }
}
