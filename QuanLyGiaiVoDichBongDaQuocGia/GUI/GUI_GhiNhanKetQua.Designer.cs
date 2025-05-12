namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_GhiNhanKetQua
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
            tlpFrame = new TableLayoutPanel();
            cbTranDau = new ComboBox();
            txtTenSan = new TextBox();
            txtTiSo = new TextBox();
            txtNgayGio = new TextBox();
            lblNgayGio = new Label();
            lblTenSan = new Label();
            btnThemBanThang = new Button();
            btnThoat = new Button();
            lblTiSo = new Label();
            lblTranDau = new Label();
            pDanhSachBanThang = new Panel();
            btnGhiNhanKetQua = new Button();
            tlpFrame.SuspendLayout();
            SuspendLayout();
            // 
            // tlpFrame
            // 
            tlpFrame.ColumnCount = 8;
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.Controls.Add(cbTranDau, 0, 1);
            tlpFrame.Controls.Add(txtTenSan, 2, 1);
            tlpFrame.Controls.Add(txtTiSo, 1, 1);
            tlpFrame.Controls.Add(txtNgayGio, 3, 1);
            tlpFrame.Controls.Add(lblNgayGio, 3, 0);
            tlpFrame.Controls.Add(lblTenSan, 2, 0);
            tlpFrame.Controls.Add(btnThemBanThang, 1, 3);
            tlpFrame.Controls.Add(btnThoat, 7, 3);
            tlpFrame.Controls.Add(lblTiSo, 1, 0);
            tlpFrame.Controls.Add(lblTranDau, 0, 0);
            tlpFrame.Controls.Add(pDanhSachBanThang, 0, 2);
            tlpFrame.Controls.Add(btnGhiNhanKetQua, 0, 3);
            tlpFrame.Dock = DockStyle.Fill;
            tlpFrame.Location = new Point(0, 0);
            tlpFrame.Margin = new Padding(0);
            tlpFrame.Name = "tlpFrame";
            tlpFrame.Padding = new Padding(10);
            tlpFrame.RowCount = 4;
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.Size = new Size(1418, 507);
            tlpFrame.TabIndex = 1;
            // 
            // cbTranDau
            // 
            tlpFrame.SetColumnSpan(cbTranDau, 2);
            cbTranDau.Dock = DockStyle.Fill;
            cbTranDau.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTranDau.FormattingEnabled = true;
            cbTranDau.Location = new Point(20, 68);
            cbTranDau.Margin = new Padding(10);
            cbTranDau.Name = "cbTranDau";
            cbTranDau.Size = new Size(328, 33);
            cbTranDau.TabIndex = 20;
            cbTranDau.SelectedIndexChanged += cbTranDau_SelectedIndexChanged;
            // 
            // txtTenSan
            // 
            txtTenSan.BorderStyle = BorderStyle.FixedSingle;
            txtTenSan.Dock = DockStyle.Fill;
            txtTenSan.Location = new Point(542, 68);
            txtTenSan.Margin = new Padding(10);
            txtTenSan.Name = "txtTenSan";
            txtTenSan.ReadOnly = true;
            txtTenSan.Size = new Size(154, 31);
            txtTenSan.TabIndex = 19;
            // 
            // txtTiSo
            // 
            txtTiSo.BorderStyle = BorderStyle.FixedSingle;
            txtTiSo.Dock = DockStyle.Fill;
            txtTiSo.Location = new Point(368, 68);
            txtTiSo.Margin = new Padding(10);
            txtTiSo.Name = "txtTiSo";
            txtTiSo.ReadOnly = true;
            txtTiSo.Size = new Size(154, 31);
            txtTiSo.TabIndex = 18;
            // 
            // txtNgayGio
            // 
            txtNgayGio.BorderStyle = BorderStyle.FixedSingle;
            txtNgayGio.Dock = DockStyle.Fill;
            txtNgayGio.Location = new Point(716, 68);
            txtNgayGio.Margin = new Padding(10);
            txtNgayGio.Name = "txtNgayGio";
            txtNgayGio.ReadOnly = true;
            txtNgayGio.Size = new Size(154, 31);
            txtNgayGio.TabIndex = 17;
            // 
            // lblNgayGio
            // 
            lblNgayGio.AutoSize = true;
            lblNgayGio.Dock = DockStyle.Fill;
            lblNgayGio.Location = new Point(716, 20);
            lblNgayGio.Margin = new Padding(10);
            lblNgayGio.Name = "lblNgayGio";
            lblNgayGio.Size = new Size(154, 28);
            lblNgayGio.TabIndex = 16;
            lblNgayGio.Text = "Ngày - Giờ";
            lblNgayGio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSan
            // 
            lblTenSan.AutoSize = true;
            lblTenSan.Dock = DockStyle.Fill;
            lblTenSan.Location = new Point(542, 20);
            lblTenSan.Margin = new Padding(10);
            lblTenSan.Name = "lblTenSan";
            lblTenSan.Size = new Size(154, 28);
            lblTenSan.TabIndex = 15;
            lblTenSan.Text = "Tên sân";
            lblTenSan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnThemBanThang
            // 
            btnThemBanThang.Dock = DockStyle.Fill;
            btnThemBanThang.Font = new Font("Segoe UI", 8F);
            btnThemBanThang.Location = new Point(194, 456);
            btnThemBanThang.Margin = new Padding(10, 10, 10, 0);
            btnThemBanThang.Name = "btnThemBanThang";
            btnThemBanThang.Size = new Size(154, 41);
            btnThemBanThang.TabIndex = 14;
            btnThemBanThang.Text = "Thêm bàn thắng";
            btnThemBanThang.UseVisualStyleBackColor = true;
            btnThemBanThang.Click += btnThemBanThang_Click;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Fill;
            btnThoat.Font = new Font("Segoe UI", 8F);
            btnThoat.Location = new Point(1238, 456);
            btnThoat.Margin = new Padding(10, 10, 10, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 41);
            btnThoat.TabIndex = 13;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblTiSo
            // 
            lblTiSo.AutoSize = true;
            lblTiSo.Dock = DockStyle.Fill;
            lblTiSo.Location = new Point(368, 20);
            lblTiSo.Margin = new Padding(10);
            lblTiSo.Name = "lblTiSo";
            lblTiSo.Size = new Size(154, 28);
            lblTiSo.TabIndex = 12;
            lblTiSo.Text = "Tỉ số";
            lblTiSo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTranDau
            // 
            lblTranDau.AutoSize = true;
            tlpFrame.SetColumnSpan(lblTranDau, 2);
            lblTranDau.Dock = DockStyle.Fill;
            lblTranDau.Location = new Point(20, 20);
            lblTranDau.Margin = new Padding(10);
            lblTranDau.Name = "lblTranDau";
            lblTranDau.Size = new Size(328, 28);
            lblTranDau.TabIndex = 1;
            lblTranDau.Text = "Trận đấu";
            lblTranDau.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pDanhSachBanThang
            // 
            pDanhSachBanThang.AutoScroll = true;
            pDanhSachBanThang.BackColor = Color.White;
            pDanhSachBanThang.BorderStyle = BorderStyle.FixedSingle;
            tlpFrame.SetColumnSpan(pDanhSachBanThang, 8);
            pDanhSachBanThang.Dock = DockStyle.Fill;
            pDanhSachBanThang.Location = new Point(20, 116);
            pDanhSachBanThang.Margin = new Padding(10);
            pDanhSachBanThang.Name = "pDanhSachBanThang";
            pDanhSachBanThang.Padding = new Padding(10);
            pDanhSachBanThang.Size = new Size(1378, 320);
            pDanhSachBanThang.TabIndex = 10;
            // 
            // btnGhiNhanKetQua
            // 
            btnGhiNhanKetQua.Dock = DockStyle.Fill;
            btnGhiNhanKetQua.Font = new Font("Segoe UI", 8F);
            btnGhiNhanKetQua.Location = new Point(20, 456);
            btnGhiNhanKetQua.Margin = new Padding(10, 10, 10, 0);
            btnGhiNhanKetQua.Name = "btnGhiNhanKetQua";
            btnGhiNhanKetQua.Size = new Size(154, 41);
            btnGhiNhanKetQua.TabIndex = 11;
            btnGhiNhanKetQua.Text = "Ghi nhận";
            btnGhiNhanKetQua.UseVisualStyleBackColor = true;
            btnGhiNhanKetQua.Click += btnGhiNhanKetQua_Click;
            // 
            // GUI_GhiNhanKetQua
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tlpFrame);
            Name = "GUI_GhiNhanKetQua";
            Text = "GUI_GhiNhanKetQua";
            Load += GUI_GhiNhanKetQua_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpFrame;
        private Button btnThemBanThang;
        private Button btnThoat;
        private Label lblTiSo;
        private Label lblTranDau;
        private Panel pDanhSachBanThang;
        private Button btnGhiNhanKetQua;
        private TextBox txtTenSan;
        private TextBox txtTiSo;
        private TextBox txtNgayGio;
        private Label lblNgayGio;
        private Label lblTenSan;
        private ComboBox cbTranDau;
    }
}