using System;
using System.IO;
using System.Text;

namespace P�evod_souboru
{
    public class Prevod
    {
        private string vstupniSoubor;
        public string VstupniSoubor {
            private get
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
                    onZmenaStavu(new StavEventArgs(procenta));
                }
            }
        }

        private int staraProcenta = 0;

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


        public void preved()
        {
            reset();
            using (StreamReader sr = new StreamReader(VstupniSoubor))
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(VystupniSoubor, FileMode.Create), Kodovani))
                {
                    string radek;
                    while ((radek = sr.ReadLine()) != null)
                    {
                        string novyRadek = "";
                        if (odstranitDiakritiku || odstranitInterpunkci)
                        {
                            int i = 0;
                            char c;
                            char novy;

                            while (i < radek.Length)
                            {
                                c = radek[i];
                                novy = camelCase(c);
                                if (!odstranDiakritiku(c) && !odstranMezeryInterpunkci(c))
                                {
                                    novyRadek += novy;
                                }
                                i++;
                            }
                        }
                        else
                            novyRadek = radek;

                        if (!odstranPrazdnyRadek(novyRadek))
                            sw.WriteLine(novyRadek);

                        Stav += radek.Length;
                    }
                }
            }
            Stav = DelkaSouboru;
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
