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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridComboBoxColumn gridComboBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridComboBoxColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            tlpFrame = new TableLayoutPanel();
            dgDanhSachTranDau = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            txtNgayKetThuc = new TextBox();
            txtNgayBatDau = new TextBox();
            lblNgayKetThuc = new Label();
            lblNgayBatDau = new Label();
            btnThemTranDau = new Button();
            btnThoat = new Button();
            lblVongThiDau = new Label();
            lblMaVongDau = new Label();
            txtMaVongDau = new TextBox();
            txtVongThiDau = new TextBox();
            btnLapLichThiDau = new Button();
            tlpFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDanhSachTranDau).BeginInit();
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
            tlpFrame.Controls.Add(dgDanhSachTranDau, 0, 2);
            tlpFrame.Controls.Add(txtNgayKetThuc, 4, 1);
            tlpFrame.Controls.Add(txtNgayBatDau, 3, 1);
            tlpFrame.Controls.Add(lblNgayKetThuc, 4, 0);
            tlpFrame.Controls.Add(lblNgayBatDau, 3, 0);
            tlpFrame.Controls.Add(btnThemTranDau, 1, 3);
            tlpFrame.Controls.Add(btnThoat, 7, 3);
            tlpFrame.Controls.Add(lblVongThiDau, 1, 0);
            tlpFrame.Controls.Add(lblMaVongDau, 0, 0);
            tlpFrame.Controls.Add(txtMaVongDau, 0, 1);
            tlpFrame.Controls.Add(txtVongThiDau, 1, 1);
            tlpFrame.Controls.Add(btnLapLichThiDau, 0, 3);
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
            tlpFrame.TabIndex = 0;
            // 
            // dgDanhSachTranDau
            // 
            dgDanhSachTranDau.AccessibleName = "Table";
            dgDanhSachTranDau.AllowDeleting = true;
            dgDanhSachTranDau.AutoGenerateColumns = false;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowResizing = true;
            gridTextColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.HeaderText = "Mã cầu thủ";
            gridTextColumn1.MappingName = "MaCauThu";
            gridTextColumn2.AllowResizing = true;
            gridTextColumn2.HeaderText = "Họ tên";
            gridTextColumn2.MappingName = "TenCauThu";
            gridTextColumn2.Width = 275D;
            gridComboBoxColumn1.AllowBlankFilters = false;
            gridComboBoxColumn1.AllowResizing = true;
            gridComboBoxColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridComboBoxColumn1.DisplayMember = "TenLoaiCauThu";
            gridComboBoxColumn1.HeaderText = "Loại cầu thủ";
            gridComboBoxColumn1.MappingName = "MaLoaiCauThu";
            gridComboBoxColumn1.ValidationMode = Syncfusion.WinForms.DataGrid.Enums.GridValidationMode.InView;
            gridComboBoxColumn1.ValueMember = "MaLoaiCauThu";
            gridDateTimeColumn1.AllowResizing = true;
            gridDateTimeColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridDateTimeColumn1.Format = "dd/MM/yyyy";
            gridDateTimeColumn1.HeaderText = "Ngày sinh";
            gridDateTimeColumn1.MappingName = "NgaySinh";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridTextColumn3.AllowResizing = true;
            gridTextColumn3.HeaderText = "Ghi chú";
            gridTextColumn3.MappingName = "GhiChu";
            gridTextColumn3.Width = 689D;
            dgDanhSachTranDau.Columns.Add(gridTextColumn1);
            dgDanhSachTranDau.Columns.Add(gridTextColumn2);
            dgDanhSachTranDau.Columns.Add(gridComboBoxColumn1);
            dgDanhSachTranDau.Columns.Add(gridDateTimeColumn1);
            dgDanhSachTranDau.Columns.Add(gridTextColumn3);
            tlpFrame.SetColumnSpan(dgDanhSachTranDau, 8);
            dgDanhSachTranDau.Dock = DockStyle.Fill;
            dgDanhSachTranDau.EditMode = Syncfusion.WinForms.DataGrid.Enums.EditMode.SingleClick;
            dgDanhSachTranDau.Location = new Point(20, 116);
            dgDanhSachTranDau.Margin = new Padding(10);
            dgDanhSachTranDau.Name = "dgDanhSachTranDau";
            dgDanhSachTranDau.PreviewRowHeight = 42;
            dgDanhSachTranDau.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
            dgDanhSachTranDau.ShowSortNumbers = true;
            dgDanhSachTranDau.Size = new Size(1378, 320);
            dgDanhSachTranDau.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgDanhSachTranDau.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgDanhSachTranDau.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgDanhSachTranDau.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgDanhSachTranDau.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgDanhSachTranDau.TabIndex = 19;
            dgDanhSachTranDau.Text = "sfDataGrid1";
            // 
            // txtNgayKetThuc
            // 
            txtNgayKetThuc.BorderStyle = BorderStyle.FixedSingle;
            txtNgayKetThuc.Dock = DockStyle.Fill;
            txtNgayKetThuc.Location = new Point(716, 68);
            txtNgayKetThuc.Margin = new Padding(10);
            txtNgayKetThuc.Name = "txtNgayKetThuc";
            txtNgayKetThuc.ReadOnly = true;
            txtNgayKetThuc.Size = new Size(154, 31);
            txtNgayKetThuc.TabIndex = 18;
            // 
            // txtNgayBatDau
            // 
            txtNgayBatDau.BorderStyle = BorderStyle.FixedSingle;
            txtNgayBatDau.Dock = DockStyle.Fill;
            txtNgayBatDau.Location = new Point(542, 68);
            txtNgayBatDau.Margin = new Padding(10);
            txtNgayBatDau.Name = "txtNgayBatDau";
            txtNgayBatDau.ReadOnly = true;
            txtNgayBatDau.Size = new Size(154, 31);
            txtNgayBatDau.TabIndex = 17;
            // 
            // lblNgayKetThuc
            // 
            lblNgayKetThuc.AutoSize = true;
            lblNgayKetThuc.Dock = DockStyle.Fill;
            lblNgayKetThuc.Location = new Point(716, 20);
            lblNgayKetThuc.Margin = new Padding(10);
            lblNgayKetThuc.Name = "lblNgayKetThuc";
            lblNgayKetThuc.Size = new Size(154, 28);
            lblNgayKetThuc.TabIndex = 16;
            lblNgayKetThuc.Text = "Ngày kết thúc";
            lblNgayKetThuc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNgayBatDau
            // 
            lblNgayBatDau.AutoSize = true;
            lblNgayBatDau.Dock = DockStyle.Fill;
            lblNgayBatDau.Location = new Point(542, 20);
            lblNgayBatDau.Margin = new Padding(10);
            lblNgayBatDau.Name = "lblNgayBatDau";
            lblNgayBatDau.Size = new Size(154, 28);
            lblNgayBatDau.TabIndex = 15;
            lblNgayBatDau.Text = "Ngày bắt đầu";
            lblNgayBatDau.TextAlign = ContentAlignment.MiddleLeft;
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
            tlpFrame.SetColumnSpan(lblVongThiDau, 2);
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
            tlpFrame.SetColumnSpan(txtVongThiDau, 2);
            txtVongThiDau.Dock = DockStyle.Fill;
            txtVongThiDau.Location = new Point(194, 68);
            txtVongThiDau.Margin = new Padding(10);
            txtVongThiDau.Name = "txtVongThiDau";
            txtVongThiDau.Size = new Size(328, 31);
            txtVongThiDau.TabIndex = 5;
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
            Controls.Add(tlpFrame);
            Name = "GUI_LapLichThiDau";
            Text = "Lập lịch thi đấu";
            Load += GUI_LapLichThiDau_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgDanhSachTranDau).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpFrame;
        private Label lblMaVongDau;
        private TextBox txtMaVongDau;
        private TextBox txtVongThiDau;
        private Button btnLapLichThiDau;
        private Label lblVongThiDau;
        private Button btnThoat;
        private Button btnThemTranDau;
        private TextBox txtNgayKetThuc;
        private TextBox txtNgayBatDau;
        private Label lblNgayKetThuc;
        private Label lblNgayBatDau;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgDanhSachTranDau;
    }
}