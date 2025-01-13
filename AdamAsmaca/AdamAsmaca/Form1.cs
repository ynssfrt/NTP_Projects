using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        private string[] Iller = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya",
                                   "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik",
                                   "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
                                   "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep",
                                   "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir",
                                   "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kilis", "Kırıkkale",
                                   "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin",
                                   "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya",
                                   "Samsun", "Siirt", "Sinop", "Sivas", "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon",
                                   "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };

        private string secilenSehir;
        private string gizliKelime;
        private int kalanHak;
        private List<string> kelimeTahmin;
        private const int MAX_HAK = 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaslatOyunu();
        }

        private void BaslatOyunu()
        {
            secilenSehir = Iller[new Random().Next(Iller.Length)];
            gizliKelime = new string('_', secilenSehir.Length);
            kalanHak = MAX_HAK;
            kelimeTahmin = new List<string>();
            GuncelleGizliKelime();
            labelKalanHak.Text = "Kalan Hak: " + kalanHak;
            pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "asama0.png"));
            CreateLetterButtons();
        }

        private void GuncelleGizliKelime()
        {
            string aralikliKelime = string.Join(" ", gizliKelime.ToCharArray());
            labelGizliKelime.Text = aralikliKelime;
        }

        private void CreateLetterButtons()
        {
            buttonPanel.Controls.Clear();
            const int BUTTON_SIZE = 40;

            foreach (char letter in "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ")
            {
                Button button = new Button
                {
                    Text = letter.ToString(),
                    Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                    BackColor = Color.LightCoral,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Margin = new Padding(5)
                };
                button.Click += (sender, e) => HarfTahminEt(button);
                buttonPanel.Controls.Add(button);
            }

            buttonPanel.AutoSize = true;
            buttonPanel.Location = new Point((this.ClientSize.Width - buttonPanel.Width) / 2, labelGizliKelime.Bottom + 20);
            buttonPanel.Dock = DockStyle.Bottom;
        }

        private void HarfTahminEt(Button tahminButonu)
        {
            string tahmin = tahminButonu.Text;

            if (kelimeTahmin.Contains(tahmin.ToLower()))
            {
                MessageBox.Show("Bu harfi zaten tahmin ettiniz!");
                return;
            }

            kelimeTahmin.Add(tahmin.ToLower());
            tahminButonu.Visible = false;

            ProcessTahmin(tahmin);
        }

        private void ProcessTahmin(string tahmin)
        {
            bool harfBulundu = false;

            for (int i = 0; i < secilenSehir.Length; i++)
            {
                if (secilenSehir.ToLower()[i] == tahmin.ToLower()[0])
                {
                    gizliKelime = gizliKelime.Remove(i, 1).Insert(i, tahmin.ToLower());
                    harfBulundu = true;
                }
            }

            if (!harfBulundu)
            {
                kalanHak--;
                string imagePath = Path.Combine(Application.StartupPath, "Resources", $"asama{MAX_HAK - kalanHak}.png");
                pictureBox1.Image = Image.FromFile(imagePath);
            }

            GuncelleGizliKelime();
            labelKalanHak.Text = "Kalan Hak: " + kalanHak;

            if (kalanHak <= 0)
            {
                MessageBox.Show("Kaybettiniz! Doğru kelime: " + secilenSehir);
                BaslatOyunu();
            }
            else if (!gizliKelime.Contains('_'))
            {
                MessageBox.Show("Tebrikler! Kelimeyi bildiniz: " + secilenSehir);
                BaslatOyunu();
            }
        }

        private void buttonTahmin_Click(object sender, EventArgs e)
        {
            string tahmin = textBoxTahmin.Text.ToUpper();

            // Klavye ile yalnızca harf girildiğinden emin ol
            if (!char.TryParse(tahmin, out char harf) || !char.IsLetter(harf))
            {
                MessageBox.Show("Lütfen yalnızca bir harf giriniz!");
                return;
            }

            // Giriş alanının boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(tahmin))
            {
                MessageBox.Show("Lütfen bir harf giriniz!");
                return;
            }

            if (tahmin.Length > 1)
            {
                MessageBox.Show("Lütfen sadece bir harf giriniz!");
                return;
            }

            if (kelimeTahmin.Contains(tahmin.ToLower()))
            {
                MessageBox.Show("Bu harfi zaten tahmin ettiniz!");
                return;
            }

            kelimeTahmin.Add(tahmin.ToLower());
            textBoxTahmin.Clear();
            ProcessTahmin(tahmin);

            foreach (Button button in buttonPanel.Controls.OfType<Button>())
            {
                if (button.Text == tahmin)
                {
                    button.Visible = false;
                }
            }
        }

        private void buttonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
