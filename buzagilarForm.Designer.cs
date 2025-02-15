namespace inekCizelge
{
    partial class buzagilarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            navPanel = new Panel();
            asilarButton = new Button();
            asiEkleButton = new Button();
            hayvanEkleButton = new Button();
            duvelerButton = new Button();
            danalarButton = new Button();
            ineklerButton = new Button();
            guncelleButton = new Button();
            tumHayvanlarButton = new Button();
            bilgiPanel = new Panel();
            danaLabel = new Label();
            hamileInekLabel = new Label();
            buzagiLabel = new Label();
            bosInekLabel = new Label();
            anaDataGridView = new DataGridView();
            suttenKesilmeGun = new DataGridViewTextBoxColumn();
            suttenKesilmeTarihi = new DataGridViewTextBoxColumn();
            kacGunluk = new DataGridViewTextBoxColumn();
            buzagiSil = new DataGridViewButtonColumn();
            navPanel.SuspendLayout();
            bilgiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)anaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // navPanel
            // 
            navPanel.AutoScroll = true;
            navPanel.Controls.Add(asilarButton);
            navPanel.Controls.Add(asiEkleButton);
            navPanel.Controls.Add(hayvanEkleButton);
            navPanel.Controls.Add(duvelerButton);
            navPanel.Controls.Add(danalarButton);
            navPanel.Controls.Add(ineklerButton);
            navPanel.Controls.Add(guncelleButton);
            navPanel.Controls.Add(tumHayvanlarButton);
            navPanel.Dock = DockStyle.Left;
            navPanel.Location = new Point(0, 0);
            navPanel.Name = "navPanel";
            navPanel.Size = new Size(192, 835);
            navPanel.TabIndex = 8;
            // 
            // asilarButton
            // 
            asilarButton.BackColor = Color.Maroon;
            asilarButton.Dock = DockStyle.Top;
            asilarButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            asilarButton.ForeColor = SystemColors.ButtonHighlight;
            asilarButton.Location = new Point(0, 693);
            asilarButton.Name = "asilarButton";
            asilarButton.Size = new Size(192, 99);
            asilarButton.TabIndex = 34;
            asilarButton.Text = "Aşılar";
            asilarButton.UseVisualStyleBackColor = false;
            asilarButton.Click += asilarButton_Click;
            // 
            // asiEkleButton
            // 
            asiEkleButton.BackColor = Color.FromArgb(0, 192, 0);
            asiEkleButton.Dock = DockStyle.Top;
            asiEkleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            asiEkleButton.ForeColor = SystemColors.ButtonHighlight;
            asiEkleButton.Location = new Point(0, 594);
            asiEkleButton.Name = "asiEkleButton";
            asiEkleButton.Size = new Size(192, 99);
            asiEkleButton.TabIndex = 33;
            asiEkleButton.Text = "Aşı Ekle";
            asiEkleButton.UseVisualStyleBackColor = false;
            asiEkleButton.Click += asiEkleButton_Click;
            // 
            // hayvanEkleButton
            // 
            hayvanEkleButton.BackColor = Color.Lime;
            hayvanEkleButton.Dock = DockStyle.Top;
            hayvanEkleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            hayvanEkleButton.ForeColor = SystemColors.ButtonHighlight;
            hayvanEkleButton.Location = new Point(0, 495);
            hayvanEkleButton.Name = "hayvanEkleButton";
            hayvanEkleButton.Size = new Size(192, 99);
            hayvanEkleButton.TabIndex = 32;
            hayvanEkleButton.Text = "Hayvan Ekle";
            hayvanEkleButton.UseVisualStyleBackColor = false;
            hayvanEkleButton.Click += hayvanEkleButton_Click;
            // 
            // duvelerButton
            // 
            duvelerButton.BackColor = Color.FromArgb(192, 0, 0);
            duvelerButton.Dock = DockStyle.Top;
            duvelerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            duvelerButton.ForeColor = SystemColors.ButtonHighlight;
            duvelerButton.Location = new Point(0, 396);
            duvelerButton.Name = "duvelerButton";
            duvelerButton.Size = new Size(192, 99);
            duvelerButton.TabIndex = 31;
            duvelerButton.Text = "Düveler/Boş İnekler";
            duvelerButton.UseVisualStyleBackColor = false;
            duvelerButton.Click += duvelerButton_Click;
            // 
            // danalarButton
            // 
            danalarButton.BackColor = Color.FromArgb(192, 0, 0);
            danalarButton.Dock = DockStyle.Top;
            danalarButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            danalarButton.ForeColor = SystemColors.ButtonHighlight;
            danalarButton.Location = new Point(0, 297);
            danalarButton.Name = "danalarButton";
            danalarButton.Size = new Size(192, 99);
            danalarButton.TabIndex = 30;
            danalarButton.Text = "Danalar";
            danalarButton.UseVisualStyleBackColor = false;
            danalarButton.Click += danalarButton_Click;
            // 
            // ineklerButton
            // 
            ineklerButton.BackColor = Color.FromArgb(128, 64, 0);
            ineklerButton.Dock = DockStyle.Top;
            ineklerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ineklerButton.ForeColor = SystemColors.ButtonHighlight;
            ineklerButton.Location = new Point(0, 198);
            ineklerButton.Name = "ineklerButton";
            ineklerButton.Size = new Size(192, 99);
            ineklerButton.TabIndex = 29;
            ineklerButton.Text = "İnekler";
            ineklerButton.UseVisualStyleBackColor = false;
            ineklerButton.Click += ineklerButon_Click;
            // 
            // guncelleButton
            // 
            guncelleButton.BackColor = Color.Fuchsia;
            guncelleButton.Dock = DockStyle.Top;
            guncelleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            guncelleButton.ForeColor = SystemColors.ButtonHighlight;
            guncelleButton.Location = new Point(0, 99);
            guncelleButton.Name = "guncelleButton";
            guncelleButton.Size = new Size(192, 99);
            guncelleButton.TabIndex = 28;
            guncelleButton.Text = "Hayvan Güncelle";
            guncelleButton.UseVisualStyleBackColor = false;
            guncelleButton.Click += hayvanGuncelleButon_Click;
            // 
            // tumHayvanlarButton
            // 
            tumHayvanlarButton.BackColor = Color.Blue;
            tumHayvanlarButton.Dock = DockStyle.Top;
            tumHayvanlarButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tumHayvanlarButton.ForeColor = SystemColors.ButtonHighlight;
            tumHayvanlarButton.Location = new Point(0, 0);
            tumHayvanlarButton.Name = "tumHayvanlarButton";
            tumHayvanlarButton.Size = new Size(192, 99);
            tumHayvanlarButton.TabIndex = 27;
            tumHayvanlarButton.Text = "Tüm Hayvanlar";
            tumHayvanlarButton.UseVisualStyleBackColor = false;
            tumHayvanlarButton.Click += tumHayvanlarButon_Click;
            // 
            // bilgiPanel
            // 
            bilgiPanel.Controls.Add(danaLabel);
            bilgiPanel.Controls.Add(hamileInekLabel);
            bilgiPanel.Controls.Add(buzagiLabel);
            bilgiPanel.Controls.Add(bosInekLabel);
            bilgiPanel.Dock = DockStyle.Top;
            bilgiPanel.Location = new Point(192, 0);
            bilgiPanel.Name = "bilgiPanel";
            bilgiPanel.Size = new Size(1066, 99);
            bilgiPanel.TabIndex = 9;
            // 
            // danaLabel
            // 
            danaLabel.AutoSize = true;
            danaLabel.FlatStyle = FlatStyle.Popup;
            danaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            danaLabel.Location = new Point(726, 35);
            danaLabel.Name = "danaLabel";
            danaLabel.Size = new Size(166, 28);
            danaLabel.TabIndex = 3;
            danaLabel.Text = "5 Adet Dana Var";
            // 
            // hamileInekLabel
            // 
            hamileInekLabel.AutoSize = true;
            hamileInekLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            hamileInekLabel.Location = new Point(6, 35);
            hamileInekLabel.Name = "hamileInekLabel";
            hamileInekLabel.Size = new Size(242, 28);
            hamileInekLabel.TabIndex = 0;
            hamileInekLabel.Text = "15 Adet Hamile İnek Var";
            // 
            // buzagiLabel
            // 
            buzagiLabel.AutoSize = true;
            buzagiLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buzagiLabel.Location = new Point(511, 35);
            buzagiLabel.Name = "buzagiLabel";
            buzagiLabel.Size = new Size(193, 28);
            buzagiLabel.TabIndex = 2;
            buzagiLabel.Text = "10 Adet Buzağı Var";
            // 
            // bosInekLabel
            // 
            bosInekLabel.AutoSize = true;
            bosInekLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bosInekLabel.Location = new Point(275, 35);
            bosInekLabel.Name = "bosInekLabel";
            bosInekLabel.Size = new Size(209, 28);
            bosInekLabel.TabIndex = 1;
            bosInekLabel.Text = "15 Adet Boş İnek Var";
            // 
            // anaDataGridView
            // 
            anaDataGridView.AllowUserToAddRows = false;
            anaDataGridView.AllowUserToDeleteRows = false;
            anaDataGridView.AllowUserToOrderColumns = true;
            anaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            anaDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            anaDataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            anaDataGridView.ColumnHeadersHeight = 50;
            anaDataGridView.Columns.AddRange(new DataGridViewColumn[] { suttenKesilmeGun, suttenKesilmeTarihi, kacGunluk, buzagiSil });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GrayText;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            anaDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            anaDataGridView.Dock = DockStyle.Fill;
            anaDataGridView.Location = new Point(192, 99);
            anaDataGridView.Name = "anaDataGridView";
            anaDataGridView.RowHeadersWidth = 51;
            anaDataGridView.Size = new Size(1066, 736);
            anaDataGridView.TabIndex = 10;
            // 
            // suttenKesilmeGun
            // 
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F);
            suttenKesilmeGun.DefaultCellStyle = dataGridViewCellStyle4;
            suttenKesilmeGun.HeaderText = "Sütten Kesilme";
            suttenKesilmeGun.MinimumWidth = 6;
            suttenKesilmeGun.Name = "suttenKesilmeGun";
            // 
            // suttenKesilmeTarihi
            // 
            suttenKesilmeTarihi.HeaderText = "Sütten Kesilme Tarihi";
            suttenKesilmeTarihi.MinimumWidth = 6;
            suttenKesilmeTarihi.Name = "suttenKesilmeTarihi";
            // 
            // kacGunluk
            // 
            kacGunluk.HeaderText = "Kaç Günlük";
            kacGunluk.MinimumWidth = 6;
            kacGunluk.Name = "kacGunluk";
            // 
            // buzagiSil
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buzagiSil.DefaultCellStyle = dataGridViewCellStyle5;
            buzagiSil.HeaderText = "Buzağı Sil";
            buzagiSil.MinimumWidth = 6;
            buzagiSil.Name = "buzagiSil";
            buzagiSil.Text = "Sil";
            buzagiSil.UseColumnTextForButtonValue = true;
            // 
            // buzagilarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 835);
            Controls.Add(anaDataGridView);
            Controls.Add(bilgiPanel);
            Controls.Add(navPanel);
            Name = "buzagilarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "buzagilarForm";
            WindowState = FormWindowState.Maximized;
            Load += buzagilarForm_Load;
            Resize += buzagilarForm_Resize;
            navPanel.ResumeLayout(false);
            bilgiPanel.ResumeLayout(false);
            bilgiPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)anaDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel navPanel;
        private Panel bilgiPanel;
        private Label danaLabel;
        private Label hamileInekLabel;
        private Label buzagiLabel;
        private Label bosInekLabel;
        private DataGridView anaDataGridView;
        private DataGridViewTextBoxColumn suttenKesilmeGun;
        private DataGridViewTextBoxColumn suttenKesilmeTarihi;
        private DataGridViewTextBoxColumn kacGunluk;
        private DataGridViewButtonColumn buzagiSil;
        private Button asilarButton;
        private Button asiEkleButton;
        private Button hayvanEkleButton;
        private Button duvelerButton;
        private Button danalarButton;
        private Button ineklerButton;
        private Button guncelleButton;
        private Button tumHayvanlarButton;
    }
}