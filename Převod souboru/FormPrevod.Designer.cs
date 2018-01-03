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
            this.buttonUloz = new System.Windows.Forms.Button();
            this.buttonPreved = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelOtevri = new System.Windows.Forms.Label();
            this.labelUloz = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelVstupVety = new System.Windows.Forms.Label();
            this.labelVstupSlova = new System.Windows.Forms.Label();
            this.labelVstupZnaky = new System.Windows.Forms.Label();
            this.labelVstupRadky = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
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
            this.ButtonOtevri.Location = new System.Drawing.Point(49, 30);
            this.ButtonOtevri.Name = "ButtonOtevri";
            this.ButtonOtevri.Size = new System.Drawing.Size(75, 23);
            this.ButtonOtevri.TabIndex = 2;
            this.ButtonOtevri.Text = "Otevři";
            this.ButtonOtevri.UseVisualStyleBackColor = true;
            this.ButtonOtevri.Click += new System.EventHandler(this.ButtonOtevri_Click);
            // 
            // buttonUloz
            // 
            this.buttonUloz.Location = new System.Drawing.Point(446, 30);
            this.buttonUloz.Name = "buttonUloz";
            this.buttonUloz.Size = new System.Drawing.Size(75, 23);
            this.buttonUloz.TabIndex = 3;
            this.buttonUloz.Text = "Ulož do";
            this.buttonUloz.UseVisualStyleBackColor = true;
            this.buttonUloz.Click += new System.EventHandler(this.buttonUloz_Click);
            // 
            // buttonPreved
            // 
            this.buttonPreved.Location = new System.Drawing.Point(253, 54);
            this.buttonPreved.Name = "buttonPreved";
            this.buttonPreved.Size = new System.Drawing.Size(68, 23);
            this.buttonPreved.TabIndex = 4;
            this.buttonPreved.Text = "Převeď";
            this.buttonPreved.UseVisualStyleBackColor = true;
            this.buttonPreved.Click += new System.EventHandler(this.buttonPreved_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vstupní soubor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Výstupní soubor";
            // 
            // labelOtevri
            // 
            this.labelOtevri.AutoSize = true;
            this.labelOtevri.Location = new System.Drawing.Point(62, 56);
            this.labelOtevri.Name = "labelOtevri";
            this.labelOtevri.Size = new System.Drawing.Size(0, 13);
            this.labelOtevri.TabIndex = 10;
            // 
            // labelUloz
            // 
            this.labelUloz.AutoSize = true;
            this.labelUloz.Location = new System.Drawing.Point(458, 56);
            this.labelUloz.Name = "labelUloz";
            this.labelUloz.Size = new System.Drawing.Size(0, 13);
            this.labelUloz.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Počet vět";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Počet slov";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Počet znaků";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Počet řádků";
            // 
            // labelVstupVety
            // 
            this.labelVstupVety.AutoSize = true;
            this.labelVstupVety.Location = new System.Drawing.Point(84, 0);
            this.labelVstupVety.Name = "labelVstupVety";
            this.labelVstupVety.Size = new System.Drawing.Size(13, 13);
            this.labelVstupVety.TabIndex = 20;
            this.labelVstupVety.Text = "0";
            // 
            // labelVstupSlova
            // 
            this.labelVstupSlova.AutoSize = true;
            this.labelVstupSlova.Location = new System.Drawing.Point(84, 24);
            this.labelVstupSlova.Name = "labelVstupSlova";
            this.labelVstupSlova.Size = new System.Drawing.Size(13, 13);
            this.labelVstupSlova.TabIndex = 20;
            this.labelVstupSlova.Text = "0";
            // 
            // labelVstupZnaky
            // 
            this.labelVstupZnaky.AutoSize = true;
            this.labelVstupZnaky.Location = new System.Drawing.Point(84, 48);
            this.labelVstupZnaky.Name = "labelVstupZnaky";
            this.labelVstupZnaky.Size = new System.Drawing.Size(13, 13);
            this.labelVstupZnaky.TabIndex = 20;
            this.labelVstupZnaky.Text = "0";
            // 
            // labelVstupRadky
            // 
            this.labelVstupRadky.AutoSize = true;
            this.labelVstupRadky.Location = new System.Drawing.Point(84, 74);
            this.labelVstupRadky.Name = "labelVstupRadky";
            this.labelVstupRadky.Size = new System.Drawing.Size(13, 13);
            this.labelVstupRadky.TabIndex = 20;
            this.labelVstupRadky.Text = "0";
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Odstranit diakritiku",
            "Odstranit řádky",
            "Odstranit mezery a interpunkci"});
            this.checkedListBox.Location = new System.Drawing.Point(201, 83);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(170, 49);
            this.checkedListBox.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Převod_souboru.Properties.Resources.long_arrow_right1600;
            this.pictureBox1.Location = new System.Drawing.Point(201, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Převod_souboru.Properties.Resources.long_arrow_right1600;
            this.pictureBox2.Location = new System.Drawing.Point(335, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupVety, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupSlova, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupZnaky, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelVstupRadky, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 100);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label22, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label23, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label24, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupVety, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupSlova, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupZnaky, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelVystupRadky, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(408, 83);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 100);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Počet vět";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Počet slov";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 13);
            this.label23.TabIndex = 14;
            this.label23.Text = "Počet znaků";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Počet řádků";
            // 
            // labelVystupVety
            // 
            this.labelVystupVety.AutoSize = true;
            this.labelVystupVety.Location = new System.Drawing.Point(84, 0);
            this.labelVystupVety.Name = "labelVystupVety";
            this.labelVystupVety.Size = new System.Drawing.Size(13, 13);
            this.labelVystupVety.TabIndex = 20;
            this.labelVystupVety.Text = "0";
            // 
            // labelVystupSlova
            // 
            this.labelVystupSlova.AutoSize = true;
            this.labelVystupSlova.Location = new System.Drawing.Point(84, 24);
            this.labelVystupSlova.Name = "labelVystupSlova";
            this.labelVystupSlova.Size = new System.Drawing.Size(13, 13);
            this.labelVystupSlova.TabIndex = 20;
            this.labelVystupSlova.Text = "0";
            // 
            // labelVystupZnaky
            // 
            this.labelVystupZnaky.AutoSize = true;
            this.labelVystupZnaky.Location = new System.Drawing.Point(84, 48);
            this.labelVystupZnaky.Name = "labelVystupZnaky";
            this.labelVystupZnaky.Size = new System.Drawing.Size(13, 13);
            this.labelVystupZnaky.TabIndex = 20;
            this.labelVystupZnaky.Text = "0";
            // 
            // labelVystupRadky
            // 
            this.labelVystupRadky.AutoSize = true;
            this.labelVystupRadky.Location = new System.Drawing.Point(84, 74);
            this.labelVystupRadky.Name = "labelVystupRadky";
            this.labelVystupRadky.Size = new System.Drawing.Size(13, 13);
            this.labelVystupRadky.TabIndex = 20;
            this.labelVystupRadky.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Název:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Název:";
            // 
            // FormPrevod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 319);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.labelUloz);
            this.Controls.Add(this.labelOtevri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPreved);
            this.Controls.Add(this.buttonUloz);
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
        private System.Windows.Forms.Button buttonUloz;
        private System.Windows.Forms.Button buttonPreved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelOtevri;
        private System.Windows.Forms.Label labelUloz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelVstupVety;
        private System.Windows.Forms.Label labelVstupSlova;
        private System.Windows.Forms.Label labelVstupZnaky;
        private System.Windows.Forms.Label labelVstupRadky;
        private System.Windows.Forms.CheckedListBox checkedListBox;
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
    }
}

