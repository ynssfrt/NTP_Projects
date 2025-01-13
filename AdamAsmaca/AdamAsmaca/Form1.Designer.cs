namespace AdamAsmaca
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelKalanHak = new System.Windows.Forms.Label();
            this.labelGizliKelime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTahminYazisi = new System.Windows.Forms.Label();
            this.textBoxTahmin = new System.Windows.Forms.TextBox();
            this.buttonTahmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelKalanHak
            // 
            this.labelKalanHak.AutoSize = true;
            this.labelKalanHak.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKalanHak.Location = new System.Drawing.Point(341, 78);
            this.labelKalanHak.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelKalanHak.Name = "labelKalanHak";
            this.labelKalanHak.Size = new System.Drawing.Size(129, 24);
            this.labelKalanHak.TabIndex = 0;
            this.labelKalanHak.Text = "Kalan Hak: 6";
            // 
            // labelGizliKelime
            // 
            this.labelGizliKelime.AutoSize = true;
            this.labelGizliKelime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGizliKelime.Location = new System.Drawing.Point(298, 117);
            this.labelGizliKelime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelGizliKelime.Name = "labelGizliKelime";
            this.labelGizliKelime.Size = new System.Drawing.Size(257, 35);
            this.labelGizliKelime.TabIndex = 1;
            this.labelGizliKelime.Text = "_ _ _ _ _ _ _ _ _ _";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Location = new System.Drawing.Point(16, 218);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(600, 200);
            this.buttonPanel.TabIndex = 3;
            this.buttonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonPanel_Paint);
            // 
            // labelTahminYazisi
            // 
            this.labelTahminYazisi.AutoSize = true;
            this.labelTahminYazisi.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTahminYazisi.Location = new System.Drawing.Point(299, 50);
            this.labelTahminYazisi.Name = "labelTahminYazisi";
            this.labelTahminYazisi.Size = new System.Drawing.Size(242, 29);
            this.labelTahminYazisi.TabIndex = 4;
            this.labelTahminYazisi.Text = "Şehri tahmin ediniz:";
            // 
            // textBoxTahmin
            // 
            this.textBoxTahmin.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxTahmin.Location = new System.Drawing.Point(287, 177);
            this.textBoxTahmin.MaxLength = 1;
            this.textBoxTahmin.Name = "textBoxTahmin";
            this.textBoxTahmin.Size = new System.Drawing.Size(121, 30);
            this.textBoxTahmin.TabIndex = 5;
            // 
            // buttonTahmin
            // 
            this.buttonTahmin.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonTahmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTahmin.Location = new System.Drawing.Point(413, 177);
            this.buttonTahmin.Name = "buttonTahmin";
            this.buttonTahmin.Size = new System.Drawing.Size(101, 30);
            this.buttonTahmin.TabIndex = 6;
            this.buttonTahmin.Text = "Tahmin Et";
            this.buttonTahmin.UseVisualStyleBackColor = false;
            this.buttonTahmin.Click += new System.EventHandler(this.buttonTahmin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(633, 462);
            this.Controls.Add(this.buttonTahmin);
            this.Controls.Add(this.textBoxTahmin);
            this.Controls.Add(this.labelTahminYazisi);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelGizliKelime);
            this.Controls.Add(this.labelKalanHak);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Adam Asmaca";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelKalanHak;
        private System.Windows.Forms.Label labelGizliKelime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Label labelTahminYazisi; // Ekleme
        private System.Windows.Forms.TextBox textBoxTahmin; // Giriş alanı
        private System.Windows.Forms.Button buttonTahmin; // Tahmin butonu
    }
}