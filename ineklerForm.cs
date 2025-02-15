using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inekCizelge
{
    public partial class ineklerForm : Form
    {
        private SQLiteConnection conn;
        public ineklerForm()
        {
            InitializeComponent();
        }

        private void ineklerForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            veriYukle();
            butonDuzen();
            HesaplaDogumaKalanGunler();
            dogumKontrol.Width = 75;
            anaDataGridView.Columns["dogumKontrol"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            dogumKontrol.DefaultCellStyle.SelectionForeColor = Color.Green;
        }

        private void ineklerForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
            dogumKontrol.Width = 75;
            anaDataGridView.Columns["dogumKontrol"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            dogumKontrol.DefaultCellStyle.SelectionForeColor = Color.Green;
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

        private void anaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // "dogumKontrol" sütununa tıklandı mı?
                if (e.ColumnIndex == anaDataGridView.Columns["dogumKontrol"].Index)
                {
                    var selectedRow = anaDataGridView.Rows[e.RowIndex];

                    // Hücrelerin null olmadığını kontrol et
                    if (selectedRow.Cells["kupeNo"].Value != null &&
                        selectedRow.Cells["inekAdi"].Value != null &&
                        selectedRow.Cells["dogumTarihi"].Value != null &&
                        selectedRow.Cells["anneAdi"].Value != null &&
                        selectedRow.Cells["anneKupeNo"].Value != null)
                    {
                        // Hücrelerden verileri al
                        string kupeNo = selectedRow.Cells["kupeNo"].Value.ToString();
                        string inekAdi = selectedRow.Cells["inekAdi"].Value.ToString();
                        string dogumTarihi = selectedRow.Cells["dogumTarihi"].Value.ToString();
                        string anneAdi = selectedRow.Cells["anneAdi"].Value.ToString();
                        string anneKupeNo = selectedRow.Cells["anneKupeNo"].Value.ToString();

                        // Fonksiyonu çağır ve başarı mesajını göster
                        dogumGirdi(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo);
                        MessageBox.Show("İnek başarıyla güncellendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        veriYukle();
                        anaDataGridView.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Gerekli bilgiler eksik. Lütfen tablodaki verileri kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            buzagilarButton.Height = navPanel.Height / 8;
            danalarButton.Height = navPanel.Height / 8;
            duvelerButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
            asiEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = tumHayvanlarButton.Height * 2;

            anaDataGridView.Columns["dogumKontrol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void HesaplaDogumaKalanGunler()
        {
            int gebelikSuresi = 280;

            foreach (DataGridViewRow row in anaDataGridView.Rows)
            {

                DateTime tohumlamaTarihi = Convert.ToDateTime(row.Cells["tohumlamaTarihi"].Value);
                DateTime bugun = DateTime.Now;
                DateTime tahminiDogumTarihi = tohumlamaTarihi.AddDays(gebelikSuresi);
                DateTime kuruTarihi = tohumlamaTarihi.AddDays(220);

                int kalanGunSayisi = (tahminiDogumTarihi - bugun).Days;

                row.Cells["kuruTarihi"].Value = kuruTarihi.ToString("yyyy-MM-dd");
                row.Cells["tahminiDogumTarihi"].Value = tahminiDogumTarihi.ToString("yyyy-MM-dd");
                row.Cells["dogumGunSayisi"].Value = kalanGunSayisi;

            }
        }


        public void veriYukle()
        {
            string query = "select * from inekler";

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
                    anaDataGridView.Columns["tohumlamaTarihi"].HeaderText = "Tohumlama Tarihi";
                }
            }
            anaDataGridView.Columns["dogumKontrol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

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


        public void dogumGirdi(string kupeNo, string inekAdi, string dogumTarihi, string anneAdi, string anneKupeNo)
        {
            string dogumGecmisEkle = "insert into inekGecmis(kupeNo, inekAdi, dogurduguTarih) values(@kupeNo, @inekAdi, @dogurduguTarih)";

            using (SQLiteCommand command = new SQLiteCommand(dogumGecmisEkle, conn))
            {
                command.Parameters.AddWithValue("@kupeNo", kupeNo);
                command.Parameters.AddWithValue("@inekAdi", inekAdi);
                command.Parameters.AddWithValue("@dogurduguTarih", DateTime.Now.ToString("yyyy-MM-dd"));

                command.ExecuteNonQuery();

            }

            string inekSil = "delete from inekler where kupeNo = @kupeNo";

            using (SQLiteCommand command = new SQLiteCommand(inekSil, conn))
            {
                command.Parameters.AddWithValue("@kupeNo", kupeNo);

                command.ExecuteNonQuery();
            }

            string duveEkle = @"insert into duveler(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, sonDogurduguTarih) 
            values(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @sonDogurduguTarih)";

            using (SQLiteCommand command = new SQLiteCommand(duveEkle, conn))
            {
                command.Parameters.AddWithValue("@kupeNo", kupeNo);
                command.Parameters.AddWithValue("@inekAdi", inekAdi);
                command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi);
                command.Parameters.AddWithValue("@anneAdi", anneAdi);
                command.Parameters.AddWithValue("@anneKupeNo", anneKupeNo);
                command.Parameters.AddWithValue("@sonDogurduguTarih", DateTime.Now.ToString("yyyy-MM-dd"));

                command.ExecuteNonQuery();
            }



            string guncelle = "update tumHayvanlar set tur = 'duve' where kupeNo = @kupeNo";

            using (SQLiteCommand command = new SQLiteCommand(guncelle, conn))
            {
                command.Parameters.AddWithValue("@kupeNo", kupeNo);

                command.ExecuteNonQuery();
            }
            veriYukle();
            anaDataGridView.Refresh();
        }

        private void tumHayvanlarButon_Click(object sender, EventArgs e)
        {
            anaForm tumHayvanciklar = new anaForm();
            tumHayvanciklar.Show();
            this.Close();
        }

        private void hayvanGuncelleButon_Click(object sender, EventArgs e)
        {
            hayvanGuncelle guncelle = new hayvanGuncelle();
            guncelle.Show();
            this.Close();
        }

        private void buzagilarButton_Click(object sender, EventArgs e)
        {
            buzagilarForm buzalar = new buzagilarForm();
            buzalar.Show();
            this.Close();
        }

        private void danalarButton_Click(object sender, EventArgs e)
        {
            danalarForm danaciklar = new danalarForm();
            danaciklar.Show();
            this.Close();
        }

        private void hayvanEkleButton_Click(object sender, EventArgs e)
        {
            hayvanEkleForm ekle = new hayvanEkleForm();
            ekle.Show();
            this.Close();
        }

        private void asiEkleButton_Click(object sender, EventArgs e)
        {
            asiEkleForm ekle = new asiEkleForm();
            ekle.Show();
            this.Close();
        }

        private void asilarButton_Click(object sender, EventArgs e)
        {
            asiListeForm asilar = new asiListeForm();
            asilar.Show();
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