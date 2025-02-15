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
    public partial class buzagilarForm : Form
    {
        private SQLiteConnection conn;
        public buzagilarForm()
        {
            InitializeComponent();
            anaDataGridView.CellClick += anaDataGridView_CellClick;
        }

        private void buzagilarForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            butonDuzen();
            veriYukle();
            buzagiVeriOto();
            anaDataGridView.Columns["kacGunluk"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            anaDataGridView.Columns["suttenKesilmeGun"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            anaDataGridView.Columns["suttenKesilmeTarihi"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            anaDataGridView.Columns["buzagiSil"].DisplayIndex = anaDataGridView.Columns.Count - 1;
            buzagiSil.Width = 75;
        }
        private void buzagilarForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
        }


        private void anaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == anaDataGridView.Columns["buzagiSil"].Index)
                {
                    var selectedRow = anaDataGridView.Rows[e.RowIndex];
                    if (selectedRow.Cells["kupeNo"].Value != null && selectedRow.Cells["inekAdi"].Value != null)
                    {
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
                            buzagiSilFonk(kupeNo);

                            veriYukle();
                            buzagiVeriOto();
                        }
                    }
                }
            }
        }


        public void buzagiSilFonk(string kupeNo)
        {
            string tumHayvanlarSil = $"DELETE FROM tumHayvanlar WHERE kupeNo = '{kupeNo}'";

            using (SQLiteCommand cmd = new SQLiteCommand(tumHayvanlarSil, conn))
            {
                cmd.ExecuteNonQuery();
            }

            string buzagiSilSorgu = $"DELETE FROM buzagilar WHERE kupeNo = '{kupeNo}'";
            using (SQLiteCommand cmd2 = new SQLiteCommand(buzagiSilSorgu, conn))
            {
                cmd2.ExecuteNonQuery();
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
            danalarButton.Height = navPanel.Height / 8;
            duvelerButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
            asiEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = tumHayvanlarButton.Height * 2;

            anaDataGridView.Columns["suttenKesilmeTarihi"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            anaDataGridView.Columns["suttenKesilmeGun"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            anaDataGridView.Columns["kacGunluk"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            anaDataGridView.Columns["buzagiSil"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void veriYukle()
        {
            string query = "select * from buzagilar";

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
                    anaDataGridView.Columns["cinsiyet"].HeaderText = "Cinsiyet";

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

        public void buzagiVeriOto()
        {
            foreach (DataGridViewRow row in anaDataGridView.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DateTime bugun = DateTime.Now;

                var hucreDegeri = row.Cells["dogumTarihi"].Value;

                if (hucreDegeri == null || string.IsNullOrWhiteSpace(hucreDegeri.ToString()))
                {
                    continue;
                }

                if (DateTime.TryParse(hucreDegeri.ToString(), out DateTime buzagiDogumTar))
                {
                    TimeSpan gun = bugun - buzagiDogumTar;

                    DateTime suttenKesilme = buzagiDogumTar.AddDays(90);

                    row.Cells["kacGunluk"].Value = gun.Days.ToString();
                    row.Cells["suttenKesilmeGun"].Value = suttenKesilme.Day.ToString();
                    row.Cells["suttenKesilmeTarihi"].Value = suttenKesilme.ToShortDateString();

                    var cinsiyetHucreDegeri = row.Cells["cinsiyet"].Value?.ToString();
                    if (cinsiyetHucreDegeri == "erkek")
                    {
                        row.DefaultCellStyle.BackColor = Color.Blue;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (cinsiyetHucreDegeri == "dişi")
                    {
                        row.DefaultCellStyle.BackColor = Color.Pink;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        private void tumHayvanlarButon_Click(object sender, EventArgs e)
        {
            anaForm anaform = new anaForm();
            anaform.Show();
            this.Close();
        }

        private void hayvanGuncelleButon_Click(object sender, EventArgs e)
        {
            hayvanGuncelle guncelle = new hayvanGuncelle();
            guncelle.Show();
            this.Close();
        }

        private void ineklerButon_Click(object sender, EventArgs e)
        {
            ineklerForm inekler = new ineklerForm();
            inekler.Show();
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
            hayvanEkleForm ekle = new hayvanEkleForm();
            ekle.Show();
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
            asiListeForm asilisteForm = new asiListeForm();
            asilisteForm.Show();
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