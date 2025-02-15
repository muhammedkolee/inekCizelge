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
    public partial class hayvanEkleForm : Form
    {
        private SQLiteConnection conn;
        public hayvanEkleForm()
        {
            InitializeComponent();
        }

        private void hayvanEkleForm_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            veriYukle();
            butonDuzen();
        }

        private void hayvanEkleForm_Resize(object sender, EventArgs e)
        {
            butonDuzen();
        }



        public void veriYukle()
        {
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
            asiEkleButton.Height = navPanel.Height / 8;
            asilarButton.Height = navPanel.Height / 8;
            navPanel.Width = tumHayvanlarButton.Height * 2;


            int leftMargin = bilgiGroupBox.Width / 6;
            int topMargin = 20;
            int verticalSpacing = 30;

            hayvanGuncelleLabel.Left = leftMargin;
            hayvanGuncelleLabel.Top = topMargin;
            hayvanComboBox.Left = leftMargin + hayvanGuncelleLabel.Width;
            hayvanComboBox.Top = topMargin;

            tohumlamaTarihiLabel.Left = leftMargin;
            tohumlamaTarihiLabel.Top = hayvanGuncelleLabel.Bottom + verticalSpacing;
            tohumlamaTarihi.Left = leftMargin + tohumlamaTarihiLabel.Width + 10;
            tohumlamaTarihi.Top = tohumlamaTarihiLabel.Top;

            kupeNoLabel.Left = leftMargin;
            kupeNoLabel.Top = tohumlamaTarihiLabel.Bottom + verticalSpacing;
            kupeNoInput.Left = tohumlamaTarihi.Left;
            kupeNoInput.Top = kupeNoLabel.Top;

            inekAdLabel.Left = leftMargin;
            inekAdLabel.Top = kupeNoLabel.Bottom + verticalSpacing;
            inekAdInput.Left = tohumlamaTarihi.Left;
            inekAdInput.Top = inekAdLabel.Top;

            dogumTarihiLabel.Left = leftMargin;
            dogumTarihiLabel.Top = inekAdLabel.Bottom + verticalSpacing;
            dogumTarihi.Left = tohumlamaTarihi.Left;
            dogumTarihi.Top = dogumTarihiLabel.Top;

            anneAdiLabel.Left = leftMargin;
            anneAdiLabel.Top = dogumTarihiLabel.Bottom + verticalSpacing;
            anneAdiInput.Left = tohumlamaTarihi.Left;
            anneAdiInput.Top = anneAdiLabel.Top;

            anneKupeNoLabel.Left = leftMargin;
            anneKupeNoLabel.Top = anneAdiLabel.Bottom + verticalSpacing;
            anneKupeNoInput.Left = tohumlamaTarihi.Left;
            anneKupeNoInput.Top = anneKupeNoLabel.Top;

            cinsiyetLabel.Left = leftMargin;
            cinsiyetLabel.Top = anneKupeNoLabel.Bottom + verticalSpacing;
            cinsiyetComboBox.Left = tohumlamaTarihi.Left;
            cinsiyetComboBox.Top = cinsiyetLabel.Top;

            sonDogurduguTarihLabel.Left = leftMargin;
            sonDogurduguTarihLabel.Top = cinsiyetLabel.Bottom + verticalSpacing;
            sonDogurduguTarihInput.Left = tohumlamaTarihi.Left;
            sonDogurduguTarihInput.Top = sonDogurduguTarihLabel.Top;

            ekleButon.Left = cinsiyetComboBox.Left + cinsiyetComboBox.Width;
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

        private void ekleButon_Click(object sender, EventArgs e)
        {
            string turr = "";
            if (hayvanComboBox.SelectedIndex == 0)
            {
                turr = "buzagi";
                // buzagilar
                string buzagiEkle = "INSERT INTO buzagilar(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, cinsiyet) values(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @cinsiyet)";
                using (SQLiteCommand command = new SQLiteCommand(buzagiEkle, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    command.Parameters.AddWithValue("@cinsiyet", cinsiyetComboBox.Text);

                    command.ExecuteNonQuery();
                }
            }
            else if (hayvanComboBox.SelectedIndex == 1)
            {
                turr = "inek";
                // inekler
                string inekEkle = "INSERT INTO inekler(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, tohumlamaTarihi) values(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @tohumlamaTarihi)";
                using (SQLiteCommand command = new SQLiteCommand(inekEkle, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    command.Parameters.AddWithValue("@tohumlamaTarihi", tohumlamaTarihi.Value.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
            else if (hayvanComboBox.SelectedIndex == 2)
            {
                turr = "dana";
                // danalar
                string danaEkle = "INSERT INTO danalar(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo) values(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo)";
                using (SQLiteCommand command = new SQLiteCommand(danaEkle, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);

                    command.ExecuteNonQuery();
                }
            }
            else if (hayvanComboBox.SelectedIndex == 3)
            {
                turr = "duve";
                // duveler
                string duveEkle = "INSERT INTO danalar(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, sonDogurduguTarih) values(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @sonDogurduguTarih)";
                using (SQLiteCommand command = new SQLiteCommand(duveEkle, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    command.Parameters.AddWithValue("@sonDogurduguTarih", sonDogurduguTarihInput.Value.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Bir Hata Meydana Geldi!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (hayvanComboBox.Text == string.Empty)
            {
                MessageBox.Show("Bir Hata Meydana Geldi!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string tumHayvanlarEkle = "INSERT INTO tumHayvanlar(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, tur) VALUES(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @tur)";

                using (SQLiteCommand command = new SQLiteCommand(tumHayvanlarEkle, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    command.Parameters.AddWithValue("@tur", turr);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void hayvanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //buzagi inek dana duve
            if (hayvanComboBox.SelectedIndex == 0)
            {
                cinsiyetComboBox.Enabled = true;
                tohumlamaTarihi.Enabled = false;
                sonDogurduguTarihInput.Enabled = false;
            }
            else if (hayvanComboBox.SelectedIndex == 1)
            {
                cinsiyetComboBox.Enabled = false;
                tohumlamaTarihi.Enabled = true;
                sonDogurduguTarihInput.Enabled = false;
            }
            else if (hayvanComboBox.SelectedIndex == 2)
            {
                cinsiyetComboBox.Enabled = false;
                tohumlamaTarihi.Enabled = false;
                sonDogurduguTarihInput.Enabled = false;
            }
            else if (hayvanComboBox.SelectedIndex == 3)
            {
                cinsiyetComboBox.Enabled = false;
                tohumlamaTarihi.Enabled = false;
                sonDogurduguTarihInput.Enabled = true;
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

        private void duvelerButton_Click(object sender, EventArgs e)
        {
            duvelerForm duveler = new duvelerForm();
            duveler.Show();
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