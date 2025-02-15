using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inekCizelge
{
    public partial class duvelerForm : Form
    {
        private SQLiteConnection conn;
        public duvelerForm()
        {
            InitializeComponent();
            anaDataGridView.CellClick += anaDataGridView_CellClick;
        }

        private void duvelerForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            veriYukle();
            butonDuzen();
            tohumlandi.DisplayIndex = anaDataGridView.Columns.Count - 1;
            tohumlandi.Width = 100;
            silButton.DisplayIndex = anaDataGridView.Columns.Count - 1;
            silButton.Width = 75;
        }

        private void duvelerForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
        }

        private void anaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == anaDataGridView.Columns["silButton"].Index)
                {
                    var selectedRow = anaDataGridView.Rows[e.RowIndex];

                    string kupeNo = selectedRow.Cells["kupeNo"].Value.ToString();
                    string inekAd = selectedRow.Cells["inekAdi"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        $"Kayıt silinecek:\nKüpe No: {kupeNo}\nBuzağı İsim: {inekAd}\nEmin misiniz?",
                        "Silme Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        string duveSil = $"DELETE FROM duveler WHERE kupeNo = {kupeNo}";
                        string tumHayvanlarSil = $"DELETE FROM tumHayvanlar WHERE kupeNo = {kupeNo}";

                        using (SQLiteCommand command = new SQLiteCommand(duveSil, conn))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (SQLiteCommand command = new SQLiteCommand(tumHayvanlarSil, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else if (e.ColumnIndex == anaDataGridView.Columns["tohumlandi"].Index)
                {
                    var selectedRow = anaDataGridView.Rows[e.RowIndex];

                    string kupeNo = selectedRow.Cells["kupeNo"].Value.ToString();


                    string inekEkle = "INSERT INTO inekler(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, tohumlamaTarihi) VALUES(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @tohumlamaTarihi)";

                    using (SQLiteCommand command = new SQLiteCommand(inekEkle, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", selectedRow.Cells["kupeNo"].Value.ToString());
                        command.Parameters.AddWithValue("@inekAdi", selectedRow.Cells["inekAdi"].Value.ToString());
                        command.Parameters.AddWithValue("@dogumTarihi", selectedRow.Cells["dogumTarihi"].Value.ToString());
                        command.Parameters.AddWithValue("@anneAdi", selectedRow.Cells["anneAdi"].Value.ToString());
                        command.Parameters.AddWithValue("@anneKupeNo", selectedRow.Cells["anneKupeNo"].Value.ToString());
                        command.Parameters.AddWithValue("@tohumlamaTarihi", DateTime.Now.ToString("yyyy-MM-dd"));

                        command.ExecuteNonQuery();
                    }

                    string duveSil = $"DELETE FROM duveler WHERE kupeNo = '{kupeNo}'";

                    using (SQLiteCommand command = new SQLiteCommand(duveSil, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    string hayvanGuncelle = $"UPDATE tumHayvanlar SET tur = 'inek' WHERE kupeNo = '{kupeNo}'";

                    using (SQLiteCommand command = new SQLiteCommand(hayvanGuncelle, conn))
                    {  
                        command.ExecuteNonQuery();
                    }
                }
            }
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
            danalarButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
            asiEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = tumHayvanlarButton.Height * 2;
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


        public void veriYukle()
        {
            string query = "select * from duveler";

            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataAdapter dadapter = new SQLiteDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    dadapter.Fill(dt);
                    anaDataGridView.DataSource = dt;

                    anaDataGridView.Columns["kupeNo"].HeaderText = "Küpe Numarası";
                    anaDataGridView.Columns["inekAdi"].HeaderText = "İnek Adı";
                    anaDataGridView.Columns["dogumTarihi"].HeaderText = "Doğum Tarihi";
                    anaDataGridView.Columns["anneAdi"].HeaderText = "Anne Adı";
                    anaDataGridView.Columns["anneKupeNo"].HeaderText = "Anne Küpe No.";
                    anaDataGridView.Columns["sonDogurduguTarih"].HeaderText = "Son Doğurduğu Tarih";
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





        private void tumHayvanlarButton_Click(object sender, EventArgs e)
        {
            anaForm tumhayvanlar = new anaForm();
            tumhayvanlar.Show();
            this.Close();
        }

        private void guncelleButton_Click(object sender, EventArgs e)
        {
            hayvanGuncelle guncelle = new hayvanGuncelle();
            guncelle.Show();
            this.Close();
        }

        private void ineklerButton_Click(object sender, EventArgs e)
        {
            ineklerForm inekler = new ineklerForm();
            inekler.Show();
            this.Close();
        }

        private void buzagilarButton_Click(object sender, EventArgs e)
        {
            buzagilarForm buzagilar = new buzagilarForm();
            buzagilar.Show();
            this.Close();
        }

        private void danalarButton_Click(object sender, EventArgs e)
        {
            danalarForm danalar = new danalarForm();
            danalar.Show();
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
            asiListeForm asilar = new asiListeForm();
            asilar.Show();
            this.Close();
        }
    }
}