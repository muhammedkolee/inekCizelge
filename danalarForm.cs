using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inekCizelge
{
    public partial class danalarForm : Form
    {
        private SQLiteConnection conn;
        public danalarForm()
        {
            InitializeComponent();
        }

        private void danalarForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            butonDuzen();
            veriYukle();
            anaDataGridView.Columns["silButton"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            silButton.Width = 75;
        }
        private void danalarForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
        }

        public void butonDuzen()
        {
            hamileInekLabel.Left = (bilgiPanel.Width - hamileInekLabel.Width) / 6;
            bosInekLabel.Left = hamileInekLabel.Left + bosInekLabel.Width + bilgiPanel.Width / 10;
            buzagiLabel.Left = bosInekLabel.Left + buzagiLabel.Width + bilgiPanel.Width / 10;
            danaLabel.Left = buzagiLabel.Left + danaLabel.Width + bilgiPanel.Width / 10;

            hamileInekLabel.Height = bilgiPanel.Height / 2;
            bosInekLabel.Height = bilgiPanel.Height / 2;
            buzagiLabel.Height = bilgiPanel.Height / 2;
            danaLabel.Height = bilgiPanel.Height / 2;


            tumHayvanlarButton.Height = navPanel.Height / 8;
            guncelleButton.Height = navPanel.Height / 8;
            ineklerButton.Height = navPanel.Height / 8;
            buzagilarButton.Height = navPanel.Height / 8;
            duvelerButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
            asiEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = tumHayvanlarButton.Height * 2;
        }

        public void veriYukle()
        {
            string query = "select * from danalar";

            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataAdapter dadapter = new SQLiteDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dadapter.Fill(dataTable);
                    anaDataGridView.DataSource = dataTable;

                    anaDataGridView.Columns["kupeNo"].HeaderText = "Küpe Numarası";
                    anaDataGridView.Columns["inekAdi"].HeaderText = "İnek Adı";
                    anaDataGridView.Columns["dogumTarihi"].HeaderText = "Doğum Tarihi";
                    anaDataGridView.Columns["anneAdi"].HeaderText = "Anne Adı";
                    anaDataGridView.Columns["anneKupeNo"].HeaderText = "Anne Küpe No.";
                }
            }

            string sorguHamile = "SELECT COUNT(*) FROM inekler";
            string sorguBos = "SELECT COUNT(*) FROM duveler";
            string sorguDana = "SELECT COUNT(*) FROM danalar";
            string sorguBuzagi = "SELECT COUNT(*) FROM buzagilar";


            using (SQLiteCommand command = new SQLiteCommand(sorguHamile, conn))
            {
                object hamileSayi = command.ExecuteScalar();

                if (hamileSayi != null && int.TryParse(hamileSayi.ToString(), out int count))
                {
                    hamileInekLabel.Text = count.ToString() + " gebe inek var.";
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            using (SQLiteCommand command = new SQLiteCommand(sorguDana, conn))
            {
                object danaSayi = command.ExecuteScalar();

                if (danaSayi != null && int.TryParse(danaSayi.ToString(), out int count2))
                {
                    danaLabel.Text = count2.ToString() + " adet dana var.";
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            using (SQLiteCommand command = new SQLiteCommand(sorguBuzagi, conn))
            {
                object buzagiSayi = command.ExecuteScalar();

                if (buzagiSayi != null && int.TryParse(buzagiSayi.ToString(), out int count3))
                {
                    buzagiLabel.Text = count3.ToString() + " adet buzağı var.";
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            using (SQLiteCommand command = new SQLiteCommand(sorguBos, conn))
            {
                object bosSayi = command.ExecuteScalar();

                if (bosSayi != null && int.TryParse(bosSayi.ToString(), out int count4))
                {
                    bosInekLabel.Text = count4.ToString() + " adet boş inek var.";
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void sqlBaglanti()
        {
            string databaseFolder = Path.Combine(Application.StartupPath, "Database");

            if (!Directory.Exists(databaseFolder))
            {
                Directory.CreateDirectory(databaseFolder);
                MessageBox.Show("Databases klasörü oluşturuldu: " + databaseFolder);
            }

            string databasePath = Path.Combine(databaseFolder, "Hayvanlar.db");

            string connectionString = $"Data Source={databasePath};Version=3;";
            conn = new SQLiteConnection(connectionString);

            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
                MessageBox.Show("Veritabanı dosyası oluşturuldu: " + databasePath);
            }
            conn.Open();
        }

        private void tumHayvanlarButon_Click(object sender, EventArgs e)
        {
            anaForm anaform = new anaForm();
            anaform.Show();
            this.Close();
        }

        private void hayvanGuncelleButon_Click(object sender, EventArgs e)
        {
            hayvanGuncelle guncelleform = new hayvanGuncelle();
            guncelleform.Show();
            this.Close();
        }

        private void ineklerButon_Click(object sender, EventArgs e)
        {
            ineklerForm ineklerform = new ineklerForm();
            ineklerform.Show();
            this.Close();
        }

        private void buzagilarButton_Click(object sender, EventArgs e)
        {
            buzagilarForm buzagilarform = new buzagilarForm();
            buzagilarform.Show();
            this.Close();
        }

        private void hayvanEkleButton_Click(object sender, EventArgs e)
        {
            hayvanEkleForm hayvanekle = new hayvanEkleForm();
            hayvanekle.Show();
            this.Close();
        }

        private void asiEkleButton_Click(object sender, EventArgs e)
        {
            asiEkleForm asiekle = new asiEkleForm();
            asiekle.Show();
            this.Close();
        }

        private void asilarButton_Click(object sender, EventArgs e)
        {
            asiListeForm asiliste = new asiListeForm();
            asiliste.Show();
            this.Close();
        }

        private void duvelerButton_Click(object sender, EventArgs e)
        {
            duvelerForm duveler = new duvelerForm();
            duveler.Show();
            this.Close();
        }
    }
}