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
    public partial class hayvanGuncelle : Form
    {
        SQLiteConnection conn;
        List<string> kupeNoListesi = new List<string>();
        public string vt = "";
        public hayvanGuncelle()
        {
            InitializeComponent();
        }

        private void hayvanGuncelle_Load(object sender, EventArgs e)
        {
            sqlBaglanti();
            butonDuzen();
            veriYukle();
        }
        private void hayvanGuncelle_Resize(object sender, EventArgs e)
        {
            butonDuzen();
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
            ineklerButton.Height = navPanel.Height / 8;
            buzagilarButton.Height = navPanel.Height / 8;
            danalarButton.Height = navPanel.Height / 8;
            duvelerButton.Height = navPanel.Height / 8;
            hayvanEkleButton.Height = navPanel.Height / 8;
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

            turLabel.Left = leftMargin;
            turLabel.Top = cinsiyetLabel.Bottom + verticalSpacing;
            turComboBox.Left = tohumlamaTarihi.Left;
            turComboBox.Top = turLabel.Top;

            sonDogurduguTarihLabel.Left = leftMargin;
            sonDogurduguTarihLabel.Top = turLabel.Bottom + verticalSpacing;
            sonDogurduguTarihInput.Left = tohumlamaTarihi.Left;
            sonDogurduguTarihInput.Top = sonDogurduguTarihLabel.Top;

            guncelleButon.Left = cinsiyetComboBox.Left + cinsiyetComboBox.Width;
        }

        public void veriGetir()
        {

            if (hayvanComboBox.SelectedItem != null)
            {
                string selectedKupeNo = hayvanComboBox.SelectedItem.ToString();
                string tur = "";
                bool recordFound = false;

                string turQuery = "SELECT tur FROM tumHayvanlar WHERE kupeNo = @kupeNo";

                using (SQLiteCommand turCommand = new SQLiteCommand(turQuery, conn))
                {
                    turCommand.Parameters.AddWithValue("@kupeNo", selectedKupeNo);

                    using (SQLiteDataReader reader = turCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tur = reader["tur"].ToString();
                            turComboBox.Text = tur;

                        }
                        else
                        {
                            MessageBox.Show("Kayıt Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string table = "";
                switch (tur.ToLower())
                {
                    case "inek":
                        table = "inekler";
                        break;
                    case "duve":
                        table = "duveler";
                        break;
                    case "buzagi":
                        table = "buzagilar";
                        break;
                    case "dana":
                        table = "danalar";
                        break;
                    default:
                        MessageBox.Show("Geçersiz tür bilgisi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }


                if (table == "inekler")
                {
                    string inekSorgu = "select kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, tohumlamaTarihi from inekler where kupeNo = @kupeNo";

                    using (SQLiteCommand command = new SQLiteCommand(inekSorgu, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", selectedKupeNo);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                kupeNoInput.Text = reader["kupeNo"].ToString();
                                inekAdInput.Text = reader["inekAdi"].ToString();
                                dogumTarihi.Value = DateTime.Parse(reader["dogumTarihi"].ToString());
                                anneAdiInput.Text = reader["anneAdi"].ToString();
                                anneKupeNoInput.Text = reader["anneKupeNo"].ToString();
                                tohumlamaTarihi.Value = DateTime.Parse(reader["tohumlamaTarihi"].ToString());

                                recordFound = true;
                            }
                        }
                    }
                }

                else if (table == "buzagilar")
                {

                    string inekSorgu = "select kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, cinsiyet from buzagilar where kupeNo = @kupeNo";

                    using (SQLiteCommand command = new SQLiteCommand(inekSorgu, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", selectedKupeNo);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                kupeNoInput.Text = reader["kupeNo"].ToString();
                                inekAdInput.Text = reader["inekAdi"].ToString();
                                dogumTarihi.Value = DateTime.Parse(reader["dogumTarihi"].ToString());
                                anneAdiInput.Text = reader["anneAdi"].ToString();
                                anneKupeNoInput.Text = reader["anneKupeNo"].ToString();
                                if (reader["cinsiyet"] == "erkek")
                                {
                                    cinsiyetComboBox.SelectedIndex = 0;
                                }
                                else
                                {
                                    cinsiyetComboBox.SelectedIndex = 1;
                                }

                                recordFound = true;
                            }
                        }
                    }

                }


                else if (table == "danalar" || table == "duveler")
                {
                    string query = $"SELECT kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo FROM {table} WHERE kupeNo = @kupeNo";

                    using (SQLiteCommand command = new SQLiteCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", selectedKupeNo);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                kupeNoInput.Text = reader["kupeNo"].ToString();
                                inekAdInput.Text = reader["inekAdi"].ToString();
                                dogumTarihi.Value = DateTime.Parse(reader["dogumTarihi"].ToString());
                                anneAdiInput.Text = reader["anneAdi"].ToString();
                                anneKupeNoInput.Text = reader["anneKupeNo"].ToString();

                                // Ek alanlar için kontrol
                                if (table == "inekler")
                                {
                                    tohumlamaTarihi.Value = DateTime.ParseExact(reader["tohumlamaTarihi"].ToString(), "dd.MM.yyyy", null);
                                }
                                if (table == "buzagilar")
                                {
                                    if (reader["cinsiyet"].ToString() == "erkek")
                                    {
                                        cinsiyetComboBox.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        cinsiyetComboBox.SelectedIndex = 1;
                                    }
                                }

                                recordFound = true;
                            }
                        }
                    }
                }
            }

        }

        public void veriYukle()
        {
            string selectQuery = "SELECT kupeNo FROM tumHayvanlar";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, conn))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kupeNoListesi.Add(reader["kupeNo"].ToString());
                    }
                }
            }

            foreach (string kupeNo in kupeNoListesi)
            {
                hayvanComboBox.Items.Add(kupeNo);
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

        private void hayvanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            veriGetir();
            string selectedTur = turComboBox.SelectedItem.ToString();

            if (selectedTur == "inek")
            {
                cinsiyetComboBox.Enabled = false;
                cinsiyetComboBox.Text = string.Empty;
                sonDogurduguTarihInput.Enabled = false;

                tohumlamaTarihi.Enabled = true;

                string query = @"
                SELECT dogurduguTarih
                FROM inekGecmis
                WHERE kupeNo = @kupeNo
                AND dogurduguTarih = (
                    SELECT MAX(dogurduguTarih)
                    FROM inekGecmis
                    WHERE kupeNo = @kupeNo
                )";

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sonDogurduguTarihInput.Value = DateTime.ParseExact(reader["dogurduguTarih"].ToString(), "dd-MM-yyyy", null);
                        }
                    }
                }
            }
            else if (selectedTur == "buzagi")
            {
                tohumlamaTarihi.Enabled = false;
                tohumlamaTarihi.Value = DateTime.Now;
                sonDogurduguTarihInput.Enabled = false;
                sonDogurduguTarihInput.Value = DateTime.Now;

                cinsiyetComboBox.Enabled = true;

                string query = @"
                SELECT cinsiyet
                FROM buzagilar
                WHERE kupeNo = @kupeNo
                ";

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cinsiyetComboBox.Text = reader["cinsiyet"].ToString();
                        }
                    }
                }
            }
            else if (selectedTur == "duve")
            {
                tohumlamaTarihi.Enabled = Enabled;
                tohumlamaTarihi.Value = DateTime.Parse("01.01.1970");
                cinsiyetComboBox.Enabled = false;
                cinsiyetComboBox.Text = string.Empty;
                sonDogurduguTarihInput.Enabled = true;
                turComboBox.Enabled = true;




                string query = @"
                SELECT dogurduguTarih
                FROM inekGecmis
                WHERE kupeNo = @kupeNo
                AND dogurduguTarih = (
                    SELECT MAX(dogurduguTarih)
                    FROM inekGecmis
                    WHERE kupeNo = @kupeNo
                )";

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sonDogurduguTarihInput.Value = DateTime.ParseExact(reader["dogurduguTarih"].ToString(), "dd-MM-yyyy", null);
                        }
                        else
                        {
                            sonDogurduguTarihInput.Value = DateTime.Now;
                        }
                    }
                }
            }
            else if (selectedTur == "dana")
            {
                cinsiyetComboBox.Enabled = false;
                cinsiyetComboBox.Text = string.Empty;
                tohumlamaTarihi.Enabled = false;
                tohumlamaTarihi.Value = DateTime.Now;
                sonDogurduguTarihInput.Enabled = false;
                sonDogurduguTarihInput.Value = DateTime.Now;
            }

        }

        private void guncelleButon_Click(object sender, EventArgs e)
        {

            string kupeNum = hayvanComboBox.SelectedItem.ToString();
            string selectedTur = turComboBox.SelectedItem.ToString();

            string tumHayvanlarGuncelleSorgu = @"
        UPDATE tumHayvanlar 
        SET 
            kupeNo = @kupeNo,
            inekAdi = @inekAdi, 
            dogumTarihi = @dogumTarihi, 
            anneAdi = @anneAdi, 
            anneKupeNo = @anneKupeNo,
            tur = @tur
        WHERE kupeNo = @kupeNoEski";

            using (SQLiteCommand tumHayvanlarCommand = new SQLiteCommand(tumHayvanlarGuncelleSorgu, conn))
            {
                tumHayvanlarCommand.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                tumHayvanlarCommand.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                tumHayvanlarCommand.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                tumHayvanlarCommand.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                tumHayvanlarCommand.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                tumHayvanlarCommand.Parameters.AddWithValue("@tur", selectedTur);
                tumHayvanlarCommand.Parameters.AddWithValue("@kupeNoEski", kupeNum);

                try
                {
                    tumHayvanlarCommand.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (turComboBox.SelectedIndex == 0)
            {
                string ineklerGuncelleSogru = $@"
        UPDATE inekler
        SET 
            kupeNo = @kupeNo,
            inekAdi = @inekAdi, 
            dogumTarihi = @dogumTarihi, 
            anneAdi = @anneAdi, 
            anneKupeNo = @anneKupeNo,
            tohumlamaTarihi = @tohumlamaTarihi
        where kupeNo = @kupeNum";

                using (SQLiteCommand ineklerGuncelle = new SQLiteCommand(ineklerGuncelleSogru, conn))
                {
                    ineklerGuncelle.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    ineklerGuncelle.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    ineklerGuncelle.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    ineklerGuncelle.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    ineklerGuncelle.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    ineklerGuncelle.Parameters.AddWithValue("@tohumlamaTarihi", tohumlamaTarihi.Value.ToString("yyyy-MM-dd"));
                    ineklerGuncelle.Parameters.AddWithValue("@kupeNum", kupeNum);

                    ineklerGuncelle.ExecuteNonQuery();
                }
            }
            else if (turComboBox.SelectedIndex == 1)
            {
                string buzagiGuncelleSogru = @"
        UPDATE buzagilar 
        SET 
            kupeNo = @kupeNo,
            inekAdi = @inekAdi, 
            dogumTarihi = @dogumTarihi, 
            anneAdi = @anneAdi, 
            anneKupeNo = @anneKupeNo,
            cinsiyet = @cinsiyet
        WHERE kupeNo = @kupeNum";

                using (SQLiteCommand command = new SQLiteCommand(buzagiGuncelleSogru, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    command.Parameters.AddWithValue("@cinsiyet", cinsiyetComboBox.SelectedIndex.ToString());
                    command.Parameters.AddWithValue("@kupeNum", kupeNum);

                    command.ExecuteNonQuery();
                }
            }
            else if (turComboBox.SelectedIndex == 2) // duve
            {

                if (tohumlamaTarihi.Value != DateTime.Parse("01.01.1970"))
                {
                    string inekEkle = @"
insert into inekler(kupeNo, inekAdi, dogumTarihi, anneAdi, anneKupeNo, tohumlamaTarihi)
values(@kupeNo, @inekAdi, @dogumTarihi, @anneAdi, @anneKupeNo, @tohumlamaTarihi)
";

                    using (SQLiteCommand command = new SQLiteCommand(inekEkle, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                        command.Parameters.AddWithValue("inekAdi", inekAdInput.Text);
                        command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                        command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                        command.Parameters.AddWithValue("@tohumlamaTarihi", tohumlamaTarihi.Value.ToString("yyyy-MM-dd"));

                        command.ExecuteNonQuery();
                    }

                    string duveSil = @"
    delete from duveler
    where kupeNo = @kupeNo
    ";

                    using (SQLiteCommand command = new SQLiteCommand(duveSil, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);

                        command.ExecuteNonQuery();
                    }

                    string turGuncelle = "update tumHayvanlar set tur = 'inek' where kupeNo = @kupeNo";

                    using (SQLiteCommand command = new SQLiteCommand(turGuncelle, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);

                        command.ExecuteNonQuery();
                    }
                }

                else
                {

                    string duveGuncelleSorgu = @"
        UPDATE duveler 
        SET 
            kupeNo = @kupeNo,
            inekAdi = @inekAdi, 
            dogumTarihi = @dogumTarihi, 
            anneAdi = @anneAdi, 
            anneKupeNo = @anneKupeNo,
            sonDogurduguTarih = @sonDogurduguTarih
        WHERE kupeNo = @kupeNum";

                    using (SQLiteCommand command = new SQLiteCommand(duveGuncelleSorgu, conn))
                    {
                        command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                        command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                        command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                        command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                        command.Parameters.AddWithValue("@sonDogurduguTarih", sonDogurduguTarihInput.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@kupeNum", kupeNum);

                        command.ExecuteNonQuery();
                    }
                }
            }
            else if (turComboBox.SelectedIndex == 3)
            {
                string danaGuncelleSorgu = @"
        UPDATE danalar 
        SET 
            kupeNo = @kupeNo,
            inekAdi = @inekAdi, 
            dogumTarihi = @dogumTarihi, 
            anneAdi = @anneAdi, 
            anneKupeNo = @anneKupeNo

        WHERE kupeNo = @kupeNum";

                using (SQLiteCommand command = new SQLiteCommand(danaGuncelleSorgu, conn))
                {
                    command.Parameters.AddWithValue("@kupeNo", kupeNoInput.Text);
                    command.Parameters.AddWithValue("@inekAdi", inekAdInput.Text);
                    command.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@anneAdi", anneAdiInput.Text);
                    command.Parameters.AddWithValue("@anneKupeNo", anneKupeNoInput.Text);
                    command.Parameters.AddWithValue("@kupeNum", kupeNum);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void tumHayvanlarButton_Click(object sender, EventArgs e)
        {
            anaForm tumhayvanlar = new anaForm();
            tumhayvanlar.Show();
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