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
        }

        private void buttonPreved_Click(object sender, EventArgs e)
        {
            if (!kontrolaSouboru(true))
                return;

            progressBar1.Visible = true;
            labelProgress.Visible = true;
            prevod.DelkaSouboru = vstupStatistiky.Znaky;

            uzamkni();
            prevod.preved();
            odemkni();

            vystupStatistiky.spocitej();
            labelVystupVety.Text = vystupStatistiky.Vety.ToString();
            labelVystupSlova.Text = vystupStatistiky.Slova.ToString();
            labelVystupRadky.Text = vystupStatistiky.Radky.ToString();
            labelVystupZnaky.Text = vystupStatistiky.Znaky.ToString();
        }

        private void ButtonOtevri_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VstupniSoubor = openFileDialog1.FileName;
                textBoxVstup.Text = System.IO.Path.GetFileName(VstupniSoubor);

                textBoxNahledVstup.Text = vratNahled(VstupniSoubor, 10);
                if (kontrolaSouboru(false))
                    textBoxNahledVystup.Text = prevod.preved(10);

                vstupStatistiky.spocitej();
                labelVstupVety.Text = vstupStatistiky.Vety.ToString();
                labelVstupSlova.Text = vstupStatistiky.Slova.ToString();
                labelVstupRadky.Text = vstupStatistiky.Radky.ToString();
                labelVstupZnaky.Text = vstupStatistiky.Znaky.ToString();
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
            textBoxNahledVystup.Text = prevod.preved(10);
        }

        private void checkBoxDiakritika_CheckedChanged(object sender, EventArgs e)
        {
            prevod.odstranitDiakritiku = checkBoxDiakritika.Checked;

            if (kontrolaSouboru(false))
                zobrazVystupNahled();
        }

        private void checkBoxRadky_CheckedChanged(object sender, EventArgs e)
        {
            prevod.odstranitRadky = checkBoxRadky.Checked;
            if (kontrolaSouboru(false))
                zobrazVystupNahled();
        }

        private void checkBoxMezery_CheckedChanged(object sender, EventArgs e)
        {
            prevod.odstranitInterpunkci = checkBoxMezery.Checked;
            if (kontrolaSouboru(false))
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
            ButtonOtevri.Enabled = false;
            ButtonUloz.Enabled = false;
            checkBoxDiakritika.Enabled = false;
            checkBoxMezery.Enabled = false;
            checkBoxRadky.Enabled = false;
        }


        private void odemkni()
        {
            ButtonOtevri.Enabled = true;
            ButtonUloz.Enabled = true;
            checkBoxDiakritika.Enabled = true;
            checkBoxMezery.Enabled = true;
            checkBoxRadky.Enabled = true;
        }
    }
}
