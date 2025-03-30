namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_LapLichThiDau
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnThemTranDau = new Button();
            btnThoat = new Button();
            lblVongThiDau = new Label();
            lblMaVongDau = new Label();
            txtMaVongDau = new TextBox();
            txtVongThiDau = new TextBox();
            pDanhSachTranDau = new Panel();
            btnLapLichThiDau = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(btnThemTranDau, 1, 3);
            tableLayoutPanel1.Controls.Add(btnThoat, 7, 3);
            tableLayoutPanel1.Controls.Add(lblVongThiDau, 1, 0);
            tableLayoutPanel1.Controls.Add(lblMaVongDau, 0, 0);
            tableLayoutPanel1.Controls.Add(txtMaVongDau, 0, 1);
            tableLayoutPanel1.Controls.Add(txtVongThiDau, 1, 1);
            tableLayoutPanel1.Controls.Add(pDanhSachTranDau, 0, 2);
            tableLayoutPanel1.Controls.Add(btnLapLichThiDau, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(1418, 507);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnThemTranDau
            // 
            btnThemTranDau.Dock = DockStyle.Fill;
            btnThemTranDau.Font = new Font("Segoe UI", 8F);
            btnThemTranDau.Location = new Point(194, 456);
            btnThemTranDau.Margin = new Padding(10, 10, 10, 0);
            btnThemTranDau.Name = "btnThemTranDau";
            btnThemTranDau.Size = new Size(154, 41);
            btnThemTranDau.TabIndex = 14;
            btnThemTranDau.Text = "Thêm trận đấu";
            btnThemTranDau.UseVisualStyleBackColor = true;
            btnThemTranDau.Click += btnThemTranDau_Click;
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
            // lblVongThiDau
            // 
            lblVongThiDau.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblVongThiDau, 2);
            lblVongThiDau.Dock = DockStyle.Fill;
            lblVongThiDau.Location = new Point(194, 20);
            lblVongThiDau.Margin = new Padding(10);
            lblVongThiDau.Name = "lblVongThiDau";
            lblVongThiDau.Size = new Size(328, 28);
            lblVongThiDau.TabIndex = 12;
            lblVongThiDau.Text = "Vòng thi đấu";
            lblVongThiDau.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaVongDau
            // 
            lblMaVongDau.AutoSize = true;
            lblMaVongDau.Dock = DockStyle.Fill;
            lblMaVongDau.Location = new Point(20, 20);
            lblMaVongDau.Margin = new Padding(10);
            lblMaVongDau.Name = "lblMaVongDau";
            lblMaVongDau.Size = new Size(154, 28);
            lblMaVongDau.TabIndex = 1;
            lblMaVongDau.Text = "Mã vòng đấu";
            lblMaVongDau.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaVongDau
            // 
            txtMaVongDau.BorderStyle = BorderStyle.FixedSingle;
            txtMaVongDau.Dock = DockStyle.Fill;
            txtMaVongDau.Location = new Point(20, 68);
            txtMaVongDau.Margin = new Padding(10);
            txtMaVongDau.Name = "txtMaVongDau";
            txtMaVongDau.ReadOnly = true;
            txtMaVongDau.Size = new Size(154, 31);
            txtMaVongDau.TabIndex = 4;
            // 
            // txtVongThiDau
            // 
            txtVongThiDau.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(txtVongThiDau, 2);
            txtVongThiDau.Dock = DockStyle.Fill;
            txtVongThiDau.Location = new Point(194, 68);
            txtVongThiDau.Margin = new Padding(10);
            txtVongThiDau.Name = "txtVongThiDau";
            txtVongThiDau.Size = new Size(328, 31);
            txtVongThiDau.TabIndex = 5;
            // 
            // pDanhSachTranDau
            // 
            pDanhSachTranDau.AutoScroll = true;
            pDanhSachTranDau.BackColor = Color.White;
            pDanhSachTranDau.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(pDanhSachTranDau, 8);
            pDanhSachTranDau.Dock = DockStyle.Fill;
            pDanhSachTranDau.Location = new Point(20, 116);
            pDanhSachTranDau.Margin = new Padding(10);
            pDanhSachTranDau.Name = "pDanhSachTranDau";
            pDanhSachTranDau.Padding = new Padding(10);
            pDanhSachTranDau.Size = new Size(1378, 320);
            pDanhSachTranDau.TabIndex = 10;
            // 
            // btnLapLichThiDau
            // 
            btnLapLichThiDau.Dock = DockStyle.Fill;
            btnLapLichThiDau.Font = new Font("Segoe UI", 8F);
            btnLapLichThiDau.Location = new Point(20, 456);
            btnLapLichThiDau.Margin = new Padding(10, 10, 10, 0);
            btnLapLichThiDau.Name = "btnLapLichThiDau";
            btnLapLichThiDau.Size = new Size(154, 41);
            btnLapLichThiDau.TabIndex = 11;
            btnLapLichThiDau.Text = "Lập lịch";
            btnLapLichThiDau.UseVisualStyleBackColor = true;
            btnLapLichThiDau.Click += btnLapLichThiDau_Click;
            // 
            // GUI_LapLichThiDau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tableLayoutPanel1);
            Name = "GUI_LapLichThiDau";
            Text = "Lập lịch thi đấu";
            Load += GUI_LapLichThiDau_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblMaVongDau;
        private TextBox txtMaVongDau;
        private TextBox txtVongThiDau;
        private Panel pDanhSachTranDau;
        private Button btnLapLichThiDau;
        private Label lblVongThiDau;
        private Button btnThoat;
        private Button btnThemTranDau;
    }
}