namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_GhiNhanBanThang_RowVersion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpThongTinCauThu = new TableLayoutPanel();
            cbDoiBong = new ComboBox();
            cbLoaiBanThang = new ComboBox();
            cbCauThu = new ComboBox();
            txtMaBanThang = new TextBox();
            lblSTT = new Label();
            btnXoa = new Button();
            nudThoiDiemGhiBan = new NumericUpDown();
            tlpThongTinCauThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudThoiDiemGhiBan).BeginInit();
            SuspendLayout();
            // 
            // tlpThongTinCauThu
            // 
            tlpThongTinCauThu.AutoScroll = true;
            tlpThongTinCauThu.BackColor = Color.Transparent;
            tlpThongTinCauThu.ColumnCount = 7;
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            tlpThongTinCauThu.Controls.Add(cbDoiBong, 3, 0);
            tlpThongTinCauThu.Controls.Add(cbLoaiBanThang, 4, 0);
            tlpThongTinCauThu.Controls.Add(cbCauThu, 2, 0);
            tlpThongTinCauThu.Controls.Add(txtMaBanThang, 1, 0);
            tlpThongTinCauThu.Controls.Add(lblSTT, 0, 0);
            tlpThongTinCauThu.Controls.Add(btnXoa, 6, 0);
            tlpThongTinCauThu.Controls.Add(nudThoiDiemGhiBan, 5, 0);
            tlpThongTinCauThu.Dock = DockStyle.Fill;
            tlpThongTinCauThu.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpThongTinCauThu.Location = new Point(0, 0);
            tlpThongTinCauThu.Margin = new Padding(0);
            tlpThongTinCauThu.Name = "tlpThongTinCauThu";
            tlpThongTinCauThu.RowCount = 1;
            tlpThongTinCauThu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpThongTinCauThu.Size = new Size(1388, 48);
            tlpThongTinCauThu.TabIndex = 2;
            // 
            // cbDoiBong
            // 
            cbDoiBong.Dock = DockStyle.Fill;
            cbDoiBong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoiBong.FormattingEnabled = true;
            cbDoiBong.Location = new Point(614, 10);
            cbDoiBong.Margin = new Padding(10);
            cbDoiBong.Name = "cbDoiBong";
            cbDoiBong.Size = new Size(343, 33);
            cbDoiBong.TabIndex = 26;
            cbDoiBong.SelectedIndexChanged += cbDoiBong_SelectedIndexChanged;
            // 
            // cbLoaiBanThang
            // 
            cbLoaiBanThang.Dock = DockStyle.Fill;
            cbLoaiBanThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiBanThang.FormattingEnabled = true;
            cbLoaiBanThang.Location = new Point(977, 10);
            cbLoaiBanThang.Margin = new Padding(10);
            cbLoaiBanThang.Name = "cbLoaiBanThang";
            cbLoaiBanThang.Size = new Size(161, 33);
            cbLoaiBanThang.TabIndex = 24;
            // 
            // cbCauThu
            // 
            cbCauThu.Dock = DockStyle.Fill;
            cbCauThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCauThu.FormattingEnabled = true;
            cbCauThu.Location = new Point(251, 10);
            cbCauThu.Margin = new Padding(10);
            cbCauThu.Name = "cbCauThu";
            cbCauThu.Size = new Size(343, 33);
            cbCauThu.TabIndex = 20;
            // 
            // txtMaBanThang
            // 
            txtMaBanThang.BorderStyle = BorderStyle.FixedSingle;
            txtMaBanThang.Dock = DockStyle.Fill;
            txtMaBanThang.Location = new Point(70, 10);
            txtMaBanThang.Margin = new Padding(10);
            txtMaBanThang.Name = "txtMaBanThang";
            txtMaBanThang.ReadOnly = true;
            txtMaBanThang.Size = new Size(161, 31);
            txtMaBanThang.TabIndex = 17;
            txtMaBanThang.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSTT
            // 
            lblSTT.AutoSize = true;
            lblSTT.Dock = DockStyle.Fill;
            lblSTT.Location = new Point(10, 10);
            lblSTT.Margin = new Padding(10);
            lblSTT.Name = "lblSTT";
            lblSTT.Size = new Size(40, 28);
            lblSTT.TabIndex = 18;
            lblSTT.Text = "0";
            lblSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnXoa
            // 
            btnXoa.Dock = DockStyle.Fill;
            btnXoa.FlatStyle = FlatStyle.System;
            btnXoa.Font = new Font("Segoe UI", 8F);
            btnXoa.Location = new Point(1339, 10);
            btnXoa.Margin = new Padding(10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(39, 28);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // nudThoiDiemGhiBan
            // 
            nudThoiDiemGhiBan.BorderStyle = BorderStyle.FixedSingle;
            nudThoiDiemGhiBan.Dock = DockStyle.Fill;
            nudThoiDiemGhiBan.Location = new Point(1158, 10);
            nudThoiDiemGhiBan.Margin = new Padding(10);
            nudThoiDiemGhiBan.Maximum = new decimal(new int[] { 96, 0, 0, 0 });
            nudThoiDiemGhiBan.Name = "nudThoiDiemGhiBan";
            nudThoiDiemGhiBan.Size = new Size(161, 31);
            nudThoiDiemGhiBan.TabIndex = 25;
            // 
            // GUI_GhiNhanBanThang_RowVersion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tlpThongTinCauThu);
            Margin = new Padding(10);
            Name = "GUI_GhiNhanBanThang_RowVersion";
            Size = new Size(1388, 48);
            Load += GUI_GhiNhanBanThang_RowVersion_Load;
            tlpThongTinCauThu.ResumeLayout(false);
            tlpThongTinCauThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudThoiDiemGhiBan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpThongTinCauThu;
        private ComboBox cbLoaiBanThang;
        private ComboBox cbCauThu;
        private TextBox txtMaBanThang;
        private Label lblSTT;
        private Button btnXoa;
        private NumericUpDown nudThoiDiemGhiBan;
        private ComboBox cbDoiBong;
    }
}
