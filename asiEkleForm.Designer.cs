namespace inekCizelge
{
    partial class asiEkleForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            navPanel = new Panel();
            asilarButton = new Button();
            hayvanEkleButton = new Button();
            duvelerButton = new Button();
            danalarButton = new Button();
            buzagilarButton = new Button();
            ineklerButton = new Button();
            guncelleButton = new Button();
            tumHayvanlarButton = new Button();
            bilgiPanel = new Panel();
            danaLabel = new Label();
            hamileInekLabel = new Label();
            buzagiLabel = new Label();
            bosInekLabel = new Label();
            bilgiGroupBox = new GroupBox();
            tumHayvanlarDataGridView = new DataGridView();
            asiVurulduMu = new DataGridViewCheckBoxColumn();
            vurulanIneklerLabel = new Label();
            asiVurmaTarihi = new DateTimePicker();
            asiTarihiLabel = new Label();
            asiAdiInput = new TextBox();
            asiAdiLabel = new Label();
            ekleButon = new Button();
            navPanel.SuspendLayout();
            bilgiPanel.SuspendLayout();
            bilgiGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tumHayvanlarDataGridView).BeginInit();
            SuspendLayout();
            // 
            // navPanel
            // 
            navPanel.AutoScroll = true;
            navPanel.Controls.Add(asilarButton);
            navPanel.Controls.Add(hayvanEkleButton);
            navPanel.Controls.Add(duvelerButton);
            navPanel.Controls.Add(danalarButton);
            navPanel.Controls.Add(buzagilarButton);
            navPanel.Controls.Add(ineklerButton);
            navPanel.Controls.Add(guncelleButton);
            navPanel.Controls.Add(tumHayvanlarButton);
            navPanel.Dock = DockStyle.Left;
            navPanel.Location = new Point(0, 0);
            navPanel.Name = "navPanel";
            navPanel.Size = new Size(192, 827);
            navPanel.TabIndex = 11;
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
            asilarButton.TabIndex = 58;
            asilarButton.Text = "Aşılar";
            asilarButton.UseVisualStyleBackColor = false;
            asilarButton.Click += asilarButton_Click;
            // 
            // hayvanEkleButton
            // 
            hayvanEkleButton.BackColor = Color.FromArgb(0, 192, 0);
            hayvanEkleButton.Dock = DockStyle.Top;
            hayvanEkleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            hayvanEkleButton.ForeColor = SystemColors.ButtonHighlight;
            hayvanEkleButton.Location = new Point(0, 594);
            hayvanEkleButton.Name = "hayvanEkleButton";
            hayvanEkleButton.Size = new Size(192, 99);
            hayvanEkleButton.TabIndex = 57;
            hayvanEkleButton.Text = "Hayvan Ekle";
            hayvanEkleButton.UseVisualStyleBackColor = false;
            hayvanEkleButton.Click += hayvanEkleButton_Click;
            // 
            // duvelerButton
            // 
            duvelerButton.BackColor = Color.Lime;
            duvelerButton.Dock = DockStyle.Top;
            duvelerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            duvelerButton.ForeColor = SystemColors.ButtonHighlight;
            duvelerButton.Location = new Point(0, 495);
            duvelerButton.Name = "duvelerButton";
            duvelerButton.Size = new Size(192, 99);
            duvelerButton.TabIndex = 56;
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
            danalarButton.Location = new Point(0, 396);
            danalarButton.Name = "danalarButton";
            danalarButton.Size = new Size(192, 99);
            danalarButton.TabIndex = 55;
            danalarButton.Text = "Danalar";
            danalarButton.UseVisualStyleBackColor = false;
            danalarButton.Click += danalarButton_Click;
            // 
            // buzagilarButton
            // 
            buzagilarButton.BackColor = Color.FromArgb(192, 0, 0);
            buzagilarButton.Dock = DockStyle.Top;
            buzagilarButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buzagilarButton.ForeColor = SystemColors.ButtonHighlight;
            buzagilarButton.Location = new Point(0, 297);
            buzagilarButton.Name = "buzagilarButton";
            buzagilarButton.Size = new Size(192, 99);
            buzagilarButton.TabIndex = 54;
            buzagilarButton.Text = "Buzağılar";
            buzagilarButton.UseVisualStyleBackColor = false;
            buzagilarButton.Click += buzagilarButton_Click;
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
            ineklerButton.TabIndex = 53;
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
            guncelleButton.TabIndex = 52;
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
            tumHayvanlarButton.TabIndex = 51;
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
            bilgiPanel.Size = new Size(896, 99);
            bilgiPanel.TabIndex = 12;
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
            // bilgiGroupBox
            // 
            bilgiGroupBox.Controls.Add(tumHayvanlarDataGridView);
            bilgiGroupBox.Controls.Add(vurulanIneklerLabel);
            bilgiGroupBox.Controls.Add(asiVurmaTarihi);
            bilgiGroupBox.Controls.Add(asiTarihiLabel);
            bilgiGroupBox.Controls.Add(asiAdiInput);
            bilgiGroupBox.Controls.Add(asiAdiLabel);
            bilgiGroupBox.Controls.Add(ekleButon);
            bilgiGroupBox.Dock = DockStyle.Fill;
            bilgiGroupBox.Font = new Font("Microsoft Sans Serif", 10.2F);
            bilgiGroupBox.Location = new Point(192, 99);
            bilgiGroupBox.Name = "bilgiGroupBox";
            bilgiGroupBox.Size = new Size(896, 728);
            bilgiGroupBox.TabIndex = 23;
            bilgiGroupBox.TabStop = false;
            // 
            // tumHayvanlarDataGridView
            // 
            tumHayvanlarDataGridView.AllowUserToAddRows = false;
            tumHayvanlarDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tumHayvanlarDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            tumHayvanlarDataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            tumHayvanlarDataGridView.BorderStyle = BorderStyle.Fixed3D;
            tumHayvanlarDataGridView.ColumnHeadersHeight = 29;
            tumHayvanlarDataGridView.Columns.AddRange(new DataGridViewColumn[] { asiVurulduMu });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            tumHayvanlarDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            tumHayvanlarDataGridView.Location = new Point(229, 198);
            tumHayvanlarDataGridView.Name = "tumHayvanlarDataGridView";
            tumHayvanlarDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            tumHayvanlarDataGridView.RowHeadersWidth = 51;
            tumHayvanlarDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tumHayvanlarDataGridView.Size = new Size(1250, 188);
            tumHayvanlarDataGridView.TabIndex = 29;
            // 
            // asiVurulduMu
            // 
            asiVurulduMu.HeaderText = "Aşı Vuruldu Mu";
            asiVurulduMu.MinimumWidth = 6;
            asiVurulduMu.Name = "asiVurulduMu";
            // 
            // vurulanIneklerLabel
            // 
            vurulanIneklerLabel.AutoSize = true;
            vurulanIneklerLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            vurulanIneklerLabel.Location = new Point(58, 198);
            vurulanIneklerLabel.Name = "vurulanIneklerLabel";
            vurulanIneklerLabel.Size = new Size(165, 25);
            vurulanIneklerLabel.TabIndex = 28;
            vurulanIneklerLabel.Text = "Vurulan İnekler:";
            // 
            // asiVurmaTarihi
            // 
            asiVurmaTarihi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            asiVurmaTarihi.Format = DateTimePickerFormat.Short;
            asiVurmaTarihi.Location = new Point(229, 136);
            asiVurmaTarihi.Name = "asiVurmaTarihi";
            asiVurmaTarihi.ShowUpDown = true;
            asiVurmaTarihi.Size = new Size(147, 27);
            asiVurmaTarihi.TabIndex = 26;
            // 
            // asiTarihiLabel
            // 
            asiTarihiLabel.AutoSize = true;
            asiTarihiLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            asiTarihiLabel.Location = new Point(26, 137);
            asiTarihiLabel.Name = "asiTarihiLabel";
            asiTarihiLabel.Size = new Size(197, 25);
            asiTarihiLabel.TabIndex = 25;
            asiTarihiLabel.Text = "Aşı Vurulma Tarihi:";
            // 
            // asiAdiInput
            // 
            asiAdiInput.Location = new Point(229, 85);
            asiAdiInput.Name = "asiAdiInput";
            asiAdiInput.Size = new Size(147, 27);
            asiAdiInput.TabIndex = 24;
            // 
            // asiAdiLabel
            // 
            asiAdiLabel.AutoSize = true;
            asiAdiLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            asiAdiLabel.Location = new Point(128, 87);
            asiAdiLabel.Name = "asiAdiLabel";
            asiAdiLabel.Size = new Size(95, 25);
            asiAdiLabel.TabIndex = 23;
            asiAdiLabel.Text = "Aşı İsmi:";
            // 
            // ekleButon
            // 
            ekleButon.BackColor = Color.Lime;
            ekleButon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            ekleButon.ForeColor = Color.Black;
            ekleButon.Location = new Point(229, 392);
            ekleButon.Name = "ekleButon";
            ekleButon.Size = new Size(116, 57);
            ekleButon.TabIndex = 22;
            ekleButon.Text = "Ekle";
            ekleButon.UseVisualStyleBackColor = false;
            ekleButon.Click += ekleButon_Click;
            // 
            // asiEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 827);
            Controls.Add(bilgiGroupBox);
            Controls.Add(bilgiPanel);
            Controls.Add(navPanel);
            Name = "asiEkleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "asiEkleForm";
            WindowState = FormWindowState.Maximized;
            Load += asiEkleForm_Load;
            Resize += asiEkleForm_Resize;
            navPanel.ResumeLayout(false);
            bilgiPanel.ResumeLayout(false);
            bilgiPanel.PerformLayout();
            bilgiGroupBox.ResumeLayout(false);
            bilgiGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tumHayvanlarDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel navPanel;
        private Panel bilgiPanel;
        private Label danaLabel;
        private Label hamileInekLabel;
        private Label buzagiLabel;
        private Label bosInekLabel;
        private GroupBox bilgiGroupBox;
        private DateTimePicker asiVurmaTarihi;
        private Label asiTarihiLabel;
        private TextBox asiAdiInput;
        private Label asiAdiLabel;
        private Button ekleButon;
        private DataGridView tumHayvanlarDataGridView;
        private Label vurulanIneklerLabel;
        private DataGridViewCheckBoxColumn asiVurulduMu;
        private Button asilarButton;
        private Button hayvanEkleButton;
        private Button duvelerButton;
        private Button danalarButton;
        private Button buzagilarButton;
        private Button ineklerButton;
        private Button guncelleButton;
        private Button tumHayvanlarButton;
    }
}