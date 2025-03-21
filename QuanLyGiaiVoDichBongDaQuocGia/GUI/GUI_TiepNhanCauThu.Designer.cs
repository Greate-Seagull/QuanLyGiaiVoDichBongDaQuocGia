namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_TiepNhanCauThu
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
            tableLayoutPanel = new TableLayoutPanel();
            lblLoaiCauThu = new Label();
            lblGhiChu = new Label();
            lblMaCauThu = new Label();
            lblNgaySinh = new Label();
            lblTenCauThu = new Label();
            txtMaCauThu = new TextBox();
            txtTenCauThu = new TextBox();
            btnTiepNhanCauThu = new Button();
            btnThoat = new Button();
            txtGhiChu = new TextBox();
            cbLoaiCauThu = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 8;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.Controls.Add(lblLoaiCauThu, 4, 2);
            tableLayoutPanel.Controls.Add(lblGhiChu, 0, 4);
            tableLayoutPanel.Controls.Add(lblMaCauThu, 0, 0);
            tableLayoutPanel.Controls.Add(lblNgaySinh, 0, 2);
            tableLayoutPanel.Controls.Add(lblTenCauThu, 1, 0);
            tableLayoutPanel.Controls.Add(txtMaCauThu, 0, 1);
            tableLayoutPanel.Controls.Add(txtTenCauThu, 1, 1);
            tableLayoutPanel.Controls.Add(btnTiepNhanCauThu, 0, 6);
            tableLayoutPanel.Controls.Add(btnThoat, 6, 6);
            tableLayoutPanel.Controls.Add(txtGhiChu, 0, 5);
            tableLayoutPanel.Controls.Add(cbLoaiCauThu, 4, 3);
            tableLayoutPanel.Controls.Add(dtpNgaySinh, 0, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 29.62963F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.8148146F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(478, 544);
            tableLayoutPanel.TabIndex = 4;
            // 
            // lblLoaiCauThu
            // 
            lblLoaiCauThu.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(lblLoaiCauThu, 4);
            lblLoaiCauThu.Dock = DockStyle.Fill;
            lblLoaiCauThu.Location = new Point(248, 136);
            lblLoaiCauThu.Margin = new Padding(10);
            lblLoaiCauThu.Name = "lblLoaiCauThu";
            lblLoaiCauThu.Size = new Size(210, 38);
            lblLoaiCauThu.TabIndex = 12;
            lblLoaiCauThu.Text = "Loại cầu thủ";
            lblLoaiCauThu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(lblGhiChu, 8);
            lblGhiChu.Dock = DockStyle.Fill;
            lblGhiChu.Location = new Point(20, 252);
            lblGhiChu.Margin = new Padding(10);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(438, 38);
            lblGhiChu.TabIndex = 11;
            lblGhiChu.Text = "Ghi chú";
            lblGhiChu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaCauThu
            // 
            lblMaCauThu.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(lblMaCauThu, 3);
            lblMaCauThu.Dock = DockStyle.Fill;
            lblMaCauThu.Location = new Point(20, 20);
            lblMaCauThu.Margin = new Padding(10);
            lblMaCauThu.Name = "lblMaCauThu";
            lblMaCauThu.Size = new Size(151, 38);
            lblMaCauThu.TabIndex = 0;
            lblMaCauThu.Text = "Mã cầu thủ";
            lblMaCauThu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(lblNgaySinh, 4);
            lblNgaySinh.Dock = DockStyle.Fill;
            lblNgaySinh.Location = new Point(20, 136);
            lblNgaySinh.Margin = new Padding(10);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(208, 38);
            lblNgaySinh.TabIndex = 1;
            lblNgaySinh.Text = "Ngày sinh";
            lblNgaySinh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenCauThu
            // 
            lblTenCauThu.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(lblTenCauThu, 5);
            lblTenCauThu.Dock = DockStyle.Fill;
            lblTenCauThu.Location = new Point(191, 20);
            lblTenCauThu.Margin = new Padding(10);
            lblTenCauThu.Name = "lblTenCauThu";
            lblTenCauThu.Size = new Size(267, 38);
            lblTenCauThu.TabIndex = 2;
            lblTenCauThu.Text = "Tên cầu thủ";
            lblTenCauThu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaCauThu
            // 
            txtMaCauThu.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel.SetColumnSpan(txtMaCauThu, 3);
            txtMaCauThu.Dock = DockStyle.Fill;
            txtMaCauThu.Location = new Point(20, 78);
            txtMaCauThu.Margin = new Padding(10);
            txtMaCauThu.Name = "txtMaCauThu";
            txtMaCauThu.ReadOnly = true;
            txtMaCauThu.Size = new Size(151, 31);
            txtMaCauThu.TabIndex = 3;
            // 
            // txtTenCauThu
            // 
            txtTenCauThu.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel.SetColumnSpan(txtTenCauThu, 5);
            txtTenCauThu.Dock = DockStyle.Fill;
            txtTenCauThu.Location = new Point(191, 78);
            txtTenCauThu.Margin = new Padding(10);
            txtTenCauThu.Name = "txtTenCauThu";
            txtTenCauThu.Size = new Size(267, 31);
            txtTenCauThu.TabIndex = 4;
            // 
            // btnTiepNhanCauThu
            // 
            tableLayoutPanel.SetColumnSpan(btnTiepNhanCauThu, 2);
            btnTiepNhanCauThu.Dock = DockStyle.Bottom;
            btnTiepNhanCauThu.Font = new Font("Segoe UI", 8F);
            btnTiepNhanCauThu.Location = new Point(20, 476);
            btnTiepNhanCauThu.Margin = new Padding(10, 10, 10, 0);
            btnTiepNhanCauThu.Name = "btnTiepNhanCauThu";
            btnTiepNhanCauThu.Size = new Size(94, 58);
            btnTiepNhanCauThu.TabIndex = 6;
            btnTiepNhanCauThu.Text = "Đồng ý";
            btnTiepNhanCauThu.UseVisualStyleBackColor = true;
            btnTiepNhanCauThu.Click += btnTiepNhanCauThu_Click;
            // 
            // btnThoat
            // 
            tableLayoutPanel.SetColumnSpan(btnThoat, 2);
            btnThoat.Dock = DockStyle.Bottom;
            btnThoat.Font = new Font("Segoe UI", 8F);
            btnThoat.Location = new Point(362, 476);
            btnThoat.Margin = new Padding(10, 10, 10, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(96, 58);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel.SetColumnSpan(txtGhiChu, 8);
            txtGhiChu.Dock = DockStyle.Fill;
            txtGhiChu.Location = new Point(20, 310);
            txtGhiChu.Margin = new Padding(10);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(438, 135);
            txtGhiChu.TabIndex = 10;
            // 
            // cbLoaiCauThu
            // 
            tableLayoutPanel.SetColumnSpan(cbLoaiCauThu, 4);
            cbLoaiCauThu.Dock = DockStyle.Fill;
            cbLoaiCauThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiCauThu.FormattingEnabled = true;
            cbLoaiCauThu.Location = new Point(248, 194);
            cbLoaiCauThu.Margin = new Padding(10);
            cbLoaiCauThu.Name = "cbLoaiCauThu";
            cbLoaiCauThu.Size = new Size(210, 33);
            cbLoaiCauThu.TabIndex = 13;
            // 
            // dtpNgaySinh
            // 
            tableLayoutPanel.SetColumnSpan(dtpNgaySinh, 4);
            dtpNgaySinh.CustomFormat = "";
            dtpNgaySinh.Location = new Point(20, 194);
            dtpNgaySinh.Margin = new Padding(10);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(208, 31);
            dtpNgaySinh.TabIndex = 14;
            // 
            // GUI_TiepNhanCauThu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 544);
            Controls.Add(tableLayoutPanel);
            Name = "GUI_TiepNhanCauThu";
            Text = "GUI_TiepNhanCauThu";
            Load += GUI_TiepNhanCauThu_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label lblMaCauThu;
        private Label lblNgaySinh;
        private Label lblTenCauThu;
        private TextBox txtMaCauThu;
        private TextBox txtTenCauThu;
        private Button btnTiepNhanCauThu;
        private Button btnThoat;
        private TextBox txtGhiChu;
        private Label lblLoaiCauThu;
        private Label lblGhiChu;
        private ComboBox cbLoaiCauThu;
        private DateTimePicker dtpNgaySinh;
    }
}