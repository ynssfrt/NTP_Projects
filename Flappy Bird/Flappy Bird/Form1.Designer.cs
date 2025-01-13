namespace Flappy_Bird
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kus = new System.Windows.Forms.PictureBox();
            this.boru1 = new System.Windows.Forms.PictureBox();
            this.zemin = new System.Windows.Forms.PictureBox();
            this.boru2 = new System.Windows.Forms.PictureBox();
            this.scoreText = new System.Windows.Forms.Label();
            this.zamanlayici = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boru1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zemin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boru2)).BeginInit();
            this.SuspendLayout();
            // 
            // kus
            // 
            this.kus.Image = global::Flappy_Bird.Properties.Resources.bird;
            this.kus.Location = new System.Drawing.Point(81, 242);
            this.kus.Name = "kus";
            this.kus.Size = new System.Drawing.Size(72, 60);
            this.kus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kus.TabIndex = 0;
            this.kus.TabStop = false;
            // 
            // boru1
            // 
            this.boru1.Image = global::Flappy_Bird.Properties.Resources.pipedown;
            this.boru1.Location = new System.Drawing.Point(560, -51);
            this.boru1.Name = "boru1";
            this.boru1.Size = new System.Drawing.Size(102, 266);
            this.boru1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boru1.TabIndex = 1;
            this.boru1.TabStop = false;
            // 
            // zemin
            // 
            this.zemin.Image = global::Flappy_Bird.Properties.Resources.ground;
            this.zemin.Location = new System.Drawing.Point(-6, 548);
            this.zemin.Name = "zemin";
            this.zemin.Size = new System.Drawing.Size(789, 98);
            this.zemin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.zemin.TabIndex = 2;
            this.zemin.TabStop = false;
            // 
            // boru2
            // 
            this.boru2.Image = global::Flappy_Bird.Properties.Resources.pipe;
            this.boru2.Location = new System.Drawing.Point(354, 412);
            this.boru2.Name = "boru2";
            this.boru2.Size = new System.Drawing.Size(106, 267);
            this.boru2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boru2.TabIndex = 3;
            this.boru2.TabStop = false;
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.Location = new System.Drawing.Point(12, 9);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(141, 33);
            this.scoreText.TabIndex = 4;
            this.scoreText.Text = "Score: 0";
            this.scoreText.Click += new System.EventHandler(this.label1_Click);
            // 
            // zamanlayici
            // 
            this.zamanlayici.Enabled = true;
            this.zamanlayici.Interval = 20;
            this.zamanlayici.Tick += new System.EventHandler(this.zamanlayici_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(766, 627);
            this.Controls.Add(this.kus);
            this.Controls.Add(this.zemin);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.boru2);
            this.Controls.Add(this.boru1);
            this.Name = "Form1";
            this.Text = "Flappy Bird Oyunu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gamekeyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gamekeyisup);
            ((System.ComponentModel.ISupportInitialize)(this.kus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boru1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zemin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boru2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox kus;
        private System.Windows.Forms.PictureBox boru1;
        private System.Windows.Forms.PictureBox zemin;
        private System.Windows.Forms.PictureBox boru2;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer zamanlayici;
    }
}

