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
        private Prevod prevod;

        private Statistiky vstupStatistiky;

        private Statistiky vystupStatistiky;

        private string vstupniSoubor;
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
            prevod.zmenaStavu += onZmenaStavu;
            vstupStatistiky = new Statistiky();
            vystupStatistiky = new Statistiky();
        }

        private void FormPrevod_Load(object sender, EventArgs e)
        {

        }

        private void onZmenaStavu(object sender, StavEventArgs e)
        {
            progressBar1.Value = e.stav;
            labelProgress.Text = (e.stav / 10).ToString() + "%";
            labelProgress.Refresh();
        }

        private void buttonPreved_Click(object sender, EventArgs e)
        {
            if (!kontrolaSouboru(true) || backgroundWorkerPreved.IsBusy)
                return;

            progressBar1.Visible = true;
            labelProgress.Visible = true;
            prevod.DelkaSouboru = vstupStatistiky.Znaky;

            uzamkni();
            labelStav.Text = "Převádím soubor";
            progressBar1.Value = 0;
            labelProgress.Text = "0%";
            backgroundWorkerPreved.RunWorkerAsync();
        }

        private void ButtonOtevri_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VstupniSoubor = openFileDialog1.FileName;
                textBoxVstup.Text = System.IO.Path.GetFileName(VstupniSoubor);

                textBoxNahledVstup.Text = vratNahled(VstupniSoubor, 10);
                zobrazVystupNahled();

                uzamkni();
                labelStav.Text = "Počítám statistiky vstupního souboru";
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
                backgroundWorkerStatistikyVstup.RunWorkerAsync();
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

        private void zobrazVystupNahled()
        {
            if (VstupniSoubor != null)
                textBoxNahledVystup.Text = prevod.preved(10);
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

        private void uzamkni()
        {
            buttonPreved.Enabled = false;
            ButtonOtevri.Enabled = false;
            ButtonUloz.Enabled = false;
            checkBoxDiakritika.Enabled = false;
            checkBoxMezery.Enabled = false;
            checkBoxRadky.Enabled = false;
        }


        private void odemkni()
        {
            buttonPreved.Enabled = true;
            ButtonOtevri.Enabled = true;
            ButtonUloz.Enabled = true;
            checkBoxDiakritika.Enabled = true;
            checkBoxMezery.Enabled = true;
            checkBoxRadky.Enabled = true;
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
    }
}
