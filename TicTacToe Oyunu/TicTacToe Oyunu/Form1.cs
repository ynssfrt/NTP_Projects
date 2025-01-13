using System;
using System.Windows.Forms;

namespace TicTacToeOyunu
{
    public partial class Form1 : Form
    {
        private Button[] buttons = new Button[9];  // Butonlar için dizi
        private string currentPlayer = "X";  // Başlangıçta X oynar
        private bool gameEnded = false;  // Oyunun bitip bitmediğini kontrol eder

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();  // Butonları başlatan metod
        }

        private void InitializeButtons()
        {
            for (int i = 0; i < 9; i++)
            {
                buttons[i] = new Button();
                buttons[i].Size = new System.Drawing.Size(75, 75);  // Buton boyutunu belirleyelim
                buttons[i].Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);  // Font boyutu
                buttons[i].Click += new EventHandler(Button_Click);  // Tıklama olayına metod bağlar
                buttons[i].Tag = i;  // Butonun indeksini tutan etiket
                this.Controls.Add(buttons[i]);  // Butonları forma ekler
            }

            // Butonları 3x3 grid şeklinde konumlandır
            buttons[0].Location = new System.Drawing.Point(10, 10);  // Üst sol
            buttons[1].Location = new System.Drawing.Point(90, 10);  // Üst orta
            buttons[2].Location = new System.Drawing.Point(170, 10);  // Üst sağ
            buttons[3].Location = new System.Drawing.Point(10, 90);  // Ortada sol
            buttons[4].Location = new System.Drawing.Point(90, 90);  // Ortada orta
            buttons[5].Location = new System.Drawing.Point(170, 90);  // Ortada sağ
            buttons[6].Location = new System.Drawing.Point(10, 170);  // Alt sol
            buttons[7].Location = new System.Drawing.Point(90, 170);  // Alt orta
            buttons[8].Location = new System.Drawing.Point(170, 170);  // Alt sağ

            lblTurn.Text = "Sıradaki Oyuncu: X";  // Başlangıçta X'nin sırası
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Eğer buton zaten tıklanmışsa veya oyun bitmişse, işlem yapma
            if (clickedButton.Text != "" || gameEnded)
            {
                return;
            }

            // Butonu güncelle
            clickedButton.Text = currentPlayer;

            // Kazanan durumu kontrol et
            if (CheckWin())
            {
                MessageBox.Show(currentPlayer + " kazandı!");
                gameEnded = true;
                return;
            }

            // Oyuncu sırasını değiştir
            currentPlayer = currentPlayer == "X" ? "O" : "X";
            lblTurn.Text = "Sıradaki Oyuncu: " + currentPlayer;
        }

        private bool CheckWin()
        {
            int[,] winningCombinations = new int[,]
            {
                { 0, 1, 2 }, 
                { 3, 4, 5 }, 
                { 6, 7, 8 }, 
                { 0, 3, 6 }, 
                { 1, 4, 7 }, 
                { 2, 5, 8 }, 
                { 0, 4, 8 }, 
                { 2, 4, 6 }  
            };

            for (int i = 0; i < 8; i++)
            {
                int pos1 = winningCombinations[i, 0];
                int pos2 = winningCombinations[i, 1];
                int pos3 = winningCombinations[i, 2];

                if (buttons[pos1].Text == currentPlayer && buttons[pos2].Text == currentPlayer && buttons[pos3].Text == currentPlayer)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            gameEnded = false; 
            currentPlayer = "X";
            lblTurn.Text = "Sıradaki Oyuncu: X";  // Oyuncu sırasını göster

            // Butonları temizle
            foreach (Button button in buttons)
            {
                button.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
