namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_LapTranDau_RowVersion
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
            dtpGio = new DateTimePicker();
            txtTenSan = new TextBox();
            cbTenDoi1 = new ComboBox();
            txtMaTranDau = new TextBox();
            dtpNgay = new DateTimePicker();
            cbTenDoi2 = new ComboBox();
            lblSTT = new Label();
            btnXoa = new Button();
            tlpThongTinCauThu.SuspendLayout();
            SuspendLayout();
            // 
            // tlpThongTinCauThu
            // 
            tlpThongTinCauThu.AutoScroll = true;
            tlpThongTinCauThu.BackColor = Color.Transparent;
            tlpThongTinCauThu.ColumnCount = 8;
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.34483F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.6896553F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.6896553F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.7931032F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.188976F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.2992134F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            tlpThongTinCauThu.Controls.Add(dtpGio, 5, 0);
            tlpThongTinCauThu.Controls.Add(txtTenSan, 6, 0);
            tlpThongTinCauThu.Controls.Add(cbTenDoi1, 2, 0);
            tlpThongTinCauThu.Controls.Add(txtMaTranDau, 1, 0);
            tlpThongTinCauThu.Controls.Add(dtpNgay, 4, 0);
            tlpThongTinCauThu.Controls.Add(cbTenDoi2, 3, 0);
            tlpThongTinCauThu.Controls.Add(lblSTT, 0, 0);
            tlpThongTinCauThu.Controls.Add(btnXoa, 7, 0);
            tlpThongTinCauThu.Dock = DockStyle.Fill;
            tlpThongTinCauThu.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpThongTinCauThu.Location = new Point(0, 0);
            tlpThongTinCauThu.Margin = new Padding(0);
            tlpThongTinCauThu.Name = "tlpThongTinCauThu";
            tlpThongTinCauThu.RowCount = 1;
            tlpThongTinCauThu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpThongTinCauThu.Size = new Size(1388, 48);
            tlpThongTinCauThu.TabIndex = 1;
            // 
            // dtpGio
            // 
            dtpGio.CustomFormat = "HH:mm";
            dtpGio.Dock = DockStyle.Fill;
            dtpGio.Format = DateTimePickerFormat.Custom;
            dtpGio.Location = new Point(902, 10);
            dtpGio.Margin = new Padding(10);
            dtpGio.Name = "dtpGio";
            dtpGio.ShowUpDown = true;
            dtpGio.Size = new Size(84, 31);
            dtpGio.TabIndex = 22;
            dtpGio.ValueChanged += dtpGio_ValueChanged;
            // 
            // txtTenSan
            // 
            txtTenSan.BorderStyle = BorderStyle.FixedSingle;
            txtTenSan.Dock = DockStyle.Fill;
            txtTenSan.Location = new Point(1006, 10);
            txtTenSan.Margin = new Padding(10);
            txtTenSan.Name = "txtTenSan";
            txtTenSan.ReadOnly = true;
            txtTenSan.Size = new Size(314, 31);
            txtTenSan.TabIndex = 21;
            txtTenSan.TextAlign = HorizontalAlignment.Center;
            // 
            // cbTenDoi1
            // 
            cbTenDoi1.Dock = DockStyle.Fill;
            cbTenDoi1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTenDoi1.FormattingEnabled = true;
            cbTenDoi1.Location = new Point(201, 10);
            cbTenDoi1.Margin = new Padding(10);
            cbTenDoi1.Name = "cbTenDoi1";
            cbTenDoi1.Size = new Size(243, 33);
            cbTenDoi1.TabIndex = 20;
            cbTenDoi1.SelectedIndexChanged += cbTenDoi1_SelectedIndexChanged;
            // 
            // txtMaTranDau
            // 
            txtMaTranDau.BorderStyle = BorderStyle.FixedSingle;
            txtMaTranDau.Dock = DockStyle.Fill;
            txtMaTranDau.Location = new Point(70, 10);
            txtMaTranDau.Margin = new Padding(10);
            txtMaTranDau.Name = "txtMaTranDau";
            txtMaTranDau.ReadOnly = true;
            txtMaTranDau.Size = new Size(111, 31);
            txtMaTranDau.TabIndex = 17;
            txtMaTranDau.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Dock = DockStyle.Fill;
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(727, 10);
            dtpNgay.Margin = new Padding(10);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(155, 31);
            dtpNgay.TabIndex = 15;
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            // 
            // cbTenDoi2
            // 
            cbTenDoi2.Dock = DockStyle.Fill;
            cbTenDoi2.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTenDoi2.FormattingEnabled = true;
            cbTenDoi2.Location = new Point(464, 10);
            cbTenDoi2.Margin = new Padding(10);
            cbTenDoi2.Name = "cbTenDoi2";
            cbTenDoi2.Size = new Size(243, 33);
            cbTenDoi2.TabIndex = 14;
            cbTenDoi2.SelectedIndexChanged += cbTenDoi2_SelectedIndexChanged;
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
            btnXoa.Location = new Point(1340, 10);
            btnXoa.Margin = new Padding(10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(38, 28);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // GUI_LapTranDau_RowVersion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tlpThongTinCauThu);
            Margin = new Padding(10);
            Name = "GUI_LapTranDau_RowVersion";
            Size = new Size(1388, 48);
            Load += GUI_LapTranDau_RowVersion_Load;
            tlpThongTinCauThu.ResumeLayout(false);
            tlpThongTinCauThu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpThongTinCauThu;
        private TextBox txtTenSan;
        private ComboBox cbTenDoi1;
        private TextBox txtMaTranDau;
        private DateTimePicker dtpNgay;
        private ComboBox cbTenDoi2;
        private Label lblSTT;
        private Button btnXoa;
        private DateTimePicker dtpGio;
    }
}
