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
            tlpFrame = new TableLayoutPanel();
            gcDanhSachTranDau = new DevExpress.XtraGrid.GridControl();
            gvcDanhSachTranDau = new DevExpress.XtraGrid.Views.Grid.GridView();
            gccMaTranDau = new DevExpress.XtraGrid.Columns.GridColumn();
            gccMaDoi1 = new DevExpress.XtraGrid.Columns.GridColumn();
            glkMaDoi1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gccMaDoi2 = new DevExpress.XtraGrid.Columns.GridColumn();
            glkMaDoi2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gccNgayGio = new DevExpress.XtraGrid.Columns.GridColumn();
            dtpNgayGio = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            gccTenSan = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)gcDanhSachTranDau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachTranDau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)glkMaDoi1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)glkMaDoi2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgayGio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgayGio.CalendarTimeProperties).BeginInit();
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
            tlpFrame.Controls.Add(gcDanhSachTranDau, 0, 2);
            tlpFrame.Controls.Add(txtNgayKetThuc, 3, 1);
            tlpFrame.Controls.Add(txtNgayBatDau, 2, 1);
            tlpFrame.Controls.Add(lblNgayKetThuc, 3, 0);
            tlpFrame.Controls.Add(lblNgayBatDau, 2, 0);
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
            // gcDanhSachTranDau
            // 
            tlpFrame.SetColumnSpan(gcDanhSachTranDau, 8);
            gcDanhSachTranDau.Dock = DockStyle.Fill;
            gcDanhSachTranDau.Location = new Point(20, 116);
            gcDanhSachTranDau.MainView = gvcDanhSachTranDau;
            gcDanhSachTranDau.Margin = new Padding(10);
            gcDanhSachTranDau.Name = "gcDanhSachTranDau";
            gcDanhSachTranDau.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { dtpNgayGio, glkMaDoi1, glkMaDoi2 });
            gcDanhSachTranDau.Size = new Size(1378, 320);
            gcDanhSachTranDau.TabIndex = 19;
            gcDanhSachTranDau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvcDanhSachTranDau });
            gcDanhSachTranDau.KeyDown += gcDanhSachTranDau_KeyDown;
            // 
            // gvcDanhSachTranDau
            // 
            gvcDanhSachTranDau.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gvcDanhSachTranDau.Appearance.HeaderPanel.Options.UseFont = true;
            gvcDanhSachTranDau.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvcDanhSachTranDau.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvcDanhSachTranDau.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvcDanhSachTranDau.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gccMaTranDau, gccMaDoi1, gccMaDoi2, gccNgayGio, gccTenSan });
            gvcDanhSachTranDau.GridControl = gcDanhSachTranDau;
            gvcDanhSachTranDau.Name = "gvcDanhSachTranDau";
            gvcDanhSachTranDau.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gvcDanhSachTranDau.OptionsNavigation.AutoFocusNewRow = true;
            gvcDanhSachTranDau.OptionsNavigation.EnterMoveNextColumn = true;
            gvcDanhSachTranDau.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvcDanhSachTranDau.OptionsSelection.MultiSelect = true;
            gvcDanhSachTranDau.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gvcDanhSachTranDau.OptionsView.ShowAutoFilterRow = true;
            gvcDanhSachTranDau.OptionsView.ShowViewCaption = true;
            gvcDanhSachTranDau.ViewCaption = "Danh sách trận đấu";
            gvcDanhSachTranDau.CustomDrawRowIndicator += gvcDanhSachTranDau_CustomDrawRowIndicator;
            gvcDanhSachTranDau.ShownEditor += gvcDanhSachTranDau_ShownEditor;
            gvcDanhSachTranDau.CellValueChanged += gvcDanhSachTranDau_CellValueChanged;
            gvcDanhSachTranDau.RowDeleted += gvcDanhSachTranDau_RowDeleted;
            gvcDanhSachTranDau.CustomUnboundColumnData += gvcDanhSachTranDau_CustomUnboundColumnData;
            // 
            // gccMaTranDau
            // 
            gccMaTranDau.Caption = "Mã cầu thủ";
            gccMaTranDau.FieldName = "MaTranDau";
            gccMaTranDau.MinWidth = 30;
            gccMaTranDau.Name = "gccMaTranDau";
            gccMaTranDau.OptionsColumn.ReadOnly = true;
            gccMaTranDau.Visible = true;
            gccMaTranDau.VisibleIndex = 0;
            gccMaTranDau.Width = 112;
            // 
            // gccMaDoi1
            // 
            gccMaDoi1.Caption = "Tên đội 1";
            gccMaDoi1.ColumnEdit = glkMaDoi1;
            gccMaDoi1.FieldName = "MaDoi1";
            gccMaDoi1.MinWidth = 30;
            gccMaDoi1.Name = "gccMaDoi1";
            gccMaDoi1.Visible = true;
            gccMaDoi1.VisibleIndex = 1;
            gccMaDoi1.Width = 112;
            // 
            // glkMaDoi1
            // 
            glkMaDoi1.AutoHeight = false;
            glkMaDoi1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            glkMaDoi1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDoiBong", "Đội chủ nhà"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSanNha", "Sân nhà") });
            glkMaDoi1.DisplayMember = "TenDoiBong";
            glkMaDoi1.Name = "glkMaDoi1";
            glkMaDoi1.NullText = "Chọn đội bóng";
            glkMaDoi1.ValueMember = "MaDoiBong";
            glkMaDoi1.EditValueChanged += glkMaDoi1_EditValueChanged;
            // 
            // gccMaDoi2
            // 
            gccMaDoi2.Caption = "Tên đội 2";
            gccMaDoi2.ColumnEdit = glkMaDoi2;
            gccMaDoi2.FieldName = "MaDoi2";
            gccMaDoi2.MinWidth = 30;
            gccMaDoi2.Name = "gccMaDoi2";
            gccMaDoi2.Visible = true;
            gccMaDoi2.VisibleIndex = 2;
            gccMaDoi2.Width = 112;
            // 
            // glkMaDoi2
            // 
            glkMaDoi2.AutoHeight = false;
            glkMaDoi2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            glkMaDoi2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDoiBong", "Đội khách") });
            glkMaDoi2.DisplayMember = "TenDoiBong";
            glkMaDoi2.Name = "glkMaDoi2";
            glkMaDoi2.NullText = "Chọn đội bóng";
            glkMaDoi2.ValueMember = "MaDoiBong";
            // 
            // gccNgayGio
            // 
            gccNgayGio.Caption = "Ngày giờ";
            gccNgayGio.ColumnEdit = dtpNgayGio;
            gccNgayGio.FieldName = "NgayGio";
            gccNgayGio.MinWidth = 30;
            gccNgayGio.Name = "gccNgayGio";
            gccNgayGio.Visible = true;
            gccNgayGio.VisibleIndex = 3;
            gccNgayGio.Width = 112;
            // 
            // dtpNgayGio
            // 
            dtpNgayGio.AutoHeight = false;
            dtpNgayGio.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpNgayGio.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpNgayGio.MaskSettings.Set("mask", "g");
            dtpNgayGio.Name = "dtpNgayGio";
            dtpNgayGio.UseMaskAsDisplayFormat = true;
            // 
            // gccTenSan
            // 
            gccTenSan.Caption = "Tên sân";
            gccTenSan.FieldName = "TenSanNha";
            gccTenSan.MinWidth = 30;
            gccTenSan.Name = "gccTenSan";
            gccTenSan.OptionsColumn.ReadOnly = true;
            gccTenSan.UnboundDataType = typeof(string);
            gccTenSan.Visible = true;
            gccTenSan.VisibleIndex = 4;
            gccTenSan.Width = 112;
            // 
            // txtNgayKetThuc
            // 
            txtNgayKetThuc.BorderStyle = BorderStyle.FixedSingle;
            txtNgayKetThuc.Dock = DockStyle.Fill;
            txtNgayKetThuc.Location = new Point(542, 68);
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
            txtNgayBatDau.Location = new Point(368, 68);
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
            lblNgayKetThuc.Location = new Point(542, 20);
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
            lblNgayBatDau.Location = new Point(368, 20);
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
            lblVongThiDau.Dock = DockStyle.Fill;
            lblVongThiDau.Location = new Point(194, 20);
            lblVongThiDau.Margin = new Padding(10);
            lblVongThiDau.Name = "lblVongThiDau";
            lblVongThiDau.Size = new Size(154, 28);
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
            txtMaVongDau.Size = new Size(154, 31);
            txtMaVongDau.TabIndex = 4;
            txtMaVongDau.TextChanged += txtMaVongDau_TextChanged;
            // 
            // txtVongThiDau
            // 
            txtVongThiDau.BorderStyle = BorderStyle.FixedSingle;
            txtVongThiDau.Dock = DockStyle.Fill;
            txtVongThiDau.Location = new Point(194, 68);
            txtVongThiDau.Margin = new Padding(10);
            txtVongThiDau.Name = "txtVongThiDau";
            txtVongThiDau.ReadOnly = true;
            txtVongThiDau.Size = new Size(154, 31);
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
            ((System.ComponentModel.ISupportInitialize)gcDanhSachTranDau).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachTranDau).EndInit();
            ((System.ComponentModel.ISupportInitialize)glkMaDoi1).EndInit();
            ((System.ComponentModel.ISupportInitialize)glkMaDoi2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgayGio.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgayGio).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcDanhSachTranDau;
        private DevExpress.XtraGrid.Views.Grid.GridView gvcDanhSachTranDau;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaTranDau;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaDoi1;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaDoi2;
        private DevExpress.XtraGrid.Columns.GridColumn gccNgayGio;
        private DevExpress.XtraGrid.Columns.GridColumn gccTenSan;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtpNgayGio;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit glkMaDoi1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit glkMaDoi2;
    }
}