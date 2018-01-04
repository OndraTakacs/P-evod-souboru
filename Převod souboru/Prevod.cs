using System;
using System.IO;
using System.Text;
using System.ComponentModel;

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
                int procenta = (int)(1000 * value / DelkaSouboru);
                if (procenta - staraProcenta > 0)
                {
                    staraProcenta = procenta;
                    if (worker != null)
                    {
                        worker.ReportProgress(procenta);
                    }
                }
            }
        }

        private int staraProcenta = 0;
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


        public string preved(int maxRadku = -1, object sender = null, DoWorkEventArgs e = null)
        {
            string nahled = "";
            int radku = 0;
            reset();

            worker = sender as BackgroundWorker;
            using (StreamReader sr = new StreamReader(VstupniSoubor))
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(VystupniSoubor, FileMode.Create), Kodovani))
                {
                    string radek;
                    string novyRadekString;
                    long stavZvysen = 0;
                    while ((radek = sr.ReadLine()) != null)
                    {
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
                                novy = camelCase(c);
                                if (!odstranDiakritiku(c) && !odstranMezeryInterpunkci(c))
                                {
                                    novyRadek[j] = novy;
                                    j++;
                                }
                                i++;

                                // po��t�n� pr�b�n�ho stavu zpracov�n�
                                if (i % 10000 == 0)
                                {
                                    Stav += 10000;
                                    stavZvysen += 10000;
                                }
                                

                                if (worker != null && worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    return nahled;
                                }

                                // o�et�en� n�hledu p�i velmi dlouh�m ��dku
                                if (maxRadku > -1 && radek.Length > 1000)
                                {
                                    return nahled + novyRadek;
                                }
                            }
                            novyRadekString = new string(novyRadek);

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
                            if (sr.Peek() == -1)
                            {
                                sw.Write(novyRadekString);
                            }
                            else
                                sw.WriteLine(novyRadekString);

                            if (maxRadku > -1) { 
                                nahled += novyRadekString + System.Environment.NewLine;
                            }
                            radku++;
                        }

                        Stav += radek.Length;

                        if (maxRadku > -1 && radku >= maxRadku)
                        {
                            break;
                        }
                    }
                }
            }
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
            if (Diakritika.maDiakritiku(c))
                return true;
            return false;
        }

        // vrac� true, kdy� se m� odstranit znak
        private bool odstranMezeryInterpunkci(char c)
        {
            if (!odstranitInterpunkci)
                return false;
            if (Interpunkce.jeInterpunkce(c) || char.IsWhiteSpace(c))
                return true;
            return false;
        }

        private char camelCase(char c)
        {
            if (!odstranitInterpunkci)
                return c;

            if (char.IsWhiteSpace(c) || Interpunkce.jeInterpunkce(c))
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
            staraProcenta = 0;
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
