namespace inekCizelge
{
    partial class asiListeForm
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            navPanel = new Panel();
            asiEkleButton = new Button();
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
            anaDataGridView = new DataGridView();
            asiSilButon = new DataGridViewButtonColumn();
            navPanel.SuspendLayout();
            bilgiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)anaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // navPanel
            // 
            navPanel.AutoScroll = true;
            navPanel.Controls.Add(asiEkleButton);
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
            navPanel.Size = new Size(192, 731);
            navPanel.TabIndex = 12;
            // 
            // asiEkleButton
            // 
            asiEkleButton.BackColor = Color.Maroon;
            asiEkleButton.Dock = DockStyle.Top;
            asiEkleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            asiEkleButton.ForeColor = SystemColors.ButtonHighlight;
            asiEkleButton.Location = new Point(0, 693);
            asiEkleButton.Name = "asiEkleButton";
            asiEkleButton.Size = new Size(171, 99);
            asiEkleButton.TabIndex = 66;
            asiEkleButton.Text = "Aşı Ekle";
            asiEkleButton.UseVisualStyleBackColor = false;
            asiEkleButton.Click += asiEkleButton_Click;
            // 
            // hayvanEkleButton
            // 
            hayvanEkleButton.BackColor = Color.FromArgb(0, 192, 0);
            hayvanEkleButton.Dock = DockStyle.Top;
            hayvanEkleButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            hayvanEkleButton.ForeColor = SystemColors.ButtonHighlight;
            hayvanEkleButton.Location = new Point(0, 594);
            hayvanEkleButton.Name = "hayvanEkleButton";
            hayvanEkleButton.Size = new Size(171, 99);
            hayvanEkleButton.TabIndex = 65;
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
            duvelerButton.Size = new Size(171, 99);
            duvelerButton.TabIndex = 64;
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
            danalarButton.Size = new Size(171, 99);
            danalarButton.TabIndex = 63;
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
            buzagilarButton.Size = new Size(171, 99);
            buzagilarButton.TabIndex = 62;
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
            ineklerButton.Size = new Size(171, 99);
            ineklerButton.TabIndex = 61;
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
            guncelleButton.Size = new Size(171, 99);
            guncelleButton.TabIndex = 60;
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
            tumHayvanlarButton.Size = new Size(171, 99);
            tumHayvanlarButton.TabIndex = 59;
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
            bilgiPanel.Size = new Size(1099, 99);
            bilgiPanel.TabIndex = 13;
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
            anaDataGridView.Columns.AddRange(new DataGridViewColumn[] { asiSilButon });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GrayText;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            anaDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            anaDataGridView.Dock = DockStyle.Fill;
            anaDataGridView.Location = new Point(192, 99);
            anaDataGridView.Name = "anaDataGridView";
            anaDataGridView.RowHeadersWidth = 51;
            anaDataGridView.Size = new Size(1099, 632);
            anaDataGridView.TabIndex = 14;
            // 
            // asiSilButon
            // 
            asiSilButon.HeaderText = "Aşı Sil";
            asiSilButon.MinimumWidth = 6;
            asiSilButon.Name = "asiSilButon";
            asiSilButon.Text = "Sil";
            asiSilButon.UseColumnTextForButtonValue = true;
            // 
            // asiListeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 731);
            Controls.Add(anaDataGridView);
            Controls.Add(bilgiPanel);
            Controls.Add(navPanel);
            Name = "asiListeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "asiListeForm";
            WindowState = FormWindowState.Maximized;
            Load += asiListeForm_Load;
            Resize += asiListeForm_Resize;
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
        private DataGridViewButtonColumn asiSilButon;
        private Button asiEkleButton;
        private Button hayvanEkleButton;
        private Button duvelerButton;
        private Button danalarButton;
        private Button buzagilarButton;
        private Button ineklerButton;
        private Button guncelleButton;
        private Button tumHayvanlarButton;
    }
}