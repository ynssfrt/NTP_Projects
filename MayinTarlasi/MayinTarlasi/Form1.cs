using System;
using System.Drawing;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        private Button[,] buttons; // Butonlar için 2D dizi
        private bool[,] mines; // Mayın yerlerini tutan 2D dizi
        private const int gridSize = 30; // Oyun tahtası boyutu (30x30)
        private int mineCount; // Kullanıcının girdiği mayın sayısı

        public Form1()
        {
            InitializeComponent(); // Otomatik oluşturulan bileşenler
            InitializeGameControls(); // Oyuna özel kontrolleri ayarla
        }

        private void InitializeGameControls()
        {
            // Mayın sayısını girme kutusu
            Label lblMineCount = new Label
            {
                Text = "Mayın Sayısı:",
                Location = new Point(10, 20), // Yüksekliği biraz arttırarak yukarıya doğru yerleştirdik
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblMineCount);

            TextBox txtMineCount = new TextBox
            {
                Location = new Point(120, 20), // Label'dan uzaklaştırarak yatayda düzgün hizaladık
                Width = 50,
                Font = new Font("Arial", 12),
                BackColor = Color.LightYellow,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(txtMineCount);

            // Oyunu başlat butonu
            Button btnStartGame = new Button
            {
                Text = "Oyunu Başlat",
                Location = new Point(180, 20),  // Mayın sayısı girişinin yanına hizaladık
                Size = new Size(120, 30),
                BackColor = Color.LightSkyBlue,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnStartGame.Click += (sender, e) =>
            {
                // Kullanıcıdan mayın sayısını al
                if (!int.TryParse(txtMineCount.Text, out mineCount) || mineCount < 1 || mineCount > gridSize * gridSize)
                {
                    MessageBox.Show($"Lütfen 1 ile {gridSize * gridSize} arasında bir sayı girin.");
                    return;
                }

                InitializeGameBoard();
            };
            this.Controls.Add(btnStartGame);
        }

        private void InitializeGameBoard()
        {
            buttons = new Button[gridSize, gridSize];
            mines = new bool[gridSize, gridSize];
            Random random = new Random();

            // Form boyutunu ayarla
            this.ClientSize = new Size(gridSize * 30, gridSize * 30 + 100); // Oyun alanını 30x30 hücreye göre boyutlandırdık

            // Mayınları yerleştir
            int placedMines = 0;
            while (placedMines < mineCount)
            {
                int row = random.Next(gridSize);
                int col = random.Next(gridSize);

                if (!mines[row, col])
                {
                    mines[row, col] = true;
                    placedMines++;
                }
            }

            // Butonları oluştur
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Size = new Size(30, 30), // Buton boyutunu 30x30 olarak ayarladım
                        Location = new Point(i * 30, j * 30 + 50), // Butonları başlangıçtaki etiketten biraz daha aşağıya yerleştiriyoruz
                        Tag = new Point(i, j),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat
                    };

                    // Buton kenarlıklarını yuvarlat
                    buttons[i, j].FlatAppearance.BorderSize = 1;
                    buttons[i, j].FlatAppearance.BorderColor = Color.Black;
                    buttons[i, j].Click += Button_Click;
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point location = (Point)clickedButton.Tag;
            int row = location.X;
            int col = location.Y;

            // Butonun tıklanıp tıklanmadığını kontrol et
            if (!clickedButton.Enabled) return; // Zaten tıklanmışsa işlem yapma

            // Mayına basıldıysa
            if (mines[row, col])
            {
                clickedButton.BackColor = Color.Red; // Mayına basıldıysa butonun rengi kırmızı olur
                clickedButton.Text = "M"; // Mayın simgesi
                MessageBox.Show("Mayına bastınız! Oyun bitti.");
                RevealAllMines();
            }
            else
            {
                clickedButton.BackColor = Color.LightBlue; // Mayın olmayan buton maviye döner
                clickedButton.Enabled = false; // Buton devre dışı bırakılır

                // Etrafındaki mayın sayısını hesapla
                int nearbyMines = CountNearbyMines(row, col);
                clickedButton.Text = nearbyMines > 0 ? nearbyMines.ToString() : ""; // Eğer mayın var ise sayıyı göster, yoksa boş bırak
            }
        }

        private void RevealAllMines()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (mines[i, j])
                    {
                        buttons[i, j].BackColor = Color.Red;
                        buttons[i, j].Text = "M";
                    }
                }
            }
        }

        private int CountNearbyMines(int row, int col)
        {
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < gridSize && j >= 0 && j < gridSize && mines[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
