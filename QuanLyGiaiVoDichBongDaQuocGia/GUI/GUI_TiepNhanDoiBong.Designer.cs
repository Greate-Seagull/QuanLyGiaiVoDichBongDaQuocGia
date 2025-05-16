namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_TiepNhanDoiBong
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
            btnThemCauThu = new Button();
            lblMaDoiBong = new Label();
            lblTenSanNha = new Label();
            lblTenDoiBong = new Label();
            txtMaDoiBong = new TextBox();
            txtTenDoiBong = new TextBox();
            txtTenSanNha = new TextBox();
            btnTiepNhanDoiBong = new Button();
            btnThoat = new Button();
            dgDanhSachCauThu = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tlpFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDanhSachCauThu).BeginInit();
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
            tlpFrame.Controls.Add(btnThemCauThu, 1, 3);
            tlpFrame.Controls.Add(lblMaDoiBong, 0, 0);
            tlpFrame.Controls.Add(lblTenSanNha, 2, 0);
            tlpFrame.Controls.Add(lblTenDoiBong, 1, 0);
            tlpFrame.Controls.Add(txtMaDoiBong, 0, 1);
            tlpFrame.Controls.Add(txtTenDoiBong, 1, 1);
            tlpFrame.Controls.Add(txtTenSanNha, 2, 1);
            tlpFrame.Controls.Add(btnTiepNhanDoiBong, 0, 3);
            tlpFrame.Controls.Add(btnThoat, 8, 3);
            tlpFrame.Controls.Add(dgDanhSachCauThu, 0, 2);
            tlpFrame.Dock = DockStyle.Fill;
            tlpFrame.Location = new Point(0, 0);
            tlpFrame.Margin = new Padding(0);
            tlpFrame.Name = "tlpFrame";
            tlpFrame.Padding = new Padding(10);
            tlpFrame.RowCount = 3;
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.Size = new Size(1418, 507);
            tlpFrame.TabIndex = 3;
            // 
            // btnThemCauThu
            // 
            btnThemCauThu.Dock = DockStyle.Bottom;
            btnThemCauThu.Font = new Font("Segoe UI", 8F);
            btnThemCauThu.Location = new Point(194, 456);
            btnThemCauThu.Margin = new Padding(10, 10, 10, 0);
            btnThemCauThu.Name = "btnThemCauThu";
            btnThemCauThu.Size = new Size(154, 41);
            btnThemCauThu.TabIndex = 8;
            btnThemCauThu.Text = "Thêm cầu thủ";
            btnThemCauThu.UseVisualStyleBackColor = true;
            btnThemCauThu.Click += btnThemCauThu_Click;
            // 
            // lblMaDoiBong
            // 
            lblMaDoiBong.AutoSize = true;
            lblMaDoiBong.Dock = DockStyle.Fill;
            lblMaDoiBong.Location = new Point(20, 20);
            lblMaDoiBong.Margin = new Padding(10);
            lblMaDoiBong.Name = "lblMaDoiBong";
            lblMaDoiBong.Size = new Size(154, 28);
            lblMaDoiBong.TabIndex = 0;
            lblMaDoiBong.Text = "Mã đội bóng";
            lblMaDoiBong.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSanNha
            // 
            lblTenSanNha.AutoSize = true;
            tlpFrame.SetColumnSpan(lblTenSanNha, 2);
            lblTenSanNha.Dock = DockStyle.Fill;
            lblTenSanNha.Location = new Point(542, 20);
            lblTenSanNha.Margin = new Padding(10);
            lblTenSanNha.Name = "lblTenSanNha";
            lblTenSanNha.Size = new Size(328, 28);
            lblTenSanNha.TabIndex = 1;
            lblTenSanNha.Text = "Tên sân nhà";
            lblTenSanNha.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenDoiBong
            // 
            lblTenDoiBong.AutoSize = true;
            tlpFrame.SetColumnSpan(lblTenDoiBong, 2);
            lblTenDoiBong.Dock = DockStyle.Fill;
            lblTenDoiBong.Location = new Point(194, 20);
            lblTenDoiBong.Margin = new Padding(10);
            lblTenDoiBong.Name = "lblTenDoiBong";
            lblTenDoiBong.Size = new Size(328, 28);
            lblTenDoiBong.TabIndex = 2;
            lblTenDoiBong.Text = "Tên đội bóng";
            lblTenDoiBong.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaDoiBong
            // 
            txtMaDoiBong.BorderStyle = BorderStyle.FixedSingle;
            txtMaDoiBong.Dock = DockStyle.Fill;
            txtMaDoiBong.Location = new Point(20, 68);
            txtMaDoiBong.Margin = new Padding(10);
            txtMaDoiBong.Name = "txtMaDoiBong";
            txtMaDoiBong.ReadOnly = true;
            txtMaDoiBong.Size = new Size(154, 31);
            txtMaDoiBong.TabIndex = 3;
            // 
            // txtTenDoiBong
            // 
            txtTenDoiBong.BorderStyle = BorderStyle.FixedSingle;
            tlpFrame.SetColumnSpan(txtTenDoiBong, 2);
            txtTenDoiBong.Dock = DockStyle.Fill;
            txtTenDoiBong.Location = new Point(194, 68);
            txtTenDoiBong.Margin = new Padding(10);
            txtTenDoiBong.Name = "txtTenDoiBong";
            txtTenDoiBong.Size = new Size(328, 31);
            txtTenDoiBong.TabIndex = 4;
            // 
            // txtTenSanNha
            // 
            txtTenSanNha.BorderStyle = BorderStyle.FixedSingle;
            tlpFrame.SetColumnSpan(txtTenSanNha, 2);
            txtTenSanNha.Dock = DockStyle.Fill;
            txtTenSanNha.Location = new Point(542, 68);
            txtTenSanNha.Margin = new Padding(10);
            txtTenSanNha.Name = "txtTenSanNha";
            txtTenSanNha.Size = new Size(328, 31);
            txtTenSanNha.TabIndex = 5;
            // 
            // btnTiepNhanDoiBong
            // 
            btnTiepNhanDoiBong.Dock = DockStyle.Bottom;
            btnTiepNhanDoiBong.Font = new Font("Segoe UI", 8F);
            btnTiepNhanDoiBong.Location = new Point(20, 456);
            btnTiepNhanDoiBong.Margin = new Padding(10, 10, 10, 0);
            btnTiepNhanDoiBong.Name = "btnTiepNhanDoiBong";
            btnTiepNhanDoiBong.Size = new Size(154, 41);
            btnTiepNhanDoiBong.TabIndex = 6;
            btnTiepNhanDoiBong.Text = "Tiếp nhận đội bóng";
            btnTiepNhanDoiBong.UseVisualStyleBackColor = true;
            btnTiepNhanDoiBong.Click += btnTiepNhanDoiBong_Click;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Bottom;
            btnThoat.Font = new Font("Segoe UI", 8F);
            btnThoat.Location = new Point(1238, 456);
            btnThoat.Margin = new Padding(10, 10, 10, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 41);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgDanhSachCauThu
            // 
            dgDanhSachCauThu.AccessibleName = "Table";
            dgDanhSachCauThu.AllowDeleting = true;
            dgDanhSachCauThu.AutoGenerateColumns = false;
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
            dgDanhSachCauThu.Columns.Add(gridTextColumn1);
            dgDanhSachCauThu.Columns.Add(gridTextColumn2);
            dgDanhSachCauThu.Columns.Add(gridComboBoxColumn1);
            dgDanhSachCauThu.Columns.Add(gridDateTimeColumn1);
            dgDanhSachCauThu.Columns.Add(gridTextColumn3);
            tlpFrame.SetColumnSpan(dgDanhSachCauThu, 8);
            dgDanhSachCauThu.Dock = DockStyle.Fill;
            dgDanhSachCauThu.EditMode = Syncfusion.WinForms.DataGrid.Enums.EditMode.SingleClick;
            dgDanhSachCauThu.Location = new Point(20, 116);
            dgDanhSachCauThu.Margin = new Padding(10);
            dgDanhSachCauThu.Name = "dgDanhSachCauThu";
            dgDanhSachCauThu.PreviewRowHeight = 42;
            dgDanhSachCauThu.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
            dgDanhSachCauThu.ShowSortNumbers = true;
            dgDanhSachCauThu.Size = new Size(1378, 320);
            dgDanhSachCauThu.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgDanhSachCauThu.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgDanhSachCauThu.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgDanhSachCauThu.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgDanhSachCauThu.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgDanhSachCauThu.TabIndex = 9;
            dgDanhSachCauThu.Text = "sfDataGrid1";
            dgDanhSachCauThu.RecordDeleting += dgDanhSachCauThu_RecordDeleting;
            dgDanhSachCauThu.RecordDeleted += dgDanhSachCauThu_RecordDeleted;
            // 
            // GUI_TiepNhanDoiBong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tlpFrame);
            Name = "GUI_TiepNhanDoiBong";
            Text = "Tiếp nhận hồ sơ đội bóng";
            Load += GUI_TiepNhanDoiBong_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgDanhSachCauThu).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tlpFrame;
        private Button btnThemCauThu;
        private Label lblMaDoiBong;
        private Label lblTenSanNha;
        private Label lblTenDoiBong;
        private TextBox txtMaDoiBong;
        private TextBox txtTenDoiBong;
        private TextBox txtTenSanNha;
        private Button btnTiepNhanDoiBong;
        private Button btnThoat;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgDanhSachCauThu;
    }
}