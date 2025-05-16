namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_TiepNhanCauThu_RowVersion
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
            txtMaCauThu = new TextBox();
            txtGhiChu = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cbLoaiCauThu = new ComboBox();
            txtTenCauThu = new TextBox();
            lblSTT = new Label();
            btnXoa = new Button();
            tlpThongTinCauThu.SuspendLayout();
            SuspendLayout();
            // 
            // tlpThongTinCauThu
            // 
            tlpThongTinCauThu.AutoScroll = true;
            tlpThongTinCauThu.BackColor = Color.Transparent;
            tlpThongTinCauThu.ColumnCount = 7;
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.0035315F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.12798F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5631056F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.30538F));
            tlpThongTinCauThu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            tlpThongTinCauThu.Controls.Add(txtMaCauThu, 1, 0);
            tlpThongTinCauThu.Controls.Add(txtGhiChu, 5, 0);
            tlpThongTinCauThu.Controls.Add(dtpNgaySinh, 4, 0);
            tlpThongTinCauThu.Controls.Add(cbLoaiCauThu, 3, 0);
            tlpThongTinCauThu.Controls.Add(txtTenCauThu, 2, 0);
            tlpThongTinCauThu.Controls.Add(lblSTT, 0, 0);
            tlpThongTinCauThu.Controls.Add(btnXoa, 6, 0);
            tlpThongTinCauThu.Dock = DockStyle.Fill;
            tlpThongTinCauThu.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpThongTinCauThu.Location = new Point(0, 0);
            tlpThongTinCauThu.Margin = new Padding(0);
            tlpThongTinCauThu.Name = "tlpThongTinCauThu";
            tlpThongTinCauThu.RowCount = 1;
            tlpThongTinCauThu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpThongTinCauThu.Size = new Size(1390, 50);
            tlpThongTinCauThu.TabIndex = 0;
            // 
            // txtMaCauThu
            // 
            txtMaCauThu.BorderStyle = BorderStyle.FixedSingle;
            txtMaCauThu.Dock = DockStyle.Fill;
            txtMaCauThu.Location = new Point(70, 10);
            txtMaCauThu.Margin = new Padding(10);
            txtMaCauThu.Name = "txtMaCauThu";
            txtMaCauThu.ReadOnly = true;
            txtMaCauThu.Size = new Size(113, 31);
            txtMaCauThu.TabIndex = 17;
            txtMaCauThu.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGhiChu
            // 
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.Dock = DockStyle.Fill;
            txtGhiChu.Location = new Point(916, 10);
            txtGhiChu.Margin = new Padding(10);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(407, 31);
            txtGhiChu.TabIndex = 16;
            txtGhiChu.TextChanged += txtGhiChu_TextChanged;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Dock = DockStyle.Fill;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(756, 10);
            dtpNgaySinh.Margin = new Padding(10);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(140, 31);
            dtpNgaySinh.TabIndex = 15;
            dtpNgaySinh.ValueChanged += dtpNgaySinh_ValueChanged;
            // 
            // cbLoaiCauThu
            // 
            cbLoaiCauThu.Dock = DockStyle.Fill;
            cbLoaiCauThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiCauThu.FormattingEnabled = true;
            cbLoaiCauThu.Location = new Point(594, 10);
            cbLoaiCauThu.Margin = new Padding(10);
            cbLoaiCauThu.Name = "cbLoaiCauThu";
            cbLoaiCauThu.Size = new Size(142, 33);
            cbLoaiCauThu.TabIndex = 14;
            cbLoaiCauThu.SelectedIndexChanged += cbLoaiCauThu_SelectedIndexChanged;
            // 
            // txtTenCauThu
            // 
            txtTenCauThu.BorderStyle = BorderStyle.FixedSingle;
            txtTenCauThu.Dock = DockStyle.Fill;
            txtTenCauThu.Location = new Point(203, 10);
            txtTenCauThu.Margin = new Padding(10);
            txtTenCauThu.Name = "txtTenCauThu";
            txtTenCauThu.Size = new Size(371, 31);
            txtTenCauThu.TabIndex = 6;
            txtTenCauThu.TextChanged += txtTenCauThu_TextChanged;
            // 
            // lblSTT
            // 
            lblSTT.AutoSize = true;
            lblSTT.Dock = DockStyle.Fill;
            lblSTT.Location = new Point(10, 10);
            lblSTT.Margin = new Padding(10);
            lblSTT.Name = "lblSTT";
            lblSTT.Size = new Size(40, 30);
            lblSTT.TabIndex = 18;
            lblSTT.Text = "0";
            lblSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnXoa
            // 
            btnXoa.Dock = DockStyle.Fill;
            btnXoa.FlatStyle = FlatStyle.System;
            btnXoa.Font = new Font("Segoe UI", 8F);
            btnXoa.Location = new Point(1343, 10);
            btnXoa.Margin = new Padding(10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(37, 30);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // GUI_TiepNhanCauThu_RowVersion
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tlpThongTinCauThu);
            Margin = new Padding(10);
            Name = "GUI_TiepNhanCauThu_RowVersion";
            Size = new Size(1390, 50);
            Load += GUI_TiepNhanCauThu_RowVersion_Load;
            tlpThongTinCauThu.ResumeLayout(false);
            tlpThongTinCauThu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpThongTinCauThu;
        private TextBox txtTenCauThu;
        private ComboBox cbLoaiCauThu;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtGhiChu;
        private TextBox txtMaCauThu;
        private Label lblSTT;
        private Button btnXoa;
    }
}
