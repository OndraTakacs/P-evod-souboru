using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Převod_souboru
{
    public partial class FormPrevod : Form
    {

        /// <summary>
        /// Objekt pro zpracování souboru
        /// </summary>
        private Prevod prevod;


        /// <summary>
        /// Objekt pro výpočet vstupních statistik
        /// </summary>
        private Statistiky vstupStatistiky;


        /// <summary>
        /// Objekt pro výpočet výstupních statistik
        /// </summary>
        private Statistiky vystupStatistiky;

        private string vstupniSoubor;

        /// <summary>
        /// Vstupní soubor, který se má zpracovat
        /// </summary>
        private string VstupniSoubor
        {
            get { return vstupniSoubor; }
            set
            {
                vstupniSoubor = value;
                prevod.VstupniSoubor = value;
                vstupStatistiky.Soubor = value;
            }
        }

        private string vystupniSoubor;

        /// <summary>
        /// Výstupní soubor, do kterého se uloží zpracovaný vstupní soubor
        /// </summary>
        private string VystupniSoubor
        {
            get { return vystupniSoubor; }
            set
            {
                vystupniSoubor = value;
                prevod.VystupniSoubor = value;
                vystupStatistiky.Soubor = value;
            }
        }

        public FormPrevod()
        {
            InitializeComponent();
            prevod = new Prevod();
            vstupStatistiky = new Statistiky();
            vystupStatistiky = new Statistiky();
        }

        private void FormPrevod_Load(object sender, EventArgs e)
        {

        }

        private void buttonPreved_Click(object sender, EventArgs e)
        {
            if (!kontrolaSouboru(true) || backgroundWorkerPreved.IsBusy)
                return;
            // aktualizace délky vstupního souboru podle spočítáných statistik
            prevod.DelkaSouboru = vstupStatistiky.Znaky;

            #region spočítání statistik
            uzamkni();
            labelStav.Text = "Převádím soubor";
            progressBar1.Value = 0;
            labelProgress.Text = "0%";
            backgroundWorkerPreved.RunWorkerAsync();
            #endregion
        }

        private void ButtonOtevri_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VstupniSoubor = openFileDialog1.FileName;
                textBoxVstup.Text = System.IO.Path.GetFileName(VstupniSoubor);

                #region zobrazení náhledu vstupního i výstupního souboru
                textBoxNahledVstup.Text = vratNahled(VstupniSoubor, 10);
                zobrazVystupNahled();
                #endregion

                #region spočítání statistik
                uzamkni();
                labelStav.Text = "Počítám statistiky vstupního souboru";
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
                backgroundWorkerStatistikyVstup.RunWorkerAsync();
                #endregion
            }
        }

        private void buttonUloz_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VystupniSoubor = saveFileDialog1.FileName;
                textBoxVystup.Text = System.IO.Path.GetFileName(VystupniSoubor);

                zobrazVystupNahled();
            }
        }

        private void checkBoxDiakritika_CheckedChanged(object sender, EventArgs e)
        {
            prevod.odstranitDiakritiku = checkBoxDiakritika.Checked;

            zobrazVystupNahled();
        }

        private void checkBoxRadky_CheckedChanged(object sender, EventArgs e)
        {
            prevod.odstranitRadky = checkBoxRadky.Checked;
            zobrazVystupNahled();
        }

        private void checkBoxMezery_CheckedChanged(object sender, EventArgs e)
        {
            prevod.odstranitInterpunkci = checkBoxMezery.Checked;
            zobrazVystupNahled();
        }

        private void buttonZrusit_Click(object sender, EventArgs e)
        {
            backgroundWorkerPreved.CancelAsync();
            backgroundWorkerStatistikyVstup.CancelAsync();
            backgroundWorkerStatistikyVystup.CancelAsync();
        }

        private void prevedDoWork(object sender, DoWorkEventArgs e)
        {
            prevod.preved(-1, sender, e);
        }

        private void prevedProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
                labelProgress.Text = (e.ProgressPercentage / 10).ToString() + "%";
            }
            catch (System.ArgumentOutOfRangeException)
            {
                progressBar1.Value = 1000;
                labelProgress.Text = "100%";
            }
            labelProgress.Refresh();
        }

        private void prevedRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                labelStav.Text = "Převod zrušen";
                odemkni();
            }
            else if (e.Error != null)
            {
                labelStav.Text = "Chyba při převodu: " + e.Error.Message;
                odemkni();
            }
            else
            {
                labelStav.Text = "Převod dokončen. Počítám výstupní statistiky";
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
                backgroundWorkerStatistikyVystup.RunWorkerAsync();
            }
        }

        private void statistikyVstupDoWork(object sender, DoWorkEventArgs e)
        {
            vstupStatistiky.spocitej(sender, e);
        }

        private void statistikyVstupRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            odemkni();
            if (e.Cancelled == true)
            {
                labelStav.Text = "Výpočet vstupních statistik zrušen";
            }
            else if (e.Error != null)
            {
                labelStav.Text = "Chyba při výpočetu vstupních statistik: " + e.Error.Message;
            }
            else
            {
                labelStav.Text = "Výpočet vstupních statistik dokončen";
                labelProgress.Text = "100%";
                progressBar1.Value = 1000;

                labelVstupVety.Text = vstupStatistiky.Vety.ToString();
                labelVstupSlova.Text = vstupStatistiky.Slova.ToString();
                labelVstupRadky.Text = vstupStatistiky.Radky.ToString();
                labelVstupZnaky.Text = vstupStatistiky.Znaky.ToString();
            }
        }

        private void statistikyVystupDoWork(object sender, DoWorkEventArgs e)
        {
            vystupStatistiky.spocitej(sender, e);
        }

        private void statistikyVystupRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            odemkni();
            if (e.Cancelled == true)
            {
                labelStav.Text = "Výpočet výstupních statistik zrušen";
            }
            else if (e.Error != null)
            {
                labelStav.Text = "Chyba při výpočetu výstupních statistik: " + e.Error.Message;
            }
            else
            {
                labelStav.Text = "Výpočet výstupních statistik dokončen";
                labelProgress.Text = "100%";
                progressBar1.Value = 1000;

                labelVystupVety.Text = vystupStatistiky.Vety.ToString();
                labelVystupSlova.Text = vystupStatistiky.Slova.ToString();
                labelVystupRadky.Text = vystupStatistiky.Radky.ToString();
                labelVystupZnaky.Text = vystupStatistiky.Znaky.ToString();
            }
        }

        /// <summary>
        /// Vrátí náhled zadaného souboru
        /// </summary>
        /// <param name="soubor">Nahlížený soubor</param>
        /// <param name="radku">Počet řádků v náhledu</param>
        /// <returns>Náhled začátku souboru</returns>
        private string vratNahled(string soubor, int radku)
        {
            string nahled = "";
            StreamReader sr = new StreamReader(soubor);
            for (int i = 0; i < radku; i++)
            {
                if (sr.Peek() == -1)
                    break;
                nahled += sr.ReadLine() + System.Environment.NewLine;
            }
            return nahled;
        }

        /// <summary>
        /// Zobrazí náhled zpracovaného souboru
        /// </summary>
        private void zobrazVystupNahled()
        {
            if (VstupniSoubor != null)
                textBoxNahledVystup.Text = prevod.preved(10);
        }


        /// <summary>
        /// Zkontroluje, jestli je zadán vstupní a výstupní soubor a případně zobrazí upozornění
        /// </summary>
        /// <param name="upozorneni">Má se zobrazit upozornění?</param>
        /// <returns>True pokud jsou oba soubory zadány</returns>
        private bool kontrolaSouboru(bool upozorneni)
        {
            if (vstupniSoubor == null)
            {
                if (upozorneni)
                    MessageBox.Show("Vyberte vstupní soubor", "Upozornění");
                return false;
            }
            if (vystupniSoubor == null)
            {
                if (upozorneni)
                    MessageBox.Show("Vyberte výstupní soubor", "Upozornění");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Uzamkne všechny ovládací prvky kromě tlačítka pro zrušení operace
        /// </summary>
        private void uzamkni()
        {
            buttonPreved.Enabled = false;
            ButtonOtevri.Enabled = false;
            ButtonUloz.Enabled = false;
            checkBoxDiakritika.Enabled = false;
            checkBoxMezery.Enabled = false;
            checkBoxRadky.Enabled = false;
        }

        /// <summary>
        /// Odemkne všechny ovládací prvky kromě tlačítka pro zrušení operace
        /// </summary>
        private void odemkni()
        {
            buttonPreved.Enabled = true;
            ButtonOtevri.Enabled = true;
            ButtonUloz.Enabled = true;
            checkBoxDiakritika.Enabled = true;
            checkBoxMezery.Enabled = true;
            checkBoxRadky.Enabled = true;
        }
    }
}
