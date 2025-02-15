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
    public partial class asiEkleForm : Form
    {
        private SQLiteConnection conn;
        public asiEkleForm()
        {
            InitializeComponent();
        }
        private void asiEkleForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            veriYukle();
            asiVurulduMu.Width = 75;
        }

        private void asiEkleForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
        }

        public void veriYukle()
        {
            string query = "select * from tumHayvanlar";

            using (SQLiteDataAdapter dadapter = new SQLiteDataAdapter(query, conn))
            {
                DataTable dataTable = new DataTable();
                dadapter.Fill(dataTable);

                tumHayvanlarDataGridView.DataSource = dataTable;
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
            buzagilarButton.Height = navPanel.Height / 8;
            danalarButton.Height = navPanel.Height / 8;
            duvelerButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = tumHayvanlarButton.Height * 2;
        }

        private void ekleButon_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tumHayvanlarDataGridView.Rows)
            {
                bool seciliMi = Convert.ToBoolean(row.Cells["asiVurulduMu"].Value);

                if (seciliMi)
                {
                    string query = "insert into asiListesi(asiAdi, asiTarihi, kupeNo, inekAdi) values(@asiAdi, @asiTarihi, @kupeNo, @inekAdi)";

                    using (SQLiteCommand command = new SQLiteCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@asiAdi", asiAdiInput.Text);
                        command.Parameters.AddWithValue("@asiTarihi", asiVurmaTarihi.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@kupeNo", row.Cells["kupeNo"].Value.ToString());
                        command.Parameters.AddWithValue("@inekAdi", row.Cells["inekAdi"].Value.ToString());

                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Aşı Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tumHayvanlarButon_Click(object sender, EventArgs e)
        {
            anaForm anaform = new anaForm();
            anaform.Show();
            this.Close();
        }

        private void hayvanGuncelleButon_Click(object sender, EventArgs e)
        {
            hayvanGuncelle hayvanguncelle = new hayvanGuncelle();
            hayvanguncelle.Show();
            this.Close();
        }

        private void ineklerButon_Click(object sender, EventArgs e)
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

        private void asilarButton_Click(object sender, EventArgs e)
        {
            asiListeForm asilistesi = new asiListeForm();
            asilistesi.Show();
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