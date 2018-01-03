using System;
using System.IO;
using System.Text;

namespace Pøevod_souboru
{
    public class Prevod
    {
        public string VstupniSoubor { get; set; }
        public string VystupniSoubor { get; set; }
        public Encoding Kodovani { get; set; }

        // má se odstranit diakritika?
        public bool odstranitDiakritiku { get; set; } = false;
        // mají se odstranit prázdné øádky?
        public bool odstranitRadky { get; set; } = false;
        // mají se odstranit mezery a interpunkce a použít CamelCase?
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
            if (Diakritika.maDiakritiku(c))
                return true;
            return false;
        }

        // vrací true, když se má odstranit znak
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
    }
}
