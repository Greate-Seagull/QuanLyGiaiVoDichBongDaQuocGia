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
            tableLayoutPanel1 = new TableLayoutPanel();
            txtMaCauThu = new TextBox();
            txtGhiChu = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cbLoaiCauThu = new ComboBox();
            txtTenCauThu = new TextBox();
            lblSTT = new Label();
            btnXoa = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.596054F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.3842163F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.15265F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.3842163F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.3842163F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.15265F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.946002F));
            tableLayoutPanel1.Controls.Add(txtMaCauThu, 1, 0);
            tableLayoutPanel1.Controls.Add(txtGhiChu, 5, 0);
            tableLayoutPanel1.Controls.Add(dtpNgaySinh, 4, 0);
            tableLayoutPanel1.Controls.Add(cbLoaiCauThu, 3, 0);
            tableLayoutPanel1.Controls.Add(txtTenCauThu, 2, 0);
            tableLayoutPanel1.Controls.Add(lblSTT, 0, 0);
            tableLayoutPanel1.Controls.Add(btnXoa, 6, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1390, 50);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMaCauThu
            // 
            txtMaCauThu.BorderStyle = BorderStyle.FixedSingle;
            txtMaCauThu.Dock = DockStyle.Fill;
            txtMaCauThu.Location = new Point(46, 10);
            txtMaCauThu.Margin = new Padding(10);
            txtMaCauThu.Name = "txtMaCauThu";
            txtMaCauThu.ReadOnly = true;
            txtMaCauThu.Size = new Size(124, 31);
            txtMaCauThu.TabIndex = 17;
            txtMaCauThu.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGhiChu
            // 
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.Dock = DockStyle.Fill;
            txtGhiChu.Location = new Point(911, 10);
            txtGhiChu.Margin = new Padding(10);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(413, 31);
            txtGhiChu.TabIndex = 16;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Dock = DockStyle.Fill;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(767, 10);
            dtpNgaySinh.Margin = new Padding(10);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(124, 31);
            dtpNgaySinh.TabIndex = 15;
            // 
            // cbLoaiCauThu
            // 
            cbLoaiCauThu.Dock = DockStyle.Fill;
            cbLoaiCauThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiCauThu.FormattingEnabled = true;
            cbLoaiCauThu.Location = new Point(623, 10);
            cbLoaiCauThu.Margin = new Padding(10);
            cbLoaiCauThu.Name = "cbLoaiCauThu";
            cbLoaiCauThu.Size = new Size(124, 33);
            cbLoaiCauThu.TabIndex = 14;
            // 
            // txtTenCauThu
            // 
            txtTenCauThu.BorderStyle = BorderStyle.FixedSingle;
            txtTenCauThu.Dock = DockStyle.Fill;
            txtTenCauThu.Location = new Point(190, 10);
            txtTenCauThu.Margin = new Padding(10);
            txtTenCauThu.Name = "txtTenCauThu";
            txtTenCauThu.Size = new Size(413, 31);
            txtTenCauThu.TabIndex = 6;
            // 
            // lblSTT
            // 
            lblSTT.AutoSize = true;
            lblSTT.Dock = DockStyle.Fill;
            lblSTT.Location = new Point(10, 10);
            lblSTT.Margin = new Padding(10);
            lblSTT.Name = "lblSTT";
            lblSTT.Size = new Size(16, 30);
            lblSTT.TabIndex = 18;
            lblSTT.Text = "0";
            lblSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnXoa
            // 
            btnXoa.Dock = DockStyle.Fill;
            btnXoa.FlatStyle = FlatStyle.System;
            btnXoa.Location = new Point(1344, 10);
            btnXoa.Margin = new Padding(10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(36, 30);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "X";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // GUI_TiepNhanCauThu_RowVersion
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(10);
            Name = "GUI_TiepNhanCauThu_RowVersion";
            Size = new Size(1390, 50);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtTenCauThu;
        private ComboBox cbLoaiCauThu;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtGhiChu;
        private TextBox txtMaCauThu;
        private Label lblSTT;
        private Button btnXoa;
    }
}
