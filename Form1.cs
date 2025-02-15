using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing.Text;
using System.Windows.Forms;

namespace inekCizelge
{
    public partial class anaForm : Form
    {
        private SQLiteConnection conn;
        public anaForm()
        {
            InitializeComponent();
            anaDataGridView.CellClick += anaDataGridView_CellClick;
        }

        private void anaForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            veriYukle();
            butonDuzen();
            hayvanSilButon.Width = 75;
            anaDataGridView.Columns["hayvanSilButon"].DisplayIndex = anaDataGridView.Columns.Count - 1;
        }
        private void anaForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
        }

        private void anaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == anaDataGridView.Columns["hayvanSilButon"].Index)
                {
                    var selectedRow = anaDataGridView.Rows[e.RowIndex];
                    if (selectedRow.Cells["kupeNo"].Value != null && selectedRow.Cells["inekAdi"].Value != null)
                    {
                        string kupeNo = selectedRow.Cells["kupeNo"].Value.ToString();
                        string inekAd = selectedRow.Cells["inekAdi"].Value.ToString();

                        DialogResult result = MessageBox.Show(
                            $"Kayýt silinecek:\nKüpe No: {kupeNo}\nÝnek Ýsim: {inekAd}\nEmin misiniz?",
                            "Silme Onayý",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            hayvanSil(kupeNo);

                            veriYukle();
                        }
                    }
                }
            }
        }





        private void hayvanSil(string kupeNo)
        {
            string tur = "";
            string selectQuery = "SELECT tur FROM tumHayvanlar WHERE kupeNo = @kupeNo";

            using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, conn))
            {
                selectCommand.Parameters.AddWithValue("@kupeNo", kupeNo);
                using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tur = reader["tur"].ToString();
                    }
                }
            }

            if (tur == "inek")
            {
                string inekSil = "DELETE FROM inekler WHERE kupeNo = @kupeNo";

                using (SQLiteCommand inekSilCommand = new SQLiteCommand(inekSil, conn))
                {
                    inekSilCommand.Parameters.AddWithValue("@kupeNo", kupeNo);
                    inekSilCommand.ExecuteNonQuery();
                }
            }
            else if (tur == "dana")
            {
                string inekSil = "DELETE FROM danalar WHERE kupeNo = @kupeNo";

                using (SQLiteCommand inekSilCommand = new SQLiteCommand(inekSil, conn))
                {
                    inekSilCommand.Parameters.AddWithValue("@kupeNo", kupeNo);
                    inekSilCommand.ExecuteNonQuery();
                }
            }
            else if (tur == "duve")
            {
                string inekSil = "DELETE FROM duveler WHERE kupeNo = @kupeNo";

                using (SQLiteCommand inekSilCommand = new SQLiteCommand(inekSil, conn))
                {
                    inekSilCommand.Parameters.AddWithValue("@kupeNo", kupeNo);
                    inekSilCommand.ExecuteNonQuery();
                }
            }
            else if (tur == "buzagi")
            {
                string inekSil = "DELETE FROM buzagilar WHERE kupeNo = @kupeNo";

                using (SQLiteCommand inekSilCommand = new SQLiteCommand(inekSil, conn))
                {
                    inekSilCommand.Parameters.AddWithValue("@kupeNo", kupeNo);
                    inekSilCommand.ExecuteNonQuery();
                }
            }

            string deleteQuery = "DELETE FROM tumHayvanlar WHERE kupeNo = @kupeNo";
            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, conn))
            {
                command.Parameters.AddWithValue("@kupeNo", kupeNo);
                command.ExecuteNonQuery();
            }
        }


        public void sqlBaglanti()
        {
            string databaseFolder = Path.Combine(Application.StartupPath, "Database");

            if (!Directory.Exists(databaseFolder))
            {
                Directory.CreateDirectory(databaseFolder);
                MessageBox.Show("Databases klasörü oluþturuldu: " + databaseFolder);
            }

            string databasePath = Path.Combine(databaseFolder, "Hayvanlar.db");

            string connectionString = $"Data Source={databasePath};Version=3;";
            conn = new SQLiteConnection(connectionString);

            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
                MessageBox.Show("Veritabaný dosyasý oluþturuldu: " + databasePath);
            }

            conn.Open();
        }

        public void veriYukle()
        {
            string query = "SELECT * FROM tumHayvanlar";

            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataAdapter dadapter = new SQLiteDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dadapter.Fill(dataTable);
                    anaDataGridView.DataSource = dataTable;

                    anaDataGridView.Columns["kupeNo"].HeaderText = "Küpe Numarasý";
                    anaDataGridView.Columns["inekAdi"].HeaderText = "Ýnek Adý";
                    anaDataGridView.Columns["dogumTarihi"].HeaderText = "Doðum Tarihi";
                    anaDataGridView.Columns["anneAdi"].HeaderText = "Anne Adý";
                    anaDataGridView.Columns["anneKupeNo"].HeaderText = "Anne Küpe No.";
                    anaDataGridView.Columns["tur"].HeaderText = "Türü";
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
                    buzagiLabel.Text = count3.ToString() + " adet buzaðý var.";
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
                    bosInekLabel.Text = count4.ToString() + " adet boþ inek var.";
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


            guncelleButton.Height = navPanel.Height / 8;
            ineklerButton.Height = navPanel.Height / 8;
            buzagilarButton.Height = navPanel.Height / 8;
            danalarButton.Height = navPanel.Height / 8;
            duvelerButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
            asiEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = guncelleButton.Height * 2;
        }

        private void guncelleButton_Click(object sender, EventArgs e)
        {
            hayvanGuncelle hayvanguncelle = new hayvanGuncelle();
            hayvanguncelle.Show();
            this.Hide();
        }

        private void ineklerButton_Click(object sender, EventArgs e)
        {
            ineklerForm inekler = new ineklerForm();
            inekler.Show();
            this.Hide();
        }

        private void buzagilarButton_Click(object sender, EventArgs e)
        {
            buzagilarForm buzagilar = new buzagilarForm();
            buzagilar.Show();
            this.Hide();
        }

        private void danalarButton_Click(object sender, EventArgs e)
        {
            danalarForm danalar = new danalarForm();
            danalar.Show();
            this.Hide();
        }

        private void hayvanEkleButton_Click(object sender, EventArgs e)
        {
            hayvanEkleForm hayvanEkle = new hayvanEkleForm();
            hayvanEkle.Show();
            this.Hide();
        }

        private void asiEkleButton_Click(object sender, EventArgs e)
        {
            asiEkleForm asiEkle = new asiEkleForm();
            asiEkle.Show();
            this.Hide();
        }

        private void asilarButton_Click(object sender, EventArgs e)
        {
            asiListeForm asiListe = new asiListeForm();
            asiListe.Show();
            this.Hide();
        }

        private void duvelerButton_Click(object sender, EventArgs e)
        {
            duvelerForm duveler = new duvelerForm();
            duveler.Show();
            this.Hide();
        }
    }
}