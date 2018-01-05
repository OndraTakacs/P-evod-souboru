using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace P�evod_souboru
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

        // m� se odstranit diakritika?
        public bool odstranitDiakritiku { get; set; } = false;
        // maj� se odstranit pr�zdn� ��dky?
        public bool odstranitRadky { get; set; } = false;
        // maj� se odstranit mezery a interpunkce a pou��t CamelCase?
        public bool odstranitInterpunkci { get; set; } = false;

        public long DelkaSouboru { get; set; } = 0;

        private bool posledniBilyInterpunkce = false;

        // po�et znak� po kter�m se aktualizuje stav zpracov�n�
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
                    // ud�v� o kolik byl zv��en pr�b�n� stav zpracov�n�
                    long stavZvysen = 0;
                    // pou�it� pole znak� pro v�t�� efektivitu
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

                            #region v�po�et CamelCase
                            novy = c;
                            if (odstranitInterpunkci)
                            {
                                if (char.IsWhiteSpace(c) || Interpunkce.interpunkce.Contains(c))
                                {
                                    posledniBilyInterpunkce = true;
                                }
                                // na�ten� znak
                                else
                                {
                                    // byl na�ten znak a znak p�ed n�m byl b�l�, tak�e se jedn� o nov� slovo
                                    if (posledniBilyInterpunkce == true)
                                    {
                                        novy = char.ToUpper(c);
                                    }
                                    posledniBilyInterpunkce = false;
                                }
                            }
                            #endregion

                            // kdy� se nem� odstranit diakritika nebo se m� odstranit a diakritiku neobsahuje
                            if ((!odstranitDiakritiku || (odstranitDiakritiku && !Diakritika.pismena.Contains(c)))
                                // a kdy� se m� nem� odstranit intrepunkce a mezery nebo m� odstranit a interpunkci neobsahuje a neobsahuje b�l� znak
                                && (!odstranitInterpunkci || (odstranitInterpunkci && !Interpunkce.interpunkce.Contains(c) && !char.IsWhiteSpace(c))))
                            // tak se zap�e nov� znak
                            {
                                novyRadek[j] = novy;
                                j++;
                            }
                            i++;

                            // po��t�n� pr�b�n�ho stavu zpracov�n�
                            if (i % krokZpracovani == 0)
                            {
                                Stav += krokZpracovani;
                                stavZvysen += krokZpracovani;

                                // o�et�en� n�hledu p�i velmi dlouh�m ��dku
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

                        // navr�cen� stavu na p�vodn� hodnotu, aby se vyrovnalo druh� zv��en� na konci ��dku
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

        // vrac� true, kdy� se m� odstranit ��dek
        private bool odstranPrazdnyRadek(string radek)
        {
            if (!odstranitRadky)
                return false;
            if (radek.Length > 0)
                return false;
            return true;
        }

        // vrac� true, kdy� se m� odstranit znak
        private bool odstranDiakritiku(char c)
        {
            if (!odstranitDiakritiku)
                return false;
            if (Diakritika.pismena.Contains(c))
                return true;
            return false;
        }

        // vrac� true, kdy� se m� odstranit znak
        private bool odstranMezeryInterpunkci(char c)
        {
            if (!odstranitInterpunkci)
                return false;
            if (Interpunkce.interpunkce.Contains(c) || char.IsWhiteSpace(c))
                return true;
            return false;
        }

        // vypo�te camelCase. Funkce se v k�du nevol� kv�li v�t�i efektivit� v�po�tu
        private char camelCase(char c)
        {
            if (!odstranitInterpunkci)
                return c;

            if (char.IsWhiteSpace(c) || Interpunkce.interpunkce.Contains(c))
            {
                posledniBilyInterpunkce = true;
            }
            // na�ten� znak
            else
            {
                // byl na�ten znak a znak p�ed n�m byl b�l�, tak�e se jedn� o nov� slovo
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
