using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        // Oyun hızını ve kuşun yer çekimini belirten değişkenler
        int speed = 8;         // Boruların soldan sağa hareket hızı
        int gravity = 13;      // Kuşun düşme hızını belirleyen yer çekimi değeri
        int score = 0;         // Oyuncunun skorunu tutan değişken

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Bu olay işleyici boş bırakılmış, bir işlevi yok
        }

        // Zamanlayıcı her tetiklendiğinde çalışan fonksiyon
        private void zamanlayici_Tick(object sender, EventArgs e)
        {
            kus.Top += gravity; // Kuşun düşmesini sağlar
            boru1.Left -= speed; // İlk boruyu sola hareket ettirir
            boru2.Left -= speed; // İkinci boruyu sola hareket ettirir
            scoreText.Text = "Score: " + score; // Skoru günceller ve ekrana yazar

            // Eğer boru ekranın solundan çıkarsa, pozisyonunu yeniden belirler ve skoru artırır
            if (boru1.Left < -150)
            {
                boru1.Left = 650; // İlk boruyu sağdan yeniden ekrana sokar
                score++;
            }
            if (boru2.Left < -170)
            {
                boru2.Left = 695; // İkinci boruyu sağdan yeniden ekrana sokar
                score++;
            }

            // Kuşun borulara, zemine çarpma durumu veya ekranın üstüne çıkma durumunu kontrol eder
            if (kus.Bounds.IntersectsWith(boru2.Bounds) ||
                kus.Bounds.IntersectsWith(boru1.Bounds) ||
                kus.Bounds.IntersectsWith(zemin.Bounds) || kus.Top < -25)
            {
                endGame(); // Oyunu bitirir
            }

            // Eğer skor 5'ten büyükse oyunun hızını artırır
            if (score > 5)
            {
                speed = 15; // Hızı artırarak oyunu zorlaştırır
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        // Boşluk tuşuna basıldığında çalışan fonksiyon
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -13; // Boşluk tuşuna basıldığında kuşu yukarı uçurur
            }
        }

        // Boşluk tuşu bırakıldığında çalışan fonksiyon
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 13; // Boşluk tuşu bırakıldığında kuşun yeniden düşmesini sağlar
            }
        }

        // Oyunu bitiren fonksiyon
        private void endGame()
        {
            zamanlayici.Stop(); // Zamanlayıcıyı durdurarak oyunu bitirir
            scoreText.Text += " Game over! "; // Ekrana "Game over!" yazdırır
        }
    }
}
