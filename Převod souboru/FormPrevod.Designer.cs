namespace Převod_souboru
{
    partial class FormPrevod
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ButtonOtevri = new System.Windows.Forms.Button();
            this.ButtonUloz = new System.Windows.Forms.Button();
            this.buttonPreved = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelVstupVety = new System.Windows.Forms.Label();
            this.labelVstupSlova = new System.Windows.Forms.Label();
            this.labelVstupZnaky = new System.Windows.Forms.Label();
            this.labelVstupRadky = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.labelVystupVety = new System.Windows.Forms.Label();
            this.labelVystupSlova = new System.Windows.Forms.Label();
            this.labelVystupZnaky = new System.Windows.Forms.Label();
            this.labelVystupRadky = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxDiakritika = new System.Windows.Forms.CheckBox();
            this.checkBoxRadky = new System.Windows.Forms.CheckBox();
            this.checkBoxMezery = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.textBoxVstup = new System.Windows.Forms.TextBox();
            this.textBoxVystup = new System.Windows.Forms.TextBox();
            this.textBoxNahledVstup = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNahledVystup = new System.Windows.Forms.TextBox();
            this.backgroundWorkerPreved = new System.ComponentModel.BackgroundWorker();
            this.buttonZrusit = new System.Windows.Forms.Button();
            this.labelStav = new System.Windows.Forms.Label();
            this.backgroundWorkerStatistikyVstup = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerStatistikyVystup = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ButtonOtevri
            // 
            this.ButtonOtevri.Location = new System.Drawing.Point(163, 206);
            this.ButtonOtevri.Name = "ButtonOtevri";
            this.ButtonOtevri.Size = new System.Drawing.Size(75, 23);
            this.ButtonOtevri.TabIndex = 2;
            this.ButtonOtevri.Text = "Otevři";
            this.ButtonOtevri.UseVisualStyleBackColor = true;
            this.ButtonOtevri.Click += new System.EventHandler(this.ButtonOtevri_Click);
            // 
            // ButtonUloz
            // 
            this.ButtonUloz.Location = new System.Drawing.Point(611, 205);
            this.ButtonUloz.Name = "ButtonUloz";
            this.ButtonUloz.Size = new System.Drawing.Size(75, 23);
            this.ButtonUloz.TabIndex = 3;
            this.ButtonUloz.Text = "Ulož do";
            this.ButtonUloz.UseVisualStyleBackColor = true;
            this.ButtonUloz.Click += new System.EventHandler(this.buttonUloz_Click);
            // 
            // buttonPreved
            // 
            this.buttonPreved.Location = new System.Drawing.Point(286, 135);
            this.buttonPreved.Name = "buttonPreved";
            this.buttonPreved.Size = new System.Drawing.Size(53, 23);
            this.buttonPreved.TabIndex = 4;
            this.buttonPreved.Text = "Převeď";
            this.buttonPreved.UseVisualStyleBackColor = true;
            this.buttonPreved.Click += new System.EventHandler(this.buttonPreved_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vstupní soubor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(502, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Výstupní soubor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Počet vět:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Počet slov:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Počet znaků:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Počet řádků:";
            // 
            // labelVstupVety
            // 
            this.labelVstupVety.AutoSize = true;
            this.labelVstupVety.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVstupVety.Location = new System.Drawing.Point(81, 0);
            this.labelVstupVety.Name = "labelVstupVety";
            this.labelVstupVety.Size = new System.Drawing.Size(14, 13);
            this.labelVstupVety.TabIndex = 20;
            this.labelVstupVety.Text = "0";
            // 
            // labelVstupSlova
            // 
            this.labelVstupSlova.AutoSize = true;
            this.labelVstupSlova.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVstupSlova.Location = new System.Drawing.Point(81, 24);
            this.labelVstupSlova.Name = "labelVstupSlova";
            this.labelVstupSlova.Size = new System.Drawing.Size(14, 13);
            this.labelVstupSlova.TabIndex = 20;
            this.labelVstupSlova.Text = "0";
            // 
            // labelVstupZnaky
            // 
            this.labelVstupZnaky.AutoSize = true;
            this.labelVstupZnaky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVstupZnaky.Location = new System.Drawing.Point(81, 48);
            this.labelVstupZnaky.Name = "labelVstupZnaky";
            this.labelVstupZnaky.Size = new System.Drawing.Size(14, 13);
            this.labelVstupZnaky.TabIndex = 20;
            this.labelVstupZnaky.Text = "0";
            // 
            // labelVstupRadky
            // 
            this.labelVstupRadky.AutoSize = true;
            this.labelVstupRadky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVstupRadky.Location = new System.Drawing.Point(81, 74);
            this.labelVstupRadky.Name = "labelVstupRadky";
            this.labelVstupRadky.Size = new System.Drawing.Size(14, 13);
            this.labelVstupRadky.TabIndex = 20;
            this.labelVstupRadky.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Převod_souboru.Properties.Resources.long_arrow_right1600;
            this.pictureBox1.Location = new System.Drawing.Point(244, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Převod_souboru.Properties.Resources.long_arrow_right1600;
            this.pictureBox2.Location = new System.Drawing.Point(418, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.32058F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.67942F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupVety, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupSlova, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupZnaky, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupRadky, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(29, 235);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(209, 100);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.95745F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.04255F));
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label22, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label23, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label24, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupVety, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupSlova, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupZnaky, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupRadky, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(497, 235);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(188, 100);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Počet vět:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Počet slov:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 13);
            this.label23.TabIndex = 14;
            this.label23.Text = "Počet znaků:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Počet řádků:";
            // 
            // labelVystupVety
            // 
            this.labelVystupVety.AutoSize = true;
            this.labelVystupVety.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVystupVety.Location = new System.Drawing.Point(80, 0);
            this.labelVystupVety.Name = "labelVystupVety";
            this.labelVystupVety.Size = new System.Drawing.Size(14, 13);
            this.labelVystupVety.TabIndex = 20;
            this.labelVystupVety.Text = "0";
            // 
            // labelVystupSlova
            // 
            this.labelVystupSlova.AutoSize = true;
            this.labelVystupSlova.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVystupSlova.Location = new System.Drawing.Point(80, 24);
            this.labelVystupSlova.Name = "labelVystupSlova";
            this.labelVystupSlova.Size = new System.Drawing.Size(14, 13);
            this.labelVystupSlova.TabIndex = 20;
            this.labelVystupSlova.Text = "0";
            // 
            // labelVystupZnaky
            // 
            this.labelVystupZnaky.AutoSize = true;
            this.labelVystupZnaky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVystupZnaky.Location = new System.Drawing.Point(80, 48);
            this.labelVystupZnaky.Name = "labelVystupZnaky";
            this.labelVystupZnaky.Size = new System.Drawing.Size(14, 13);
            this.labelVystupZnaky.TabIndex = 20;
            this.labelVystupZnaky.Text = "0";
            // 
            // labelVystupRadky
            // 
            this.labelVystupRadky.AutoSize = true;
            this.labelVystupRadky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVystupRadky.Location = new System.Drawing.Point(80, 74);
            this.labelVystupRadky.Name = "labelVystupRadky";
            this.labelVystupRadky.Size = new System.Drawing.Size(14, 13);
            this.labelVystupRadky.TabIndex = 20;
            this.labelVystupRadky.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Název:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(458, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Název:";
            // 
            // checkBoxDiakritika
            // 
            this.checkBoxDiakritika.AutoSize = true;
            this.checkBoxDiakritika.Location = new System.Drawing.Point(262, 164);
            this.checkBoxDiakritika.Name = "checkBoxDiakritika";
            this.checkBoxDiakritika.Size = new System.Drawing.Size(113, 17);
            this.checkBoxDiakritika.TabIndex = 32;
            this.checkBoxDiakritika.Text = "Odstranit diakritiku";
            this.checkBoxDiakritika.UseVisualStyleBackColor = true;
            this.checkBoxDiakritika.CheckedChanged += new System.EventHandler(this.checkBoxDiakritika_CheckedChanged);
            // 
            // checkBoxRadky
            // 
            this.checkBoxRadky.AutoSize = true;
            this.checkBoxRadky.Location = new System.Drawing.Point(262, 183);
            this.checkBoxRadky.Name = "checkBoxRadky";
            this.checkBoxRadky.Size = new System.Drawing.Size(139, 17);
            this.checkBoxRadky.TabIndex = 33;
            this.checkBoxRadky.Text = "Odstranit prázdné řádky";
            this.checkBoxRadky.UseVisualStyleBackColor = true;
            this.checkBoxRadky.CheckedChanged += new System.EventHandler(this.checkBoxRadky_CheckedChanged);
            // 
            // checkBoxMezery
            // 
            this.checkBoxMezery.AutoSize = true;
            this.checkBoxMezery.Location = new System.Drawing.Point(262, 204);
            this.checkBoxMezery.Name = "checkBoxMezery";
            this.checkBoxMezery.Size = new System.Drawing.Size(168, 30);
            this.checkBoxMezery.TabIndex = 34;
            this.checkBoxMezery.Text = "Odstranit mezery a interpunkci\r\na použít CamelCase";
            this.checkBoxMezery.UseVisualStyleBackColor = true;
            this.checkBoxMezery.CheckedChanged += new System.EventHandler(this.checkBoxMezery_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(244, 106);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(210, 23);
            this.progressBar1.TabIndex = 35;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(339, 110);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(21, 13);
            this.labelProgress.TabIndex = 36;
            this.labelProgress.Text = "0%";
            // 
            // textBoxVstup
            // 
            this.textBoxVstup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxVstup.Location = new System.Drawing.Point(57, 208);
            this.textBoxVstup.Name = "textBoxVstup";
            this.textBoxVstup.ReadOnly = true;
            this.textBoxVstup.Size = new System.Drawing.Size(100, 20);
            this.textBoxVstup.TabIndex = 38;
            // 
            // textBoxVystup
            // 
            this.textBoxVystup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxVystup.Location = new System.Drawing.Point(505, 208);
            this.textBoxVystup.Name = "textBoxVystup";
            this.textBoxVystup.ReadOnly = true;
            this.textBoxVystup.Size = new System.Drawing.Size(100, 20);
            this.textBoxVystup.TabIndex = 39;
            // 
            // textBoxNahledVstup
            // 
            this.textBoxNahledVstup.Location = new System.Drawing.Point(12, 57);
            this.textBoxNahledVstup.Multiline = true;
            this.textBoxNahledVstup.Name = "textBoxNahledVstup";
            this.textBoxNahledVstup.ReadOnly = true;
            this.textBoxNahledVstup.Size = new System.Drawing.Size(226, 143);
            this.textBoxNahledVstup.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Náhled souboru:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(458, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Náhled souboru:";
            // 
            // textBoxNahledVystup
            // 
            this.textBoxNahledVystup.Location = new System.Drawing.Point(460, 57);
            this.textBoxNahledVystup.Multiline = true;
            this.textBoxNahledVystup.Name = "textBoxNahledVystup";
            this.textBoxNahledVystup.ReadOnly = true;
            this.textBoxNahledVystup.Size = new System.Drawing.Size(226, 143);
            this.textBoxNahledVystup.TabIndex = 42;
            // 
            // backgroundWorkerPreved
            // 
            this.backgroundWorkerPreved.WorkerReportsProgress = true;
            this.backgroundWorkerPreved.WorkerSupportsCancellation = true;
            this.backgroundWorkerPreved.DoWork += new System.ComponentModel.DoWorkEventHandler(this.prevedDoWork);
            this.backgroundWorkerPreved.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.prevedProgressChanged);
            this.backgroundWorkerPreved.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.prevedRunWorkerCompleted);
            // 
            // buttonZrusit
            // 
            this.buttonZrusit.Location = new System.Drawing.Point(355, 135);
            this.buttonZrusit.Name = "buttonZrusit";
            this.buttonZrusit.Size = new System.Drawing.Size(57, 23);
            this.buttonZrusit.TabIndex = 44;
            this.buttonZrusit.Text = "Zrušit";
            this.buttonZrusit.UseVisualStyleBackColor = true;
            this.buttonZrusit.Click += new System.EventHandler(this.buttonZrusit_Click);
            // 
            // labelStav
            // 
            this.labelStav.AutoSize = true;
            this.labelStav.Location = new System.Drawing.Point(241, 90);
            this.labelStav.Name = "labelStav";
            this.labelStav.Size = new System.Drawing.Size(101, 13);
            this.labelStav.TabIndex = 45;
            this.labelStav.Text = "Čekám na instrukce";
            // 
            // backgroundWorkerStatistikyVstup
            // 
            this.backgroundWorkerStatistikyVstup.WorkerReportsProgress = true;
            this.backgroundWorkerStatistikyVstup.WorkerSupportsCancellation = true;
            this.backgroundWorkerStatistikyVstup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.statistikyVstupDoWork);
            this.backgroundWorkerStatistikyVstup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.prevedProgressChanged);
            this.backgroundWorkerStatistikyVstup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.statistikyVstupRunWorkerCompleted);
            // 
            // backgroundWorkerStatistikyVystup
            // 
            this.backgroundWorkerStatistikyVystup.WorkerReportsProgress = true;
            this.backgroundWorkerStatistikyVystup.WorkerSupportsCancellation = true;
            this.backgroundWorkerStatistikyVystup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.statistikyVystupDoWork);
            this.backgroundWorkerStatistikyVystup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.prevedProgressChanged);
            this.backgroundWorkerStatistikyVystup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.statistikyVystupRunWorkerCompleted);
            // 
            // FormPrevod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 346);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.labelStav);
            this.Controls.Add(this.buttonZrusit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxNahledVystup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNahledVstup);
            this.Controls.Add(this.textBoxVystup);
            this.Controls.Add(this.textBoxVstup);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBoxMezery);
            this.Controls.Add(this.checkBoxRadky);
            this.Controls.Add(this.checkBoxDiakritika);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPreved);
            this.Controls.Add(this.ButtonUloz);
            this.Controls.Add(this.ButtonOtevri);
            this.Name = "FormPrevod";
            this.Text = "Převod souboru";
            this.Load += new System.EventHandler(this.FormPrevod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ButtonOtevri;
        private System.Windows.Forms.Button ButtonUloz;
        private System.Windows.Forms.Button buttonPreved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelVstupVety;
        private System.Windows.Forms.Label labelVstupSlova;
        private System.Windows.Forms.Label labelVstupZnaky;
        private System.Windows.Forms.Label labelVstupRadky;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label labelVystupVety;
        private System.Windows.Forms.Label labelVystupSlova;
        private System.Windows.Forms.Label labelVystupZnaky;
        private System.Windows.Forms.Label labelVystupRadky;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxDiakritika;
        private System.Windows.Forms.CheckBox checkBoxRadky;
        private System.Windows.Forms.CheckBox checkBoxMezery;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.TextBox textBoxVstup;
        private System.Windows.Forms.TextBox textBoxVystup;
        private System.Windows.Forms.TextBox textBoxNahledVstup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxNahledVystup;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPreved;
        private System.Windows.Forms.Button buttonZrusit;
        private System.Windows.Forms.Label labelStav;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStatistikyVstup;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStatistikyVystup;
    }
}

