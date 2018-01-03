using System;
using System.IO;
using System.Text;

namespace P�evod_souboru
{
    public class Prevod
    {
        public string VstupniSoubor { get; set; }
        public string VystupniSoubor { get; set; }
        public Encoding Kodovani { get; set; }

        // m� se odstranit diakritika?
        public bool odstranitDiakritiku { get; set; } = false;
        // maj� se odstranit pr�zdn� ��dky?
        public bool odstranitRadky { get; set; } = false;
        // maj� se odstranit mezery a interpunkce a pou��t CamelCase?
        public bool odstranitInterpunkci { get; set; } = false;

        private bool posledniBilyInterpunkce = false;

        public void preved()
        {
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
                                novy = camelCase(radek[i]);
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
                    }
                }
            }
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
    }
}
