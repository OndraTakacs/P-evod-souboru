using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
          set {
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
            vstupStatistiky = new Statistiky();
            vystupStatistiky = new Statistiky();
        }

        private void FormPrevod_Load(object sender, EventArgs e)
        {

        }

        private void buttonPreved_Click(object sender, EventArgs e)
        {
            prevod.preved();

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
                labelOtevri.Text = System.IO.Path.GetFileName(VstupniSoubor);
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
                labelUloz.Text = System.IO.Path.GetFileName(VystupniSoubor);
            }
        }
    }
}
