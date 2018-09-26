namespace Koctas_tasarim
{
    partial class frmEtiketSecimi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEtiketSecimi));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTNOrjDosyaSeç = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDevam = new System.Windows.Forms.Button();
            this.lbEtiket = new System.Windows.Forms.ListBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(291, 35);
            this.textBox1.TabIndex = 9;
            // 
            // BTNOrjDosyaSeç
            // 
            this.BTNOrjDosyaSeç.Location = new System.Drawing.Point(52, 12);
            this.BTNOrjDosyaSeç.Name = "BTNOrjDosyaSeç";
            this.BTNOrjDosyaSeç.Size = new System.Drawing.Size(201, 23);
            this.BTNOrjDosyaSeç.TabIndex = 8;
            this.BTNOrjDosyaSeç.Text = "Orjinal Tasarım Dosyası Seç";
            this.BTNOrjDosyaSeç.UseVisualStyleBackColor = true;
            this.BTNOrjDosyaSeç.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDevam);
            this.groupBox1.Controls.Add(this.lbEtiket);
            this.groupBox1.Controls.Add(this.btnCikis);
            this.groupBox1.Location = new System.Drawing.Point(52, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 196);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etiket Seçimi";
            // 
            // btnDevam
            // 
            this.btnDevam.Location = new System.Drawing.Point(89, 154);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(75, 31);
            this.btnDevam.TabIndex = 3;
            this.btnDevam.Text = "DEVAM";
            this.btnDevam.UseVisualStyleBackColor = true;
            this.btnDevam.Click += new System.EventHandler(this.btnDevam_Click);
            // 
            // lbEtiket
            // 
            this.lbEtiket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbEtiket.FormattingEnabled = true;
            this.lbEtiket.ItemHeight = 25;
            this.lbEtiket.Location = new System.Drawing.Point(27, 19);
            this.lbEtiket.Name = "lbEtiket";
            this.lbEtiket.Size = new System.Drawing.Size(137, 129);
            this.lbEtiket.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(27, 154);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(56, 31);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmEtiketSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 303);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BTNOrjDosyaSeç);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEtiketSecimi";
            this.Text = "Etiket Seçimi";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BTNOrjDosyaSeç;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDevam;
        private System.Windows.Forms.ListBox lbEtiket;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

