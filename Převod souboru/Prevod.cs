using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace P�evod_souboru
{

    /// <summary>
    /// T��da realizuj�c� p�evod souboru
    /// </summary>
    public class Prevod
    {
        private string vstupniSoubor;
        /// <summary>
        /// Soubor, kter� se m� p�ev�d�t
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
        /// Soubor, do kter�ho se maj� ulo�it v�sledky
        /// </summary>
        public string VystupniSoubor { private get; set; }

        /// <summary>
        /// K�dov�n� vstupn�ho a v�stupn�ho souboru. Automaticky rozpozn�v� jen UTF-8
        /// </summary>
        public Encoding Kodovani{ get; set; }



        private long stav = 0;
        /// <summary>
        /// Stav zpracov�n� souboru v po�tu p�e�ten�ch znak�
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
        /// Pomocn� prom�nn� pro v�po�et dostate�n� zm�ny stavu
        /// </summary>
        private int starePromile = 0;

        private BackgroundWorker worker;

        /// <summary>
        /// m� se odstranit diakritika?
        /// </summary>
        public bool odstranitDiakritiku { get; set; } = false;

        /// <summary>
        /// maj� se odstranit pr�zdn� ��dky?
        /// </summary>
        public bool odstranitRadky { get; set; } = false;

        /// <summary>
        /// maj� se odstranit mezery a interpunkce a pou��t CamelCase?
        /// </summary>
        public bool odstranitInterpunkci { get; set; } = false;


        /// <summary>
        /// D�lka souboru ve znac�ch
        /// </summary>
        public long DelkaSouboru { get; set; } = 0;

        
        /// <summary>
        /// Byl posledn� na�ten� znak p�ed aktu�ln�m znakem b�l� nebo interpunkce?
        /// </summary>
        private bool posledniBilyInterpunkce = false;

        /// <summary>
        /// Po�et znak� na ��dku, po kter�m se aktualizuje stav zpracov�n�
        /// </summary>
        private static int krokZpracovani = 5000;


        /// <summary>
        /// Konstanta, kter� ur�uje, kdy se nejedn� o n�hled
        /// </summary>
        private static int neniNahled = -1;


        /// <summary>
        /// Zpracuje soubor ulo�en� ve vstupniSoubor a v�stup vr�t� ve form� n�hledu nebo jej zap�e do souboru
        /// </summary>
        /// <param name="maxRadku"> maxim�ln� po�et ��dk� p�i n�hlade, -1 ud�v�, �e nejde o n�hled</param>
        /// <param name="sender">BackgroundWorker, kter� volal tuto metodu</param>
        /// <param name="e">Ud�lost od BackgroundWorkera</param>
        /// <returns>N�hled prvn�ch n�kolika ��dk� zpracovan�ho souboru</returns>
        public string preved(int maxRadku = -1, object sender = null, DoWorkEventArgs e = null)
        {
            string nahled = "";
            int radku = 0;
            reset();

            worker = sender as BackgroundWorker;
            StreamWriter sw = null;
            using (StreamReader sr = new StreamReader(VstupniSoubor))
            {
                // kdy� se nejedn� o n�hled, tak se zapisuje na v�stup
                if (maxRadku == neniNahled)
                {
                    sw = new StreamWriter(new FileStream(VystupniSoubor, FileMode.Create), Kodovani);
                }
                // ��dek na�ten� ze vstupn�ho souboru
                string radek;
                // ��dek, kter� se m� zapsat na v�stup nebo do n�hledu
                string novyRadekString = "";
                // pro ka�d� ��dek souboru
                while ((radek = sr.ReadLine()) != null)
                {
                    // ud�v� o kolik byl zv��en pr�b�n� stav zpracov�n�
                    long stavZvysen = 0;
                    // pou�it� pole znak� pro nov� ��dek pro v�t�� efektivitu
                    char[] novyRadek = new char[radek.Length];

                    // jestli se m� odstranit diakritika nebo interpunkce, je t�eba proj�t v�echny znaky ��dku
                    if (odstranitDiakritiku || odstranitInterpunkci)
                    {
                        // index vstupn�ho ��dku
                        int i = 0;
                        // index v�stupn�ho ��dku
                        int j = 0;
                        // aktu�ln� na�ten� znak
                        char c;
                        // nov� na�ten� znak
                        char novy;

                        // zpracov�n� v�ech znak� ��dku
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

                            #region po��t�n� pr�b�n�ho stavu zpracov�n�
                            if (i % krokZpracovani == 0)
                            {
                                Stav += krokZpracovani;
                                stavZvysen += krokZpracovani;

                                // o�et�en� n�hledu p�i velmi dlouh�m ��dku
                                if (maxRadku > neniNahled)
                                {
                                    return nahled + novyRadek;
                                }
                            }
                            #endregion

                            #region zpracov�n� po�adavku na p�eru�en� operace
                            if (worker != null && worker.CancellationPending)
                            {
                                e.Cancel = true;
                                if (!(maxRadku > neniNahled))
                                    sw.Close();
                                return nahled;
                            }
                            #endregion
                        }

                        #region o�et�en� vkl�d�n� pr�zn�ch znak� do �et�zce
                        if (j > 0)
                            novyRadekString = new string(novyRadek);
                        else
                            novyRadekString = "";
                        #endregion

                        #region navr�cen� stavu na p�vodn� hodnotu, aby se vyrovnalo druh� zv��en� na konci ��dku
                        if (stavZvysen > 0)
                        {
                            stav -= stavZvysen;
                        }
                        #endregion
                    }
                    // nebylo t�eba zpracov�vat ��dek
                    else
                        novyRadekString = radek;

                    // pokud se nem� p�esko�it pr�zdn� ��dek
                    if (!odstranPrazdnyRadek(novyRadekString))
                    {
                        #region ulo�en� n�hledu
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
                        #region ulo�en� do v�stupn�ho souboru
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
                    // aktualizase stavu zpracov�n�
                    Stav += radek.Length;
                }
            }
            sw.Close();
            return nahled;
        }

        /// <summary>
        /// M� se odstranit pr�zdn� ��dek?
        /// </summary>
        /// <param name="radek">��dek dat</param>
        /// <returns>True pokud se m� ��dek odstranit</returns>
        private bool odstranPrazdnyRadek(string radek)
        {
            if (!odstranitRadky)
                return false;
            if (radek.Length > 0)
                return false;
            return true;
        }

        /// <summary>
        /// M� se odstranit znak?
        /// </summary>
        /// <param name="c">Znak, jeho� odstran�n� se posuzuje</param>
        /// <returns>Vrac� true, kdy� se m� odstranit znak</returns>
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
        /// M� se odstranit tento znak v p��pad� mezery nebo interpunkce?
        /// </summary>
        /// <param name="c">Posuzovan� znak</param>
        /// <returns>Vrac� true, kdy� se m� odstranit zadan� znak</returns>
        private bool odstranMezeryInterpunkci(char c)
        {
            if (!odstranitInterpunkci)
                return false;
            if (Interpunkce.interpunkce.Contains(c) || char.IsWhiteSpace(c))
                return true;
            return false;
        }

        /// <summary>
        /// Vypo�te CamelCase. Funkce se v k�du nevol� kv�li v�t�i efektivit� v�po�tu
        /// </summary>
        /// <param name="c">Znak, kter� se m� p�ev�d�t</param>
        /// <returns>p�vodn� znak nebo velk� znak</returns>
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


        /// <summary>
        /// Znovunastaven� prom�nn�ch t��dy
        /// </summary>
        private void reset()
        {
            stav = 0;
            starePromile = 0;
            posledniBilyInterpunkce = false;
        }
    }
}
